<template>
  <b-container class="main-content">
    <b-input type="text" v-model="Message"></b-input>
    <b-button @click="SendMessage">Send</b-button>
    <b-row class="mt-5">
      <b-col>
        <b-radio-group v-model="Receiver">
          <b-radio
            v-for="(user, index) in GetOnlineUsers"
            :key="index"
            :value="user.id"
          >{{user.clients[0].clientName}}</b-radio>
        </b-radio-group>
      </b-col>
    </b-row>
    <chat-box></chat-box>
  </b-container>
</template>

<script>
import ChatBox from "@/components/ChatWindow/ChatBox";

export default {
  props: ["user"],
  name: "Chat",
  data() {
    return {
      ChatHub: null,
      Message: "",
      Receiver: ""
    };
  },
  components: {
    "chat-box": ChatBox
  },
  computed: {
    GetOnlineUsers() {
      return this.$store.getters["stats/GetOnlineUsers"];
    }
  },
  methods: {
    SendMessage() {
      this.$store.dispatch("chat/SendChatMessage", {
        SenderId: this.user.id,
        ReceiverId: this.Receiver,
        Message: this.Message
      });
      this.Message = "";
      this.Receiver = "";
    }
  },
  created() {},
  beforeDestroy() {}
};
</script>

<style scoped>
</style>