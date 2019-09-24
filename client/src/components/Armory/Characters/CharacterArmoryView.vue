<template>
  <b-container>
    <div v-if="Loading" class="text-center">
      <b-spinner style="width: 3rem; height: 3rem;" variant="primary" label="Spinning"></b-spinner>
    </div>
    <div v-if="!Loading && Stats">
      <b-row>
        <b-col>
          <div class="information">
            <div class="information-left">
              <div class="name">
                {{character.name}}
                <span class="guild-name" v-if="character.guild">
                  <router-link :to="'#'">{{character.guild.name}}</router-link>
                </span>
              </div>
              <div class="level-race-class">
                Level
                <span class="font-weight-bold">{{character.level}}</span>
                <font :color="GetRaceColor(character.race)">{{GetRaceName(character.race)}}</font>
                <font :color="GetClassColor(character.class)">{{GetClassName(character.class)}}</font>
                <p>
                  Map:
                  <b>{{GetMapName(character.map)}}</b> Zone:
                  <b>{{GetZoneName(character.zone)}}</b>
                </p>
              </div>
            </div>
            <div class="information-right">
              <div id="armory_bars">
                <div id="armory_health">
                  Health:
                  <b>{{Stats.maxHealth}}</b>
                </div>

                <div id="armory_mana" v-if="Stats.mana">
                  Mana:
                  <b>{{Stats.mana}}</b>
                </div>
                <div id="armory_rage" v-if="Stats.rage && character.class === 1">
                  Rage:
                  <b>{{Stats.rage / 10}}</b>
                </div>
                <div id="armory_focus" v-if="Stats.focus">
                  Focus:
                  <b>{{Stats.focus}}</b>
                </div>
                <div id="armory_energy" v-if="Stats.energy && character.class === 4">
                  Energy:
                  <b>{{Stats.energy}}</b>
                </div>
                <div id="armory_runic" v-if="Stats.runicPower && character.class === 6">
                  Runic Power:
                  <b>{{Stats.runicPower / 10}}</b>
                </div>
              </div>
            </div>
          </div>
        </b-col>
      </b-row>
      <b-row class="full-width text-center ml-0">
        <b-col cols="3" class="armory-left">
          <div v-for="slot in EquipmentSlotsLeft" :key="slot">
            <item
              :eSlot="slot"
              :entry="GetEntryForSlot(slot)"
              :item="GetItemForSlot(slot)"
              :realm="realm.id"
            ></item>
          </div>
        </b-col>
        <b-col cols="6" class="armory-stats">
          <div class="overview">
            <b-card no-body>
              <b-tabs
                v-model="TabIndex"
                fill
                active-nav-item-class="font-weight-bold text-info"
                no-fade
              >
                <b-tab title="Stats" active>
                  <b-list-group>
                    <b-list-group-item>
                      <span class="float-left">Strength:</span>
                      <span class="float-right">{{Stats.strength}}</span>
                    </b-list-group-item>
                    <b-list-group-item>
                      <span class="float-left">Agility:</span>
                      <span class="float-right">{{Stats.agility}}</span>
                    </b-list-group-item>
                    <b-list-group-item>
                      <span class="float-left">Stamina:</span>
                      <span class="float-right">{{Stats.stamina}}</span>
                    </b-list-group-item>
                    <b-list-group-item>
                      <span class="float-left">Intellect:</span>
                      <span class="float-right">{{Stats.intellect}}</span>
                    </b-list-group-item>
                    <b-list-group-item>
                      <span class="float-left">Spirit:</span>
                      <span class="float-right">{{Stats.spirit}}</span>
                    </b-list-group-item>
                    <b-list-group-item>
                      <span class="float-left">Armor:</span>
                      <span class="float-right">{{Stats.armor}}</span>
                    </b-list-group-item>
                  </b-list-group>
                </b-tab>
                <b-tab title="Melee">
                  <b-card-text>
                    <b-list-group>
                      <b-list-group-item>
                        <span class="float-left">Damage:</span>
                        <span class="float-right">1000</span>
                      </b-list-group-item>
                      <b-list-group-item>
                        <span class="float-left">Speed:</span>
                        <span class="float-right">1000</span>
                      </b-list-group-item>
                      <b-list-group-item>
                        <span class="float-left">Attack Power:</span>
                        <span class="float-right">{{Stats.attackPower}}</span>
                      </b-list-group-item>
                      <b-list-group-item>
                        <span class="float-left">Hit Rating:</span>
                        <span class="float-right">{{Stats.strength}}</span>
                      </b-list-group-item>
                      <b-list-group-item>
                        <span class="float-left">Crit Chance:</span>
                        <span class="float-right">{{(Stats.critPct).toFixed(2)}}%</span>
                      </b-list-group-item>
                      <b-list-group-item>
                        <span class="float-left">Expertise:</span>
                        <span class="float-right">{{Stats.strength}}</span>
                      </b-list-group-item>
                    </b-list-group>
                  </b-card-text>
                </b-tab>
                <b-tab title="Ranged">
                  <b-card-text>
                    <b-card-text>
                      <b-list-group>
                        <b-list-group-item>
                          <span class="float-left">Damage:</span>
                          <span class="float-right">1000</span>
                        </b-list-group-item>
                        <b-list-group-item>
                          <span class="float-left">Speed:</span>
                          <span class="float-right">1000</span>
                        </b-list-group-item>
                        <b-list-group-item>
                          <span class="float-left">Ranged Attack Power:</span>
                          <span class="float-right">{{Stats.rangedAttackPower}}</span>
                        </b-list-group-item>
                        <b-list-group-item>
                          <span class="float-left">Hit Rating:</span>
                          <span class="float-right">{{Stats.strength}}</span>
                        </b-list-group-item>
                        <b-list-group-item>
                          <span class="float-left">Crit Chance:</span>
                          <span class="float-right">{{(Stats.rangedCritPct).toFixed(2)}}%</span>
                        </b-list-group-item>
                      </b-list-group>
                    </b-card-text>
                  </b-card-text>
                </b-tab>
                <b-tab title="Spell">
                  <b-card-text>
                    <b-card-text>
                      <b-list-group>
                        <b-list-group-item>
                          <span class="float-left">Bonus Damage:</span>
                          <span class="float-right">{{Stats.spellPower}}</span>
                        </b-list-group-item>
                        <b-list-group-item>
                          <span class="float-left">Bonus Healing:</span>
                          <span class="float-right">1000</span>
                        </b-list-group-item>
                        <b-list-group-item>
                          <span class="float-left">Hit Rating:</span>
                          <span class="float-right">{{Stats.strength}}</span>
                        </b-list-group-item>
                        <b-list-group-item>
                          <span class="float-left">Crit Chance:</span>
                          <span class="float-right">{{(Stats.spellCritPct).toFixed(2)}}</span>
                        </b-list-group-item>
                        <b-list-group-item>
                          <span class="float-left">Haste Rating:</span>
                          <span class="float-right">{{Stats.strength}}</span>
                        </b-list-group-item>
                        <b-list-group-item>
                          <span class="float-left">Mana Rgen:</span>
                          <span class="float-right">1000</span>
                        </b-list-group-item>
                      </b-list-group>
                    </b-card-text>
                  </b-card-text>
                </b-tab>
                <b-tab title="Defense">
                  <b-card-text>
                    <b-card-text>
                      <b-list-group>
                        <b-list-group-item>
                          <span class="float-left">Armor:</span>
                          <span class="float-right">{{Stats.armor}}</span>
                        </b-list-group-item>
                        <b-list-group-item>
                          <span class="float-left">Defense:</span>
                          <span class="float-right">{{Stats.defense}}</span>
                        </b-list-group-item>
                        <b-list-group-item>
                          <span class="float-left">Dodge:</span>
                          <span class="float-right">{{(Stats.dodgePct).toFixed(2)}}%</span>
                        </b-list-group-item>
                        <b-list-group-item>
                          <span class="float-left">Parry:</span>
                          <span class="float-right">{{(Stats.parryPct).toFixed(2)}}%</span>
                        </b-list-group-item>
                        <b-list-group-item>
                          <span class="float-left">Block:</span>
                          <span class="float-right">{{(Stats.blockPct).toFixed(2)}}%</span>
                        </b-list-group-item>
                        <b-list-group-item>
                          <span class="float-left">Resilience:</span>
                          <span class="float-right">{{Stats.resilience}}</span>
                        </b-list-group-item>
                      </b-list-group>
                    </b-card-text>
                  </b-card-text>
                </b-tab>
              </b-tabs>
            </b-card>
          </div>
          <b-row class="mt-3">
            <b-col>
              <b-button variant="dark" class="mt-1" block size="sm" @click="TabIndex--">Previous</b-button>
            </b-col>
            <b-col>
              <b-button variant="dark" class="mt-1" block size="sm" @click="TabIndex++">Next</b-button>
            </b-col>
          </b-row>
        </b-col>
        <b-col cols="3" class="armory-right">
          <div v-for="slot in EquipmentSlotsRight" :key="slot">
            <item
              :eSlot="slot"
              :entry="GetEntryForSlot(slot)"
              :item="GetItemForSlot(slot)"
              :realm="realm.id"
            ></item>
          </div>
        </b-col>
      </b-row>
      <div class="d-flex justify-content-center">
        <div v-for="slot in EquipmentSlotsWeapons" :key="slot">
          <item
            :eSlot="slot"
            :entry="GetEntryForSlot(slot)"
            :item="GetItemForSlot(slot)"
            :realm="realm.id"
          ></item>
        </div>
      </div>
    </div>
    <div v-if="!Loading && !Stats" class="text-center">
      <h3>No stats available for {{character.name}}.</h3>
    </div>
  </b-container>
