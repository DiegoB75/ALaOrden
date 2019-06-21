<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Cupon</v-toolbar-title>
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
                    <v-text-field v-model="codigo" label="Codigo"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="fechaemision" label="Fecha Emision"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="fechaexpiracion" label="Fecha Expiracion"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="vigente" label="Vigente"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="descuento" label="Descuento"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="pedido" label="Pedido"></v-text-field>
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
      <v-data-table :headers="headers" :items="cupones" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>{{ props.item.codigo }}</td>
          <td>{{ props.item.fechaemision }}</td>
          <td>{{ props.item.fechaexpiracion }}</td>
          <td>{{ props.item.vigente }}</td>
          <td>{{ props.item.descuento }}</td>
          <td>{{ props.item.pedido }}</td>
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
      cupones: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Codigo", value: "codigo", sortable: true },
        { text: "Fecha de Emision", value: "fechaemision", sortable: true },
        { text: "Fecha de Expriacion", value: "fechaexpiracion", sortable: true },
        { text: "Vigente", value: "vigente", sortable: true },
        { text: "Descuento", value: "descuento", sortable: true },
        { text: "Pedido", value: "pedido", sortable: true }
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      

    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Cupon" : "Actualizar Cupon";
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
      this.codigo = "";
      this.fechaemision = "";
      this.fechaexpiracion = "";
      this.vigente = "";
      this.descuento = "";
      this.pedido = "";
    },
    guardar() {
     //TODO
    }
  }
};
</script>
