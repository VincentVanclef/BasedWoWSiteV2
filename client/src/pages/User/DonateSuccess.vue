<template>
  <div class="container">
    <div class="d-flex justify-content-center" v-if="Loading" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'" />
    </div>
    <div v-if="Data">
      <div class="form-group">
        <h3>
          Thank you
          <strong>{{ user.firstname }} {{ user.lastname}}</strong> for your donation!
          <br />The donation points are now active on your account.
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
                <strong>{{ Data.payerFirstName }} {{ Data.payerLastName }}</strong>
              </div>
              <div>{{ Data.payerPostalCode }}, {{ Data.payerCity }}</div>
              <div>Email: {{ Data.payerEmail }}</div>
            </div>

            <div class="col-sm-6">
              <h6 class="mb-3">To:</h6>
              <div>
                <strong>Titans-League</strong>
              </div>
              <div>Att: Vincent Vanclef</div>
              <div>Email: admin@titans-league.org</div>
            </div>
          </div>

          <div class="table-responsive-sm">
            <table class="table table-striped table-bordered">
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
                  <td class="left">{{ Data.item }}</td>

                  <td class="right">{{ Data.price }} {{ Data.currency }}</td>
                  <td class="center">{{ Data.quantity }}</td>
                  <td class="right">{{ Data.price * Data.quantity }} {{ Data.currency }}</td>
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
import { SemipolarSpinner } from "epic-spinners";
import moment from "moment";

export default {
  props: ["user"],
  data() {
    return {
      Loading: false,
      Data: null,
      Update: false
    };
  },
  computed: {},
  methods: {
    async ProcessDonation() {
      this.Loading = true;

      const userId = this.user.id;
      const accountId = this.user.accountId;
      const payerId = this.$route.query.PayerID;
      const paymentId = this.$route.query.paymentId;
      const token = this.$route.query.token;

      const data = await this.$store.dispatch("user/donate/CompletePayment", {
        userId,
        accountId,
        payerId,
        paymentId,
        token
      });

      return data;
    },
    async ProcessResult(data) {
      if (typeof data != "object") {
        this.$toasted.error(data.error);
        return;
      }

      const { dp, payPalLog } = data;

      this.Data = payPalLog;

      // Update User DP on site
      this.$store.commit("user/UpdateUser", {
        index: "dp",
        value: dp
      });
    },
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
    }
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  created() {
    if (this.Data == null) {
      this.ProcessDonation()
        .then(data => {
          this.ProcessResult(data).finally(() => (this.Loading = false));
        })
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

