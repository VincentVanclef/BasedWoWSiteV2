using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace server.ApiExtensions
{
    public class RequestHandler
    {
        public static BadRequestObjectResult BadRequest(string message)
        {
            return new BadRequestObjectResult(new { message });
        }

        public static BadRequestObjectResult BadRequest(IEnumerable<IdentityError> errors)
        {
            var result = new StringBuilder();

            foreach (var error in errors)
            {
                result.AppendLine(error.Description);
            }

            return new BadRequestObjectResult(new { message = result.ToString() });
        }

        public static BadRequestObjectResult Unauthorized()
        {
            return new BadRequestObjectResult(new { message = "An error occured when validating your identity" });
        }

        public static BadRequestObjectResult UserNotFound()
        {
            return new BadRequestObjectResult(new { message = "User does not exists" });
        }

        public static BadRequestObjectResult WrongCredentials()
        {
            return new BadRequestObjectResult(new { message = "Username or password is incorrect" });
        }
    }
}
