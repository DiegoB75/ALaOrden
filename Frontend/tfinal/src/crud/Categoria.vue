<!--REVISAR CATEGORIA POR COMPLETO, RECURSIVIDAD -->
<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Categorias</v-toolbar-title>
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
          <v-btn slot="activator" color="primary" dark class="mb-2" @click.native="nuevoItem">Nuevo</v-btn>
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container grid-list-md>
                <v-layout wrap>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="nombre" label="Nombre"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-autocomplete
                      v-model="idCategoriaPadre"
                      :items="categorias"
                      item-text="nombre"
                      item-value="idCategoriaPadre"
                    >
                    </v-autocomplete>
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
      <v-data-table :headers="headers" :items="categorias" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
            <v-icon small class="mr-2" @click="deleteItem(props.item)">delete</v-icon>
          </td>
          <td>{{ props.item.nombre }}</td>
          <td>{{ props.item.idcategoriapadre }}</td>
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
      categorias: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Nombre", value: "nombre", sortable: true },
        { text: "Categoria Padre", value: "categoriapadre", sortable: true }
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      idCategoria:"",
      nombre:"",
      idCategoriaPadre:""

    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nueva Categoria" : "Actualizar Categoria";
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
      let me = this;
      axios
        .get("api/categoria")
        .then(function(response){
          //console.log(response);
          me.categorias = response.data;
        })
        .catch(function(error){
          console.log(error);
        });
    },
    editItem(item) {
      //TODO
      this.idCategoria = item.idCategoria;
      this.nombre = item.nombre;
      this.idCategoriaPadre = item.idCategoriaPadre;
      this.dialog = true;
      this.editedIndex = 1;
    },
    close() {
      this.dialog = false;
    },
    nuevoItem(){
      let me = this;
      this.editedIndex = -1;
      axios
        .get("api/categoria")
        .then(function(response) {
          //console.log(response);
          me.categorias = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    limpiar() {
      this.idCategoria = "";
      this.nombre = "";
      this.idCategoriaPadre= "";
    },
    deleteItem(item){
        let me = this;

        axios
        .delete("api/categoria/"+item.idCategoria)
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
     //TODO
      if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/categoria/"+me.idCategoria, {
            idCategoria: me.idCategoria,
            nombre: me.nombre,
            idCategoriaPadre: me.idCategoriaPadre
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
          .post("api/categoria", {
            nombre: me.nombre,
            idCategoriaPadre: me.idCategoriaPadre
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
