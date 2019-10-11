<template>
  <emoji-picker @emoji="AppendEmoji" :search="EmojiSearch">
    <div
      class="emoji-invoker"
      slot="emoji-invoker"
      slot-scope="{ events: { click: clickEvent } }"
      @click.stop="clickEvent"
      @click="reevaluatePosition"
      @click.right.prevent
    >
      <svg height="24" viewBox="0 0 24 24" width="24" xmlns="http://www.w3.org/2000/svg">
        <path d="M0 0h24v24H0z" fill="none" />
        <path
          d="M11.99 2C6.47 2 2 6.48 2 12s4.47 10 9.99 10C17.52 22 22 17.52 22 12S17.52 2 11.99 2zM12 20c-4.42 0-8-3.58-8-8s3.58-8 8-8 8 3.58 8 8-3.58 8-8 8zm3.5-9c.83 0 1.5-.67 1.5-1.5S16.33 8 15.5 8 14 8.67 14 9.5s.67 1.5 1.5 1.5zm-7 0c.83 0 1.5-.67 1.5-1.5S9.33 8 8.5 8 7 8.67 7 9.5 7.67 11 8.5 11zm3.5 6.5c2.33 0 4.31-1.46 5.11-3.5H6.89c.8 2.04 2.78 3.5 5.11 3.5z"
        />
      </svg>
    </div>
    <div slot="emoji-picker" slot-scope="{ emojis, insert }">
      <div class="emoji-picker" :style="style" @click.right.prevent>
        <div class="emoji-picker__search">
          <input type="text" v-model="EmojiSearch" v-focus />
        </div>
        <div>
          <div v-for="(emojiGroup, category) in emojis" :key="category">
            <h5>{{ category }}</h5>
            <div class="emojis">
              <span
                v-for="(emoji, emojiName) in emojiGroup"
                :key="emojiName"
                @click="insert(emoji)"
                :title="emojiName"
              >{{ emoji }}</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  </emoji-picker>
</template>

<script>
export default {
  data() {
    return {
      style: null,
      EmojiSearch: "",
      Vm: null,
      Node: null,

      Opened: false
    };
  },
  methods: {
    AppendEmoji(emoji) {
      this.Vm.AppendEmoji(emoji);
    },
    async reevaluatePosition(e) {
      this.Opened = !this.Opened;
      if (!this.Opened) return;

      await this.$nextTick();
      await this.$nextTick();

      let { x, y } = e;
      x = x + 20;

      // get the window current inner height and width
      let { innerHeight, scrollY, innerWidth } = window;

      // get the component height and width through element.getBoundingClientRect
      if (this.Node.elm.nextElementSibling.children.length < 2) return;

      const emojiPicker = this.Node.elm.nextElementSibling.children[1]
        .firstElementChild.firstChild;
      let { height, width } = emojiPicker.getBoundingClientRect();

      // console.log(this.Node);
      // then subtract window inner height and width with
      // context-menu event source points (x, y)
      let dY = innerHeight - y;
      let dX = innerWidth - x;
      // check if the context-menu height is not
      // longer than the available
      if (dY < height) {
        y = y - height;
      }
      if (dX < width) {
        x = x - width;
      }

      // set the position
      this.style = { left: x + "px", top: y + "px" };
    }
  }
};
</script>

<style scoped>
.emoji-invoker {
  position: absolute;
  top: 0.5rem;
  right: 3.5rem;
  width: 1.5rem;
  height: 1.5rem;
  border-radius: 50%;
  cursor: pointer;
  transition: all 0.2s;
}
.emoji-invoker:hover {
  transform: scale(1.1);
}
.emoji-invoker > svg {
  fill: #97a1a5;
}

.emoji-picker {
  position: fixed;
  top: -300px;
  z-index: 9999;
  font-family: Montserrat;
  border: 1px solid #ccc;
  width: 15rem;
  height: 20rem;
  overflow: scroll;
  padding: 1rem;
  box-sizing: border-box;
  border-radius: 0.5rem;
  background: #fff;
  box-shadow: 1px 1px 8px #c7dbe6;
}
.emoji-picker__search {
  display: flex;
}
.emoji-picker__search > input {
  flex: 1;
  border-radius: 10rem;
  border: 1px solid #ccc;
  padding: 0.5rem 1rem;
  outline: none;
  width: 100%;
  margin-bottom: 7px;
}
.emoji-picker h5 {
  margin-bottom: 0;
  color: #b1b1b1;
  text-transform: uppercase;
  font-size: 0.8rem;
  cursor: default;
}
.emoji-picker .emojis {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
}
.emoji-picker .emojis:after {
  content: "";
  flex: auto;
}
.emoji-picker .emojis span {
  padding: 0.2rem;
  cursor: pointer;
  border-radius: 5px;
}
.emoji-picker .emojis span:hover {
  background: #ececec;
  cursor: pointer;
}
</style>