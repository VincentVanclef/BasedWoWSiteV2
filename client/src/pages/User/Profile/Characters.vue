<template>
  <b-container>
    <div class="form-group" v-if="realms.length > 0">
      <label>Select Realm</label>
      <select
        name="realm-selection"
        class="form-control"
        v-model="SelectedRealm"
        @change="SelectedRealmchange()"
      >
        <option disabled>Choose Realm</option>
        <option v-for="realm in realms" :key="realm.id" v-bind:value="realm">{{ realm.name }}</option>
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
        :realms="realms"
        :user="user"
      ></teleport-service>
    </div>
  </b-container>
</template>

<script>
import TeleportService from "@/components/CharacterServices/Teleport.vue";

export default {
  name: "character-tools",
  props: ["user", "realms"],
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
    Characters() {
      return this.$store.getters["user/characters/GetCharacters"];
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
      this.$router.replace({ query: { realm: this.SelectedRealm.id } });
    }
  },
  created() {
    if (this.Characters.length == 0) {
      for (const realm of this.realms) {
        this.$store.dispatch("user/characters/GetAllCharactersByUser", {
          RealmType: realm.id
        });
      }
    }

    const realmId = this.$route.query.realm;
    if (realmId > 0) {
      this.SelectedRealm = this.realms.find(x => x.id == realmId);
    }
  }
};
</script>

<style scoped>
select {
  font-weight: bold;
}
</style>
