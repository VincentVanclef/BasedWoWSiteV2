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
        v-if="!Loading"
      >
        <i class="fa fa-location-arrow fa-fw"></i> Teleport Character
      </button>
      <b-spinner
        v-if="Loading"
        class="mt-3 mb-5"
        style="width: 3rem; height: 3rem;"
        label="Large Spinner"
      ></b-spinner>
    </div>
  </div>
</template>

<script>
import moment from "moment";

const API_CHAR = process.env.API.CHARACTERS;

export default {
  name: "character-service-teleport",
  props: ["SelectedRealm", "SelectedCharacter", "Realms", "User"],
  data() {
    return {
      SelectedLocation: "Select Location",
      Loading: false
    };
  },
  computed: {
    UnstuckLocations() {
      return this.$store.getters.GetUnstuckLocations;
    },
    SelectedUnstuckLocations() {
      const data = this.UnstuckLocations.filter(
        x => x.realmId == this.SelectedRealm.id
      );
      return data ? data : [];
    },
    GetSelectedLocation() {
      return typeof this.SelectedLocation == "object"
        ? this.SelectedLocation
        : null;
    }
  },
  methods: {
    async TeleportCharacter() {
      const then = moment(this.User.UnstuckTimer * 1000);
      const now = moment();
      if (then > now) {
        const timeLeft = moment
          .utc(moment(then).diff(moment(now)))
          .format("HH:mm:ss");
        this.$toasted.error(
          `You must wait ${timeLeft} until you can use the Teleport Service again.`
        );
        return;
      }

      this.Loading = true;
      try {
        const result = await this.$http.post(`${API_CHAR}/TeleportCharacter`, {
          RealmType: this.SelectedRealm.id,
          Guid: this.SelectedCharacter.guid,
          Location: this.SelectedLocation.id
        });
      } catch (e) {
        if (e.response) {
          this.$toasted.error(e.response.data.error);
        } else {
          this.$toasted.error(e.message);
        }
        return;
      } finally {
        this.Loading = false;
      }

      this.$toasted.success(
        `Succesfully teleported ${this.SelectedCharacter.name} to ${this.SelectedLocation.name}.`
      );
      const unsetTime = new moment().add(5, "minutes").unix();
      this.$store.commit("UPDATE_USER", {
        index: "UnstuckTimer",
        value: unsetTime
      });
    }
  },
  created() {
    if (this.UnstuckLocations.length == 0) {
      for (const realm of this.Realms) {
        this.$store
          .dispatch("GetUnstuckLocations", { RealmType: realm.id })
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