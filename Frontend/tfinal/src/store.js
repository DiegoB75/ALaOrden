import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    authentication:false,
    cartItems:[],
    categories:[],
    results:[],
    user:'',
    direccion:'',

  },
  mutations: {
    SET_AUTHENTICATION(state,user){
      state.user = user;
      state.authentication = true;
    }
  },
  actions: {

  }
})
