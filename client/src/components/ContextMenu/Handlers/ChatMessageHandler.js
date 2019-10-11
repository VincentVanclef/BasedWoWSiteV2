export default {
  GetMenuData: (vm, Message) => {
    if (
      !vm.IsMessageOwner(Message.senderId) &&
      !vm.IsUserAdmin &&
      !vm.IsUserModerator
    )
      return null;

    let ctxMenuData = [
      {
        title: "Edit Message",
        handler: function() {
          vm.EditMessage(Message.id);
        }
      },
      {
        title: "Delete Message",
        handler: function() {
          vm.DeleteMessage(Message.id);
        }
      }
    ];

    return ctxMenuData;
  }
};
