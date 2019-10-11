import Vue from "vue";
import axios from "axios";
import { CreateGUID } from "@/services/api/UUIDGenerator";

const API_URL = process.env.API.CHAT;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    GroupChats: new Map(),
    NewGroupChats: new Set()
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetGroupChats: state => {
      return state.GroupChats;
    },
    GetGroupById: (state, groupId) => {
      return state.GroupChats.get(groupId);
    },
    GetNewGroupChats: state => {
      return state.NewGroupChats;
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
      state.GroupChats.delete(groupId);
      Vue.set(state, "GroupChats", new Map(state.GroupChats));
    },
    AddGroups: (state, groupChats) => {
      for (const chat of groupChats) {
        state.GroupChats.set(chat.id, chat);
      }
    },
    ClearNewGroupChat: (state, groupChatId) => {
      state.NewGroupChats.delete(groupChatId);
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
      if (!found) return null;

      Vue.set(
        state,
        "GroupChats",
        new Map(state.GroupChats.set(Group.id, Group))
      );
    }
  },
  // ---------------------------------------------------------------------------------
  actions: {
    CreateGroupChat: async (context, data) => {
      const { Members } = data;
      try {
        await axios.post(`${API_URL}/CreateGroupChat`, { Members });
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
        const result = await axios.get(`${API_URL}/GetGroupChats`);
        context.commit("AddGroups", result.data);
      } catch (error) {
        return Promise.reject(error);
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
    LeaveGroup: async (context, GroupId) => {
      try {
        await Vue.prototype.$signalR.invoke("LeaveGroupChat", {
          GroupId
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
    }
  }
};
