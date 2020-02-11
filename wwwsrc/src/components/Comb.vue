<template>
  <li class="hex comb">
    <div class="hexIn">
      <a class="hexLink img" :style="{ backgroundImage: 'url('+ combData.img +')' }">
        <h1 id="demo1">{{combData.name}}</h1>
        <p id="demo2">{{combData.description}}</p>
      </a>
    </div>
  </li>
</template>

<script>
export default {
  name: "comb",
  props: ["combData"]
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
