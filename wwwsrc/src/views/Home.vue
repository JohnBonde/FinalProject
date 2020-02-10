<template>
  <div class="home container-fluid">
    <h1>BeeKeepr</h1>
    <div class="row">
      <div class="col"></div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>
<style scoped>
/* Hexagons */
.hex-container {
  overflow: hidden;
}
.hex-grid {
  list-style: none;
  margin: 0;
  padding: 0;
  width: 5000px;
}
.hex-grid__item {
  float: left;
  height: 252.59px;
  width: calc(100vw / 6);
  -webkit-clip-path: polygon(
    50% 0%,
    100% 25%,
    100% 75%,
    50% 100%,
    0% 75%,
    0% 25%
  );
  clip-path: polygon(50% 0%, 100% 25%, 100% 75%, 50% 100%, 0% 75%, 0% 25%);
  border-left: 4px solid #fff;
  border-right: 4px solid #fff;
  -webkit-transform: translateZ(0);
  transform: translateZ(0);
  background-color: blue;
}
.hex-grid__item:hover {
  opacity: 0.4;
}

@media (max-width: 768px) {
  .hex-grid {
    width: 100%;
  }
}

@media (min-width: 1200px) {
  .hex-grid__item {
    border-left: 4px solid #fff;
    border-right: 4px solid #fff;
  }
}

@media (max-width: 768px) {
  .hex-grid__item {
    width: calc(100vw / 2);
    margin-bottom: calc(100vw / -7.5);
  }

  .hex-grid__item:nth-child(3n + 1) {
    margin-left: calc(100vw / 4);
    clear: left;
    opacity: 0.4;
  }

  .hex-grid__item:nth-child(3n + 1):last-child {
    margin-bottom: 0;
  }
}

@media (min-width: 768px) {
  .hex-grid__item:nth-child(7),
  .hex-grid__item:nth-child(14) {
    clear: left;
  }

  .hex-grid__item:nth-child(1),
  .hex-grid__item:nth-child(6),
  .hex-grid__item:nth-child(7),
  .hex-grid__item:nth-child(13),
  .hex-grid__item:nth-child(14),
  .hex-grid__item:nth-child(19) {
    opacity: 0.4;
    z-index: -1;
  }

  .hex-grid__item:nth-child(n + 7):nth-child(-n + 13) {
    position: relative;
    left: -105px;
    left: calc(100vw / -12);
    top: -58px;
    top: calc(100vw / -24);
    margin-bottom: -111px;
    margin-bottom: calc(100vw / -12);
  }
}
</style>
