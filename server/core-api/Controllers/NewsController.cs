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

        [HttpGet("GetAllNews")]
        public async Task<IActionResult> GetAllNews()
        {
            var result = await _websiteContext.News.OrderByDescending(o => o.Id).ToListAsync();

            foreach (var news in result)
            {
                var user = await _userManager.FindByIdAsync(news.Author.ToString());
                news.AuthorName = user == null ? "Unknown" : user.UserName;
            }

            return Ok(result);
        }

        [HttpGet("GetCommentsForNews/{id}")]
        public async Task<IActionResult> GetCommentsForNews(int id)
        {
            var result = await _websiteContext.NewsComments.Where(x => x.NewsId == id).OrderBy(o => o.Id).ToListAsync();

            foreach (var comment in result)
            {
                var user = await _userManager.FindByIdAsync(comment.UserId.ToString());
                comment.UserName = user == null ? "Unknown" : user.UserName;
            }

            return Ok(result);
        }

        [HttpGet("GetCommentsCountForNews/{id}")]
        public async Task<IActionResult> GetCommentsCountForNews(int id)
        {
            var result = await _websiteContext.NewsComments.CountAsync(x => x.NewsId == id);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("AddNewComment")]
        public async Task<IActionResult> AddNewComment([FromBody] NewCommentModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var newComment = new NewsComment
            {
                UserId  = user.Id,
                Comment = model.Comment,
                NewsId  = model.NewsId,
                Date    = DateTime.Now
            };

            await _websiteContext.NewsComments.AddAsync(newComment);
            await _websiteContext.SaveChangesAsync();

            // TODO: Only send the new comment back
            var newComments = await _websiteContext.NewsComments.Where(x => x.NewsId == model.NewsId).OrderBy(o => o.Id).ToListAsync();

            foreach (var comment in newComments)
            {
                var commentUser = await _userManager.FindByIdAsync(comment.UserId.ToString());
                comment.UserName = commentUser == null ? "Unknown" : commentUser.UserName;
            }

            return Ok(newComments);
        }

        [Authorize]
        [HttpPost("DeleteNewsComment")]
        public async Task<IActionResult> DeleteNewsComment([FromBody] DeleteCommentModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var comment = await _websiteContext.NewsComments.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (comment == null)
                return RequestHandler.BadRequest($"Comment with id {model.Id} does not exist");

            // Only validate admin permissions if the comment is not posted by the user trying to delete it
            if (comment.UserId != user.Id)
            {
                var rank = await _userPermissions.GetRankByAccountId(user.AccountId);
                if (rank < (int)UserRanks.GMRanks.Admin)
                    return RequestHandler.Unauthorized();
            }

            var newsId = comment.NewsId;

            _websiteContext.NewsComments.Remove(comment);
            await _websiteContext.SaveChangesAsync();

            // TODO: Only send the new comment back
            var newComments = await _websiteContext.NewsComments.Where(x => x.NewsId == newsId).OrderBy(o => o.Id).ToListAsync();

            foreach (var newComment in newComments)
            {
                var commentUser = await _userManager.FindByIdAsync(newComment.UserId.ToString());
                newComment.UserName = commentUser == null ? "Unknown" : commentUser.UserName;
            }

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

            var news = new News
            {
                Author = model.Author,
                Title = model.Title,
                Content = model.Content,
                Image = model.Image,
                Date = DateTime.Now
            };

            await _websiteContext.News.AddAsync(news);
            await _websiteContext.SaveChangesAsync();

            return Ok(new { newsId = news.Id });
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

            if (_userManager.FindByIdAsync(model.Author.ToString()) == null)
                return RequestHandler.BadRequest("That user does not exist");

            var news = await _websiteContext.News.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (news == null)
                return RequestHandler.BadRequest($"News with id {model.Id} does not exist");

            news.Author = model.Author;
            news.Title = model.Title;
            news.Content = model.Content;
            news.Image = model.Image;

            await _websiteContext.SaveChangesAsync();

            return Ok();
        }
    }
}