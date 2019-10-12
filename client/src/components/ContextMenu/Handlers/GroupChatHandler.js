export default {
  GetMenuData: (vm, Group, User) => {
    console.log(Group);
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
          vm.LeaveGroupChat(Group);
        }
      }
    ];

    return ctxMenuData;
  }
};
