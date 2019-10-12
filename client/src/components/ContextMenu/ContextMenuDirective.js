import CharacterMenuContext from "./Handlers/CharacterMenuHandler";
import ChatMessageHandler from "./Handlers/ChatMessageHandler";
import GroupChatHandler from "./Handlers/GroupChatHandler";
import MemberMenuHandler from "./Handlers/MemberMenuHandler";

export default {
  name: "ContextMenuDirective",
  install(Vue) {
    Vue.directive("contextmenu", {
      bind: function(el, binding, vnode) {
        const vm = vnode.context;
        const data = binding.value;
        const type = binding.modifiers;
        addEvents(vm, el, type, data);
      }
    });

    const addEvents = (vm, el, type, data) => {
      let registerEvent;

      if (type.player) {
        const { player, realm } = data;
        const ctxMenuData = CharacterMenuContext.GetMenuData(player, realm);
        if (!ctxMenuData) return;

        registerEvent = event => {
          vm.$root.$emit("contextmenu", { event, ctxMenuData });
        };
      } else if (type.chatmessage) {
        const { Message } = data;
        const ctxMenuData = ChatMessageHandler.GetMenuData(vm, Message);
        if (!ctxMenuData) return;

        registerEvent = event => {
          vm.$root.$emit("contextmenu", { event, ctxMenuData });
        };
      } else if (type.groupchat) {
        const { GroupId, User } = data;
        const ctxMenuData = GroupChatHandler.GetMenuData(vm, GroupId, User);
        if (!ctxMenuData) return;

        registerEvent = event => {
          vm.$root.$emit("contextmenu", { event, ctxMenuData });
        };
      } else if (type.member) {
        const { User } = data;
        const ctxMenuData = MemberMenuHandler.GetMenuData(vm, User);
        if (!ctxMenuData) return;

        registerEvent = event => {
          vm.$root.$emit("contextmenu", { event, ctxMenuData });
        };
      }

      if (!registerEvent) return;

      el.addEventListener("contextmenu", registerEvent, false);
    };
  }
};