</template>

<script>
import EquipmentSlots from "@/services/itemService/EquipmentSlots";
import UserHelper from "@/helpers/UserHelper";
import MapHelper from "@/helpers/MapHelper";

import ItemComponent from "@/components/Armory/Items/ItemComponent";

export default {
  name: "CharacterArmoryView",
  props: ["character", "realm"],
  data() {
    return {
      Stats: null,
      Inventory: null,
      TabIndex: 0,
      Loading: false,

      EquipmentSlotsLeft: [],
      EquipmentSlotsRight: [],
      EquipmentSlotsWeapons: []
    };
  },
  components: {
    item: ItemComponent
  },
  computed: {
    ArmoryItemsLeft() {
      return this.Inventory.filter(x =>
        this.EquipmentSlotsLeft.includes(x.slot)
      );
    },
    ArmoryItemsRight() {
      return this.Inventory.filter(x =>
        this.EquipmentSlotsRight.includes(x.slot)
      );
    },
    ArmoryItemsWeapons() {
      return this.Inventory.filter(x =>
        this.EquipmentSlotsWeapons.includes(x.slot)
      );
    }
  },
  methods: {
    async GetCharacterStatsAndInventory() {
      this.Loading = true;
      this.Stats = await this.$store.dispatch("armory/GetCharacterStats", {
        Guid: this.character.guid,
        RealmType: this.realm.id
      });
      this.Inventory = await this.$store.dispatch(
        "armory/GetCharacterInventory",
        {
          Guid: this.character.guid,
          RealmType: this.realm.id
        }
      );

      await this.GetItemIcons();

      this.Loading = false;
    },
    async GetItemIcons() {
      const displayIdsList = this.Inventory.map(x => x.item.displayId);
      await this.$store.dispatch("armory/GetItemIcons", displayIdsList);
    },
    GetRaceName(raceId) {
      return UserHelper.GetRaceName(raceId);
    },
    GetRaceColor(raceId) {
      return UserHelper.GetRaceColor(raceId);
    },
    GetClassName(classId) {
      return UserHelper.GetClassName(classId);
    },
    GetClassColor(classId) {
      return UserHelper.GetClassColor(classId);
    },
    GetMapName(mapId) {
      return MapHelper.GetMap(mapId);
    },
    GetZoneName(zoneId) {
      return MapHelper.GetZone(zoneId);
    },
    GetGender(genderId) {
      return UserHelper.GetGender(genderId);
    },
    GetEntryForSlot(slot) {
      const item = this.Inventory.find(x => x.slot == slot);
      return item ? item.itemEntry : 0;
    },
    GetItemForSlot(slot) {
      const item = this.Inventory.find(x => x.slot == slot);
      return item ? item : null;
    }
  },
  created() {
    this.GetCharacterStatsAndInventory();

    this.EquipmentSlotsLeft = [
      EquipmentSlots.HEAD,
      EquipmentSlots.NECK,
      EquipmentSlots.SHOULDERS,
      EquipmentSlots.BACK,
      EquipmentSlots.CHEST,
      EquipmentSlots.BODY,
      EquipmentSlots.TABARD,
      EquipmentSlots.WRISTS
    ];

    this.EquipmentSlotsRight = [
      EquipmentSlots.HANDS,
      EquipmentSlots.WAIST,
      EquipmentSlots.LEGS,
      EquipmentSlots.FEET,
      EquipmentSlots.FINGER1,
      EquipmentSlots.FINGER2,
      EquipmentSlots.TRINKET1,
      EquipmentSlots.TRINKET2
    ];

    this.EquipmentSlotsWeapons = [
      EquipmentSlots.MAINHAND,
      EquipmentSlots.OFFHAND,
      EquipmentSlots.RANGED
    ];
  }
};
</script>

