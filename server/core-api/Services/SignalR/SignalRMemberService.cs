using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using server.Model.DTO;
using server.Util;
using Sparrow.Collections;

namespace server.Services.SignalR
{
    public static class SignalRMemberService 
    {
        private static ConcurrentDictionary<string, List<SignalRClient>> UserConnections { get; } = new ConcurrentDictionary<string, List<SignalRClient>>();
        private static ConcurrentSet<string> VisitorConnections { get; } = new ConcurrentSet<string>();

        public static void AddConnection(HubCallerContext context)
        {
            var connectionId = context.ConnectionId;
            var userIdentifier = context.UserIdentifier;

            if (userIdentifier != null)
            {
                var username = context.User.Identity.Name;
                var websiteClient = new SignalRClient(username, connectionId);

                if (UserConnections.TryGetValue(userIdentifier, out var connectionList))
                {
                    connectionList.Add(websiteClient);
                }
                else
                {
                    UserConnections.TryAdd(userIdentifier, new List<SignalRClient>() { websiteClient });
                }
            }
            else
            {
                VisitorConnections.Add(connectionId);
            }
        }

        public static void RemoveConnection(HubCallerContext context)
        {
            var connectionId = context.ConnectionId;
            var userIdentifier = context.UserIdentifier;

            if (userIdentifier != null)
            {
                if (UserConnections.TryGetValue(userIdentifier, out var connectionList))
                {
                    connectionList.RemoveAll(x => x.ConnectionId == connectionId);
                    if (!connectionList.Any())
                        UserConnections.TryRemove(userIdentifier, out _);
                }
            }
            else
            {
                VisitorConnections.TryRemove(connectionId);
            }
        }

        public static WebsiteClient[] GetOnlineUsers()
        {
            return UserConnections.Select(x => new WebsiteClient(x.Key, x.Value)).ToArray();
        }

        public static int GetVisitorCount()
        {
            return VisitorConnections.Count;
        }
    }

    public class WebsiteClient
    {
        public WebsiteClient(string id, IEnumerable<SignalRClient> clients)
        {
            Id = id;
            Clients = clients;
        }

        public string Id { get; }
        public IEnumerable<SignalRClient> Clients { get; }
    }

    public class SignalRClient
    {
        public SignalRClient(string clientName, string connectionId)
        {
            ClientName = clientName;
            ConnectionId = connectionId;
        }

        public string ClientName { get; set; }
        public string ConnectionId { get; set; }
    }
}
