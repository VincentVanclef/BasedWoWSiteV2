export default {
  GetMenuData: (vm, GroupId, User) => {
    const group = vm.$store.getters["chat/GetGroupById"](GroupId);

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
        handler: function() {
          vm.LeaveGroupChat(group);
        }
      }
    ];

    return ctxMenuData;
  }
};
