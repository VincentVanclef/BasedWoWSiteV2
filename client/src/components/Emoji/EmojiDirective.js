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
  ":-D": "\uD83D\uDE00",
  ":-)": "\uD83D\uDE03",
  ";-)": "\uD83D\uDE09",
  ":-(": "\uD83D\uDE12",
  ":-p": "\uD83D\uDE1B",
  ";-p": "\uD83D\uDE1C",
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
        const data = binding.value;

        const emojiPicker = new MyEmojiPicker({
          el: document.createElement("div"),
          data: {
            Vm: vm,
            Node: vnode,
            PosRight: data.PosRight
          }
        });

        el.instance = emojiPicker;
        el.emojiPicker = emojiPicker.$el;

        Vue.nextTick(() => {
          vnode.elm.parentNode.insertBefore(
            emojiPicker.$el,
            vnode.elm.nextElementSibling
          );
        });

        addEvents(el);
      },
      unbind: function(el, binding, vnode) {
        if (el.emojiPicker && el.emojiPicker.parentNode) {
          el.emojiPicker.parentNode.removeChild(el.emojiPicker);
        }
        el.instance && el.instance.$destroy();
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
