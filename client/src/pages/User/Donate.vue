<template>
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
          <div class="title"><p>Enter amount of <strong>Donation Points</strong> you wish to purchase.<br>The price is <strong>1 USD</strong> per point.</p></div>
          <form>
            <div class="form-group">
              <div class="input-group">
                <div class="input-group-prepend">
                  <span class="input-group-text">
                    <i class="fa fa-circle fa-fw"></i>
                  </span>
                </div>
                <b-input
                  id="DonationPoint"
                  name="Donation Point"
                  class="form-control"
                  placeholder="Amount of points"
                  type="number"
                  v-model="Amount"
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
              <input
                type="image"
                src="/static/images/paypal_checkout_button.png"
                width="215"
                @click="ProcessDonation()"
              >
            </div>
          </form>
        </div>
        <div class="col text-right">
          <img src="/static/images/paypal_checkout.png" width="300" height="80">
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import ProfileNav from "@/components/ProfileNav";
import { SemipolarSpinner } from "epic-spinners";
import config from "@/config";

const API_PAYPAL = config.API.PAYPAL;

export default {
  name: "DonatePanel",
  data() {
    return {
      Amount: 1,
      Loading: false
    };
  },
  methods: {
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
        console.log(err);
      }

      window.open(result.data, "_self");
    },
    async isFormValid() {
      const result = await this.$validator.validateAll();
      return result;
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
  width: 300px;
}
</style>
