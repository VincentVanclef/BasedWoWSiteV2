import Vue from "vue";
import EmojiPicker from "./EmojiPicker.vue";

const EmojiMap = {
  "<3": "\u2764\uFE0F",
  "</3": "\uD83D\uDC94",
  ":D": "\uD83D\uDE00",
  ":)": "\uD83D\uDE03",
  ";)": "\uD83D\uDE09",
  ":(": "\uD83D\uDE12",
  ":p": "\uD83D\uDE1B",
  ";p": "\uD83D\uDE1C",
  ":'(": "\uD83D\uDE22",
  xD: "\uD83D\uDE06"
};

function escapeSpecialChars(regex) {
  return regex.replace(/([()[{*+.$^\\|?])/g, "\\$1");
}

const MyEmojiPicker = Vue.extend(EmojiPicker);

export default {
  name: "EmojiDirective",
  install(Vue) {
    Vue.directive("emojis", {
      bind: function(el, binding, vnode) {
        const vm = vnode.context;

        const emojiPicker = new MyEmojiPicker({
          el: document.createElement("div"),
          data: {
            Vm: vm,
            Node: vnode
          }
        });

        Vue.nextTick(() => {
          vnode.elm.parentNode.insertBefore(
            emojiPicker.$el,
            vnode.elm.nextElementSibling
          );
        });

        addEvents(el);
      }
    });
    const addEvents = el => {
      const registerEvent = event => {
        for (var i in EmojiMap) {
          var regex = new RegExp(escapeSpecialChars(i), "gim");
          el.value = el.value = el.value.replace(regex, EmojiMap[i]);
        }
      };

      el.addEventListener("input", registerEvent, true);
    };
  }
};
