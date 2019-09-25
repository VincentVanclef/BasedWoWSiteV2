const ItemQualities = {
  POOR: 0, //GREY
  NORMAL: 1, //WHITE
  UNCOMMON: 2, //GREEN
  RARE: 3, //BLUE
  EPIC: 4, //PURPLE
  LEGENDARY: 5, //ORANGE
  ARTIFACT: 6, //LIGHT YELLOW
  HEIRLOOM: 7
};

const ItemQualityMap = new Map([
  [ItemQualities.POOR, "#9d9d9d"],
  [ItemQualities.NORMAL, "#ffffff"],
  [ItemQualities.UNCOMMON, "#1eff00"],
  [ItemQualities.RARE, "#0070dd"],
  [ItemQualities.EPIC, "#a335ee"],
  [ItemQualities.LEGENDARY, "#ff8000"],
  [ItemQualities.ARTIFACT, "#e5cc80"],
  [ItemQualities.HEIRLOOM, "#e5cc80"]
]);

const ItemQualityArray = [
  { id: ItemQualities.POOR, name: "Poor" },
  { id: ItemQualities.NORMAL, name: "Normal" },
  { id: ItemQualities.UNCOMMON, name: "Uncommon" },
  { id: ItemQualities.RARE, name: "Rare" },
  { id: ItemQualities.EPIC, name: "Epic" },
  { id: ItemQualities.LEGENDARY, name: "Legendary" },
  { id: ItemQualities.ARTIFACT, name: "Artifact" },
  { id: ItemQualities.HEIRLOOM, name: "Heirloom" }
];

export default {
  name: "ItemQualities",

  ItemQualities,
  ItemQualityMap,
  ItemQualityArray,

  GetQuality: function(id) {
    return ItemQualityMap.get(id);
  }
};
