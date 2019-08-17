const alasql = require('alasql')

class PaypalExtractor {
  constructor(payload) {
    this.data = payload;
  }

  get PayerData() {
    return alasql(
      `
        SEARCH payer->payer_info AS @data

        RETURN(
            @data->email AS PayerEmail,
            @data->country_code AS CountryCode,
            @data->first_name AS PayerFirstName,
            @data->last_name AS PayerLastName) FROM ?`,
      [this.data]
    );
  }

  get ShippingData() {
    return alasql(
      `
        SEARCH payer->payer_info->shipping_address AS @data

        RETURN(
            @data->city AS City,
            @data->country_code AS CountryCode,
            @data->postal_code AS PostalCode,
            @data->state AS State) FROM ? `,
      [this.data]
    );
  }

  get TransactionData() {
    return alasql(
      `
        SEARCH transactions / AS @data

        RETURN(
            @data->description AS Description,
            @data->amount->total AS Total,
            @data->amount->currency AS Currency
            ) FROM ? `,
      [this.data]
    );
  }

  get ItemsData() {
    return alasql(
      `
      SEARCH
         transactions / item_list->items / AS @data

         RETURN(@data->currency AS Currency,
         @data->name AS Item,
         @data->quantity AS Quantity,
         @data->price AS Price

         ) FROM ? `,
      [this.data]
    );
  }
}

module.exports = PaypalExtractor;
