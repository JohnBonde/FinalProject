<template>
  <div class="hive-view container-fluid">
    <div class="row">
      <div class="col">
        <h1>{{hive.name}}</h1>
        <h3>{{hive.description}}</h3>
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
  }
};
</script>

<style>
</style>