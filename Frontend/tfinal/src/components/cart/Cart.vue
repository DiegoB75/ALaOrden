<template>
  <div class="text-xs-center">
    <v-menu offset-y>
      <template v-slot:activator="{ on }">
        <v-btn
           color="primary"
           dark
           v-on="on"
        >
          Dropdown
        </v-btn>
      </template>
      <v-list>
        <v-list-tile
                v-for="(item, index) in items"
                :key="index"
                @click=""
        >
          <v-list-tile-title>{{ item.title }}</v-list-tile-title>
        </v-list-tile>
      </v-list>
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
        gaa(){
            this.cart.push({id:2});
        }
    },
    components: {
    'cart-item': CartItem
  }
  }
</script>