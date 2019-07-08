<template>
  <b-container>
    <div class="form-group" v-if="Realms.length > 0">
      <select name="realm-selection" class="form-control" v-model="SelectedRealm">
        <option disabled>Choose Realm</option>
        <option v-for="realm in Realms" :key="realm.id" v-bind:value="realm">{{ realm.name }}</option>
      </select>
    </div>

    <div v-if="isAdmin" class="form-group">
      <button class="btn btn-primary" type="submit" @click="ToggleAdminTools()">
        <i class="fa fa-lock fa-fw"></i>
        {{ AdminToolsEnabled ? "Disable" : "Enable" }} Admin Tools
      </button>
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
          <tr v-for="(change, index) in SelectedRealm.changes" :key="index">
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

      <!-- MODAL -->
      <b-modal
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
  </b-container>
</template>

<script>
import UserHelper from "@/helpers/UserHelper";
import config from "@/assets/config/config";
import moment from "moment";

const CHANGELOG_API = process.env.API.CHANGELOG;

class CHANGELOG_REALM {
  constructor(id, name, changes) {
    this.id = id;
    this.name = name;
    this.changes = changes.sort((a, b) => {
      if (a.date < b.date) return 1;
      if (a.date > b.date) return -1;
      return 0;
    });
  }
}

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
    }
  },
  methods: {
    async GetCategories() {
      const result = await this.$http.get(`${CHANGELOG_API}/all/categories`);
      this.Categories = result.data;
    },
    async GetChanges() {
      const result = await this.$http.get(`${CHANGELOG_API}/all/changes`);
      this.Changes = result.data;

      if (this.Changes.length > 0) {
        // Fix Dates
        for (let change of this.Changes) {
          change.date = this.GetDate(change.date);
        }
        this.PopulateChanges();
      }
    },
    PopulateChanges() {
      for (const realm of config.REALMS) {
        const changes = this.Changes.filter(x => x.realm == realm.id);
        const changelog_realm = new CHANGELOG_REALM(
          realm.id,
          realm.name,
          changes
        );
        this.Realms.push(changelog_realm);
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
    SelectChangesForView() {},
    async Update(change) {
      const result = await this.$http.post(`${CHANGELOG_API}/update/change`, {
        id: change.id,
        category: change.category,
        title: change.title,
        content: change.content
      });

      if (result.data.status == "success") {
        // Update real object
        const CHANGE_TO_BE_CHANGED = this.SelectedRealm.changes.find(
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
        const index = this.SelectedRealm.changes.findIndex(
          x => x.id == change.id
        );
        this.SelectedRealm.changes.splice(index, 1);

        this.$toasted.success(
          `'${change.title}' has been deleted successfully`
        );
      } else {
        this.$toasted.error(`Unable to delete '${change.title}'`);
      }
    },
    /* SORTING */
    SortByCategory() {
      this.SelectedRealm.changes.sort((a, b) => {
        return this.CategoryASC ? b.id - a.id : a.id - b.id;
      });

      this.CategoryASC = !this.CategoryASC;
    },
    SortByTitle() {
      this.SelectedRealm.changes.sort((a, b) => {
        return this.TitleASC
          ? a.title.localeCompare(b.title)
          : b.title.localeCompare(a.title);
      });

      this.TitleASC = !this.TitleASC;
    },
    SortByContent() {
      this.SelectedRealm.changes.sort((a, b) => {
        return this.ContentASC
          ? a.content.localeCompare(b.content)
          : b.content.localeCompare(a.content);
      });

      this.ContentASC = !this.ContentASC;
    },
    SortByDate() {
      this.SelectedRealm.changes.sort((a, b) => {
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
