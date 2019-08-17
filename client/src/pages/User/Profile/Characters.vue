<template>
  <b-container>
    <div class="form-group" v-if="Realms.length > 0">
      <label>Select Realm</label>
      <select
        name="realm-selection"
        class="form-control"
        v-model="SelectedRealm"
        @change="SelectedRealmchange()"
      >
        <option disabled>Choose Realm</option>
        <option v-for="realm in Realms" :key="realm.id" v-bind:value="realm">{{ realm.name }}</option>
      </select>
    </div>

    <div class="form-group">
      <b-row>
        <b-col>
          <label>Select Character</label>
          <select
            name="realm-selection"
            class="form-control"
            v-model="SelectedCharacter"
            :disabled="SelectedCharacters.length == 0"
          >
            <option disabled>Select Character</option>
            <option
              v-for="character in SelectedCharacters"
              :key="character.guid"
              v-bind:value="character"
            >{{ character.name }}</option>
          </select>
        </b-col>
        <b-col>
          <label>Select Service</label>
          <select
            name="service-selection"
            class="form-control"
            v-model="SelectedService"
            :disabled="!GetSelectedCharacter"
          >
            <option disabled>Select Service</option>
            <option
              v-for="service in Services"
              :key="service.id"
              v-bind:value="service"
            >{{ service.name }}</option>
          </select>
        </b-col>
      </b-row>
    </div>

    <hr />

    <div class="services" v-if="typeof SelectedService == 'object'">
      <!-- TELEPORT SERVICE -->
      <teleport-service
        v-if="SelectedService.id == 1"
        :SelectedRealm="SelectedRealm"
        :SelectedCharacter="GetSelectedCharacter"
        :Realms="Realms"
        :User="User"
      ></teleport-service>
    </div>
  </b-container>
</template>

<script>
import TeleportService from "@/components/CharacterServices/Teleport.vue";
import config from "@/assets/config/config";

export default {
  name: "character-tools",
  props: ["User"],
  data() {
    return {
      SelectedRealm: "Choose Realm",
      SelectedCharacter: "Select Character",

      Services: [
        {
          id: 1,
          name: "Teleport"
        }
      ],
      SelectedService: "Select Service"
    };
  },
  components: {
    "teleport-service": TeleportService
  },
  computed: {
    Realms() {
      return config.REALMS;
    },
    Characters() {
      return this.$store.getters.GetCharacters;
    },
    SelectedCharacters() {
      const data = this.Characters.find(
        x => x.realmid == this.SelectedRealm.id
      );
      return data ? data.data : [];
    },
    GetSelectedCharacter() {
      return typeof this.SelectedCharacter == "object"
        ? this.SelectedCharacter
        : null;
    }
  },
  methods: {
    SelectedRealmchange() {
      this.SelectedService = "Select Service";
      this.SelectedCharacter = "Select Character";
    }
  },
  created() {
    if (this.Characters.length == 0) {
      for (const realm of this.Realms) {
        this.$store
          .dispatch("GetCharacters", {
            RealmType: realm.id,
            AccountId: this.User.accountId
          })
          .then(result => {
            if (result != "success") {
              this.$toasted.error(result);
            }
          });
      }
    }
  }
};
</script>

<style scoped>
select {
  font-weight: bold;
}
</style>
