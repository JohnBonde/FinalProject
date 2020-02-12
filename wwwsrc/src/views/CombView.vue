<template>
  <div class="comb-view container-fluid">
    <div class="row content-row">
      <div class="col content">
        <h1>{{comb.name}}</h1>
        <img :src="comb.img" />
        <h3>{{comb.description}}</h3>
      </div>
    </div>
    <div class="row numbers-row">
      <div class="col-4 numbers">
        <i class="fas fa-eye fa-3x">
          <span></span>
          {{comb.views}}
        </i>
        <i class="fas fa-share fa-3x">
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
      <div class="col-4 dropdown">
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
    </div>
  </div>
</template>

<script>
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
      debugger;
      let update = this.comb;
      update.keeps++;
      this.$store.dispatch("addCount", update);
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
.numbers-row,
.drop {
  justify-content: center;
}
.numbers,
.dropdown {
  display: flex;
  justify-content: space-around;
}
.fa-share {
  cursor: pointer;
}
</style>