export default {
  GetMenuData: (vm, User) => {
    const ctxMenuData = [
      {
        title: "View Profile",
        loginRequired: false,
        handler: () =>
          window.open(
            `/profile/${User.name || User.username || User.userName}`,
            "_blank"
          )
      },
      {
        type: "divider",
        loginRequired: true,
        targetId: User.id
      },
      {
        title: "Start Chat",
        loginRequired: true,
        targetId: User.id,
        handler: async () => {
          const group = vm.$store.getters["chat/GetGroupByUserId"](User.id);
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
        loginRequired: true,
        targetId: User.id,
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
