export default {
  GetMenuData: (vm, GroupId, User) => {
    let ctxMenuData = [
      {
        title: "View Profile",
        handler: () =>
          window.open(
            `/profile/${User.name || User.username || User.userName}`,
            "_blank"
          )
      },
      {
        type: "divider"
      },
      {
        title: "Leave Chat",
        handler: () => vm.LeaveGroupChat(GroupId)
      }
    ];

    return ctxMenuData;
  }
};
