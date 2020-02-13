<template>
  <div class="hive-view container-fluid">
    <div class="row" style="margin-top: 10px;">
      <div class="col-10">
        <h1>{{hive.name}}</h1>
        <h3>{{hive.description}}</h3>
      </div>
      <div class="col-2 delete-hive">
        <img
          @click.prevent="deleteHive"
          src="../assets/hive-png-3.png"
          style="width:50px;height:50px"
        />
        <i class="fas fa-times"></i>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <div class="grid">
          <ul id="hexGrid">
            <comb :combData="comb" v-for="comb in combs" :key="comb.id" />
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import router from "../router.js";
import Comb from "../components/Comb";
export default {
  name: "hive-view",
  components: {
    Comb
  },
  mounted() {
    this.$store.dispatch("getKeepsByVaultId", this.hive.id);
  },
  computed: {
    hive() {
      return this.$store.state.activeVault;
    },
    combs() {
      return this.$store.state.vaultKeeps;
    }
  },
  methods: {
    deleteHive() {
      this.$store.dispatch("deleteVault", this.hive.id);
      this.$store.dispatch("getVaults");
      router.push({ path: "/dashboard" });
    }
  }
};
</script>

<style scoped>
.delete-hive {
  display: flex;
  justify-content: flex-end;
}

img,
i {
  cursor: pointer;
}
</style>