import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    privateKeeps: [],
    vaults: [],
    vaultKeeps: [],
    activeVault: {},
    activeKeep: {}
  },
  mutations: {
    setPrivateKeeps(state, keep) {
      state.privateKeeps.push(keep);
    },
    addKeep(state, keep) {
      state.publicKeeps.push(keep);
    },
    setPublicKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
    addVault(state, vault) {
      state.vaults.push(vault);
    },
    setVaults(state, vaults) {
      state.vaults = vaults;
    },
    setActiveVault(state, vault) {
      state.activeVault = vault;
    },
    setActiveKeep(state, keep) {
      state.activeKeep = keep;
    },
    setVaultKeeps(state, vks) {
      state.vaultKeeps = vks;
    },
    addVaultKeep(state, vk) {
      state.vaultKeeps.push(vk);
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    //#region --Keep Functions--
    async addKeep({ commit, dispatch }, newKeep) {
      let res = await api.post("keeps", newKeep);
      if (res.data.isPrivate == true) {
        commit("setPrivateKeeps", res.data);
      } else {
        commit("addKeep", res.data);
      }
    },
    async getPublicKeeps({ commit, dispatch }) {
      let res = await api.get("keeps");
      commit("setPublicKeeps", res.data);
    },
    async getKeepsByVaultId({ commit, dispatch }, id) {
      let res = await api.get("vaultkeeps/" + id + "/keeps");
      commit("setVaultKeeps", res.data);
    },
    async addCount({ commit, dispatch }, update) {
      let res = await api.put("keeps/" + update.id + "/keeps", update);
      commit("setActiveKeep", res.data);
    },
    async deleteKeep({ commit, dispatch }, id) {
      await api.delete("keeps/" + id);
    },
    //#endregion
    //#region --Vault Functions--
    async addVault({ commit, dispatch }, newVault) {
      let res = await api.post("vaults", newVault);
      commit("addVault", res.data);
    },
    async getVaults({ commit, dispatch }) {
      let res = await api.get("vaults");
      commit("setVaults", res.data);
    },
    async getVaultById({ commit, dispatch }, id) {
      let res = await api.get("vaults/" + id);
      commit("setActiveVault", res.data);
    },
    async deleteVault({ commit, dispatch }, id) {
      await api.delete("vaults/" + id);
    },
    //#endregion
    //#region --VaultKeep Functions--
    async createVaultKeep({ commit, dispatch }, newData) {
      let res = await api.post("vaultkeeps", newData);
      commit("addVaultKeep", res.data);
    },
    async getVaultKeeps({ commit, dispatch }, vaultId) {
      let res = await api.get("vaultkeeps/" + vaultId + "/keeps");
      commit("setVaultKeeps", res.data);
    },
    async deleteVaultKeep({ commit, dispatch }, ids) {
      await api.delete("vaultkeeps/" + ids.vaultId + "/keeps/" + ids.keepId);
    }
    //#endregion
  }
});
