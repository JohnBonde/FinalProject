<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-10">
        <h1>Your Hives</h1>
      </div>
      <div class="col-2 create-hive">
        <img @click="showModal" src="../assets/hive-png-3.png" style="width:50px;height:50px" />
        <i class="fas fa-plus"></i>
      </div>
    </div>
    <div class="row">
      <hive :hiveData="hive" v-for="hive in hives" :key="hive.id" />
    </div>
    <hive-modal v-show="isModalVisible" @close="closeModal" />
  </div>
</template>

<script>
import HiveModal from "../components/HiveModal";
import Hive from "../components/Hive";
export default {
  name: "dashboard",
  components: {
    HiveModal,
    Hive
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  data() {
    return {
      isModalVisible: false
    };
  },
  computed: {
    hives() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    showModal() {
      this.isModalVisible = true;
    },
    closeModal() {
      this.isModalVisible = false;
    }
  }
};
</script>

<style scoped>
.create-hive {
  display: flex;
  justify-content: flex-end;
  align-items: center;
}
i {
  margin-top: -30px;
}
.create-hive img,
.fa-plus {
  cursor: pointer;
}
</style>
