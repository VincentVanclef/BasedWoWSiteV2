<template>
</template>

<script>
  export default {
    name: 'home',
    data () {
      return {
        msg: 'Welcome to the Cart Page'
      }
    },
    created() {
    document.title = this.$Title + " - Cart";
  }
  }
</script>
