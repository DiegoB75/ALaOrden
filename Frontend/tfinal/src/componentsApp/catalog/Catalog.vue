<template>
    <div v-if="results.length>0">
        <h1>YES</h1>
    </div>
    <div v-else>
        <v-container fluid grid-list-md>
    <v-data-iterator
      :items="items"
      :rows-per-page-items="rowsPerPageItems"
      :pagination.sync="pagination"
      content-tag="v-layout"
      row
      wrap
    >
      </v-data-iterator>
  </v-container>
    </div>
</template>
<script>
  export default {
    data() {
    return {
     results:[{id:1},{id:2},{id:3}]
    }},
    methods:{

    }
  }

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