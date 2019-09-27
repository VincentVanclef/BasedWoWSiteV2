<template>
  <b-container>
    <b-row v-if="Loading" class="d-flex justify-content-center mt-5">
      <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'" />
    </b-row>
    <div v-else class="container">
      <b-row>
        <div class="col-4">
          <div class="title">
            <p>
              Enter amount of
              <strong>Donation Points</strong> you wish to purchase.
              <br />The price is
              <strong>1 USD</strong> per point.
            </p>
            <p>Points: {{ Amount }} Price: {{ Amount }} $</p>
          </div>
          <div class="form-group">
            <div class="input-group">
              <b-input
                id="DonationPoint"
                name="Donation Point"
                class="form-control"
                placeholder="Amount of points"
                type="number"
                v-model="Amount"
                max="5"
                onKeyPress="if (this.value.length == 4) return false;"
                v-validate="'required|numeric|min_value:1|max_value:500'"
                :class="{'form-control': true, 'error': errors.has('Donation Point') }"
              ></b-input>
              <b-tooltip
                placement="bottom"
                target="DonationPoint"
              >{{ getErrorMsg('Donation Point') }}</b-tooltip>
            </div>
          </div>
          <div class="form-group">
            <img
              class="donate-paypal-checkout-button"
              :src="require('@/assets/images/paypal_checkout_button.png')"
              @click="ProcessDonation()"
            />
          </div>
        </div>
        <div class="col text-right">
          <img class="donate-paypal-checkout" :src="require('@/assets/images/paypal_checkout.png')" />
        </div>
        <p>The donation points will automatically be added to your ingame account as well. Log ingame and spend them on various perks and bonuses. If you do not see them instantly, just relog.</p>
      </b-row>
    </div>
  </b-container>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";

export default {
  name: "DonatePanel",
  data() {
    return {
      Amount: 1,
      Loading: false
    };
  },
  methods: {
    async isFormValid() {
      const result = await this.$validator.validateAll();
      return result;
    },
    async ProcessDonation() {
      const formValid = await this.isFormValid();
      if (!formValid) {
        return;
      }

      this.Loading = true;

      await this.$store.dispatch("user/donate/Donate", this.Amount);
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  }
};
</script>


<style scoped>
.paypal-checkout {
  background: url("https://www.paypalobjects.com/digitalassets/c/website/marketing/apac/C2/logos-buttons/44_Yellow_CheckOut_Pill_Button.png")
    no-repeat;
}

.donate-paypal-checkout {
  width: 80%;
}

.donate-paypal-checkout-button {
  cursor: pointer;
  width: 100%;
}

.asdfsdfs {
  height: 100%;
}
</style>
