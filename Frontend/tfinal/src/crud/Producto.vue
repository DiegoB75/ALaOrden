<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Productos</v-toolbar-title>
        <v-divider class="mx-2" inset vertical></v-divider>
        <v-spacer></v-spacer>
        <v-text-field
          class="text-xs-center"
          v-model="search"
          append-icon="search"
          label="Búsqueda"
          single-line
          hide-details
        ></v-text-field>
        <v-spacer></v-spacer>
        <v-dialog v-model="dialog" max-width="500px">
          <v-btn slot="activator" color="primary" dark class="mb-2">Nuevo</v-btn>
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container grid-list-md>
                <v-layout wrap>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="categoria" label="Categoria"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="marca" label="Marca"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="nombre" label="Nombre"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="presentacion" label="Presentacion"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="cantidad" label="Cantidad"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="magnitud" label="Magnitud"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="unidad" label="Unidad"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="descripcion" label="Descripcion"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="imagen" label="Imagen"></v-text-field>
                  </v-flex>
                </v-layout>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
              <v-btn color="blue darken-1" flat @click.native="guardar">Guardar</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
      <v-data-table :headers="headers" :items="productos" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>{{ props.item.categoria }}</td>
          <td>{{ props.item.marca }}</td>
          <td>{{ props.item.nombre }}</td>
          <td>{{ props.item.presentacion }}</td>
          <td>{{ props.item.cantidad }}</td>
          <td>{{ props.item.magnitud }}</td>
          <td>{{ props.item.unidad }}</td>
          <td>{{ props.item.descripcion }}</td>
          <td>{{ props.item.imagen }}</td>
        </template>
        <template slot="no-data">
          <v-btn color="primary" @click="listar">Resetear</v-btn>
        </template>
      </v-data-table>
    </v-flex>
  </v-layout>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      productos: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Categoria", value: "categoria", sortable: true },
        { text: "Marca", value: "marca", sortable: true },
        { text: "Nombre", value: "nombre", sortable: true },
        { text: "Presentacion", value: "presentacion", sortable: true },
        { text: "Cantidad", value: "cantidad", sortable: true },
        { text: "Magnitud", value: "magnitud", sortable: true },
        { text: "Unidad", value: "unidad", sortable: true },
        { text: "Descripcion", value: "descripcion", sortable: false },
        { text: "Imagen", value: "imagen", sortable: false }
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      

    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Producto" : "Actualizar Producto";
    }
  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },

  created() {
    //TODO

  },
  methods: {
    listar() {
      //TODO
    },
    editItem(item) {
      //TODO
    },
    close() {
      this.dialog = false;
    },
    limpiar() {
      this.id = "";
      this.categoria = "";
      this.marca = "";
      this.nombre = "";
      this.presentacion = "";
      this.cantidad = "";
      this.magnitud = "";
      this.unidad = "";
      this.descripcion = "";
      this.imagen = "";
    },
    guardar() {
     //TODO
    }
  }
};
</script>
