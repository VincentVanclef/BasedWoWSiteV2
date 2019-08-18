using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.ApiExtensions;
using server.Context;
using server.Data.Website;
using server.Model.Website;
using server.Util;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly WebsiteContext _websiteContext;
        private readonly UserPermissions _userPermissions;

        public NewsController(UserManager<ApplicationUser> userManager, WebsiteContext websiteContext, UserPermissions userPermissions)
        {
            _websiteContext = websiteContext;
            _userManager = userManager;
            _userPermissions = userPermissions;
        }

        [HttpGet("GetNews")]
        public async Task<IActionResult> GetNews()
        {
            var result = await _websiteContext.News.OrderByDescending(o => o.Id).ToListAsync();

            await GetAuthorNames(result);

            foreach (var news in result)
            {
                await GetAuthorNames(news.Comments);
            }

            return Ok(result);
        }

        [HttpGet("GetCommentsForNews/{id}")]
        public async Task<IActionResult> GetCommentsForNews(int id)
        {
            var result = await _websiteContext.NewsComments.Where(x => x.NewsId == id).OrderBy(o => o.Id).ToListAsync();

            await GetAuthorNames(result);

            return Ok(result);
        }

        [HttpGet("GetCommentsCountForNews/{id}")]
        public async Task<IActionResult> GetCommentsCountForNews(int id)
        {
            var result = await _websiteContext.NewsComments.CountAsync(x => x.NewsId == id);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment([FromBody] NewCommentModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var newComment = new NewsComment
            {
                Author  = user.Id,
                Comment = model.Comment,
                NewsId  = model.NewsId,
                Date    = DateTime.Now
            };

            await _websiteContext.NewsComments.AddAsync(newComment);
            await _websiteContext.SaveChangesAsync();

            // TODO: Only send the new comment back
            var newComments = await _websiteContext.NewsComments.Where(x => x.NewsId == model.NewsId).OrderBy(o => o.Id).ToListAsync();

            await GetAuthorNames(newComments);

            return Ok(newComments);
        }

        [Authorize]
        [HttpPost("DeleteComment")]
        public async Task<IActionResult> DeleteComment([FromBody] DeleteCommentModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var comment = await _websiteContext.NewsComments.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (comment == null)
                return RequestHandler.BadRequest($"Comment with id {model.Id} does not exist");

            // Only validate admin permissions if the comment is not posted by the user trying to delete it
            if (comment.Author != user.Id)
            {
                var rank = await _userPermissions.GetRankByAccountId(user.AccountId);
                if (rank < (int)UserRanks.GMRanks.Admin)
                    return RequestHandler.Unauthorized();
            }

            _websiteContext.NewsComments.Remove(comment);
            await _websiteContext.SaveChangesAsync();

            // TODO: Only send the new comment back
            var newComments = await _websiteContext.NewsComments.Where(x => x.NewsId == comment.NewsId).OrderBy(o => o.Id).ToListAsync();

            await GetAuthorNames(newComments);

            return Ok(newComments);
        }

        [Authorize]
        [HttpPost("DeleteNews")]
        public async Task<IActionResult> DeleteNews([FromBody] DeleteNewsModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var rank = await _userPermissions.GetRankByAccountId(user.AccountId);
            if (rank < (int)UserRanks.GMRanks.Admin)
                return RequestHandler.Unauthorized();

            var news = await _websiteContext.News.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (news == null)
                return RequestHandler.BadRequest($"News with id {model.Id} does not exist");

            var comments = await _websiteContext.NewsComments.Where(x => x.NewsId == model.Id).ToListAsync();
            if (comments.Any())
            {
                // Remove comments first else news cant be removed
                _websiteContext.NewsComments.RemoveRange(comments);
                await _websiteContext.SaveChangesAsync();
            }

            _websiteContext.News.Remove(news);

            await _websiteContext.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpPost("CreateNews")]
        public async Task<IActionResult> CreateNews([FromBody] NewNewsModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var rank = await _userPermissions.GetRankByAccountId(user.AccountId);
            if (rank < (int)UserRanks.GMRanks.Admin)
                return RequestHandler.Unauthorized();

            var author = await _userManager.FindByIdAsync(model.Author.ToString());
            if (author == null)
                return RequestHandler.BadRequest("Author does not exist");

            var news = new News
            {
                Author = model.Author,
                AuthorName = author.UserName,
                Title = model.Title,
                Content = model.Content,
                Image = model.Image,
                Date = DateTime.Now,
                Comments = new List<NewsComment>()
            };

            await _websiteContext.News.AddAsync(news);
            await _websiteContext.SaveChangesAsync();

            return Ok(news);
        }

        [Authorize]
        [HttpPost("EditNews")]
        public async Task<IActionResult> EditNews([FromBody] News model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var rank = await _userPermissions.GetRankByAccountId(user.AccountId);
            if (rank < (int)UserRanks.GMRanks.Admin)
                return RequestHandler.Unauthorized();

            var newUser = await _userManager.FindByIdAsync(model.Author.ToString());
            if (newUser == null)
                return RequestHandler.BadRequest("Author does not exist");

            var news = await _websiteContext.News.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (news == null)
                return RequestHandler.BadRequest($"News with id {model.Id} does not exist");

            news.Author = model.Author;
            news.AuthorName = newUser.UserName;
            news.Title = model.Title;
            news.Content = model.Content;
            news.Image = model.Image;

            await _websiteContext.SaveChangesAsync();

            return Ok(news);
        }

        private async Task GetAuthorNames<T>(IEnumerable<T> authorList) where T : AuthorModel
        {
            var authorCache = new Dictionary<string, string>();

            foreach (var author in authorList)
            {
                var userId = author.Author.ToString();
                if (authorCache.ContainsKey(userId))
                {
                    author.AuthorName = authorCache[userId];
                    continue;
                }

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    continue;

                author.AuthorName = user.UserName;
                authorCache.Add(userId, user.UserName);
            }
        }
    }
}