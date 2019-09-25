const Classes = {
  CLASS_WARRIOR: 1,
  CLASS_PALADIN: 2,
  CLASS_HUNTER: 3,
  CLASS_ROGUE: 4,
  CLASS_PRIEST: 5,
  CLASS_DEATH_KNIGHT: 6,
  CLASS_SHAMAN: 7,
  CLASS_MAGE: 8,
  CLASS_WARLOCK: 9,
  CLASS_DRUID: 11
};

const WoWClassesMap = new Map([
  [Classes.CLASS_WARRIOR, { name: "WARRIOR", color: "#C79C6E" }],
  [Classes.CLASS_PALADIN, { name: "PALADIN", color: "#F58CBA" }],
  [Classes.CLASS_HUNTER, { name: "HUNTER", color: "#ABD473" }],
  [Classes.CLASS_ROGUE, { name: "ROGUE", color: "#F8C621" }],
  [Classes.CLASS_PRIEST, { name: "PRIEST", color: "#A330C9" }],
  [Classes.CLASS_DEATH_KNIGHT, { name: "DEATH KNIGHT", color: "#C41F3B" }],
  [Classes.CLASS_SHAMAN, { name: "SHAMAN", color: "#0070DE" }],
  [Classes.CLASS_MAGE, { name: "MAGE", color: "#40C7EB" }],
  [Classes.CLASS_WARLOCK, { name: "WARLOCK", color: "#8787ED" }],
  [Classes.CLASS_DRUID, { name: "DRUID", color: "#FF7D0A" }]
]);

export default {
  name: "WoWClasses",

  Classes,

  GetClassColor: classId => {
    const _class = WoWClassesMap.get(classId);
    return _class ? _class.color : "";
  },

  GetClassName: classId => {
    const _class = WoWClassesMap.get(classId);
    return _class ? _class.name : "";
  }
};
