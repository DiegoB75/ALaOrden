<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Producto por Franquicia</v-toolbar-title>
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
          <v-btn slot="activator" color="primary" dark class="mb-2" @click.native="nuevoItem" >Nuevo</v-btn>
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container grid-list-md>
                <v-layout wrap>
                  <v-flex xs12 sm12 md12>
                    <v-autocomplete
                      v-model="idProducto"
                      :items="productos"
                      item-text="nombre"
                      item-value="idProducto"
                    >
                    </v-autocomplete>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-autocomplete
                      v-model="idFranquicia"
                      :items="franquicias"
                      item-text="nombre"
                      item-value="idFranquicia"
                    >
                    </v-autocomplete>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="codreferencia" label="Codigo de referencia"></v-text-field>
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
      <v-data-table :headers="headers" :items="usuarios" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
            <v-icon small class="mr-2" @click="deleteItem(props.item)">delete</v-icon>
          </td>
          <td>{{ props.item.producto.nombre }}</td>
          <td>{{ props.item.franquicia.nombre }}</td>
          <td>{{ props.item.codreferencia }}</td>
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
      productos:[],
      productofranquicias: [],
      franquicias:[],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Producto", value: "producto" },
        { text: "Franquicia", value: "franquicia"},
        { text: "Codigo de referencia", value: "codreferencia"  },
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      producto:"",
      franquicia:"",
      codreferencia:"",
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Producto Franquicia" : "Actualizar Producto Franquicia";
    }
  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },

  created() {
    //TODO
    this.listar();
  },
  methods: {
    listar() {
      //TODO
      let me = this;

      axios
        .get("api/detallefranquicia")
        .then(function(response) {
          //console.log(response);
          me.productofranquicias = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    editItem(item) {
      //TODO
      this.producto = item.producto;
      this.franquicia = item.franquicia;
      this.codreferencia = item.codreferencia;
      this.dialog = true;
      this.editedIndex = 1;
    },
    nuevoItem(){
      let me = this;
      this.editedIndex = -1;
      axios
        .get("api/producto")
        .then(function(response) {
          //console.log(response);
          me.productos = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
      axios
        .get("api/franquicia")
        .then(function(response) {
          //console.log(response);
          me.franquicias = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    close() {
      this.dialog = false;
    },
    limpiar() {
      this.producto = "";
      this.franquicia = "";
      this.codreferencia = "";
    },
    deleteItem(item){
        let me = this;

        axios
        .delete("api/detallefranquicia/"+item.franquicia+"/"+item.producto)
        .then(function(response) {
          //console.log(response);
          me.close();
          me.listar();
          me.limpiar();
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    guardar() {
     if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/detallefranquicia/"+me.franquicia+"/"+me.producto, {
            producto: me.producto,
            franquicia: me.franquicia,
            codreferencia: me.codreferencia
          })
          .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
          })
          .catch(function(error) {
            console.log(error);
          });
      } else {
        //Código para guardar
        let me = this;
        axios
          .post("api/detallefranquicia", {
            producto: me.producto,
            franquicia: me.franquicia,
            codreferencia: me.codreferencia
          })
          .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
          })
          .catch(function(error) {
            console.log(error);
          });
      }
    }
  }
};
</script>
