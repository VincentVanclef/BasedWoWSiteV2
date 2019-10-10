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
        handler: () => vm.EditMessage(Message)
      },
      {
        title: "Delete Message",
        handler: () => vm.DeleteMessage(Message.id)
      }
    ];

    return ctxMenuData;
  }
};
