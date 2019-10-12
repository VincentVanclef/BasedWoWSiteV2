using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Services.SignalR.Chat
{
    public interface IGroupChatService
    {
        Task<GroupChat> GetGroupChatByIdAsync(string id);
        Task<List<GroupChat>> GetGroupChatsByMemberIdAsync(string id);
        Task<GroupChat> GetExistingGroupChatAsync(string one, string two);
        Task<GroupChat> SaveGroupChatAsync(GroupChat groupChat, string id = null);
        void DeleteGroupChat(GroupChat groupChat);
        Task AddUserConnectionToGroupsAsync(string id, string connectionId);
    }
}
