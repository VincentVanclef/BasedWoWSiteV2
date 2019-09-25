import Vue from "vue";
import Popper from "popper.js";
import Tooltip from "./ItemTooltipComponent.vue";

const MyTooltip = Vue.extend(Tooltip);

export default {
  name: "ItemTooltip",
  install(Vue) {
    Vue.directive("itemtooltip", {
      bind: function(el, binding, vnode) {
        const vm = vnode.context;

        const { item, realm } = binding.value;

        const tooltip = new MyTooltip({
          el: document.createElement("div"),
          data: {
            item,
            realm
          }
        });

        el.instance = tooltip;
        el.tooltip = tooltip.$el;
        addEvents(el);
      },

      unbind: function(el, binding) {
        if (el.domInserted) {
          if (el.tooltip && el.tooltip.parentNode) {
            el.tooltip.parentNode.removeChild(el.tooltip);
          }
        }
        el.instance && el.instance.$destroy();
      }
    });

    const addEvents = el => {
      const addTooltip = e => {
        document.body.appendChild(el.tooltip);
        Vue.nextTick(() => {
          new Popper(el, el.tooltip, {
            placement: "top",
            positionFixed: true
          });
        });
        el.instance.visible = true;
      };

      const hideTooltip = () => {
        el.instance.visible = false;
        removeTooltip();
      };

      const removeTooltip = e => {
        if (!el.instance.visible) {
          document.body.removeChild(el.tooltip);
        }
      };

      el.addEventListener("mouseover", addTooltip, false);
      el.addEventListener("mouseleave", hideTooltip, false);
      el.tooltip.addEventListener("transitionend", removeTooltip, false);
    };
  }
};
