<template>
  <b-container>
    <div class="form-group" v-if="Realms.length > 0">
      <select name="realm-selection" class="form-control" v-model="SelectedRealm">
        <option disabled>Choose Realm</option>
        <option v-for="realm in Realms" :key="realm.id" v-bind:value="realm">{{ realm.name }}</option>
      </select>
    </div>

    <div v-if="isAdmin">
      <div class="form-group">
        <button class="btn btn-primary" type="submit" @click="ToggleAdminTools()">
          <i class="fa fa-lock fa-fw"></i>
          {{ AdminToolsEnabled ? "Disable" : "Enable" }} Admin Tools
        </button>
      </div>

      <div class="form-group text-center" v-if="AdminToolsEnabled">
        <b-row>
          <b-col lg="3" sm="6">
            <input
              type="text"
              id="new-category"
              name="new category"
              maxlength="15"
              v-validate="'required|min:3|max:15'"
              :class="{ 'text-center': true, 'form-control': true, 'error': errors.has('new category') }"
              v-model="NewCategory"
            />
            <b-tooltip placement="bottom" target="new-category">{{ errors.first('new category') }}</b-tooltip>
          </b-col>
          <b-col lg="3" sm="6">
            <button class="btn btn-primary" type="submit" @click="AddCategory()">
              <i class="fa fa-plus fa-fw"></i> Add Category
            </button>
          </b-col>
          <b-col lg="3" sm="6">
            <select class="form-control" v-model="SelectedCategory">
              <option
                v-for="category in Categories"
                :key="category.id"
                v-bind:value="category"
              >{{ GetCategoryName(category.id) }}</option>
            </select>
          </b-col>
          <b-col lg="3" sm="6">
            <button class="btn btn-primary" type="submit" @click="DeleteCategory()">
              <i class="fa fa-trash fa-fw"></i> Delete Category
            </button>
          </b-col>
        </b-row>
      </div>

      <div class="form-group" v-if="AdminToolsEnabled">
        <button class="btn btn-primary" type="submit" @click="OpenCreateEditor()">
          <i class="fa fa-plus fa-fw"></i> Add New Change
        </button>
      </div>
    </div>

    <div v-if="typeof SelectedRealm == 'object'">
      <table class="table table-striped table-bordered">
        <thead>
          <th id="th-category" title="Sort by Category">
            <a href="#" @click="SortByCategory()">Category</a>
          </th>
          <th id="th-title" title="Sort by Title">
            <a href="#" @click="SortByTitle()">Title</a>
          </th>
          <th id="th-content" title="Sort by Content">
            <a href="#" @click="SortByContent()">Content</a>
          </th>
          <th id="th-date" title="Sort by Date">
            <a href="#" @click="SortByDate()">Date</a>
          </th>
        </thead>
        <!-- PLAYER SECTION -->
        <tbody>
          <tr v-for="(change, index) in GetChangesForRealm" :key="index">
            <td
              v-bind:style="{ color: GetColor(change.category) }"
            >{{ GetCategoryName(change.category) }}</td>
            <td v-html="change.title"></td>
            <td v-html="change.content"></td>
            <td>{{ change.date }}</td>
            <td v-if="isAdmin && AdminToolsEnabled">
              <button class="profile-update-button" type="submit" @click="OpenEditor(change)">
                <i class="fa fa-edit fa-fw" title="Open Editor"></i>
              </button>
              <button class="profile-update-button" type="submit" @click="Delete(change)">
                <i class="fa fa-close fa-fw" title="Cancel"></i>
              </button>
            </td>
          </tr>
        </tbody>
      </table>

      <!-- UPDATE MODAL -->
      <b-modal
        centered
        v-if="SelectedChange"
        v-model="ShowEditor"
        :title="'Edit Change: ' + SelectedChangeTitle"
        ok-title="Save Changes"
        header-bg-variant="info"
        @ok="Update(SelectedChange)"
      >
        <div class="form-group">
          <label>Category</label>
          <select name="category-selection" class="form-control" v-model="SelectedChange.category">
            <option
              v-for="category in Categories"
              :key="category.id"
              v-bind:value="category.id"
            >{{ GetCategoryName(category.id) }}</option>
          </select>
        </div>

        <div class="form-group">
          <label>Title</label>
          <b-input name="modal-title" class="form-control" v-model="SelectedChange.title"></b-input>
        </div>

        <div class="form-group">
          <label>Content</label>
          <b-textarea class="form-control" v-model="SelectedChange.content"></b-textarea>
        </div>
      </b-modal>
    </div>

    <!-- CREATE MODAL -->
    <b-modal
      centered
      v-if="SelectedChange"
      v-model="ShowCreateEditor"
      title="Create New Change"
      ok-title="Add Change"
      header-bg-variant="info"
      @ok="AddChange()"
    >
      <div class="form-group">
        <label>Category</label>
        <select name="category-selection" class="form-control" v-model="SelectedChange.category">
          <option
            v-for="category in Categories"
            :key="category.id"
            v-bind:value="category.id"
          >{{ GetCategoryName(category.id) }}</option>
        </select>
      </div>

      <div class="form-group">
        <label>Title</label>
        <b-input name="modal-title" class="form-control" v-model="SelectedChange.title"></b-input>
      </div>

      <div class="form-group">
        <label>Content</label>
        <b-textarea class="form-control" v-model="SelectedChange.content"></b-textarea>
      </div>

      <div class="form-group">
        <label>Realm</label>
        <select name="realm-selection" class="form-control" v-model="SelectedChange.realm">
          <option
            v-for="realm in GetRealmsForCreate"
            :key="realm.id"
            v-bind:value="realm.id"
          >{{ realm.name }}</option>
        </select>
      </div>
    </b-modal>
  </b-container>
