<template>
  <div class="teleport-service text-center">
    <h3 class="mb-5">Teleport Service</h3>
    <h5>
      Pick a location where you wish to teleport your character to.
      <br />Do note that your character must be offline for this to work.
      <br />
      <br />After logging in again your character will be placed alive at the selected location.
    </h5>

    <div class="form-group mt-5">
      <select class="teleport-selection form-control mx-0" v-model="SelectedLocation">
        <option disabled>Select Location</option>
        <option
          v-for="location in SelectedUnstuckLocations"
          :key="location.id"
          v-bind:value="location"
        >{{ location.name }}</option>
      </select>
    </div>

    <div class="form-group">
      <button
        class="btn btn-dark btn-lg mt-3 mb-5"
        type="submit"
        :disabled="!SelectedCharacter || !GetSelectedLocation"
        @click="TeleportCharacter()"
      >
        <i class="fa fa-location-arrow fa-fw"></i> Teleport Character
      </button>
    </div>
  </div>
</template>

<script>
const API_CHAR = process.env.API.CHARACTERS;

export default {
  name: "character-service-teleport",
  props: ["SelectedRealm", "SelectedCharacter", "Realms"],
  data() {
    return {
      SelectedLocation: "Select Location"
    };
  },
  computed: {
    UnstuckLocations() {
      return this.$store.getters.GetUnstuckLocations;
    },
    SelectedUnstuckLocations() {
      const data = this.UnstuckLocations.find(
        x => x.realmid == this.SelectedRealm.id
      );
      return data ? data.data : [];
    },
    GetSelectedLocation() {
      return typeof this.SelectedLocation == "object"
        ? this.SelectedLocation
        : null;
    }
  },
  methods: {
    async TeleportCharacter() {
      try {
        const result = await this.$http.post(`${API_CHAR}/character/teleport`, {
          database: this.SelectedRealm.chardb,
          guid: this.SelectedCharacter.guid,
          location: this.SelectedLocation.id
        });
      } catch (e) {
        if (e.response) {
          this.$toasted.error(e.response.data.error);
        } else {
          this.$toasted.error(e.message);
        }
        return;
      }

      this.$toasted.success(`Succesfully teleported ${this.SelectedCharacter.name} to ${this.SelectedLocation.name}.`);
    }
  },
  created() {
    if (this.UnstuckLocations.length == 0) {
      for (const realm of this.Realms) {
        this.$store.dispatch("GetUnstuckLocations", realm).then(result => {
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
.teleport-service {
  background-image: url("~@/assets/images/map.png");
  background-size: 100%;
}

.teleport-selection {
  display: inline-block;
  width: 40%;
  text-align-last: center;
  font-weight: bold;
}
</style>