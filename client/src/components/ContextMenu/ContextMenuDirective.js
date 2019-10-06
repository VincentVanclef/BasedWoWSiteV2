import CharacterMenuContext from "./Handlers/CharacterMenuHandler";

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

        registerEvent = event => {
          const ctxMenuData = CharacterMenuContext.GetMenuData(player, realm);
          vm.$root.$emit("contextmenu", { event, ctxMenuData });
        };
      }

      if (!registerEvent) return;

      el.addEventListener("contextmenu", registerEvent, false);
    };
  }
};
