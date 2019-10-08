import Vue from "vue";
import axios from "axios";
import { CreateGUID } from "@/services/api/UUIDGenerator";

import {
  GroupChat,
  GroupMember,
  ChatMessage,
  GroupChatMessage
} from "./chatModels";

const API_URL = process.env.API.CHAT;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    GroupChats: []
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetGroupChats: function(state) {
      return state.GroupChats;
    },
    GetGroupById: (state, groupId) => {
      return state.GroupChats.find(x => x.groupId === groupId);
    }
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    CreateGroup: (state, groupChat) => {
      const GroupId = groupChat.groupId;
      const Members = groupChat.members;
      state.GroupChats.unshift(new GroupChat(GroupId, Members));
    },
    DeleteGroup: (state, groupId) => {
      state.GroupChats.delete(groupId);
    },
    AddMessage: (state, data) => {
      const { GroupId, Message } = data;
      const GroupChat = getters.GetGroupById(GroupId);
      this.Messages.push(new ChatMessage());
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    CreateGroupChat: async (context, data) => {
      const { Owner, Members } = data;
      console.log(JSON.stringify(Members));
      const GroupId = CreateGUID();
      try {
        await Vue.prototype.$signalR.invoke("CreateGroupChat", {
          GroupId,
          Members
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    SendChatMessage: async (context, data) => {
      const { SenderId, ReceiverId, Message } = data;
      try {
        await Vue.prototype.$signalR.invoke(
          "SendMessage",
          new ChatMessage(SenderId, ReceiverId, Message)
        );
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    SendGroupChatMessage: async (context, data) => {
      const { GroupId, SenderId, ReceiverId, Message } = data;
      try {
        await Vue.prototype.$signalR.invoke(
          "SendGroupMessage",
          new GroupChatMessage(GroupId, SenderId, ReceiverId, Message)
        );
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
