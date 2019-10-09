using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server.Services.SignalR
{
    [Serializable]
    public class WebsiteClient
    {
        public WebsiteClient()
        {
            
        }

        public WebsiteClient(string id, List<SignalRClient> clients)
        {
            Id = id;
            Clients = clients;
            Name = clients[0].ClientName;
            Email = clients[0].ClientEmail;
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public List<SignalRClient> Clients { get; set; }
    }
}