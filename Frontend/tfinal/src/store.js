import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    
    authentication: false,
    user: {},
    
    categories:[],
    results:[],

    cart:[],

    step: 1,

    address: {},
    query: '',

    options: [],
    order: {},

    token: {},
    
  },
  mutations: {
    SET_AUTHENTICATION(state,user){
      state.user = user;
      state.authentication = true;
    },
    //Busqueda
    SET_QUERY(state,query){
      state.query = query;
    },
    //ORDER
    SET_STEP(state,step){
      state.state = step;
    },
    //Direcciones
    SET_ADDRESS(state,address){
      state.address = address;
    },

    //Cotizaciones
    GET_OPTIONS(state,options){
      state.options = options;
    }
  },
  actions: {
    /*Iniciar Sesion*/

    /*Buscar*/

    /*Carrito*/

    /*Direccion*/
    solicitarCotizacion(context, address) {

      context.commit(SET_ADDRESS, address);
      context.commit(SET_STEP,2);

      //TODO: cargar proformas
      let proformas = [];

      context.commit(GET_OPTIONS, proformas);
    },
    /*Cotizaciones*/
    confirmarLugarCompra(context, proforma) { },
    /*Pago*/
  },
  getters: {

  }
})
