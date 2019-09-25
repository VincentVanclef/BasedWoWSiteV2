<template>
  <b-modal
    centered
    size="xl"
    v-if="ShowEditor"
    v-model="ShowEditor"
    :title="'Viewing characters for ' + Account.username"
    header-bg-variant="info"
    @hide="CloseModal"
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
    <guild-component />
    <character-armory />
    <character-inventory />
  </b-modal>
</template>

<script>
import GuildComponent from "@/components/Admin/Guilds/Views/GuildComponent";
import CharacterArmoryComponent from "@/components/Armory/Characters/CharacterArmoryComponent";
import CharacterInventoryComponent from "@/components/Admin/Characters/Views/CharacterInventoryComponent";

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
    "guild-component": GuildComponent,
    "character-armory": CharacterArmoryComponent,
    "character-inventory": CharacterInventoryComponent
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
      return characters.sort((a, b) => {
        if (a.online > b.online) return -1;
        if (a.online < b.online) return 1;

        if (a.guid < b.guid) return -1;
        if (a.guid > b.guid) return 1;
      });
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
    CloseModal() {
      const QUERY = this.$route.query;

      this.$router.replace({
        query: Object.assign(
          {},
          {
            query: QUERY.query ? QUERY.query : undefined
          }
        )
      });
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
      } else {
        this.SelectedRealmChange();
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

      this.CheckGuildQuery();
      this.CheckArmoryQuery();
      this.CheckInventoryQuery();
    },
    CheckGuildQuery() {
      const query = this.$route.query;
      if (!query) return;

      const guildName = query.guild;
      if (!guildName) return;

      const character = this.SelectedCharacters.find(
        x => x.guild && x.guild.name == guildName
      );
      if (!character) return;

      const guild = character.guild;
      if (!guild) return;

      this.$store
        .dispatch("user/guild/ShowGuildComponent", {
          Realm: this.SelectedRealm,
          Guild: guild
        })
        .then(() => this.$bvModal.show("guild-modal"));
    },
    CheckArmoryQuery() {
      const query = this.$route.query;
      if (!query) return;

      const showArmory = query.showArmory;
      if (!showArmory) return;

      const character = this.SelectedCharacters.find(
        x => x.name === showArmory
      );
      if (!character) return;

      this.$store
        .dispatch("armory/ShowArmoryComponent", {
          Realm: this.SelectedRealm,
          Character: character
        })
        .then(() => this.$bvModal.show("armory-modal"));
    },
    CheckInventoryQuery() {
      const query = this.$route.query;
      if (!query) return;

      const showInventory = query.showInventory;
      if (!showInventory) return;

      const character = this.SelectedCharacters.find(
        x => x.name === showInventory
      );
      if (!character) return;

      this.$store
        .dispatch("armory/ShowInventoryComponent", {
          Realm: this.SelectedRealm,
          Character: character
        })
        .then(() => this.$bvModal.show("inventory-modal"));
    }
  }
};
</script>