﻿using System;
using System.ComponentModel.DataAnnotations;

namespace server.Services.SignalR.Chat
{
    [Serializable]
    public class GroupChatMember
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime LastAccessed { get; set; } = default(DateTime);
    }
}
