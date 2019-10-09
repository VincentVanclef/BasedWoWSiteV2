class GroupChat {
  constructor(id, members, date) {
    this.Id = id;
    this.Members = this.InitializeMembers(members);
    this.LastAccessed = date;
  }

  InitializeMembers(members) {
    const memberList = [];
    for (const member of members) {
      memberList.push(new GroupMember(member));
    }
    return memberList;
  }

  AddMember(member) {
    this.Members.push(new GroupMember(member));
  }

  RemoveMember(id) {
    this.Members = this.Members.filter(x => x.id !== id);
  }

  CreateMessage(senderId, receiverId, message) {
    return new GroupChatMessage(null, this.Id, senderId, receiverId, message);
  }

  AddMessage(message) {
    this.Messages.set((id, new ChatMessage(id, senderId, receiverId, message)));
  }

  RemoveMessage(id) {
    this.Messages.delete(id);
  }

  EditMessage(id, message) {
    this.Messages.set(id, message);
  }
}

class GroupMember {
  constructor(member) {
    this.Id = member.id;
    this.Name = member.name;
    this.Email = member.email;
    this.Clients = member.clients;
    this.ChatMessages = member.chatMessages;
    this.LastAccessed = member.lastAccessed;
  }

  CreateMessage(message) {
    const date = new Date().toLocaleString();
    const msg = new ChatMessage(null, this.Id, "", message, date);
    this.ChatMessages.unshift(msg);
  }
}

class ChatMessage {
  constructor(senderId, receiverId, message, dateTime = null) {
    this.SenderId = senderId;
    this.receiverId = receiverId;
    this.Message = message;
    this.DateTime = dateTime ? dateTime : new Date().toLocaleString();
  }
}

class GroupChatMessage extends ChatMessage {
  constructor(id, groupId, senderId, receiverId, message) {
    super(id, senderId, receiverId, message);
    this.GroupId = groupId;
  }
}

export { GroupChat, GroupMember, ChatMessage, GroupChatMessage };
