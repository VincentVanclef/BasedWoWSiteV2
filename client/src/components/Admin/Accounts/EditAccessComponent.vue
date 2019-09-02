<template>
  <b-modal
    centered
    size="sm"
    v-if="showEditor"
    v-model="showEditor"
    :title="account.username"
    ok-title="Save Changes"
    header-bg-variant="info"
    @ok="UpdateAccountAccess"
  >
    <b-form-group>
      <label>Select Realm</label>
      <b-select name="realm-selection" class="form-control" v-model="selectedRealm">
        <option v-for="realm in filteredRealms" :key="realm.id" :value="realm">{{realm.name}}</option>
      </b-select>
    </b-form-group>

    <b-form-group>
      <label>Select Rank</label>
      <ul>
        <li v-for="role in roles" :key="role.id">
          <b-radio v-model="selectedAccess" :value="role">{{role.title}}</b-radio>
        </li>
      </ul>
    </b-form-group>
  </b-modal>
</template>

<script>
export default {
  props: ["roles", "realms"],
  data() {
    return {
      account: null,
      showEditor: false,
      filteredRealms: [],
      selectedRealm: null,
      selectedAccess: null
    };
  },
  computed: {
    SortedRoles() {
      const temp = [...this.roles];
      return temp.sort((a, b) => {
        return a.id < b.id ? -1 : 1;
      });
    }
  },
  methods: {
    show(account) {
      this.account = account;
      this.showEditor = true;
      this.selectedAccess = this.SortedRoles[0];
    },
    UpdateAccountAccess(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          this.$bvModal
            .msgBoxConfirm(
              `Are you sure you wish to update ${this.account.username}?`,
              {
                centered: true,
                okTitle: "Yes"
              }
            )
            .then(ok => {
              if (ok) {
                this.$store
                  .dispatch("user/account/UpdateAccountAccess", {
                    account: this.account,
                    realm: this.selectedRealm,
                    access: this.selectedAccess
                  })
                  .then(user => {
                    this.$toasted.success(
                      `${this.account.username} has been updated successfully.`
                    );
                    this.showEditor = false;
                  });
              }
            })
            .catch(() => {});
        }
      });
    }
  },
  created() {
    this.filteredRealms = this.realms.map(x => ({
      id: x.id,
      name: x.name
    }));

    this.selectedRealm = this.filteredRealms[0];
  }
};
</script>
