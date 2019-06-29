import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import CartManager from "./util/CartManager";


Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    response: '',

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
    //LogIn
    SET_AUTHENTICATION(state,user){
      state.user = user;
      state.authentication = true;
    },
    LOG_OFF(state) {
      state.authentication = false;
      state.user = {};
      state.cart = [];
    },

    //Busqueda
    LOAD_CATEGORIES(state,categories){
      state.categories = categories;
    },
    SET_QUERY(state,query){
      state.query = query;
    },
    LOAD_RESULTS(state,results) {
      state.results = results;
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
    logIn(context,user){
      //validate user
      let rpta = user;

      if (rpta.idUsuario !== null) {
        context.commit(context.mutations.SET_AUTHENTICATION,rpta);
        context.loadCart(context,rpta.idUsuario);
      }
    },

    logOut(context){
      context.commit(context.mutations.LOG_OFF)
    },

    registerAccount(context, params) {

      //armar usuario con params
      let usuario = {
        apodo: '',
        email: '',
        hashContrasena: ''
      };

      axios
        .post("api/usuario/", )
        .then(function(response) {
          context.dispatch('loadCart',item.idUsuario);
        })
        .catch(function(error) {

        });
    },

    /*Buscar*/
    loadProducts(context, params){
      axios
        .get("api/producto")
        .then(function(response) {
          context.commit(context.mutations.LOAD_RESULTS,response.data);
        })
        .catch(function(error) {

        });
    },

    /*Carrito*/
    addCartItem(context, item){
      if (this.state.ordering){
        console.log("no puede agregar productos mientras haya una orden en proceso");
        return;
      }

      if (this.state.authentication){
        axios
          .post("api/carrito/", item)
          .then(function(response) {
            context.dispatch('loadCart',item.idUsuario);
          })
          .catch(function(error) {

          });
      }
      else {
        let cart = CartManager.addToCart(context.state.cart,item);
        context.commit(context.mutations.UPDATE_CART,cart)
      }
    },
    modifyCartItem(context, item){
      if (this.state.ordering){
        console.log("no puede modificar productos mientras haya una orden en proceso");
        return;
      }

      if (this.state.authentication){
        axios
          .put("api/carrito/" + item.idUsuario + "/" + item.idProducto, item )
          .then(function(response) {
            context.dispatch('loadCart',item.idUsuario);
          })
          .catch(function(error) {

          });
      } else {
        let cart = CartManager.updateCart(context.state.cart,item.idProducto,item.cantidad);
        context.commit(context.mutations.UPDATE_CART,cart)
      }
    },

    removeCartItem(context, item){
      if (this.state.ordering){
        console.log("no puede eliminar productos mientras haya una orden en proceso");
        return;
      }

      if (this.state.authentication) {
        axios
          .post("api/carrito", {
            //TODO: CartItem
          })
          .then(function (response) {
            context.dispatch('loadCart', item.idUsuario);
          })
          .catch(function (error) {

          });
      } else {
        let cart = CartManager.removeFromCart(context.state.cart,item.idProducto);
        context.commit(context.mutations.UPDATE_CART,cart)
      }
    },
    loadCart(context, userId){
      if (this.state.authentication){
        axios
          .get("api/carrito/" + userId)
          .then(function(response) {
            context.commit(context.mutations.UPDATE_CART,response.data);
          })
          .catch(function(error) {
          });
      }
    },
    emptyCart(context, userId){

      if (context.state.authentication) {
        axios
          .delete("api/carrito/" + userId)
          .then(function (response) {
            context.commit(context.mutations.UPDATE_CART, []);
          })
          .catch(function (error) {

          });
      } else {
        context.commit(context.mutations.UPDATE_CART,[]);
      }
    },

    /*Direccion*/
    askQuotation(context, address) {
      context.commit(context.mutations.SET_ADDRESS, address);
      //TODO: fetch
      let proformas = [];

      context.commit(context.mutations.GET_OPTIONS, proformas);
    },
    /*Cotizaciones*/
    confirmLocation(context, proforma) {
      context.commit()
    },
    /*Pago*/
  },
  getters: {

  }
})
