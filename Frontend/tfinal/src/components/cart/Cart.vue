<template>
  <div class="text-xs-center">
    <v-menu
      v-model="menu"
      :close-on-content-click="false"
      :nudge-width="200"
      offset-x
    >
      <template v-slot:activator="{ on }">
        <v-btn large color="orange" dark v-on="on">
          Carrito
          <v-badge overlap>
            <template v-slot:badge v-if="cart.length > 0">
              <span>{{cart.length}}</span>
            </template>
            <v-icon
              color="white lighten-1"
            >
              shopping_cart
            </v-icon>
          </v-badge>
        </v-btn>
      </template>

      <v-card>
        <v-list three-line>
          <v-subheader>Resumen de compra</v-subheader>
          <v-divider></v-divider>

          <v-list-tile v-for="(item, index) in cart" :key="index">

<!--            <v-layout>
              <v-flex>
                <v-img :src="'img/products/'+item.producto.imagen" />
              </v-flex>
              <v-flex>
                <v-layout>
                  {{ item.producto.marca.nombre.toUpperCase() + " " + item.producto.nombre}}
                </v-layout>
                <v-layout>
                  {{ item.producto.presentacion + " x" + item.producto.cantidad + ": " + item.producto.magnitud + item.producto.unidad }}
                </v-layout>
                <v-layout>
                  <v-input append-icon="add" prepend-icon="remove">{{item.cantidad}}</v-input>
                </v-layout>
              </v-flex>
            </v-layout>-->


            <v-list-tile-avatar tile>
              <v-img :src="'img/products/'+item.producto.imagen" />
            </v-list-tile-avatar>

            <v-list-tile-content>
              <v-list-tile-title>
                {{ item.producto.marca.nombre.toUpperCase() + " " + item.producto.nombre}}
              </v-list-tile-title>
              <v-list-tile-sub-title>
                {{ item.producto.presentacion + " x" + item.producto.cantidad + ": " + item.producto.magnitud + item.producto.unidad }}
              </v-list-tile-sub-title>
            </v-list-tile-content>
            <v-spacer></v-spacer>
            <v-list-tile-action>
              <v-text-field v-model="item.cantidad" style="width: 20px;"
                            append-icon="add" prepend-icon="remove"></v-text-field>
            </v-list-tile-action>
            <v-list-tile-action>
              <v-btn icon ripple>
                <v-icon color="red lighten-1">delete</v-icon>
              </v-btn>
            </v-list-tile-action>
          </v-list-tile>
        </v-list>
        <v-card-actions>
          <v-btn v-if="!ordering" :disabled="cart.length === 0" color="secondary"  block flat @click="">Iniciar Compra</v-btn>
          <v-btn v-else block flat @click="gaa">Cancelar</v-btn>
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
        hints: true,
      }
    },
    computed: {
      ordering() { return this.$store.state.ordering },
      cart() { return this.$store.state.cart }

    },
    methods: {
      gaa() {
        this.cart.push({id: 2});
      }
    },
    components: {
      'cart-item': CartItem
    }
  }
</script>