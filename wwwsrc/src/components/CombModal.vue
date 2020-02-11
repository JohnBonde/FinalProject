<template id="modal-template">
  <div class="modal-backdrop">
    <div class="modal">
      <header class="modal-header">
        <slot name="header">
          <h3>Create Comb</h3>
          <button type="button" class="btn-close" @click="close">
            <span aria-hidden="true">&times;</span>
          </button>
        </slot>
      </header>
      <section class="modal-body">
        <slot name="body">
          <form class="new-cpmb-form" @submit.prevent="addComb(), close()">
            <div id="name-form">
              <input
                required
                id="title"
                type="text"
                placeholder="Enter comb tile"
                v-model="newComb.name"
              />
              <input
                required
                id="description"
                type="text"
                placeholder="Enter comb description"
                v-model="newComb.description"
              />
              <input
                id="img"
                type="text"
                placeholder="Enter image url"
                v-model="newComb.img"
              />
              <input
                for="isPrivate"
                type="checkbox"
                value="Private"
                v-model="newComb.isPrivate"
              />
              <label for="isPrivate">Make Private</label>
            </div>
            <footer>
              <button type="submit" class="btn btn-success m-1">Submit</button>
              <button type="button" class="btn btn-danger m-1" @click="close">
                Cancel
              </button>
            </footer>
          </form>
        </slot>
      </section>
    </div>
  </div>
</template>

<script>
export default {
  name: "modal",
  data() {
    return {
      newComb: {
        name: "",
        description: "",
        img: "",
        isPrivate: false
      }
    };
  },
  methods: {
    async addComb() {
      let comb = { ...this.newComb };
      this.$store.dispatch("addKeep", comb);
      this.newComb = {
        name: "",
        description: "",
        img: "",
        isPrivate: false
      };
    },
    close() {
      this.$emit("close");
    }
  }
};
</script>
<style>
.modal-backdrop {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: rgba(0, 0, 0, 0.3);
  display: flex;
  justify-content: center;
  align-items: center;
}
.modal {
  background: #ffffff;
  box-shadow: 2px 2px 20px 1px;
  overflow-x: auto;
  display: flex;
  flex-direction: column;
  width: 50vh;
  height: 50%;
  top: 20vh;
  left: 9vw;
}
.modal-header,
.modal-footer {
  padding: 15px;
  display: flex;
}
.modal-header {
  border-bottom: 1px solid #eeeeee;
  color: black;
  justify-content: space-between;
  align-items: baseline;
  height: 9vh;
}
.modal-footer {
  border-top: 1px solid #eeeeee;
  justify-content: flex-end;
}
.modal-body {
  position: relative;
  padding: 20px 10px;
  margin-bottom: 0;
}
.btn-close {
  border: none;
  font-size: 20px;
  padding: 20px;
  cursor: pointer;
  font-weight: bold;
  color: black;
  background: transparent;
}
input {
  width: 101%;
}
label {
  margin-bottom: 2pt;
}
textarea {
  width: 100%;
  height: 8vh;
}
#name-form,
#title-form {
  display: flex;
  flex-direction: column;
  margin-bottom: 12pt;
  margin-top: 0;
}
#name-form {
  padding: 7%;
}
footer {
  display: flex;
  justify-content: flex-end;
}
</style>