<style scoped>
.information {
  height: 100px;
  width: 100%;
  position: relative;
}

.information .information-left {
  float: left;
}

.information .information-right {
  color: #606060;
  float: right;
}

.information .name {
  font-size: 36px;
  font-weight: bold;
  color: #c1b575;
}

.information .guild-name {
  height: 27px;
  line-height: 27px;
  font-size: 20px;
}

.information .power-points {
  width: 180px;
  font-size: 36px;
  font-weight: bold;
  text-align: right;
}
/* alliance https://i.pinimg.com/originals/8f/45/c9/8f45c9d9a14769b0e8d6f9a214cdaa04.png
   horde https://wallpaperplay.com/walls/full/d/d/a/146337.jpg
*/
.armory {
  /* background-image: url("~@/assets/images/armory/armory_horde_bg.png"); */
  background-size: 100%;
  background-position: center;
  background-repeat: no-repeat;
}

.armory-left {
  padding: 0;
  margin-top: 2rem;
}

.armory-right {
  padding: 0;
  margin-top: 2rem;
}

.armory-stats {
  padding: 0;
  margin-top: 120px;
  width: 100%;
  font-weight: bold;
}

.armory-stats .overview {
  min-height: 350px;
}

#armory_bars div {
  color: #fff;
  text-shadow: 1px 1px 0px #1e1e1e;
  text-align: center;
  padding: 2px;
  margin-bottom: 5px;
  border-radius: 2px;
  -moz-border-radius: 2px;
  -webkit-border-radius: 2px;
  box-shadow: 0px 1px 0px rgba(255, 255, 255, 0.3) inset;
  -moz-box-shadow: 0px 1px 0px rgba(255, 255, 255, 0.3) inset;
  -webkit-box-shadow: 0px 1px 0px rgba(255, 255, 255, 0.3) inset;
}

