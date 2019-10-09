using System;
using System.ComponentModel.DataAnnotations;

namespace server.Services.SignalR
{
    [Serializable]
    public class SignalRClient
    {
        public SignalRClient(string clientName, string clientEmail, string connectionId)
        {
            ClientName = clientName;
            ClientEmail = clientEmail;
            ConnectionId = connectionId;
        }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string ClientEmail { get; set; }

        [Required]
        public string ConnectionId { get; set; }
    }
}