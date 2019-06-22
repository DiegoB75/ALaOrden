<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Franquicias</v-toolbar-title>
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
          <v-btn slot="activator" color="primary" dark class="mb-2" @click.native="limpiar">Nuevo</v-btn>
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
                    <v-text-field v-model="webUrl" label="Url de la página web"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="apiUrl" label="Url del Api"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="logo" label="Logo"></v-text-field>
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
      <v-data-table :headers="headers" :items="franquicias" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
            <v-icon small class="mr-2" @click="deleteItem(props.item)">delete</v-icon>
          
          </td>
          <td>{{ props.item.nombre }}</td>
          <td>{{ props.item.webUrl }}</td>
          <td>{{ props.item.apiUrl }}</td>
          <td>{{ props.item.logo }}</td>
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
      franquicias: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Nombre", value: "nombre", sortable: true },
        { text: "Url de la página Web", value: "webUrl", sortable: false },
        { text: "Url del api", value: "apiUrl", sortable: false },
        { text: "Logo", value: "logo", sortable: false }
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      idFranquicia:"",
      nombre:"",
      webUrl:"",
      apiUrl:"",
      logo:"",

    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nueva Franquicia" : "Actualizar Franquicia";
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
        .get("api/franquicia")
        .then(function(response) {
          //console.log(response);
          me.franquicias = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    deleteItem(item)
    {
       let me = this;
      axios
        .delete("api/franquicia/"+item.idFranquicia)
        .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    editItem(item) {
      //TODO
      this.editedIndex = 1;
      this.dialog = true;
      this.idFranquicia = item.idFranquicia;
      this.nombre = item.nombre;
      this.webUrl = item.webUrl;
      this.apiUrl = item.apiUrl;
      this.logo = item.logo;
    },
    close() {
      this.dialog = false;
    },
    limpiar() {
      this.idFranquicia = "";
      this.nombre = "";
      this.webUrl = "";
      this.apiUrl = "";
      this.logo = "";
      this.editedIndex = -1;
    },
    guardar() {
         if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/franquicia/"+me.idFranquicia, {
            idFranquicia: me.idFranquicia,
            nombre: me.nombre,
            webUrl:me.webUrl,
            apiUrl:me.apiUrl,
            logo:me.logo
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
          .post("api/franquicia", {
            nombre: me.nombre,
            webUrl:me.webUrl,
            apiUrl:me.apiUrl,
            logo:me.logo
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
