<template>
  <b-modal
    centered
    size="sm"
    v-if="showEditor"
    v-model="showEditor"
    :title="'Edit Roles for ' + member.userName"
    ok-title="Save Changes"
    header-bg-variant="info"
    @ok="EditComment"
  >
    <b-form-checkbox
      class="font-weight-bold"
      v-for="role in roles"
      v-model="selectedRoles"
      :key="role.id"
      :value="role.name"
      switch
    >{{ role.name }}</b-form-checkbox>
  </b-modal>
</template>

<script>
export default {
  props: ["roles"],
  data() {
    return {
      member: null,
      showEditor: false,
      selectedRoles: []
    };
  },
  computed: {
    MemberRoles() {
      return this.member.userRoles.map(x => ({
        id: x.roleId,
        name: x.role.name
      }));
    },
    MemberRoleIds() {
      return this.member.userRoles.map(x => x.roleId);
    },
    FilteredRoles() {
      return this.roles.filter(val => !this.MemberRoleIds.includes(val.id));
    }
  },
  methods: {
    show(member) {
      this.member = Object.assign({}, member);
      this.selectedRoles = [...this.MemberRoles.map(x => x.name)];
      this.showEditor = true;
    },
    EditComment(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          this.$bvModal
            .msgBoxConfirm(
              `Are you sure you wish to update ${this.member.userName}?`,
              {
                centered: true,
                okTitle: "Yes"
              }
            )
            .then(ok => {
              if (ok) {
                this.$store
                  .dispatch("admin/roles/AddUserToRoles", {
                    userId: this.member.id,
                    roles: this.selectedRoles
                  })
                  .then(() => {
                    this.$toasted.success(
                      `${this.member.userName} has been updated successfully.`
                    );
                    this.showEditor = false;
                  });
              }
            })
            .catch(() => {});
        }
      });
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  },
  beforeDestroy() {
    console.log("destroy");
  }
};
</script>

<style scoped>
</style>