</template>

<script>
import UserHelper from "@/helpers/UserHelper";
import config from "@/assets/config/config";
import moment from "moment";

const CHANGELOG_API = process.env.API.CHANGELOG;

export default {
  name: "Changelog",
  data() {
    return {
      /* CONTAINERS */
      Categories: [],
      Changes: [],
      Realms: [],

      /* SELECTION */
      SelectedRealm: "Choose Realm",
      ShowEditor: false,
      SelectedChange: null,
      SelectedChangeTitle: "",
      SelectedCategory: null,

      /* CREATE NEW */
      ShowCreateEditor: false,
      NewCategory: "",

      /* ADMIN */
      AdminToolsEnabled: false,

      /* SORTING */
      CategoryASC: true,
      TitleASC: true,
      ContentASC: true,
      DateASC: true
    };
  },
  computed: {
    isAdmin() {
      return UserHelper.IsAdmin();
    },
    GetRealmsForCreate() {
      const realms = [...this.Realms];
      realms.unshift({ id: 0, name: "All Realms" });
      return realms;
    },
    GetChangesForRealm() {
      return this.Changes.filter(
        x => x.realm == this.SelectedRealm.id || x.realm == 0
      );
    }
  },
  methods: {
    async GetCategories() {
      const result = await this.$http.get(`${CHANGELOG_API}/get/categories`);
      this.Categories = result.data;
    },
    async GetChanges() {
      const result = await this.$http.get(`${CHANGELOG_API}/get/changes`);
      this.Changes = result.data;

      if (this.Changes.length > 0) {
        // Fix Dates
        for (let change of this.Changes) {
          change.date = this.GetDate(change.date);
        }
      }
    },
    GetCategoryName(id) {
      return this.Categories.find(x => x.id == id).title;
    },
    GetColor(id) {
      return id <= 11 ? UserHelper.GetClassColor(id) : "blue";
    },
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY");
    },
    ToggleAdminTools() {
      this.AdminToolsEnabled = !this.AdminToolsEnabled;
    },
    OpenEditor(change) {
      this.SelectedChange = Object.assign({}, change);
      this.SelectedChangeTitle = change.title;
      this.ShowEditor = true;
    },
    OpenCreateEditor() {
      this.SelectedChange = {
        id: 0,
        title: "",
        category: 1,
        content: "",
        realm: 0,
        date: this.GetDate(new Date())
      };
      this.SelectedChangeTitle = "";
      this.ShowCreateEditor = true;
    },
    async Update(change) {
      const result = await this.$http.post(`${CHANGELOG_API}/update/change`, {
        id: change.id,
        category: change.category,
        title: change.title,
        content: change.content
      });

      if (result.data.status == "success") {
        // Update real object
        const CHANGE_TO_BE_CHANGED = this.Changes.find(
          x => x.id == change.id
        );
        Object.assign(CHANGE_TO_BE_CHANGED, change);

        this.$toasted.success(
          `'${change.title}' has been updated successfully`
        );
      } else {
        this.$toasted.error(`Unable to update '${change.title}'`);
      }
    },
    async AddChange() {
      const result = await this.$http.post(`${CHANGELOG_API}/add/change`, {
        title: this.SelectedChange.title,
        content: this.SelectedChange.content,
        realm: this.SelectedChange.realm,
        category: this.SelectedChange.category
      });

      console.log(result);
      if (result.data.NewId > 0) {
        // Add new change to list
        this.SelectedChange.id = result.data.NewId;
        this.Changes.push(this.SelectedChange);

        this.$toasted.success(
          `Change: '${this.SelectedChange.title}' has been added successfully`
        );
      } else {
        this.$toasted.error("Unable to add a new change");
      }

      this.SelectedChange = null;
    },
    async Delete(change) {
      try {
        await this.$dialog.confirm(`Continue deleting '${change.title}?'`);
      } catch (e) {
        return;
      }

      const result = await this.$http.post(`${CHANGELOG_API}/delete/change`, {
        id: change.id
      });

      if (result.data.status == "success") {
        const index = this.Changes.findIndex(
          x => x.id == change.id
        );
        this.Changes.splice(index, 1);

        this.$toasted.success(
          `'${change.title}' has been deleted successfully`
        );
      } else {
        this.$toasted.error(`Unable to delete '${change.title}'`);
      }
    },
    async isFormValid() {
      const result = await this.$validator.validateAll();
      return result;
    },
    async AddCategory() {
      const formValid = await this.isFormValid();
      if (!formValid) {
        return;
      }

      try {
        await this.$dialog.confirm(
          `Continue adding category: '${this.NewCategory}'?`
        );
      } catch (e) {
        return;
      }

      const result = await this.$http.post(`${CHANGELOG_API}/add/category`, {
        title: this.NewCategory
      });

      if (result.data.NewId > 0) {
        // Add new category to list
        this.Categories.push({
          id: result.data.NewId,
          title: this.NewCategory.toUpperCase()
        });

        this.$toasted.success(
          `Category: '${this.NewCategory}' has been added successfully`
        );
      } else {
        this.$toasted.error("Unable to add a new category");
      }
    },
    async DeleteCategory() {
      try {
        await this.$dialog.confirm(
          `Continue deleting category: '${this.SelectedCategory.title}'?`
        );
      } catch (e) {
        return;
      }

      const result = await this.$http.post(`${CHANGELOG_API}/delete/category`, {
        id: this.SelectedCategory.id
      });

      if (result.data.status == "success") {
        const index = this.Categories.findIndex(
          x => x.id == this.SelectedCategory.id
        );
        this.Categories.splice(index, 1);

        this.$toasted.success(
          `'${this.SelectedCategory.title}' has been deleted successfully`
        );
      } else {
        this.$toasted.error(
          `Unable to delete '${this.SelectedCategory.title}' Error: ${result.data.status}`
        );
      }
    },
    /* SORTING */
    SortByCategory() {
      this.Changes.sort((a, b) => {
        return this.CategoryASC ? b.category - a.category : a.category - b.category;
      });

      this.CategoryASC = !this.CategoryASC;
    },
    SortByTitle() {
      this.Changes.sort((a, b) => {
        return this.TitleASC
          ? a.title.localeCompare(b.title)
          : b.title.localeCompare(a.title);
      });

      this.TitleASC = !this.TitleASC;
    },
    SortByContent() {
      this.Changes.sort((a, b) => {
        return this.ContentASC
          ? a.content.localeCompare(b.content)
          : b.content.localeCompare(a.content);
      });

      this.ContentASC = !this.ContentASC;
    },
    SortByDate() {
      this.Changes.sort((a, b) => {
        if (a.date < b.date) return this.DateASC ? 1 : -1;
        if (a.date > b.date) return this.DateASC ? -1 : 1;
        return 0;
      });

      this.DateASC = !this.DateASC;
    }
  },
  created() {
    try {
      this.GetCategories();
    } catch (e) {
      console.log(e);
    }
    try {
      this.GetChanges();
    } catch (e) {
      console.log(e);
    }

    this.Realms = [...config.REALMS];
  }
};
</script>

<style scoped>
#th-category {
  width: 20%;
}

#th-title {
  width: 20%;
}

#th-content {
  width: 45%;
}

#th-date {
  width: 15%;
}

#new-category {
  font-weight: bold;
  text-transform: uppercase;
}

.profile-update-button {
  background: #efdb06;
  border: 1px solid #f9e610;
  color: #3d3d3d;
  width: 100%;
}

.profile-update-button:hover {
  transform: scaleX(1.1);
}

textarea {
  resize: vertical;
  max-height: 200px;
}
</style>
