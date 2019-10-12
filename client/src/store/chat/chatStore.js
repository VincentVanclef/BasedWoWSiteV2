import Vue from "vue";
import axios from "axios";

const API_URL = process.env.API.CHAT;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    GroupChats: new Map(),
    NewGroupChats: new Set(),
    Loaded: false,

    /* ChatBox Settings */
    ActiveChatId: null
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetGroupChats: state => {
      return state.GroupChats;
    },
    GetGroupById: state => groupId => {
      return state.GroupChats.get(groupId);
    },
    GetGroupByUserId: state => userId => {
      const groups = Array.from(state.GroupChats.values());
      const group = groups.find(x => x.members.some(x => x.id === userId));
      return group;
    },
    GetNewGroupChats: state => {
      return state.NewGroupChats;
    },
    GetLoadingStatus: state => state.Loaded,
    GetActiveChatId: state => state.ActiveChatId,
    GetActiveChat: state => {
      return state.ActiveChatId
        ? state.GroupChats.get(state.ActiveChatId)
        : null;
    }
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    GroupChatUpdated: (state, groupChat) => {
      Vue.set(
        state,
        "GroupChats",
        new Map(state.GroupChats.set(groupChat.id, groupChat))
      );
    },
    GroupChatCreated: (state, groupChat) => {
      Vue.set(
        state,
        "NewGroupChats",
        new Set(state.NewGroupChats.add(groupChat.id))
      );

      Vue.set(
        state,
        "GroupChats",
        new Map(state.GroupChats.set(groupChat.id, groupChat))
      );
    },
    GroupChatRemoved: (state, groupId) => {
      state.NewGroupChats.delete(groupId);
      Vue.set(state, "NewGroupChats", new Set(state.NewGroupChats));
      state.GroupChats.delete(groupId);
      Vue.set(state, "GroupChats", new Map(state.GroupChats));
    },
    AddGroups: (state, groupChats) => {
      for (const chat of groupChats) {
        state.GroupChats.set(chat.id, chat);
      }
    },
    ClearNewGroupChat: (state, groupId) => {
      state.NewGroupChats.delete(groupId);
      Vue.set(state, "NewGroupChats", new Set(state.NewGroupChats));
    },
    MarkAllMessagesAsRead: (state, data) => {
      const { UserId, Group } = data;

      let found = false;

      for (const message of Group.chatMessages) {
        if (message.senderId !== UserId) {
          message.read = true;
          found = true;
        }
      }

      if (!found) return;

      Vue.set(
        state,
        "GroupChats",
        new Map(state.GroupChats.set(Group.id, Group))
      );
    },
    SetLoadingStatus: (state, status) => {
      Vue.set(state, "Loaded", status);
    },
    SetActiveChat: (state, id) => {
      state.ActiveChatId = id;
    }
  },
  // ---------------------------------------------------------------------------------
  actions: {
    CreateGroupChat: async (context, data) => {
      const { Id, Name, Email } = data;
      try {
        const result = await axios.post(`${API_URL}/CreateGroupChat`, {
          Id,
          Name,
          Email
        });
        return Promise.resolve(result.data);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    SendGroupChatMessage: async (context, data) => {
      const { GroupId, Message } = data;
      try {
        await Vue.prototype.$signalR.invoke("SendGroupChatMessage", {
          GroupId,
          Message
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetGroupChats: async context => {
      try {
        context.commit("SetLoadingStatus", false);
        const result = await axios.get(`${API_URL}/GetGroupChats`);
        context.commit("AddGroups", result.data);
      } catch (error) {
        return Promise.reject(error);
      } finally {
        context.commit("SetLoadingStatus", true);
      }
    },
    DeleteMessage: async (context, data) => {
      const { GroupId, MessageId } = data;
      try {
        await Vue.prototype.$signalR.invoke("DeleteGroupChatMessage", {
          GroupId,
          MessageId
        });
      } catch (error) {
        return Promise.reject(error);
      }
    },
    EditMessage: async (context, data) => {
      const { GroupId, Message } = data;
      try {
        await Vue.prototype.$signalR.invoke("EditGroupChatMessage", {
          GroupId,
          Message
        });
      } catch (error) {
        return Promise.reject(error);
      }
    },
    LeaveGroup: async (context, data) => {
      const { UserId, Group } = data;

      try {
        context.commit("ClearNewGroupChat", Group.id);

        await Vue.prototype.$signalR.invoke("LeaveGroupChat", {
          GroupId: Group.id
        });
      } catch (error) {
        return Promise.reject(error);
      }
    },
    MarkAllMessagesAsRead: async (context, data) => {
      const { UserId, Group } = data;
      try {
        context.commit("MarkAllMessagesAsRead", {
          UserId,
          Group
        });

        await Vue.prototype.$signalR.invoke("MarkAllMessagesAsRead", Group);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    SearchUsers: async (context, query) => {
      try {
        const response = await axios.get(`${API_URL}/SearchUsers/${query}`);
        const { members, count } = response.data;
        return Promise.resolve({ members, count });
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
