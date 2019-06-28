<template>
  <v-container fluid grid-list-md>
    <v-data-iterator
      :items="items"
      :rows-per-page-items="rowsPerPageItems"
      :pagination.sync="pagination"
      content-tag="v-layout"
      hide-actions
      row
      wrap
    >
      <template v-slot:header>
        <v-toolbar
          class="mb-2"
          color="indigo darken-5"
          dark
          flat
        >
          <v-toolbar-title>This is a header</v-toolbar-title>
        </v-toolbar>
      </template>
      <v-layout v-slot:items="props">
        <card-product><h1>AEA</h1></card-product>
      </v-layout>
      <template v-slot:footer>
        <v-toolbar
          class="mt-2"
          color="indigo"
          dark
          dense
          flat
        >
          <v-toolbar-title class="subheading">This is a footer</v-toolbar-title>
        </v-toolbar>
      </template>
    </v-data-iterator>
  </v-container>
</template>

<script>


  export default {
    data: () => ({
      items: [{idCategoria:1,nombre:'mamamia',subCategorias:[]},{idCategoria:2,nombre:'mamamia2',subCategorias:[]}
      ],
    })
  }
</script>