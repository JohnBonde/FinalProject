<template>
  <div class="comb-view container-fluid">
    <div class="row content-row">
      <div class="col content" style="margin-top: 10px;">
        <h1>{{comb.name}}</h1>
        <img :src="comb.img" />
        <br />
        <h3>{{comb.description}}</h3>
      </div>
    </div>
    <div class="row numbers-row">
      <div class="col-4 numbers">
        <i class="fas fa-eye fa-3x">
          <span></span>
          {{comb.views}}
        </i>
        <i @click="addShare" class="fas fa-share fa-3x">
          <span></span>
          {{comb.shares}}
        </i>
        <i class="fas fa-archive fa-3x">
          <span></span>
          {{comb.keeps}}
        </i>
      </div>
    </div>
    <div class="row drop">
      <div class="col-2 dropdown">
        <div class="btn-group">
          <button
            type="button"
            class="btn btn-danger dropdown-toggle"
            data-toggle="dropdown"
            aria-haspopup="true"
            aria-expanded="false"
          >Add To Hive</button>
          <div class="dropdown-menu" aria-labelledby="btnGroupDrop1">
            <div :hiveData="hive" v-for="hive in hives" :key="hive.id">
              <a class="dropdown-item" @click="addToVault(hive.id);addArchive()">{{hive.name}}</a>
            </div>
          </div>
        </div>
      </div>
      <div class="col-2 delete-comb">
        <button class="btn btn-danger" @click.prevent="deleteComb">Delete Comb</button>
      </div>
      <div class="col-2 delete-vaultkeep">
        <button
          v-if="this.$store.state.activeVault.id != undefined"
          class="btn btn-danger"
          @click.prevent="deleteVaultKeep"
        >Remove from Hive</button>
      </div>
    </div>
  </div>
</template>

<script>
import router from "../router.js";
export default {
  name: "comb-view",
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    comb() {
      return this.$store.state.activeKeep;
    },
    hives() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    addToVault(vId) {
      let newVaultKeep = {
        vaultId: vId,
        keepId: this.comb.id
      };
      this.$store.dispatch("createVaultKeep", newVaultKeep);
    },
    addArchive() {
      let update = this.comb;
      update.keeps++;
      this.$store.dispatch("addCount", update);
    },
    addShare() {
      let update = this.comb;
      update.shares++;
      this.$store.dispatch("addCount", update);
    },
    deleteComb() {
      this.$store.dispatch("deleteKeep", this.$store.state.activeKeep.id);
      router.push({ path: "/" });
    },
    deleteVaultKeep() {
      let ids = {
        vaultId: this.$store.state.activeVault.id,
        keepId: this.comb.id
      };
      this.$store.dispatch("deleteVaultKeep", ids);
    }
  }
};
</script>

<style scoped>
.content {
  display: flex;
  flex-direction: column;
  align-items: center;
}
.numbers-row {
  justify-content: center;
}
.numbers {
  display: flex;
  justify-content: space-around;
}
.drop {
  justify-content: center;
  margin-bottom: 20px;
}
.dropdown,
.delete-comb,
.delete-vaultkeep {
  display: flex;
}
.dropdown {
  justify-content: flex-end;
}
.delete-comb {
  justify-content: center;
}
.delete-vaultkeep {
  justify-content: flex-start;
}
.fa-share {
  cursor: pointer;
}
</style>