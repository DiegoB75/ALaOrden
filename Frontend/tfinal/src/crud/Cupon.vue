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
          <v-btn slot="activator" color="primary" dark class="mb-2" @click.native="nuevoItem">Nuevo</v-btn>
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
                    <v-date-picker v-model="fechaEmision"></v-date-picker>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                   <v-date-picker v-model="fechaExpiracion" ></v-date-picker>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-checkbox
                      v-model="vigente"
                      :label="`Vigente: ${show2.toString()}`" :readonly="!show2"
                    ></v-checkbox>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="descuento" label="Descuento"></v-text-field>
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
            <v-icon small class="mr-2" @click="deleteItem(props.item)">delete</v-icon>
          
          </td>
          <td>{{ props.item.codigo }}</td>
          <td>{{ props.item.fechaEmision }}</td>
          <td>{{ props.item.fechaExpiracion }}</td>
          <td>{{ props.item.vigente }}</td>
          <td>{{ props.item.descuento }}</td>
          <td>{{ props.item.idPedido }}</td>
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
      pedidos:[],
      show2:false,
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Codigo", value: "codigo", sortable: true },
        { text: "Fecha de Emision", value: "fechaemision", sortable: true },
        { text: "Fecha de Expriacion", value: "fechaexpiracion", sortable: true },
        { text: "Vigente", value: "vigente", sortable: true },
        { text: "Descuento", value: "descuento", sortable: true },
        { text: "Pedido", value: "idPedido", sortable: true }
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      idCupon:"",
      codigo:"",
      fechaEmision:new Date().toISOString().substr(0, 10),
      fechaExpiracion:new Date().toISOString().substr(0, 10),
      vigente:"",
      descuento:"",
      idPedido:null
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
    this.listar();
  },
  methods: {
    listar() {
      //TODO
      let me=this;
     axios
        .get("api/cupon")
        .then(function(response) {
          //console.log(response);
          me.cupones = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    editItem(item) {
      //TODO
      this.show2=true;
      this.dialog = true;
      this.idCupon = item.idCupon;
      this.codigo = item.codigo;
      this.fechaEmision = item.fechaEmision;
      this.fechaExpiracion = item.fechaExpiracion;
      this.vigente = item.vigente;
      this.descuento = item.descuento;
      this.editedIndex = 1;
    },
    close() {
      this.dialog = false;
    },nuevoItem(){
      this.show2 = false;
      this.editedIndex = -1;
    },
    limpiar() {
      this.idCupon = "";
      this.codigo = "";
      this.fechaEmision = "";
      this.fechaExpiracion = "";
      this.vigente = "";
      this.descuento = "";
      this.idPedido = "";
      this.editedIndex = -1;
    },
    guardar() {
     //TODO
     if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/cupon/"+me.idCupon, {
            idCupon: me.idCupon,
            codigo:me.codigo,
            fechaEmision:me.fechaEmision,
            fechaExpiracion:me.fechaExpiracion,
            vigente:me.vigente,
            descuento:me.descuento,
            idPedido:null
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
          .post("api/cupon", {
            codigo:me.codigo,
            fechaEmision:me.fechaEmision,
            fechaExpiracion:me.fechaExpiracion,
            vigente:me.vigente,
            descuento:me.descuento,
            idPedido:null
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
