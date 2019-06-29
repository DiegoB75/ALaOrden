import Vue from 'vue'
import Vuex from 'vuex'
import { connect } from 'http2';
import CartManager from './util/CartManager';

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    
    authentication: false,
    user: {},
    
    categories:[],
    results:[],

    cart:[],

    ordering: false,
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

    //Carrito
    UPDATE_CART(state, cart){
      if (state.ordering){
        state.cart = cart;
      }
    },

    //*Orden
    SET_STEP(state,step){
      state.step = step;
    },
    //Direcciones
    SET_ADDRESS(state,address){
      state.address = address;
    },
    ASK_OPTIONS(state,options){
      state.ordering = true;
      state.options = options;
      state.step = 2;
    },

    //Cotizaciones
    SET_ORDER(state,order){
      state.order = order;
    }

  },
  actions: {
    /*Iniciar Sesion*/

    /*Buscar*/

    /*Carrito*/
    addCartItem(context, item){
      if (this.state.ordering){
        console.log("no puede agregar productos mientras haya una orden en proceso");
        return;
      }

      let me = this;
      axios
        .post("api/carrito/", item)
        .then(function(response) {
          me.dispatch('loadCart',item.idUsuario);
        })
        .catch(function(error) {
          
        });
    },
    modifyCartItem(context, item){
      if (this.state.ordering){
        console.log("no puede modificar productos mientras haya una orden en proceso");
        return;
      }

      let me = this;
      axios
        .put("api/carrito/" + item.idUsuario + "/" + item.idProducto, item )
        .then(function(response) {
          me.dispatch('loadCart',item.idUsuario);
        })
        .catch(function(error) {
          
        });
    },
    removeCartItem(context, item){
      if (this.state.ordering){
        console.log("no puede eliminar productos mientras haya una orden en proceso");
        return;
      }

      let me = this;
      axios
        .post("api/carrito", {
          //TODO: CartItem
        })
        .then(function(response) {
          me.dispatch('loadCart',item.idUsuario);
        })
        .catch(function(error) {
          
        });
    },
    loadCart(context, userId){
      let me = this;
      axios
        .get("api/carrito/" + userId)
        .then(function(response) {
          me.commit(UPDATE_CART,response.data);
        })
        .catch(function(error) {
          
        });
    },
    emptyCart(contex, userId){
      axios
        .delete("api/carrito/clear="+userId)
        .then(function(response) {
          me.commit(UPDATE_CART,[]);
        })
        .catch(function(error) {
          
        });
    },

    /*Direccion*/
    solicitarCotizacion(context, address) {
      context.commit(SET_ADDRESS, address);

    
      context.commit(GET_OPTIONS, proformas);
    },
    /*Cotizaciones*/
    confirmarLugarCompra(context, proforma) {
      context.commit()
    },
    /*Pago*/
  },
  getters: {

  }
})