#armory_health {
  background-image: linear-gradient(bottom, #2aa728 100%, #199517 0%);
  background-image: -o-linear-gradient(bottom, #2aa728 100%, #199517 0%);
  background-image: -moz-linear-gradient(bottom, #2aa728 100%, #199517 0%);
  background-image: -webkit-linear-gradient(bottom, #2aa728 100%, #199517 0%);
  background-image: -ms-linear-gradient(bottom, #2aa728 100%, #199517 0%);
  background-image: -webkit-gradient(
    linear,
    left bottom,
    left top,
    color-stop(1, #2aa728),
    color-stop(0, #199517)
  );
  background-color: #199517;
  border: 1px solid #22600c;
  min-width: 150px;
}

#armory_mana {
  background-image: linear-gradient(bottom, #2876a7 100%, #176595 0%);
  background-image: -o-linear-gradient(bottom, #2876a7 100%, #176595 0%);
  background-image: -moz-linear-gradient(bottom, #2876a7 100%, #176595 0%);
  background-image: -webkit-linear-gradient(bottom, #2876a7 100%, #176595 0%);
  background-image: -ms-linear-gradient(bottom, #2876a7 100%, #176595 0%);
  background-image: -webkit-gradient(
    linear,
    left bottom,
    left top,
    color-stop(1, #2876a7),
    color-stop(0, #176595)
  );
  background-color: #176595;
  border: 1px solid #0c3e5d;
}

#armory_rage {
  background-image: linear-gradient(bottom, #a72828 100%, #951717 0%);
  background-image: -o-linear-gradient(bottom, #a72828 100%, #951717 0%);
  background-image: -moz-linear-gradient(bottom, #a72828 100%, #951717 0%);
  background-image: -webkit-linear-gradient(bottom, #a72828 100%, #951717 0%);
  background-image: -ms-linear-gradient(bottom, #a72828 100%, #951717 0%);
  background-image: -webkit-gradient(
    linear,
    left bottom,
    left top,
    color-stop(1, #a72828),
    color-stop(0, #951717)
  );
  background-color: #951717;
  border: 1px solid #5d0c0c;
}

#armory_focus {
  background-image: linear-gradient(bottom, #863d14 0%, #a74b14 100%);
  background-image: -o-linear-gradient(bottom, #863d14 0%, #a74b14 100%);
  background-image: -moz-linear-gradient(bottom, #863d14 0%, #a74b14 100%);
  background-image: -webkit-linear-gradient(bottom, #863d14 0%, #a74b14 100%);
  background-image: -ms-linear-gradient(bottom, #863d14 0%, #a74b14 100%);
  background-image: -webkit-gradient(
    linear,
    left bottom,
    left top,
    color-stop(0, #863d14),
    color-stop(1, #a74b14)
  );
  background-color: #a74b14;
  border: 1px solid #5d300c;
}

#armory_energy {
  background-image: linear-gradient(bottom, #a78828 100%, #957917 0%);
  background-image: -o-linear-gradient(bottom, #a78828 100%, #957917 0%);
  background-image: -moz-linear-gradient(bottom, #a78828 100%, #957917 0%);
  background-image: -webkit-linear-gradient(bottom, #a78828 100%, #957917 0%);
  background-image: -ms-linear-gradient(bottom, #a78828 100%, #957917 0%);
  background-image: -webkit-gradient(
    linear,
    left bottom,
    left top,
    color-stop(1, #a78828),
    color-stop(0, #957917)
  );
  background-color: #957917;
  border: 1px solid #5d4b0c;
}

#armory_runic {
  background-image: linear-gradient(bottom, #28a3a7 100%, #179195 0%);
  background-image: -o-linear-gradient(bottom, #28a3a7 100%, #179195 0%);
  background-image: -moz-linear-gradient(bottom, #28a3a7 100%, #179195 0%);
  background-image: -webkit-linear-gradient(bottom, #28a3a7 100%, #179195 0%);
  background-image: -ms-linear-gradient(bottom, #28a3a7 100%, #179195 0%);
  background-image: -webkit-gradient(
    linear,
    left bottom,
    left top,
    color-stop(1, #28a3a7),
    color-stop(0, #179195)
  );
  background-color: #179195;
  border: 1px solid #0c5d58;
}
</style>