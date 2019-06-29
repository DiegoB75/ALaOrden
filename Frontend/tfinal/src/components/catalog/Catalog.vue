<template>
<v-layout align-start>
  <v-flex>
  <v-container row>
 <v-toolbar flat color="white" md12 xs12 xl12>
     
        <v-toolbar-title>Catalogo de Productos</v-toolbar-title>
        <v-divider class="mx-2" inset vertical></v-divider>
        <v-spacer></v-spacer>
        <v-text-field
          class="text-xs-center"
          v-model="search"
          append-icon="search"
          label="Búsqueda"
          hide-details
        ></v-text-field>
      </v-toolbar>
  </v-container >
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
         <card-product product="item"></card-product>
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
export default {
  created(){
      let me = this;
      axios
        .get("api/producto")
        .then(function(response) {
          //console.log(response);
          me.items = response.data;
          console.log(me.items);
        })
        .catch(function(error) {
          console.log(error);
        });
  },
  data() {
    return {
      items: [],
      rowsPerPageItems: [4, 8, 12],
      pagination: {
        rowsPerPage: 4
      },
      search:'',
      quantityRules: [
        v => !!v || 'Number is required',
        v => v >= 0 || 'Number must be greater than 0',
        v => v <= 99 || 'Number must be less than 100'
      ]
    };
  },
  methods: {
    controlQuantity(item){
       let q = parseInt(this.item.cantidad);
        if(q < 0){
         this.item.cantidad = 0;
        }else if(q > 99){
          this.item.cantidad = 99;
        }
      },
 validar(){
        let q = parseInt(this.quantity);
        if(q < 0){
          this.quantity = 0;
        }else if(q > 99){
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
