<template>
  <div class="container">
    <profile-nav></profile-nav>
    <div class="d-flex justify-content-center" v-if="Loading" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="250" :color="'#7289da'"/>
    </div>
    <div v-else>
      <div class="form-group">
        <h3>
          Thank you
          <strong>{{ User.firstname }}</strong> for your donation!<br>
          The donation points are now active on your account.
        </h3>
      </div>
      <div class="card">
        <div class="card-header">
          Invoice
          <strong>{{ GetDate(Data.date )}}</strong>
          <span class="float-right">
            <strong>Status:</strong> Complete
          </span>
        </div>
        <div class="card-body">
          <div class="row mb-4">
            <div class="col-sm-6">
              <h6 class="mb-3">From:</h6>
              <div>
                <strong>{{ Data.firstName }} {{ Data.lastName }}</strong>
              </div>
              <div>Madalinskiego 8</div>
              <div>{{ Data.postalCode }}, {{ Data.city }}</div>
              <div>Email: {{ Data.email }}</div>
            </div>

            <div class="col-sm-6">
              <h6 class="mb-3">To:</h6>
              <div>
                <strong>Titans-League</strong>
              </div>
              <div>Att: Vincent Vanclef</div>
              <div>Email: admin@titans-league.com</div>
            </div>
          </div>

          <div class="table-responsive-sm">
            <table class="table table-striped">
              <thead>
                <tr>
                  <th class="center">#</th>
                  <th>Item</th>
                  <th>Description</th>

                  <th class="right">Unit Cost</th>
                  <th class="center">Qty</th>
                  <th class="right">Total</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td class="center">1</td>
                  <td class="left strong">DP</td>
                  <td class="left">{{ Data.name }}</td>

                  <td class="right">{{ Data.price }} {{ Data.currency }}</td>
                  <td class="center">{{ Data.amount }}</td>
                  <td class="right">{{ Data.price * Data.amount }}</td>
                </tr>
              </tbody>
            </table>
          </div>
          <div class="row">
            <div class="col-lg-4 col-sm-5"></div>

            <div class="col-lg-4 col-sm-5 ml-auto">
              <table class="table table-clear">
                <tbody>
                  <tr>
                    <td class="left">
                      <strong>Total</strong>
                    </td>
                    <td class="right">{{ Data.total }} {{ Data.currency }}</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import ProfileNav from "@/components/ProfileNav";
import { SemipolarSpinner } from "epic-spinners";
import config from "@/config";
import PayPalExtractor from "@/helpers/PayPalExtractor";

const API_PAYPAL = config.API.PAYPAL;

export default {
  data() {
    return {
      Loading: false,
      Data: null
    };
  },
  computed: {
    User() {
      return this.$store.getters.GetUser;
    }
  },
  methods: {
    async ProcessDonation() {
      this.Loading = true;

      const userId = this.$store.getters.GetUser.id;
      const payerId = this.$route.query.PayerID;
      const paymentId = this.$route.query.paymentId;

      let result;
      try {
        result = await this.$http.post(`${API_PAYPAL}/success`, {
          userId,
          payerId,
          paymentId
        });
      } catch (err) {
        this.$toasted.error(err.message);
      }

      return result.data;
    },
    async ProcessResult(data) {
      const extractor = new PayPalExtractor(data);
      const date = data.create_time;
      const payerData = await extractor.PayerData;
      const shippingData = await extractor.ShippingData;
      const transactionData = await extractor.TransactionData;
      const itemsData = await extractor.ItemsData;
      // All results are arrays cuz paypal is meh
      const result = {
        date,
        ...payerData[0],
        ...shippingData[0],
        ...transactionData[0],
        ...itemsData[0]
      };
      this.Data = result;

      // Update User DP on site
      const dp = this.$store.getters.GetUser.dp;
      this.$store.commit("UPDATE_USER", { index: "dp", value: this.Data.amount + dp })
    },
    GetDate(date) {
      const options = {
        year: "numeric",
        month: "numeric",
        day: "numeric",
        hour: "numeric",
        minute: "numeric",
        second: "numeric"
      };
      const newdate = new Date(date);
      return new Intl.DateTimeFormat("it-IT", options).format(newdate);
    }
  },
  components: {
    "profile-nav": ProfileNav,
    "semipolar-spinner": SemipolarSpinner
  },
  created() {
    if (this.Data == null) {
      this.ProcessDonation()
        .then(data => this.ProcessResult(data))
        .finally(() => (this.Loading = false));
    }
  }
};
</script>

<style scoped>
#atom-spinner {
  margin-top: 40%;
}

h3 {
  text-align: center;
}
</style>

