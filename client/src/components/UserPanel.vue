<template>
  <div class="card rounded" style="margin-bottom: 20px">
    <article class="card-body">
      <h4 class="card-title text-center mb-4 mt-1">User Panel {{  }}</h4>
      <hr>
    </article>
  </div>
</template>

<script>
export default {
  data() {
    return {
        user: { }
    };
  },
  created() {
      this.user = this.$store.getters.user
      //console.log(this.$store.getters.user)
  }
};
</script>
