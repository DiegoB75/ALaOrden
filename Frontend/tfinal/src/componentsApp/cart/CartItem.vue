<template>
<v-card width="350px">

        <v-card-title primary-title >
          <div>
                    <v-img
          src="https://cdn.vuetifyjs.com/images/cards/desert.jpg"
          
          aspect-ratio="2.75"
          height="70px"
          width="70px"
          style="display: block;"
        ></v-img>
            <h3 style="display: inline;" class="headline mb-0">{{cartItem.producto.nombre}}</h3>
        <v-input   type="number" v-model="cartItem.cantidad"
        click:append="incrementar" click:prepend="decrementar"
         append-icon="add" prepend-icon="remove">{{cartItem.cantidad}} </v-input>
          <a click="eliminar">eliminar</a>
          </div>
        </v-card-title>

      
      </v-card>
</template>
<script>
import { mapActions } from 'vuex'
  export default {
    props:['carrito'],
    data() {
    return {
      fav: true,
      menu: false,
      message: false,
      hints: true
      ,cartItem:''
    }},
    methods:{
      ...mapActions({
        modifyItem: 'modifytItem',
        removeItem: 'removeCartItem'
      }),

      incrementar(){
        this.cartItem.cantidad = this.cartItem.cantidad+1;
          modifyItem(this.cartItem);
      },decrementar(){
          this.cartItem.cantidad = this.cartItem.cantidad-1;
          modifyItem(this.cartItem);
      },eliminar(){
        removeCartItem(this.cartItem.idProducto);
      }
    },created(){
      this.cartItem = this.carrito;
      console.log(this.carrito);
    },
  }
</script>