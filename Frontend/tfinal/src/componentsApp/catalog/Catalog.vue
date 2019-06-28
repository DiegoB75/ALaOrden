<template>
  <v-container fluid grid-list-md>
    <span v-for="(product, index) in items" :key="`${index}`">
        <card-product><h1>AEA</h1></card-product>
    </span>

  </v-container>
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
      }
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