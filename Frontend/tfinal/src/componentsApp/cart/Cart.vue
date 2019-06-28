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
          color="indigo"
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
            <cart-item v-for="(cartitem, index) in cart" :key="`fruit-${index}`"></cart-item>
        </v-list>

        <v-card-actions>
          <v-spacer></v-spacer>

          <v-btn flat @click="menu = false">Cancel</v-btn>
          <v-btn color="primary" flat @click="gaa">Save</v-btn>
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
      ,cart:[{id:1},{id:2},{id:3},{id:4}]
    }},
    methods:{
        gaa(){
            this.cart.push({id:2});
        }
    },
    components: {
    'cart-item': CartItem
  }
  }
</script>