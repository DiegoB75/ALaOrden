<template>
  <v-layout align-start>
    <v-flex>
      <v-container row>
        <v-toolbar flat color="white" md12 xs12 xl12>

          <v-toolbar-title>Catalogo de Productos</v-toolbar-title>
          <v-divider class="mx-2" inset vertical></v-divider>
          <v-spacer></v-spacer>


          <div>{{JSON.stringify(items)}}</div>



          <v-text-field
            class="text-xs-center"
            v-model="search"
            append-icon="search"
            label="Búsqueda"
            hide-details
          ></v-text-field>
        </v-toolbar>
      </v-container>
      <template>
        <v-container fluid grid-list-md>
          <v-data-iterator
            :items="items"
            :rows-per-page-items="rowsPerPageItems"
            :pagination.sync="pagination"
            content-tag="v-layout"
            row
            wrap
          >
            <template v-slot:item="props">
              <v-flex
                xs12
                sm6
                md4
                lg3
              >

                <v-card>
                  <v-list dense>
                    <v-card-title primary-title>
                      <div>
                        <v-img
                          :src="'img/products/'+props.item.imagen"
                          aspect-ratio="2.75"
                          width="200px"
                          height="150px"
                        ></v-img>

                        <h2 class="headline mb-0">
                          {{ props.item.marca.nombre.toUpperCase() + " " + props.item.nombre}}
                        </h2>

                        <h4 class="headline mb-0">
                          {{ props.item.presentacion + " x" + props.item.cantidad + ": " + props.item.magnitud + props.item.unidad }}
                        </h4>

                        <v-text-field v-model="quantity" type="number" label="Quantity" :rules="quantityRules"></v-text-field>
                        <a click="agregarCarrito">agregar a carrito</a>

                      </div>
                    </v-card-title>
                  </v-list>
                </v-card>

              </v-flex>
            </template>


          </v-data-iterator>
        </v-container>
      </template>
    </v-flex>
  </v-layout>

</template>
<script>
  import ProductCard from "./ProductCard.vue";
  import axios from 'axios';
  import {mapActions} from "vuex";

  export default {
    created() {
      this.$store.dispatch('loadProducts',"");
    },
    data() {
      return {
        rowsPerPageItems: [4, 8, 12],
        pagination: {
          rowsPerPage: 4
        },
        search: '',
        quantityRules: [
          v => !!v || 'Number is required',
          v => v >= 0 || 'Number must be greater than 0',
          v => v <= 99 || 'Number must be less than 100'
        ]
      };
    },
    computed: {
      items() { return this.$store.state.results}
    },
    methods: {
      ...mapActions(['loadProducts']),

      controlQuantity(item) {
        let q = parseInt(this.item.cantidad);
        if (q < 0) {
          this.item.cantidad = 0;
        } else if (q > 99) {
          this.item.cantidad = 99;
        }
      },
      validar() {
        let q = parseInt(this.quantity);
        if (q < 0) {
          this.quantity = 0;
        } else if (q > 99) {
          this.quantity = 99;
        }
      }

    },
    components: {
      "card-product": ProductCard
    }
  };

  /*let title = results.length === 0 ?
        (<h5>No se han encontrado coincidencias a su busqueda</h5>) :
        (<h5>Mostrando: {results.length} de {"x"} </h5>);

      return (
        <div>
          {title}
          <div className="grid-container">
            {results.map((x, i) => <ProductCard key={i} index={i}/>)}
          </div>
        </div>
      );*/
</script>
