<template>
  <div class="container-fluid" id="app">
    <button @click="showForm = !showForm" type="button" class="btn btn-primary">Add</button>
    <picture-table v-show="!showForm" />
    <picture-form v-show="showForm"/>
  </div>
</template>

<script>
import PictureTable from './components/Table.vue'
import PictureForm from './components/Form.vue'
import MotionPictureService from './service/MotionPictureService.js'

export default {
  name: 'App',
  components: {
    PictureTable,
    PictureForm
  },
  created() {
    MotionPictureService.listPictures()
    .then(response => {
      if(response.status == 200) {
        response.data.forEach(picture => {
          this.$store.commit('LOAD_PICTURES', picture);
        })
      }
    })
  },
  data() {
    return {
      showForm: false
    }
  },
  props: {
    showForm: {
      type: Boolean,
      default: false
    }
  }
}
</script>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
