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
                      v-model="idCategoria"
                      :items="categorias"
                      item-text="nombre"
                      item-value="idCategoria"
                    >
                    </v-autocomplete>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-autocomplete
                      v-model="idMarca"
                      :items="marcas"
                      item-text="nombre"
                      item-value="idMarca"
                    >
                    </v-autocomplete>
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
            <v-icon small class="mr-2" @click="deleteItem(props.item)">delete</v-icon>
          </td>
          <td>{{ props.item.categoria.nombre }}</td>
          <td>{{ props.item.marca.nombre }}</td>
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
      categorias: [],
      marcas: [],
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
      idProducto:"",
      categoria:"",
      marca:"",
      nombre:"",
      presentacion:"",
      cantidad:"",
      magnitud:"",
      unidad:"",
      descripcion:"",
      imagen:"",
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
    this.listar();
  },
  methods: {
    listar() {
      //TODO
      let me = this;

      axios
        .get("api/producto")
        .then(function(response) {
          //console.log(response);
          me.productos = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    editItem(item) {
      //TODO
      this.idProducto = item.idProducto;
      this.categoria = item.categoria;
      this.marca = item.marca;
      this.nombre = item.nombre;
      this.presentacion = item.presentacion;
      this.cantidad = item.cantidad;
      this.magnitud = item.magnitud;
      this.unidad = item.unidad;
      this.descripcion = item.descripcion;
      this.imagen = item.imagen;
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
      axios
        .get("api/marca")
        .then(function(response) {
          //console.log(response);
          me.marcas = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    limpiar() {
      this.idProducto = "";
      this.idCategoria = "";
      this.idMarca = "";
      this.nombre = "";
      this.presentacion = "";
      this.cantidad = "";
      this.magnitud = "";
      this.unidad = "";
      this.descripcion = "";
      this.imagen = "";
      this.editedIndex = -1;
    },
    deleteItem(item){
        let me = this;

        axios
        .delete("api/producto/"+item.idProducto)
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
          .put("api/producto/"+me.idProducto, {
            idProducto: me.idProducto,
            idCategoria:me.idCategoria,
            idMarca:me.idMarca,
            nombre:me.nombre,
            presentacion:me.presentacion,
            cantidad: me.cantidad,
            magnitud:me.magnitud,
            unidad:me.unidad,
            descripcion:me.descripcion,
            imagen:me.imagen
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
          .post("api/producto", {
            idCategoria:me.idCategoria,
            idMarca:me.idMarca,
            nombre:me.nombre,
            presentacion:me.presentacion,
            cantidad: me.cantidad,
            magnitud:me.magnitud,
            unidad:me.unidad,
            descripcion:me.descripcion,
            imagen:me.imagen
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
