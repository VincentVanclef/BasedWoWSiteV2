<template>
  <div>
    <div class="d-flex justify-content-center" v-if="IsLoading" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'" />
    </div>
    <div v-else>
      <select class="form-control" v-model="SelectedNews" required @change="ChangeNews">
        <option disabled>Select News</option>
        <option v-for="(news, index) in News" :key="index" :value="news">{{ news.title }}</option>
      </select>

      <hr />

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
              v-model="NewTitle"
              v-validate="'required|min:5|max:50'"
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
              v-model="NewContent"
              v-validate="'required|min:25|max:1000'"
              :class="{'error': errors.has('News Content') }"
            ></b-textarea>
            <b-tooltip placement="bottom" target="news-content">{{ errors.first('News Content') }}</b-tooltip>
          </div>

          <label>Author</label>
          <select class="form-group form-control" v-model="NewAuthor">
            <option :value="NewAuthor">{{NewAuthor.username}}</option>
            <option v-for="admin in GetAdmins" :key="admin.id" :value="admin">{{ admin.username }}</option>
          </select>

          <div class="form-group">
            <label>Image</label>
            <b-input
              id="news-image"
              type="text"
              class="form-control"
              name="Author Image"
              placeholder="URL to news avatar..."
              v-model="NewImage"
              v-validate="'required|url|image'"
              :class="{'error': errors.has('Author Image') }"
            ></b-input>
            <b-tooltip placement="bottom" target="news-image">{{ errors.first('Author Image') }}</b-tooltip>

            <div class="form-group">
              <div class="container">
                <div class="row">
                  <label>Image Preview</label>
                </div>
                <div class="row">
                  <img
                    class="news-avatar"
                    :src="NewImage"
                    @error="InvalidImage"
                    @load="ValidImage"
                  />
                </div>
              </div>
            </div>
          </div>

          <button class="button update-account" @click="UpdateNews" name="update">
            <i class="fa fa-check-circle"></i>
            <span>Save Changes</span>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";

const API_NEWS = process.env.API.NEWS;

export default {
  props: ["User", "Admins", "News"],
  name: "news-admin-edit",
  data() {
    return {
      SelectedNews: "Select News",

      NewTitle: "",
      NewContent: "",
      NewAuthor: null,
      NewImage: "",
      ImageAccepted: false,

      IsLoading: false
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  computed: {
    GetAdmins() {
      return this.Admins.filter(admins => admins.id != this.NewAuthor.id);
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
      this.NewAuthor = this.GetAdminByName(this.SelectedNews.author);
      this.NewTitle = this.SelectedNews.title;
      this.NewContent = this.SelectedNews.content;
      this.NewImage = this.SelectedNews.image;
    },
    InvalidImage() {
      this.ImageAccepted = false;
    },
    ValidImage() {
      this.ImageAccepted = true;
    },
    Reset() {
      this.NewTitle = "";
      this.NewContent = "";
      this.NewAuthor = null;
      this.NewImage = "";
      this.SelectedNews = "Select News";
    },
    async UpdateNews() {
      const formValid = await this.isFormValid();
      if (!formValid) {
        return;
      }

      try {
        await this.$dialog.confirm(`Continue editing ${this.SelectedNews.title}?`);
      } catch (e) {
        return;
      }

      this.IsLoading = true;

      let result;

      try {
        result = await this.$http.post(`${API_NEWS}/edit`, {
          id: this.SelectedNews.id,
          title: this.NewTitle,
          content: this.NewContent,
          author: this.NewAuthor.id,
          image: this.NewImage
        });
      } catch (error) {
        this.$toasted.error(error);
        return;
      } finally {
        this.IsLoading = false;
      }

      if (result.data == "success") {
        this.$toasted.success(
          `${this.SelectedNews.title} has been edited successfully`
        );

        const updates = [
          { index: "title", value: this.NewTitle },
          { index: "content", value: this.NewContent },
          { index: "author", value: this.NewAuthor.username, },
          { index: "image", value: this.NewImage }
        ];

        this.$store.commit("NEWS_UPDATE_ARRAY", {
          newsid: this.SelectedNews.id,
          updates: updates
        });

        this.Reset();
      } else {
        this.$toasted.error(result.data);
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
    this.$validator.extend("image", {
      getMessage: () => "Please enter a valid avatar URL",
      validate: () => {
        return this.ImageAccepted == true;
      }
    });
  }
};
</script>

<style scoped>
#atom-spinner {
  margin-top: 40%;
}

.news-avatar {
  max-height: 25%;
  max-width: 25%;
}

.news-content {
  min-height: 200px;
  max-height: 600px;
}
</style>
