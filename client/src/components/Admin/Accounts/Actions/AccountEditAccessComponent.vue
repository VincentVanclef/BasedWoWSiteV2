<template>
  <b-modal
    centered
    size="md"
    v-if="showEditor"
    v-model="showEditor"
    :title="'Game Access for ' + account.username"
    ok-title="Save Changes"
    header-bg-variant="info"
    @ok="UpdateAccountAccess"
  >
    <b-container>
      <b-row>
        <b-col v-for="realm in filteredRealms" :key="realm.id" sm="12" md="6" lg="6">
          {{realm.name}}
          <ul>
            <li v-for="role in realm.roles" :key="role.id">
              <b-radio
                v-model="realm.activeRole"
                :value="role.id"
                @change="ChangeRole"
              >{{role.title}}</b-radio>
            </li>
          </ul>
        </b-col>
      </b-row>
    </b-container>
  </b-modal>
</template>

<script>
export default {
  props: ["roles", "realms"],
  data() {
    return {
      account: null,
      showEditor: false,
      filteredRealms: []
    };
  },
  computed: {
    SortedRoles() {
      const temp = [...this.roles];
      return temp.sort((a, b) => {
        return a.id < b.id ? -1 : 1;
      });
    },
    FilteredRoles() {
      const temp = [...this.roles];
      const sorted = temp.sort((a, b) => {
        return a.id < b.id ? -1 : 1;
      });
    }
  },
  methods: {
    show(account) {
      this.account = account;
      this.showEditor = true;
      this.SyncAccess(account);
    },
    SyncAccess(account) {
      for (const realm of this.filteredRealms) {
        const access = account.accountAccess;
        const realmAccess = access.find(x => x.realmId == realm.id);
        realm.activeRole = realmAccess ? realmAccess.gmlevel : 0;
      }
    },
    ChangeRole(data) {},
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
                const AccessData = this.filteredRealms.map(x => ({
                  RealmType: x.id,
                  AccessId: x.activeRole
                }));
                this.$store
                  .dispatch("user/account/UpdateAccountAccess", {
                    Account: this.account,
                    AccessData
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
      name: x.name,
      activeRole: 0,
      roles: [...this.roles]
    }));
  }
};
</script>
