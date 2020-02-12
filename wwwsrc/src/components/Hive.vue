<template>
  <div class="col-12 col-lg-4 hive" @click.prevent="setActiveVault">
    <h3>{{hiveData.name}}</h3>
    <img src="../assets/hive-png-3.png" style="width:300px;height:300px" />
    <h4>{{hiveData.description}}</h4>
  </div>
</template>

<script>
import router from "../router.js";
export default {
  name: "hive",
  props: ["hiveData"],
  mounted() {
    this.$store.dispatch("getVaultKeeps", this.$store.state.activeVault.id);
  },
  methods: {
    setActiveVault() {
      this.$store.commit("setActiveVault", this.hiveData);
      router.push({ path: "/hive", params: { hiveId: this.hiveData.id } });
    }
  },
  computed: {}
};
</script>

<style scoped>
.hive {
  display: flex;
  flex-direction: column;
  align-items: center;
}
</style>