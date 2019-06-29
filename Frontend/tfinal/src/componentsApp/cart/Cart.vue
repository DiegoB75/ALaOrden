<template>
  <div class="text-xs-center">
    <v-menu
      v-model="menu"
      :close-on-content-click="false"
      :nudge-width="200"
      offset-x
    >
      <template v-slot:activator="{ on }">
        <v-btn
          color="orange darken"
          dark
          v-on="on"
        >
         Carrito  - {{cart.length}} items
        </v-btn>
      </template>

      <v-card>
        <v-list>
          <v-list-tile avatar>
            <v-list-tile-content>
              <v-list-tile-title>Carrito de Compras</v-list-tile-title>
              <v-list-tile-sub-title>Founder of Vuetify.js</v-list-tile-sub-title>
            </v-list-tile-content>
          </v-list-tile>
        </v-list>
        <v-divider></v-divider>

        <v-list>
          <div  v-for="(cartitem, index) in cart" :key="`fruit-${index}`">
            <cart-item :carrito = "cartitem"></cart-item>
          </div>
        </v-list>

        <v-card-actions class="text-center">
          <v-spacer></v-spacer>

          <v-btn color="primary" flat @click="procesarPago">Procesar Pago</v-btn>
        </v-card-actions>
      </v-card>
    </v-menu>
  </div>
</template>
<script>
import CartItem from './CartItem';
  export default {
    data() {
    return {
      fav: true,
      menu: false,
      message: false,
      hints: true
      ,cart:[
        {producto:{idProducto:1,nombre:'Agua Mineral'},marca:{idMarca:1,nombre:'San Luis'},cantidad:18}
      ]
    }},
    methods:{
        procesarPago(){
            this.cart.push({producto:{idProducto:1,nombre:'Galleta Oreo'},marca:{idMarca:1,nombre:'San Luis'},cantidad:10});
        }
    },
    components: {
    'cart-item': CartItem
  }
  }
</script>