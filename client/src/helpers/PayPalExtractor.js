import alasql from "alasql";

export default class PaypalExtractor {
  constructor(payload) {
    this.data = payload;
  }

  get PayerData() {
    return alasql.promise(
      `
        SEARCH payer->payer_info AS @data

        RETURN(
            @data->email AS email,
            @data->country_code AS countryCode,
            @data->first_name AS firstName,
            @data->last_name AS lastName) FROM ?`,
      [this.data]
    );
  }

  get ShippingData() {
    return alasql.promise(
      `
        SEARCH payer->payer_info->shipping_address AS @data

        RETURN(
            @data->city AS city,
            @data->country_code AS countryCode,
            @data->postal_code AS postalCode,
            @data->state AS state) FROM ? `,
      [this.data]
    );
  }

  get TransactionData() {
    return alasql.promise(
      `
        SEARCH transactions / AS @data

        RETURN(
            @data->description AS description,
            @data->amount->total AS total,
            @data->amount->currency AS currency
            ) FROM ? `,
      [this.data]
    );
  }

  get ItemsData() {
    return alasql.promise(
      `
      SEARCH
         transactions / item_list->items / AS @data

         RETURN(@data->currency AS currency,
         @data->name AS name,
         @data->quantity AS amount,
         @data->price AS price

         ) FROM ? `,
      [this.data]
    );
  }
}
