<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-10" style="margin-top: 10px;">
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
    <div class="row">
      <div class="col-10">
        <h1>Your Honeycombs</h1>
      </div>
      <div class="col-2 create-comb2">
        <img @click="showModal" src="../assets/honeycomb.png" style="width:50px;height:50px" />
        <i class="fas fa-plus"></i>
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
    <hive-modal v-show="isModalVisible" @close="closeModal" />
    <comb-modal v-show="isModalVisible2" @close="closeModal2" />
  </div>
</template>

<script>
import HiveModal from "../components/HiveModal";
import Hive from "../components/Hive";
import Comb from "../components/Comb";
import CombModal from "../components/CombModal";
export default {
  name: "dashboard",
  components: {
    HiveModal,
    Hive,
    CombModal,
    Comb
  },
  mounted() {
    this.$store.dispatch("getVaults");
    this.$store.dispatch("getUserKeeps");
  },
  data() {
    return {
      isModalVisible: false,
      isModalVisible2: false
    };
  },
  computed: {
    hives() {
      return this.$store.state.vaults;
    },
    combs() {
      return this.$store.state.privateKeeps;
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
    },
    showModal2() {
      this.isModalVisible2 = true;
    },
    closeModal2() {
      this.isModalVisible2 = false;
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
.create-hive i {
  margin-top: -30px;
}
.create-hive img,
.fa-plus {
  cursor: pointer;
}
.create-comb2 {
  display: flex;
  justify-content: flex-end;
}
</style>
