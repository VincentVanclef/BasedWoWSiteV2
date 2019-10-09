using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Raven.Client.Documents;
using server.Services.Ravendb;

namespace server.Services.SignalR.Chat
{
    public class GroupChatService : IGroupChatService
    {
        private readonly IDocumentStoreHolder _documentStore;
        private readonly IHubContext<SignalRHub, ISignalRHub> _signalRHub;

        public GroupChatService(IDocumentStoreHolder  documentStore, IHubContext<SignalRHub, ISignalRHub> signalRHub)
        {
            _documentStore = documentStore;
            _signalRHub = signalRHub;
        }

        public async Task<GroupChat> GetGroupChatByIdAsync(string id)
        {
            using (var session = _documentStore.Store.OpenAsyncSession())
            {
                return await session.LoadAsync<GroupChat>(id);
            }
        }

        public async Task<List<GroupChat>> GetGroupChatsByMemberIdAsync(string id)
        {
            List<GroupChat> groupChats;

            using (var session = _documentStore.Store.OpenAsyncSession())
            {
                groupChats = await session.Query<GroupChat>().Where(c => c.Members.Any(m => m.Id == id)).ToListAsync();
            }

            return groupChats;
        }

        public async Task<GroupChat> GetExistingGroupChatAsync(string one, string two)
        {
            using (var session = _documentStore.Store.OpenAsyncSession())
            {
                return await session.Query<GroupChat>()
                    .Where(c => c.Members.Any(m => m.Id == one) && c.Members.Any(m => m.Id == two))
                    .FirstOrDefaultAsync();
            }
        }

        public async Task<GroupChat> SaveGroupChatAsync(GroupChat groupChat)
        {
            using (var session = _documentStore.Store.OpenAsyncSession())
            {
                groupChat.LastModified = DateTime.Now;

                await session.StoreAsync(groupChat);
                await session.SaveChangesAsync();
            }

            return groupChat;
        }

        public async Task AddUserConnectionToGroupsAsync(string id, string connectionId)
        {
            var groupChats = await GetGroupChatsByMemberIdAsync(id);
            foreach (var chat in groupChats)
            {
                await _signalRHub.Groups.AddToGroupAsync(connectionId, chat.Id);
            }
        }
    }
}
