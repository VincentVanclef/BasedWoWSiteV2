<template>
  <div class="container">
    <div class="form-group" v-if="realms.length > 0">
      <select
        name="realm-selection"
        class="form-control"
        v-model="SelectedRealm"
        @change="SelectedRealmChange()"
      >
        <option disabled>Choose Realm</option>
        <option v-for="realm in realms" :key="realm.id" v-bind:value="realm">{{ realm.name }}</option>
      </select>
    </div>

    <!-- ADMIN PANEL -->
    <div v-if="IsAdmin || IsModerator">
      <div class="form-group">
        <button class="btn btn-dark btn-block" type="submit" @click="ToggleAdminTools()">
          <i class="fa fa-lock fa-fw"></i>
          {{ AdminToolsEnabled ? "Hide" : "Show" }} Admin Tools
        </button>
      </div>

      <div class="form-group text-center" v-if="AdminToolsEnabled">
        <b-row>
          <b-col lg="4" sm="6">
            <button class="btn btn-dark btn-block mb-2" type="submit" @click="OpenCreateEditor()">
              <i class="fa fa-plus fa-fw"></i> Add New Change
            </button>
          </b-col>
          <b-col lg="4" sm="6">
            <button
              class="btn btn-dark btn-block mb-2"
              type="submit"
              @click="OpenCreateCategoryEditor()"
            >
              <i class="fa fa-plus fa-fw"></i> Add Category
            </button>
          </b-col>
          <b-col lg="4" sm="6">
            <button
              class="btn btn-dark btn-block mb-2"
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
          v-bind:style="{ color: GetCategoryColorCode(data.value) }"
        >{{ data.value.title }}</span>
        <span slot="content" slot-scope="data" v-html="data.value"></span>
        <template slot="Action" slot-scope="data">
          <button class="profile-update-button" type="submit" @click="OpenEditor(data.item)">
            <i class="fa fa-edit fa-fw" title="Open Editor"></i>
          </button>
          <button class="profile-update-button" type="submit" @click="Delete(data.item)">
            <i class="fa fa-close fa-fw" title="Delete Change"></i>
          </button>
        </template>
        <span slot="authorName" slot-scope="data">
          <router-link :to="'/profile/' + data.value">{{data.value}}</router-link>
        </span>
      </b-table>

      <!-- UPDATE MODAL -->
      <b-modal
        id="update-change-modal"
        centered
        v-if="SelectedChange"
        v-model="ShowEditor"
        :title="'Edit Change: ' + SelectedChange.id"
        ok-title="Save Changes"
        header-bg-variant="info"
        @ok="Update"
      >
        <div class="form-group">
          <label>Category</label>
          <select name="category-selection" class="form-control" v-model="SelectedChange.category">
            <option
              v-for="category in Categories"
              :key="category.id"
              v-bind:value="category"
            >{{ category.title }}</option>
          </select>
        </div>

        <div class="form-group">
          <label>Author</label>
          <select
            id="changelog-author"
            class="form-group form-control"
            name="changelog author"
            v-model="SelectedChange.author"
            v-validate="'required|select'"
            :class="{'error': errors.has('changelog author') }"
          >
            <option
              v-for="(admin, index) in GetAdminsAndModerators"
              :key="index"
              :value="admin.id"
            >{{ admin.userName }}</option>
          </select>
          <b-tooltip
            placement="bottom"
            target="changelog-author"
          >{{ errors.first('changelog author') }}</b-tooltip>
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
            v-bind:value="category"
          >{{ category.title }}</option>
        </select>
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
        <label>Author</label>
        <select
          id="changelog-author"
          class="form-group form-control"
          name="changelog author"
          v-model="SelectedChange.author"
          v-validate="'required|select'"
          :class="{'error': errors.has('changelog author') }"
        >
          <option disabled>Select Author</option>
          <option
            v-for="(admin, index) in GetAdminsAndModerators"
            :key="index"
            :value="admin.id"
          >{{ admin.userName }}</option>
        </select>
        <b-tooltip
          placement="bottom"
          target="changelog-author"
        >{{ errors.first('changelog author') }}</b-tooltip>
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
          >{{ category.title }}</option>
        </select>
      </div>
    </b-modal>
  </div>
</template>

<script>
import UserHelper from "@/helpers/UserHelper";
import moment from "moment";

const CHANGELOG_API = process.env.API.CHANGELOG;

