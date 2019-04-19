<template>
<b-container>
    <h4>
        Welcome {{ user.firstname }}
    </h4>
    <b-row>
        <div>yes</div>
    </b-row>
</b-container>
</template>

<script>
export default {
  data() {
    return {
        user: null
    };
  },
  created() {
      this.user = this.$store.getters.user;
  }
};
</script>
