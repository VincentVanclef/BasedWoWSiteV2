class GroupChat {
  constructor(id, members) {
    this.GroupId = id;
    this.Members = this.InitializeMembers(members);
  }

  InitializeMembers(members) {
    const memberMap = new Map();
    for (const member of members) {
      memberMap.set(member.id, new GroupMember(member));
    }
    return memberMap;
  }

  AddMember(member) {
    this.Members.set(member.id, new GroupMember(member));
  }

  RemoveMember(id) {
    this.Members.delete(id);
  }
}

class GroupMember {
  constructor(member) {
    this.Identity = member;
    this.Messages = new Map();
    this.MessageIndex = 0;
  }

  AddMessage(message) {
    const id = this.MessageIndex++;
    this.Messages.set((id, new ChatMessage(id, senderId, receiverId, message)));
  }

  RemoveMessage(id) {
    this.Messages.delete(id);
  }

  EditMessage(id, message) {
    this.Messages.set(id, message);
  }
}

class ChatMessage {
  constructor(id, senderId, receiverId, message) {
    this.Id = id;
    this.SenderId = senderId;
    this.receiverId = receiverId;
    this.Message = message;
  }
}

class GroupChatMessage extends ChatMessage {
  constructor(groupId, senderId, receiverId, message) {
    super(senderId, receiverId, message);
    this.GroupId = groupId;
  }
}

export { GroupChat, GroupMember, ChatMessage, GroupChatMessage };
