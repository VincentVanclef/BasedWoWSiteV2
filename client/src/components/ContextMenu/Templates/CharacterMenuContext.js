export default class CharacterMenuContext {
  constructor(vm) {
    this.vm = vm;
  }

  SetupMenuContext() {
    const items = this.vm.$el.querySelectorAll("a");
    items.forEach(element => {
      element.addEventListener(
        "contextmenu",
        event => {
          const playerData = JSON.parse(element.getAttribute("player-data"));
          const player = playerData.player;
          const realmId = playerData.realm;

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
                  `/armory/characters/Search?query=${player.name}&realm=${realmId}`,
                  "_blank"
                )
            },
            {
              title: "View Character Armory",
              requiresAdmin: false,
              handler: () =>
                window.open(
                  `/armory/characters/Search?query=${player.name}&realm=${realmId}&showArmory=${player.name}`,
                  "_blank"
                )
            },
            {
              title: "View Character Inventory",
              requiresAdmin: true,
              handler: () =>
                window.open(
                  `/armory/characters/Search?query=${player.name}&realm=${realmId}&showInventory=${player.name}`,
                  "_blank"
                )
            }
          ];

          if (!this.vm.IsAdmin) {
            ctxMenuData = ctxMenuData.filter(x => !x.requiresAdmin);
          }

          this.vm.$root.$emit("contextmenu", { event, ctxMenuData });
        },
        false
      );
    });
  }
}
