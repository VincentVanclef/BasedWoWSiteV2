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
              maxlength="100"
              v-validate="'required|min:5|max:100'"
              :class="{'error': errors.has('News Title') }"
            ></b-input>
            <b-tooltip placement="bottom" target="news-title">{{ errors.first('News Title') }}</b-tooltip>
          </div>

          <div class="form-group">
            <label>News Content</label>
            <ckeditor
              id="news-content"
              name="News Content"
              class="form-control"
              :editor="editor"
              :config="editorConfig"
              v-model="NewContent"
            ></ckeditor>
          </div>

          <label>Author</label>
          <select class="form-group form-control" v-model="NewAuthor">
            <option v-for="admin in Admins" :key="admin.id" :value="admin">{{ admin.userName }}</option>
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
                  <img class="news-avatar" :src="NewImage" @error="InvalidImage" @load="ValidImage" />
                </div>
              </div>
            </div>
          </div>

          <button class="button update-account mb-3" @click="UpdateNews" name="update">
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
import CKEditor from "@ckeditor/ckeditor5-vue";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";

const API_NEWS = process.env.API.NEWS;

export default {
  props: ["user", "Admins", "News"],
  name: "news-admin-edit",
  data() {
    return {
      SelectedNews: "Select News",

      NewTitle: "",
      NewContent: "",
      NewAuthor: null,
      NewImage: "",
      ImageAccepted: false,

      IsLoading: false,

      editor: ClassicEditor,
      editorConfig: {}
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner,
    ckeditor: CKEditor.component
  },
  computed: {},
  methods: {
    async isFormValid() {
      const result = await this.$validator.validateAll();
      return result;
    },
    GetAdminByName(name) {
      return this.$store.getters["admin/GetAdminByUsername"](name);
    },
    ChangeNews() {
      this.NewAuthor = this.GetAdminByName(this.SelectedNews.authorName);
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

      const check = await this.$bvModal.msgBoxConfirm(
        `Continue editing ${this.SelectedNews.title}?`,
        {
          centered: true,
          okTitle: "Yes"
        }
      );

      if (!check) return;

      this.IsLoading = true;

      try {
        const result = await this.$store.dispatch("news/EditNews", {
          id: this.SelectedNews.id,
          title: this.NewTitle,
          content: this.NewContent,
          author: this.NewAuthor.id,
          image: this.NewImage
        });
      } catch (error) {
        this.$root.ToastError(error);
        return;
      } finally {
        this.IsLoading = false;
      }

      this.$root.ToastSuccess(
        `${this.SelectedNews.title} has been edited successfully`
      );

      this.Reset();
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
