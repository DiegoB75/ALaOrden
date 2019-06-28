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
          <a>eliminar</a>
          </div>
        </v-card-title>

      
      </v-card>
</template>
<script>
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
      incrementar(){
        this.carrito.cantidad = this.carrito.cantidad + 1;
      },decrementar(){
this.carrito.cantidad = this.carrito.cantidad - 1;
      }
    },created(){
      this.cartItem = this.carrito;
      console.log(this.carrito);
    },
  }
</script>