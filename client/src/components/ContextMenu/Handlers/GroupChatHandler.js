export default {
  GetMenuData: (vm, GroupId) => {
    let ctxMenuData = [
      {
        title: "Leave Chat",
        handler: () => vm.LeaveGroupChat(GroupId)
      }
    ];

    return ctxMenuData;
  }
};
