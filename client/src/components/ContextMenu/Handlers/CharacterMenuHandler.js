import UserHelper from "@/helpers/UserHelper";

export default {
  GetMenuData: (player, realm) => {
    let ctxMenuData = [
      {
        title: "View Account",
        requiresAdmin: true,
        handler: () =>
          window.open(
            `/admin/accounts/search?query=${player.accountId}`,
            "_blank"
          )
      },
      {
        type: "divider"
      },
      {
        title: "View Character",
        requiresAdmin: false,
        handler: () =>
          window.open(
            `/armory/characters/Search?query=${player.name}&realm=${realm}`,
            "_blank"
          )
      },
      {
        title: "View Character Armory",
        requiresAdmin: false,
        handler: () =>
          window.open(
            `/armory/characters/Search?query=${player.name}&realm=${realm}&showArmory=${player.name}`,
            "_blank"
          )
      },
      {
        title: "View Character Inventory",
        requiresAdmin: true,
        handler: () =>
          window.open(
            `/armory/characters/Search?query=${player.name}&realm=${realm}&showInventory=${player.name}`,
            "_blank"
          )
      }
    ];

    if (!UserHelper.CanModerate()) {
      ctxMenuData = ctxMenuData.filter(x => !x.requiresAdmin);
    }

    return ctxMenuData;
  }
};
