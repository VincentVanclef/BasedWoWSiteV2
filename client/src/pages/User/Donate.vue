<template>
  <div class="container">
    <profile-nav></profile-nav>
  </div>
</template>

<script>
import ProfileNav from "@/components/ProfileNav";
import { SemipolarSpinner } from "epic-spinners";

export default {
  name: "DonatePanel",
  data() {
    return {};
  },
  components: {
    "profile-nav": ProfileNav,
    "semipolar-spinner": SemipolarSpinner
  }
};
</script>
