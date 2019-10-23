<template>
  <b-container>
    <div v-if="Loading" class="text-center">
      <b-spinner style="width: 3rem; height: 3rem;" variant="primary" label="Spinning"></b-spinner>
    </div>
    <div v-if="!Loading">
      <b-row class="inventory-stats">
        <b-col sm="12" md="12" lg="3" class="mb-3">
          <label class="control-label">Search Inventory</label>
          <b-input
            type="text"
            id="item_search"
            name="search item"
            @input="isTyping = true"
            v-model="searchQuery"
            placeholder="Enter item name"
            v-validate="'max:50'"
            :class="{'form-control': true, 'error': errors.has('search item') }"
          />
          <b-tooltip placement="bottom" target="item_search">{{ errors.first('search item') }}</b-tooltip>
          <div class="mt-3">
            <div class="mb-1">
              Total Items:
              <span class="float-right">
                <b-badge variant="info">{{this.TotalItems}}</b-badge>
              </span>
            </div>
            <div class="mb-1">
              Total Unique Items:
              <span class="float-right">
                <b-badge variant="info">{{this.Items.length}}</b-badge>
              </span>
            </div>
            <div>
              Filtered Items:
              <span class="float-right">
                <b-badge variant="info">{{this.searchResult.length}}</b-badge>
              </span>
            </div>
          </div>
        </b-col>
        <b-col cols="6" md="6" lg="3">
          <label class="control-label">Search Qualities</label>
          <b-form-select
            v-model="SelectedQualities"
            multiple
            :select-size="5"
            @change="isTyping = true"
          >
            <option
              v-for="quality in ItemQualityArray"
              :key="quality.id"
              :value="quality.id"
            >{{ quality.name }}</option>
          </b-form-select>
        </b-col>
        <b-col cols="6" md="6" lg="3">
          <label class="control-label">Sort By</label>
          <b-form-radio-group
            v-model="SelectedSort"
            :options="SortOptions"
            stacked
            @change="isTyping = true"
          ></b-form-radio-group>
        </b-col>
        <b-col cols="6" md="6" lg="3" class="d-flex flex-column-reverse">
          <b-button block variant="dark" class="mt-3" @click="ClearFilter()">Clear Filter</b-button>
        </b-col>
      </b-row>
      <hr class="border-dark mt-4 mb-4" />
      <b-row class="inventory-bg">
        <b-col
          cols="4"
          md="3"
          lg="1"
          v-for="item in searchResult"
          :key="item.itemEntry"
          class="inventory-item"
        >
          <b-badge variant="dark">
            <item :eSlot="item.slot" :entry="item.itemEntry" :item="item.item" :realm="realm.id"></item>
            {{item.itemCount}}
          </b-badge>
        </b-col>
      </b-row>
    </div>
  </b-container>
</template>

<script>
import _ from "lodash";

import ItemQualities from "@/services/itemService/ItemQualities";
import ItemComponent from "@/components/Armory/Items/ItemComponent";

export default {
  name: "CharacterInventoryView",
  props: ["character", "realm"],
  data() {
    return {
      Loading: false,
      Items: [],
      TotalItems: 0,

      searchQuery: "",
      searchResult: [],
      isTyping: false,

      SelectedQualities: [],

      SelectedSort: null,

      SortOptions: [
        {
          text: "No Sort",
          value: null
        },
        {
          text: "Name",
          value: {
            sort: (itemA, itemB) => (itemA.item.name > itemB.item.name ? 1 : -1)
          }
        },
        {
          text: "Quality",
          value: {
            sort: (itemA, itemB) =>
              itemA.item.quality < itemB.item.quality ? 1 : -1
          }
        },
        {
          text: "Count",
          value: {
            sort: (itemA, itemB) => (itemA.itemCount < itemB.itemCount ? 1 : -1)
          }
        },
        {
          text: "Type",
          value: {
            sort: (itemA, itemB) =>
              itemA.item.class > itemB.item.class ? 1 : -1
          }
        }
      ]
    };
  },
  components: {
    item: ItemComponent
  },
  watch: {
    searchQuery: _.debounce(function() {
      this.isTyping = false;
    }, 1000),
    SelectedQualities: _.debounce(function() {
      this.isTyping = false;
    }, 1500),
    SelectedSort: _.debounce(function() {
      this.isTyping = false;
    }, 1000),
    isTyping: function(value) {
      if (!value) {
        this.ApplySearchFilter();
        this.ApplyQueryFilter();
      }
    }
  },
  computed: {
    ItemQualityArray() {
      return ItemQualities.ItemQualityArray;
    }
  },
  methods: {
    async GetCharacterItems() {
      this.Loading = true;
      try {
        const items = await this.$store.dispatch("armory/GetCharacterItems", {
          Guid: this.character.guid,
          RealmType: this.realm.id
        });

        this.Items = this.MergeDuplicateItems(items);
        this.searchResult = [...this.Items];

        this.TotalItems = items.length;

        await this.GetItemIcons();
      } finally {
        this.Loading = false;
        this.ApplyFilterFromQuery();
      }
    },
    async GetItemIcons() {
      const displayIdsList = this.Items.map(x => x.item.displayId);
      await this.$store.dispatch("armory/GetItemIcons", displayIdsList);
    },
    MergeDuplicateItems(items) {
      return items.reduce(function(accumulator, cur) {
        const entry = cur.itemEntry;
        const found = accumulator.find(x => x.item && x.itemEntry == entry);
        if (found) found.itemCount += cur.itemCount;
        else accumulator.push(cur);
        return accumulator;
      }, []);
    },
    ApplySearchFilter() {
      let items = [...this.Items];

      const filter = this.searchQuery;

      // Filter by name
      if (filter.length > 0) {
        items = items.filter(item =>
          item.item.name.toLowerCase().includes(filter.toLowerCase())
        );
      }

      if (this.SelectedQualities.length > 0) {
        items = items.filter(item =>
          this.SelectedQualities.includes(item.item.quality)
        );
      }

      if (this.SelectedSort) {
        items = items.sort(this.SelectedSort.sort);
      }

      this.searchResult = items;
    },
    ClearFilter() {
      this.SelectedSort = null;
      this.SelectedQualities = [];
      this.searchQuery = "";
      this.ApplySearchFilter();
      this.ClearQuery();
    },
    async ApplyQueryFilter() {
      const QUERY = this.$route.query;

      try {
        await this.$router.replace({
          query: Object.assign({}, QUERY, {
            filter: JSON.stringify({
              searchQuery: this.searchQuery,
              selectedQualities: this.SelectedQualities
            })
          })
        });
      } catch (e) {}
    },
    ApplyFilterFromQuery() {
      const QUERY = this.$route.query;

      const filter = QUERY.filter ? JSON.parse(QUERY.filter) : null;
      if (filter) {
        this.searchQuery = filter.searchQuery;
        this.SelectedQualities = filter.selectedQualities;
        this.ApplySearchFilter();
      }
    },
    async ClearQuery() {
      const QUERY = this.$route.query;

      try {
        await this.$router.replace({
          query: Object.assign({}, QUERY, {
            filter: undefined
          })
        });
      } catch (e) {}
    }
  },
  created() {
    this.GetCharacterItems();
  }
};
</script>

<style scoped>
.inventory-item {
  padding: 2px;
  margin-bottom: 0.25rem;
}

.inventory-bg {
  text-align: center;
  padding: 10px;
  border-radius: 7px;
  background-color: rgba(0, 0, 0, 0.3);
  height: 530px;
  overflow: auto;
}

.control-label {
  font-weight: bold;
}
</style>