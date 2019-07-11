<template>
  <div class="container">
    <div class="form-group" v-if="Realms.length > 0">
      <select name="realm-selection" class="form-control" v-model="SelectedRealm">
        <option disabled>Choose Realm</option>
        <option v-for="realm in Realms" :key="realm.id" v-bind:value="realm">{{ realm.name }}</option>
      </select>
    </div>

    <!-- ADMIN PANEL -->
    <div v-if="isAdmin">
      <div class="form-group">
        <button class="btn btn-primary btn-block" type="submit" @click="ToggleAdminTools()">
          <i class="fa fa-lock fa-fw"></i>
          {{ AdminToolsEnabled ? "Hide" : "Show" }} Admin Tools
        </button>
      </div>

      <div class="form-group text-center" v-if="AdminToolsEnabled">
        <b-row>
          <b-col lg="4" sm="6">
            <button
              class="btn btn-primary btn-block mb-2"
              type="submit"
              @click="OpenCreateEditor()"
            >
              <i class="fa fa-plus fa-fw"></i> Add New Change
            </button>
          </b-col>
          <b-col lg="4" sm="6">
            <button
              class="btn btn-primary btn-block mb-2"
              type="submit"
              @click="OpenCreateCategoryEditor()"
            >
              <i class="fa fa-plus fa-fw"></i> Add Category
            </button>
          </b-col>
          <b-col lg="4" sm="6">
            <button
              class="btn btn-primary btn-block mb-2"
              type="submit"
              @click="OpenDeleteCategoryEditor()"
            >
              <i class="fa fa-trash fa-fw"></i> Delete Category
            </button>
          </b-col>
        </b-row>
      </div>
    </div>

    <div v-if="typeof SelectedRealm == 'object'">
      <!-- CHANGELOG PAGEINATION -->
      <b-pagination
        v-model="CurrentPage"
        :total-rows="GetChangesForRealm.length"
        :per-page="PerPage"
        first-text="First"
        prev-text="Prev"
        next-text="Next"
        last-text="Last"
        aria-controls="changelog-table"
      ></b-pagination>

      <!-- CHANGELOG TABLE -->
      <b-table
        id="changelog-table"
        :items="GetChangesForRealm"
        :fields="GetTableFields"
        :current-page="CurrentPage"
        :per-page="PerPage"
        :sort-compare-options="{ numeric: true, sensitivity: 'base' }"
        responsive
        striped
        bordered
      >
        <span
          slot="category"
          slot-scope="data"
          cols="2"
          v-bind:style="{ color: GetColor(data.value) }"
        >{{ data.value }}</span>
        <span slot="content" slot-scope="data" v-html="data.value"></span>
        <template slot="Action" slot-scope="data">
          <button class="profile-update-button" type="submit" @click="OpenEditor(data.item)">
            <i class="fa fa-edit fa-fw" title="Open Editor"></i>
          </button>
          <button class="profile-update-button" type="submit" @click="Delete(data.item)">
            <i class="fa fa-close fa-fw" title="Delete Change"></i>
          </button>
        </template>
      </b-table>

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
              v-bind:value="category.title"
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

    <!-- CREATE CHANGE MODAL -->
    <b-modal
      id="create-change-modal"
      centered
      v-if="SelectedChange"
      v-model="NewChangeModal"
      title="Create New Change"
      ok-title="Add Change"
      header-bg-variant="info"
      @ok="AddChange"
    >
      <div class="form-group">
        <label>Category</label>
        <select name="category-selection" class="form-control" v-model="SelectedChange.category">
          <option
            v-for="category in Categories"
            :key="category.id"
            v-bind:value="category.title"
          >{{ GetCategoryName(category.id) }}</option>
        </select>
      </div>

      <div class="form-group">
        <label>Title</label>
        <b-input
          id="changelog-title"
          name="changelog title"
          class="form-control"
          v-model="SelectedChange.title"
          v-validate="'required|min:3|max:50'"
          :class="{ 'text-center': true, 'form-control': true, 'error': errors.has('changelog title') }"
        ></b-input>
        <b-tooltip placement="bottom" target="changelog-title">{{ errors.first('changelog title') }}</b-tooltip>
      </div>

      <div class="form-group">
        <label>Content</label>
        <b-textarea
          id="changelog-content"
          name="changelog content"
          class="form-control"
          v-model="SelectedChange.content"
          v-validate="'required|min:3|max:500'"
          :class="{ 'text-center': true, 'form-control': true, 'error': errors.has('changelog content') }"
        ></b-textarea>
        <b-tooltip
          placement="bottom"
          target="changelog-content"
        >{{ errors.first('changelog content') }}</b-tooltip>
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

    <!-- CREATE CATEGORY MODAL -->
    <b-modal
      id="create-category-modal"
      centered
      v-if="NewCategoryModal"
      v-model="NewCategoryModal"
      title="Create New Category"
      ok-title="Add Category"
      header-bg-variant="info"
      @ok="AddCategory"
    >
      <div class="form-group">
        <label>Title</label>
        <b-input
          type="text"
          id="category-title"
          name="category title"
          maxlength="15"
          v-validate="'required|min:3|max:15'"
          :class="{ 'text-center': true, 'form-control': true, 'error': errors.has('category title') }"
          v-model="NewCategory.Title"
        />
        <b-tooltip placement="bottom" target="category-title">{{ errors.first('category title') }}</b-tooltip>
      </div>

      <div class="form-group">
        <label>Color Code</label>
        <b-input
          type="text"
          id="category-color"
          name="category color"
          maxlength="6"
          v-validate="'required|color'"
          :class="{ 'text-center': true, 'form-control': true, 'error': errors.has('category color') }"
          v-model="NewCategory.Color"
          @keydown="ResetColor"
        />
        <b-tooltip placement="bottom" target="category-color">{{ errors.first('category color') }}</b-tooltip>
      </div>
      <label>Color</label>
      <div
        id="category-color-strip"
        class="category-color-strip"
        v-bind:style="{ background: GetColorCode }"
      ></div>
    </b-modal>

    <!-- DELETE CATEGORY MODAL -->
    <b-modal
      centered
      v-if="DeleteCategoryModal"
      v-model="DeleteCategoryModal"
      title="Delete Category"
      ok-title="Delete Category"
      header-bg-variant="info"
      @ok="DeleteCategory()"
    >
      <div class="form-group">
        <label>Select Category</label>
        <select class="form-control" v-model="DeleteCategoryObject">
          <option
            v-for="category in Categories"
            :key="category.id"
            v-bind:value="category"
          >{{ GetCategoryName(category.id) }}</option>
        </select>
      </div>
    </b-modal>
  </div>
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

      /* TABLE CONFIG */
      CurrentPage: 1,
      PerPage: 10,
      TableFields: [
        { key: "category", sortable: true, tdClass: "th-category" },
        { key: "title", sortable: true, tdClass: "th-title" },
        { key: "content", sortable: true, tdClass: "th-content" },
        { key: "date", sortable: true, tdClass: "th-date" }
      ],

      /* SELECTION */
      SelectedRealm: "Choose Realm",
      ShowEditor: false,
      SelectedChange: null,
      SelectedChangeTitle: "",

      /* CREATE NEW CATEGORY */
      NewCategoryModal: false,
      NewCategory: {},

      /* DELETE CATEGORY */
      DeleteCategoryModal: false,
      DeleteCategoryObject: null,

      /* CREATE NEW CHANGE */
      NewChangeModal: false,

      /* ADMIN */
      AdminToolsEnabled: false
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
    },
    GetColorCode() {
      return "#" + this.NewCategory.Color;
    },
    GetTableFields() {
      let data = [];
      this.isAdmin && this.AdminToolsEnabled
        ? (data = [
            { key: "category", sortable: true, thClass: "th-category" },
            { key: "title", sortable: true, thClass: "th-title" },
            { key: "content", sortable: true, thClass: "th-content" },
            { key: "date", sortable: true, thClass: "th-date" },
            "Action"
          ])
        : (data = [
            { key: "category", sortable: true, thClass: "th-category" },
            { key: "title", sortable: true, thClass: "th-title" },
            { key: "content", sortable: true, thClass: "th-content" },
            { key: "date", sortable: true, thClass: "th-date" }
          ]);

      return data;
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
        // Fix Data
        for (let change of this.Changes) {
          change.date = this.GetDate(change.date);
          change.category = this.GetCategoryName(change.category);
        }
      }
    },
    GetCategoryIdByTitle(title) {
      return this.Categories.find(x => x.title == title).id;
    },
    GetCategoryName(id) {
      return this.Categories.find(x => x.id == id).title;
    },
    GetCategoryColor(title) {
      return this.Categories.find(x => x.title == title).color;
    },
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY");
    },
    GetColor(title) {
      return "#" + this.GetCategoryColor(title);
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
        category: "WARRIOR",
        content: "",
        realm: 0,
        date: this.GetDate(new Date())
      };
      this.NewChangeModal = true;
    },
    OpenCreateCategoryEditor() {
      this.NewCategoryModal = true;
    },
    OpenDeleteCategoryEditor() {
      this.DeleteCategoryModal = true;
    },
    ResetColor() {
      const inputbar = document.getElementById("category-color");
      if (inputbar.value.length != 6) {
        const colorbar = document.getElementById("category-color-strip");
        colorbar.style.backgroundColor = "";
      }
    },
    ResetCategory() {
      this.NewCategory.Title = "";
      this.NewCategory.Color = "";
    },
    async Update(change) {
      const result = await this.$http.post(`${CHANGELOG_API}/update/change`, {
        id: change.id,
        category: this.GetCategoryIdByTitle(change.category),
        title: change.title,
        content: change.content
      });

      if (result.data.status == "success") {
        // Update real object
        const CHANGE_TO_BE_CHANGED = this.Changes.find(x => x.id == change.id);
        Object.assign(CHANGE_TO_BE_CHANGED, change);

        this.$toasted.success(
          `'${change.title}' has been updated successfully`
        );
      } else {
        this.$toasted.error(`Unable to update '${change.title}'`);
      }
    },
    AddChange(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          this.$http
            .post(`${CHANGELOG_API}/add/change`, {
              title: this.SelectedChange.title,
              content: this.SelectedChange.content,
              realm: this.SelectedChange.realm,
              category: this.GetCategoryIdByTitle(this.SelectedChange.category)
            })
            .then(result => {
              if (result.data.NewId > 0) {
                // Add new change to list
                this.SelectedChange.id = result.data.NewId;
                this.Changes.push(this.SelectedChange);

                this.$toasted.success(
                  `Change: '${this.SelectedChange.title}' has been added successfully`
                );
              } else {
                this.$toasted.error(result);
              }
            })
            .finally(() => {
              this.$bvModal.hide("create-change-modal");
              this.SelectedChange = null;
            });
        }
      });
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
        const index = this.Changes.findIndex(x => x.id == change.id);
        this.Changes.splice(index, 1);

        this.$toasted.success(
          `'${change.title}' has been deleted successfully`
        );
      } else {
        this.$toasted.error(`Unable to delete '${change.title}'`);
      }
    },
    async isFormValid() {
      return await this.$validator.validateAll();
    },
    AddCategory(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          const newTitle = this.NewCategory.Title.toUpperCase();
          const newColor = this.NewCategory.Color.toUpperCase();

          this.$http
            .post(`${CHANGELOG_API}/add/category`, {
              title: newTitle,
              color: newColor
            })
            .then(result => {
              if (result.data.NewId > 0) {
                // Add new category to list
                this.Categories.push({
                  id: result.data.NewId,
                  title: newTitle,
                  color: newColor
                });

                this.$toasted.success(
                  `Category: '${newTitle}' has been added successfully`
                );
              } else {
                this.$toasted.error(result);
              }
            })
            .finally(() => {
              this.$bvModal.hide("create-category-modal");
              this.ResetCategory();
            });
        }
      });
    },
    async DeleteCategory() {
      try {
        await this.$dialog.confirm(
          `Continue deleting category: '${this.DeleteCategoryObject.title}'?`
        );
      } catch (e) {
        return;
      }

      const result = await this.$http.post(`${CHANGELOG_API}/delete/category`, {
        id: this.DeleteCategoryObject.id
      });

      if (result.data.status == "success") {
        const index = this.Categories.findIndex(
          x => x.id == this.DeleteCategoryObject.id
        );
        this.Categories.splice(index, 1);

        this.$toasted.success(
          `'${this.DeleteCategoryObject.title}' has been deleted successfully`
        );
      } else {
        this.$toasted.error(
          `Unable to delete '${this.DeleteCategoryObject.title}' Error: ${result.data.status}`
        );
      }
    }
  },
  created() {
    this.GetCategories()
      .then(() => {
        this.GetChanges().catch(err => console.log(err));
      })
      .catch(err => console.log(err));

    this.Realms = [...config.REALMS];

    this.$validator.extend("color", {
      getMessage: () => "Please enter a valid color code.",
      validate: () => {
        return /^#[0-9a-f]{3}([0-9a-f]{3})?$/i.test(
          "#" + this.NewCategory.Color
        );
      }
    });
  }
};
</script>

<style>
.th-category {
  width: 20%;
}

.th-title {
  width: 20%;
}

.th-content {
  width: 45%;
}

.th-date {
  width: 15%;
}
</style>

<style scoped>
#category-title,
#category-color {
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

.category-color-strip {
  width: 100%;
  height: 30px;
}

textarea {
  resize: vertical;
  max-height: 200px;
}
</style>
