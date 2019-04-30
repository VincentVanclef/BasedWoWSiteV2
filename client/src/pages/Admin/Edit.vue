<template lang="html">
  <div>
    <div class="title">
      <h1>{{msg}}</h1>
      <h1>This is Admin/Edit/{{$route.params.id}}</h1>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  data() {
    return {
      msg: "Welcome to the Edit Admin Page"
    };
  }
};
</script>
