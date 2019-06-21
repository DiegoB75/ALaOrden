<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Detalle Pedido</v-toolbar-title>
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
                    <v-text-field v-model="pedido" label="Pedido"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="producto" label="Producto"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="precio" label="Precio"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="cantidad" label="Cantidad"></v-text-field>
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
      <v-data-table :headers="headers" :items="detallepedidos" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>{{ props.item.pedido }}</td>
          <td>{{ props.item.producto }}</td>
          <td>{{ props.item.precio }}</td>
          <td>{{ props.item.cantidad }}</td>
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
      detallepedidos: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Pedido", value: "pedido", sortable: true },
        { text: "Producto", value: "producto", sortable: true },
        { text: "Precio", value: "precio", sortable: true },
        { text: "Cantidad", value: "cantidad", sortable: true }
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      

    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Detalle Pedido" : "Actualizar Detalle Pedido";
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
      this.pedido = "";
      this.producto = "";
      this.precio = "";
      this.cantidad = "";
    },
    guardar() {
     //TODO
    }
  }
};
</script>
