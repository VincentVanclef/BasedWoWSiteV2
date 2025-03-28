﻿using System;

namespace server.Model.DTO
{
    public class WebAccDTO
    {
        public Guid Id { get; set; }
        public int AccountId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int VP { get; set; }
        public int DP { get; set; }
        public DateTime JoinDate { get; set; }
        public string Location { get; set; }
        public string[] Roles { get; set; }
        public int TotalVotes { get; set; }
        public Data.Auth.Account Account { get; set; }
    }
}
