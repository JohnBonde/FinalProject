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
    vaults: []
  },
  mutations: {
    setPrivateKeeps(state, keep) {
      state.privateKeeps.push(keep);
    },
    setKeep(state, keep) {
      state.publicKeeps.push(keep);
    },
    setPublicKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
    setVault(state, vault) {
      state.vaults.push(vault);
    },
    setVaults(state, vaults) {
      debugger;
      state.vaults = vaults;
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async addKeep({ commit, dispatch }, newKeep) {
      let res = await api.post("keeps", newKeep);
      if (res.data.isPrivate == true) {
        commit("setPrivateKeeps", res.data);
      } else {
        commit("setKeep", res.data);
      }
    },
    async getPublicKeeps({ commit, dispatch }) {
      let res = await api.get("keeps");
      commit("setPublicKeeps", res.data);
    },
    async addVault({ commit, dispatch }, newVault) {
      let res = await api.post("vaults", newVault);
      commit("setVault", res.data);
    },
    async getVaults({ commit, dispatch }) {
      debugger;
      let res = await api.get("vaults");
      commit("setVaults", res.data);
    }
  }
});
