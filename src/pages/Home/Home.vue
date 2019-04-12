<template lang="html">
  <b-container>
    <h1>{{msg}}</h1>
  </b-container>
</template>

<script lang="js">
  export default  {
    name: 'home',
    props: [],
    mounted() {

    },
    data() {
      return {
        msg: 'homepage'
      }
    },
    methods: {

    },
    computed: {

    },
    created() {
      document.title = this.$Title;
  }
}
</script>

<style scoped lang="css">
</style>
