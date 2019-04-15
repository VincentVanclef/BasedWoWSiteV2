<template>
  <div class="card rounded" style="margin-bottom: 20px">
    <div class="card-body">
      <h4 class="card-title text-center mb-4 mt-1">Server Status</h4>
      <hr>
      <div class="row online-status">
        <div class="col-4">
          <span class="badge badge-pill badge-success">Online</span>
        </div>
        <div class="col-8">
          <p>Realm of Titans</p>
        </div>
      </div>
      <b-row>
          <div class="col-6 text-left">Alliance</div>
          <div class="col-6 text-right">Horde</div>
      </b-row>
      <div class="progress">
        <div
          id="progress-bar-alliance"
          class="progress-bar progress-bar-striped"
          role="progressbar"
          :style="{ width: AllianceOnlinePct + '%' }"
          aria-valuenow="70"
          aria-valuemin="0"
          aria-valuemax="100"
        ></div>
        <b-tooltip
          placement="bottom"
          target="progress-bar-alliance"
        >{{ AllianceOnline }} players online</b-tooltip>
        <div
          id="progress-bar-horde"
          class="progress-bar progress-bar-striped bg-danger"
          role="progressbar"
          :style="{ width: HordeOnlinePct + '%'}"
          aria-valuenow="90"
          aria-valuemin="0"
          aria-valuemax="100"
        ></div>
        <b-tooltip placement="bottom" target="progress-bar-horde">{{ HordeOnline }} players online</b-tooltip>
      </div>
    </div>
    <div class="card-footer">
      <div class="card-title text-center">Realmlist</div>
      <div class="text-center">logon.titans-league.com</div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      AllianceOnline: 38,
      HordeOnline: 89
    };
  },
  computed: {
    TotalOnline() {
      return this.AllianceOnline + this.HordeOnline;
    },
    AllianceOnlinePct() {
      let pct = parseInt((this.AllianceOnline / this.TotalOnline) * 100);
      // ensure its always 100%
      if (pct + this.HordeOnlinePct != 100) pct += 1;
      return pct;
    },
    HordeOnlinePct() {
      return parseInt((this.HordeOnline / this.TotalOnline) * 100);
    }
  }
};
</script>

<style scoped>
.card {
    height: 300px;
}

.online-status {
  font-size: 18px;
}

.progress {
  height: 22px;
}
.progress .progress-bar {
  border-radius: 3px;
}
</style>

