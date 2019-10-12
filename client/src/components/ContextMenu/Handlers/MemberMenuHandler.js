export default {
  GetMenuData: (vm, User) => {
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
        title: "Start Chat",
        handler: async () => {
          const group = vm.$store.getters["chat/GetGroupByUserId"](User.id);
          const me = vm.$store.getters["user/GetUser"];
          if (me.id == User.id) {
            vm.$root.ToastError("You can't start a chat with yourself", "Chat");
            return;
          }
          if (group) {
            vm.$root.ToastError(
              `You already have an active chat with ${User.name ||
                User.username ||
                User.userName}`,
              "Chat"
            );
            return;
          }

          await vm.$store.dispatch("chat/CreateGroupChat", {
            Id: User.id,
            Email: User.email,
            Name: User.name || User.username || User.userName
          });

          vm.$bvModal.hide("show-users-modal");
          vm.$root.ToastSuccess(
            `You have started a new chat with ${User.name ||
              User.username ||
              User.userName}`,
            "Chat"
          );

          vm.$root.$emit("GroupChatInviteSuccessful");
        }
      },
      {
        title: "Leave Chat",
        handler: async () => {
          const group = vm.$store.getters["chat/GetGroupByUserId"](User.id);
          if (!group) {
            vm.$root.ToastError(
              `You have no active chat with ${User.name ||
                User.username ||
                User.userName}`,
              "Chat"
            );
            return;
          }

          await vm.$store.dispatch("chat/LeaveGroup", {
            UserId: null,
            Group: group
          });

          vm.$bvModal.hide("show-users-modal");
          vm.$root.ToastSuccess("You have left the chat.");

          vm.$root.$emit("GroupChatLeaveSuccessful", group.id);
        }
      }
    ];

    return ctxMenuData;
  }
};
