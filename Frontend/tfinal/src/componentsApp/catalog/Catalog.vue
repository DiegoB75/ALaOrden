<template>
<v-layout align-start>
  <v-container>
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
  </v-container>
        <v-container >
    <div class="ml-3 mr-3 mt-3 mb-3" md3 v-for="(product, index) in items" :key="`${index}`" :search="search">
        <card-product></card-product>
    </div>

  </v-container>
</v-layout>
  
</template>
<script>
import ProductCard from "./ProductCard.vue";
export default {
  data() {
    return {
      items: [{ id: 1 }, { id: 2 }, { id: 3 }],
      rowsPerPageItems: [4, 8, 12],
      pagination: {
        rowsPerPage: 4
      },
      search:''
    };
  },
  methods: {},
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
