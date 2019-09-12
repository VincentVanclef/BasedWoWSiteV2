<template>
  <b-modal
    centered
    size="xl"
    v-if="ShowEditor"
    v-model="ShowEditor"
    :title="'Viewing characters for ' + Account.username"
    header-bg-variant="info"
  >
    <b-container>
      <b-row>
        <b-form-group>
          <label>Select Realm</label>
          <b-select
            name="realm-selection"
            class="form-control"
            v-model="SelectedRealm"
            @change="SelectedRealmChange()"
          >
            <option v-for="realm in realms" :key="realm.id" :value="realm">
              {{realm.name}}
              ({{GetCharactersForRealm(realm.id)}})
            </option>
          </b-select>
        </b-form-group>
      </b-row>
    </b-container>
    <div v-if="Loading" class="text-center">
      <b-spinner style="width: 3rem; height: 3rem;" variant="primary" label="Spinning"></b-spinner>
    </div>
    <b-row>
      <b-card-group v-if="!Loading" class="card-member">
        <b-col v-for="character in GetSortedCharacters" :key="character.guid" sm="12" md="6" lg="6">
          <character-component :character="character" :realm="SelectedRealm"></character-component>
        </b-col>
      </b-card-group>
    </b-row>
  </b-modal>
</template>

<script>
import CharacterComponent from "./Views/CharacterComponent";

export default {
  name: "CharacterViewComponent",
  props: ["realms"],
  data() {
    return {
      Account: null,
      ShowEditor: false,
      Loading: false,
      SelectedRealm: this.realms[0],
      SelectedCharacter: null,
      Characters: []
    };
  },
  components: {
    "character-component": CharacterComponent
  },
  computed: {
    SelectedCharacters() {
      const data = this.Characters.find(
        x => x.realmid == this.SelectedRealm.id
      );
      return data ? data.data : [];
    },
    GetSortedCharacters() {
      const characters = this.SelectedCharacters;
      return characters.sort((a, b) => (a.online < b.online ? 1 : -1));
    },
    GetSelectedCharacter() {
      return typeof this.SelectedCharacter == "object"
        ? this.SelectedCharacter
        : null;
    }
  },
  methods: {
    show(Account) {
      this.reset();
      this.Account = Account;
      this.ShowEditor = true;
      this.FetchCharacters();
      this.ApplyRealmFromQuery();
    },
    reset() {
      this.Account = null;
      this.Loading = false;
      this.Characters = [];
    },
    GetCharactersForRealm(realm) {
      const data = this.Characters.find(x => x.realmid == realm);
      return data ? data.data.length : 0;
    },
    SelectedRealmChange() {
      this.$router.replace({
        query: Object.assign({}, this.$route.query, {
          realm: this.SelectedRealm.id
        })
      });
    },
    ApplyRealmFromQuery() {
      const realm = this.$route.query.realm;
      if (realm) {
        const selectedRealm = this.realms.find(x => x.id == realm);
        if (selectedRealm) {
          this.SelectedRealm = selectedRealm;
        }
      }
    },
    async FetchCharacters() {
      this.Loading = true;
      for (const realm of this.realms) {
        const data = await this.$store.dispatch(
          "user/characters/GetAllCharactersByAccountId",
          {
            AccountId: this.Account.id,
            RealmType: realm.id
          }
        );
        this.Characters.push(data);
      }

      this.Loading = false;
    }
  }
};
</script>