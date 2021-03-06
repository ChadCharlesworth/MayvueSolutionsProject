import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    motionPictures: []
  },
  mutations: {
    LOAD_PICTURES(state, motionPicture) {
      state.motionPictures.push(motionPicture);
    },
    
  },
  actions: {
  },
  modules: {
  }
})
