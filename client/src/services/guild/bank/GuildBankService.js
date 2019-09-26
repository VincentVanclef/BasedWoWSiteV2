const GuildBankEventLogTypes = {
  DEPOSIT_ITEM: 1,
  WITHDRAW_ITEM: 2,
  MOVE_ITEM: 3,
  DEPOSIT_MONEY: 4,
  WITHDRAW_MONEY: 5,
  REPAIR_MONEY: 6,
  MOVE_ITEM2: 7,
  UNK1: 8,
  BUY_SLOT: 9
};

export default {
  name: "GuildBankService",

  GuildBankEventLogTypes,

  GetGuildBankLogDescription(log, realm) {
    switch (log.eventType) {
      case GuildBankEventLogTypes.DEPOSIT_ITEM:
        return `${log.playerName} deposited <div v-itemtooltip="${{
          item: log.item,
          realm: realm
        }}">[${log.item.name}]</div>`;
    }
  }
};
