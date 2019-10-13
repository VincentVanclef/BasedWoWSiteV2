using System;

namespace server.Model.Website
{
    public class UserInformationResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