export default {
  name: "Changelog",
  props: ["realms"],
  data() {
    return {
      /* CONTAINERS */
      Categories: [],
      Changes: [],

      /* TABLE CONFIG */
      CurrentPage: 1,
      PerPage: 10,

      /* SELECTION */
      SelectedRealm: "Choose Realm",
      ShowEditor: false,
      SelectedChange: null,

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
    GetAdmins() {
      return this.$store.getters["admin/GetAdmins"];
    },
    GetModerators() {
      return this.$store.getters["admin/GetModerators"];
    },
    GetAdminsAndModerators() {
      return this.GetAdmins.concat(this.GetModerators);
    },
    IsAdmin() {
      return UserHelper.IsAdmin();
    },
    IsModerator() {
      return UserHelper.IsModerator();
    },
    GetRealmsForCreate() {
      const realms = [...this.realms];
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
      (this.IsAdmin || this.IsModerator) && this.AdminToolsEnabled
        ? (data = [
            { key: "category", sortable: true, thClass: "th-category" },
            { key: "content", sortable: true, thClass: "th-content" },
            { key: "date", sortable: true, thClass: "th-date" },
            {
              key: "authorName",
              label: "Author",
              sortable: true,
              thClass: "th-author"
            },
            "Action"
          ])
        : (data = [
            { key: "category", sortable: true, thClass: "th-category" },
            { key: "content", sortable: true, thClass: "th-content" },
            { key: "date", sortable: true, thClass: "th-date" },
            {
              key: "authorName",
              label: "Author",
              sortable: true,
              thClass: "th-author"
            }
          ]);

      return data;
    }
  },
  methods: {
    async GetCategories() {
      const result = await this.$http.get(`${CHANGELOG_API}/GetAllCategories`);
      this.Categories = result.data;
    },
    async GetChanges() {
      const result = await this.$http.get(`${CHANGELOG_API}/GetAllChanges`);
      this.Changes = result.data;

      if (this.Changes.length > 0) {
        // Fix Data
        for (let change of this.Changes) {
          change.date = this.GetDate(change.date);
          change.category = this.GetCategoryById(change.categoryId);
        }
      }
    },
    GetCategoryById(id) {
      return this.Categories.find(x => x.id == id);
    },
    GetCategoryNamebyId(id) {
      return this.Categories.find(x => x.id == id).title;
    },
    GetCategoryColorById(id) {
      return this.Categories.find(x => x.id == id).color;
    },
    GetDate(date) {
      return moment(date).format("MM-D-YYYY");
    },
    GetCategoryColorCode(category) {
      return "#" + category.color;
    },
    ToggleAdminTools() {
      this.AdminToolsEnabled = !this.AdminToolsEnabled;
    },
    OpenEditor(change) {
      this.SelectedChange = Object.assign({}, change);
      this.ShowEditor = true;
    },
    OpenCreateEditor() {
      this.SelectedChange = {
        id: 0,
        author: "Select Author",
        category: this.Categories[0],
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
    Update(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          this.$http
            .post(`${CHANGELOG_API}/UpdateChangelog`, {
              Id: this.SelectedChange.id,
              Author: this.SelectedChange.author,
              Content: this.SelectedChange.content,
              Category: this.SelectedChange.category.id
            })
            .then(() => {
              // Update real object
              const CHANGE_TO_BE_CHANGED = this.Changes.find(
                x => x.id == this.SelectedChange.id
              );

              const author = this.GetAdminsAndModerators.find(
                x => x.id == this.SelectedChange.author
              );

              this.SelectedChange.authorName = author.userName;

              Object.assign(CHANGE_TO_BE_CHANGED, this.SelectedChange);

              this.$toasted.success(
                `Changelog id: ${this.SelectedChange.id} has been updated successfully`
              );
            })
            .finally(() => {
              this.$bvModal.hide("update-change-modal");
              this.SelectedChange = null;
            });
        }
      });
    },
    AddChange(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          this.$http
            .post(`${CHANGELOG_API}/AddNewChangelog`, {
              Author: this.SelectedChange.author,
              Content: this.SelectedChange.content,
              Realm: this.SelectedChange.realm,
              Category: this.SelectedChange.category.id
            })
            .then(result => {
              if (result.data.newId > 0) {
                // Add new change to list
                const author = this.GetAdminsAndModerators.find(
                  x => x.id == this.SelectedChange.author
                );

                this.SelectedChange.authorName = author.userName;
                this.SelectedChange.id = result.data.newId;
                this.Changes.unshift(this.SelectedChange);

                this.$toasted.success(`Changelog has been added successfully`);
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
      const check = await this.$bvModal.msgBoxConfirm(
        `Continue deleting change id: '${change.id}?'`,
        {
          centered: true,
          okTitle: "Yes"
        }
      );

      if (!check) return;

      const result = await this.$http.post(`${CHANGELOG_API}/DeleteChangelog`, {
        Id: change.id
      });

      const index = this.Changes.findIndex(x => x.id == change.id);
      this.Changes.splice(index, 1);

      this.$toasted.success(
        `changelog id: ${change.id} has been deleted successfully`
      );
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
            .post(`${CHANGELOG_API}/AddNewCategory`, {
              Title: newTitle,
              Color: newColor
            })
            .then(result => {
              if (result.data.newId > 0) {
                // Add new category to list
                this.Categories.push({
                  id: result.data.newId,
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
      const check = await this.$bvModal.msgBoxConfirm(
        `Continue deleting category: '${this.DeleteCategoryObject.title}'?`,
        {
          centered: true,
          okTitle: "Yes"
        }
      );

      if (!check) return;

      const result = await this.$http.post(
        `${CHANGELOG_API}/DeleteChangelogCategory`,
        {
          Id: this.DeleteCategoryObject.id
        }
      );

      const index = this.Categories.findIndex(
        x => x.id == this.DeleteCategoryObject.id
      );
      this.Categories.splice(index, 1);

      this.$toasted.success(
        `'${this.DeleteCategoryObject.title}' has been deleted successfully`
      );
    },
    SelectedRealmChange() {
      this.$router.replace({ query: { realm: this.SelectedRealm.id } });
    }
  },
  created() {
    this.GetCategories().then(() => {
      this.GetChanges();
    });

    this.$validator.extend("select", {
      getMessage: () => "Please select an Author",
      validate: () => {
        const result = this.GetAdminsAndModerators.find(
          x => x.id == this.SelectedChange.author
        );
        return result != undefined;
      }
    });

    this.$validator.extend("color", {
      getMessage: () => "Please enter a valid color code.",
      validate: () => {
        return /^#[0-9a-f]{3}([0-9a-f]{3})?$/i.test(
          "#" + this.NewCategory.Color
        );
      }
    });

    const realmId = this.$route.query.realm;
    if (realmId > 0) {
      this.SelectedRealm = this.realms.find(x => x.id == realmId);
    }
  }
};
</script>

<style>
.th-category {
  width: 20%;
}

.th-author {
  width: 15%;
}

.th-content {
  width: 50%;
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
