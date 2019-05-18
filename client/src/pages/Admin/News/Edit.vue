<template>
  <div>
    <select class="form-control" v-model="SelectedNews" required @change="ChangeNews">
      <option disabled>Select News</option>
      <option v-for="(news, index) in News" :key="index" :value="news">{{ news.title }}</option>
    </select>

    <hr>

    <div v-if="typeof(SelectedNews) == 'object'">
      <div class="form-group">
        <h4 class="text-center">Edit News</h4>

        <div class="form-group">
          <label>News Title</label>
          <b-input
            id="news-title"
            name="News Title"
            type="text"
            class="form-control news-title"
            v-model="NewsTitle"
            v-validate="'required|alpha_num|min:7|max:50'"
            :class="{'error': errors.has('News Title') }"
          ></b-input>
          <b-tooltip placement="bottom" target="news-title">{{ errors.first('News Title') }}</b-tooltip>
        </div>

        <div class="form-group">
          <label>News Content</label>
          <b-textarea
            id="news-content"
            name="News Content"
            class="form-control news-content"
            v-model="NewsContent"
            v-validate="'required|min:100|max:1000'"
            :class="{'error': errors.has('News Content') }"
          ></b-textarea>
          <b-tooltip placement="bottom" target="news-content">{{ errors.first('News Content') }}</b-tooltip>
        </div>

        <label>Author</label>
        <select class="form-group form-control" v-model="NewsAuthor">
          <option :value="NewsAuthor">{{NewsAuthor.username}}</option>
          <option v-for="admin in GetAdmins" :key="admin.id" :value="admin">{{ admin.username }}</option>
        </select>

        <button class="button update-account" @click="UpdateNews" name="update">
          <i class="fa fa-check-circle"></i>
          <span>Save Changes</span>
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: ["User", "Admins", "News"],
  name: "news-admin-edit",
  data() {
    return {
      SelectedNews: "Select News",

      NewsTitle: "",
      NewsContent: "",
      NewsAuthor: null
    };
  },
  computed: {
    GetAdmins() {
      return this.Admins.filter(admins => admins.id != this.NewsAuthor.id);
    }
  },
  methods: {
    async isFormValid() {
      const result = await this.$validator.validateAll();
      return result;
    },
    GetAdminByName(name) {
      const admin = this.Admins.find(x => x.username == name);
      return admin;
    },
    ChangeNews() {
      this.NewsAuthor = this.GetAdminByName(this.SelectedNews.author);
      this.NewsTitle = this.SelectedNews.title;
      this.NewsContent = this.SelectedNews.content;
    },
    async UpdateNews() {
      const formValid = await this.isFormValid();
      if (!formValid) {
        return;
      }
    }
  }
};
</script>

<style scoped>
#atom-spinner {
  margin-top: 40%;
}

.news-content {
  min-height: 200px;
  max-height: 600px;
}
</style>
