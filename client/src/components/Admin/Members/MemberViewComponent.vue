<template>
  <b-card-group class="card-member">
    <b-col v-for="(member, index) in OrderMembers" :key="index" :sm="sm" :md="md" :lg="lg">
      <b-card no-body border-variant="dark" class="mt-2 mb-2">
        <b-card-header header-bg-variant="info" header-text-variant="white" class="text-capitalize">
          <text-highlight :queries="query">{{member.userName}}</text-highlight>
        </b-card-header>

        <b-card-body>
          <b-list-group>
            <b-list-group-item>
              Firstname:
              <span class="float-right">
                <text-highlight :queries="query">{{member.firstname}}</text-highlight>
              </span>
            </b-list-group-item>
            <b-list-group-item>
              Lastname:
              <span class="float-right">
                <text-highlight :queries="query">{{member.lastname}}</text-highlight>
              </span>
            </b-list-group-item>
            <b-list-group-item>
              Email:
              <span class="float-right">
                <text-highlight :queries="query">{{member.email}}</text-highlight>
              </span>
            </b-list-group-item>
            <b-list-group-item>
              Joindate:
              <span class="float-right">{{GetDate(member.joinDate)}}</span>
            </b-list-group-item>
            <b-list-group-item>
              Roles:
              <span class="float-right">
                <span v-for="role in member.userRoles" :key="role.roleId">
                  <font :color="GetRoleColor(role.role.name)">[{{role.role.name}}]</font>
                </span>
              </span>
            </b-list-group-item>
          </b-list-group>
        </b-card-body>

        <b-card-footer footer-variant="info" footer-bg-variant="info" footer-text-variant="white">
          <b-row>
            <b-col sm="12" md="6" lg="4" class="mt-2">
              <b-button
                variant="dark"
                block
                :to="'/admin/accounts/search?query=' + member.accountId"
              >View Account</b-button>
            </b-col>
            <b-col sm="12" md="6" lg="4" class="mt-2">
              <b-button variant="dark" block @click="OpenRoleEditor(member)">Manage Roles</b-button>
            </b-col>
            <b-col sm="12" md="6" lg="4" class="mt-2">
              <b-button variant="dark" block>Manage Profile</b-button>
            </b-col>
          </b-row>
        </b-card-footer>
      </b-card>
    </b-col>
    <edit-roles-component :roles="roles" ref="editRolesComponent"></edit-roles-component>
  </b-card-group>
</template>

<script>
import moment from "moment";
import UserHelper from "@/helpers/UserHelper";
import EditRolesComponent from "@/components/Admin/Members/EditRolesComponent";

export default {
  name: "MemberViewComponent",
  props: ["user", "members", "roles", "sm", "md", "lg", "query"],
  data() {
    return {};
  },
  components: {
    "edit-roles-component": EditRolesComponent
  },
  computed: {
    IsSuperAdmin() {
      return UserHelper.IsSuperAdmin();
    },
    OrderMembers() {
      const temp = [...this.members];
      return temp.sort((a, b) =>
        a.userRoles.length < b.userRoles.length ? 1 : -1
      );
    }
  },
  methods: {
    OpenRoleEditor(member) {
      if (!this.IsSuperAdmin) {
        this.$toasted.error("You are not authorized to edit member roles.");
        return;
      }

      this.$refs.editRolesComponent.show(member);
    },
    GetRoleColor(role) {
      return UserHelper.GetRoleColor(role);
    },
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
    }
  },
  created() {}
};
</script>