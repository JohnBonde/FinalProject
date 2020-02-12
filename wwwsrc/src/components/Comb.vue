<template>
  <li class="hex comb">
    <div class="hexIn">
      <a
        @click="selectComb"
        class="hexLink img"
        :style="{ backgroundImage: 'url('+ combData.img +')' }"
      >
        <h6 id="demo1">{{combData.name}}</h6>
        <p id="demo2">
          <i class="fas fa-eye">{{combData.views}}</i>
          <br />
          <i class="fas fa-share">{{combData.shares}}</i>
          <br />
          <i class="fas fa-archive">{{combData.keeps}}</i>
        </p>
      </a>
    </div>
  </li>
</template>

<script>
import router from "../router.js";
export default {
  name: "comb",
  props: ["combData"],
  methods: {
    selectComb() {
      debugger;
      this.$store.commit("setActiveKeep", this.combData);
      let update = this.combData;
      update.views++;
      this.$store.dispatch("addCount", update);
      router.push({ path: "/comb", params: { combId: this.combData.id } });
    }
  }
};
</script>

<style>
/*** HEX CONTENT **********************************************************************/
.img {
  left: -100%;
  right: -100%;
  width: auto;
  height: 100%;
  margin: 0 auto;
  -webkit-transform: rotate3d(0, 0, 0, 0deg);
  -ms-transform: rotate3d(0, 0, 0, 0deg);
  transform: rotate3d(0, 0, 0, 0deg);
}
</style>
