<template>
  <div>
    <div class="d-flex justify-content-center" v-if="IsLoading" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'"/>
    </div>
    <div v-else>
      <div class="form-group">
        <h4 class="text-center">Create News</h4>

        <div class="form-group">
          <label>News Title</label>
          <b-input
            id="news-title"
            type="text"
            class="form-control news-title"
            name="News Title"
            v-model="NewTitle"
            v-validate="'required|alpha_num|min:10|max:50'"
            :class="{'error': errors.has('News Title') }"
          ></b-input>
          <b-tooltip placement="bottom" target="news-title">{{ errors.first('News Title') }}</b-tooltip>
        </div>
        <div class="form-group">
          <label>News Content</label>
          <b-textarea
            id="news-content"
            class="form-control news-content"
            name="News Content"
            v-model="NewContent"
            v-validate="'required|min:100|max:1000'"
            :class="{'error': errors.has('News Content') }"
          ></b-textarea>
          <b-tooltip placement="bottom" target="news-content">{{ errors.first('News Content') }}</b-tooltip>
        </div>
        <select
          id="news-author"
          class="form-group form-control"
          name="Select Author"
          v-model="NewAuthor"
          v-validate="'required|select'"
          :class="{'error': errors.has('Select Author') }"
          @change="ChangeAuthor"
        >
          <option disabled>Select Author</option>
          <option v-for="(admin, index) in Admins" :key="index" :value="admin">{{ admin.username }}</option>
        </select>
        <b-tooltip placement="bottom" target="news-author">{{ errors.first('Select Author') }}</b-tooltip>

        <button class="button update-account" @click="CreateNews" name="create">
          <i class="fa fa-check-circle"></i>
          <span>Create News</span>
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";

export default {
  props: ["Admins", "User"],
  name: "news-admin-create",
  data() {
    return {
      NewTitle: "",
      NewContent: "",
      NewAuthor: "Select Author",

      IsLoading: false
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  computed: {
    GetAdmins() {
      return this.Admins.filter(admins => admins.id != this.NewsAuthor.id);
    }
  },
  methods: {
    ChangeAuthor() {},
    async isFormValid() {
      const result = await this.$validator.validateAll();
      return result;
    },
    async CreateNews() {
      const formValid = await this.isFormValid();
      if (!formValid) {
        return;
      }
    }
  },
  created() {
    this.$validator.extend("select", {
      getMessage: () => "Please select an Author",
      validate: () => {
        return typeof this.NewAuthor == "object";
      }
    });
  }
};
</script>

<style scoped lang="css">
#atom-spinner {
  margin-top: 40%;
}

.news-content {
  min-height: 200px;
  max-height: 600px;
}
</style>
