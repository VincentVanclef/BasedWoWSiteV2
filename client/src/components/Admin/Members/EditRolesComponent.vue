<template>
  <b-modal
    centered
    size="lg"
    v-if="showEditor"
    v-model="showEditor"
    :title="'Edit Roles for ' + member.userName"
    ok-title="Save Changes"
    header-bg-variant="info"
    @ok="EditComment"
  >
    <b-form>
      <label>Member Roles</label>
      <b-form-select v-model="selectedRoles" multiple>
        <option v-for="role in MemberRoles" :key="role.id" :value="role.id">{{ role.name }}</option>
      </b-form-select>
      <div class="mt-3">
        Selected:
        <strong>{{ selectedRoles }}</strong>
      </div>
    </b-form>
    <b-form>
      <label>Available Roles</label>
      <b-form-select v-model="selectedRoles" multiple>
        <option v-for="role in FilteredRoles" :key="role.id" :value="role.id">{{ role.name }}</option>
      </b-form-select>
      <div class="mt-3">
        Selected:
        <strong>{{ selectedRoles }}</strong>
      </div>
    </b-form>
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
      console.log(member);
      this.showEditor = true;
    },
    EditComment(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          this.$store
            .dispatch("news/EditComment", this.newComment)
            .catch(e => this.toasted.error(this.$root.GetErrorMessage(e)))
            .then(result => {
              this.$toasted.success("Comment successfully edited");
            })
            .finally(() => {
              this.$bvModal.hide("new-comment");
              this.showEditor = false;
            });
        }
      });
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  }
};
</script>

<style scoped>
</style>