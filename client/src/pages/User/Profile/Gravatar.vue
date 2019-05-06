<template>
  <div class="container">
    <section>
      <h4>
        We make use of
        <a href="http://gravatar.com" target="_blank">Gravatar</a>
        which provides an easy way to maintain your avatars across the web.
      </h4>
      <br>
      <h5>
        To change your avatar you need to
        <a href="http://gravatar.com" target="_blank">sign up for</a>
        or
        <a href="http://gravatar.com" target="_blank">log into</a>
        Gravatar using the following email:
      </h5>
      <br>
      <div class="title text-center">
        <h4>{{ User.email.toUpperCase() }}</h4>
      </div>
    </section>
  </div>
</template>

<script>
export default {
  props: ["User"],
  name: "Gravatar",
  data() {
    return {};
  }
};
</script>

<style scoped>
h2 {
  color: #007bff;
}
</style>


