<template>
  <div class="dashboard container-fluid">
    <h1>Your Hives</h1>
    <button class="btn btn-primary" @click="showModal">Create Hive</button>
    <div class="row">
      <div class="col"></div>
    </div>
    <hive-modal v-show="isModalVisible" @close="closeModal" />
  </div>
</template>

<script>
import HiveModal from "../components/HiveModal";
export default {
  name: "dashboard",
  components: {
    HiveModal
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  data() {
    return { isModalVisible: false };
  },
  computed: {},
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

<style></style>
