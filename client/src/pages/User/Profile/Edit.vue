<template lang="html">
  <b-container>
    <div class="d-flex justify-content-center" v-if="Loading" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="250" :color="'#7289da'"/>
    </div>
    <div v-else>
      <div class="form-group">
        <label>New Username</label>
        <div class="input-group">
          <div class="input-group-prepend">
            <span class="input-group-text">
              <i class="fa fa-user fa-fw"></i>
            </span>
          </div>
          <b-input
            id="Firstname"
            name="firstname"
            class="form-control"
            type="text"
            v-model="Firstname"
            v-validate="'alpha_num|min:6'"
            :class="{'form-control': true, 'error': errors.has('new username') }"
            autofocus
          ></b-input>
          <b-tooltip placement="bottom" target="NewUsername">{{ getErrorMsg('firstname') }}</b-tooltip>
        </div>
      </div>
    </div>
  </b-container>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";

export default {
  name: "Edit User",
  props: ["User"],
  data() {
    return {
      Firstname: "",
      Lastname: "",
      Location: "",

      Loading: false
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  methods: {
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  }
};
</script>

