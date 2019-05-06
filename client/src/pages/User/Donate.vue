<template lang="html">
  <div class="container">
    <profile-nav></profile-nav>
    <div class="row align-items-center" v-if="Loading" id="atom-spinner">
      <div class="col"></div>
      <div class="col-6">
        <h2>Processing donation ...</h2>
        <semipolar-spinner :animation-duration="2000" :size="250" :color="'#7289da'" id="spinner"/>
      </div>
      <div class="col"></div>
    </div>
    <div v-else class="container">
      <div class="row">
        <div class="col-4">
          <div class="title">
            <p>
              Enter amount of
              <strong>Donation Points</strong> you wish to purchase.
              <br>The price is
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
              <img class="donate-paypal-checkout-button" src="/static/images/paypal_checkout_button.png" @click="ProcessDonation()">
            </div>
        </div>
        <div class="col text-right">
          <img class="donate-paypal-checkout" src="/static/images/paypal_checkout.png">
        </div>
        <p>The donation points will automatically be added to your ingame account as well. Log ingame and spend them on various perks and bonuses. If you do not see them instantly, just relog.</p>
      </div>
    </div>
  </div>
</template>

<script>
import ProfileNav from "@/components/ProfileNav";
import { SemipolarSpinner } from "epic-spinners";

const API_PAYPAL = process.env.API.PAYPAL;

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

      let result;
      try {
        result = await this.$http.post(`${API_PAYPAL}/donate`, {
          donationpoint: this.Amount
        });
      } catch (err) {
        this.$toasted.error(err);
        this.Loading = false;
      }

      window.open(result.data, "_self");
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  },
  components: {
    "profile-nav": ProfileNav,
    "semipolar-spinner": SemipolarSpinner
  }
};
</script>


<style scoped>
#atom-spinner {
  margin-top: 40%;
}

#spinner {
  margin-top: 30px;
  margin-left: 20px;
}

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
</style>
