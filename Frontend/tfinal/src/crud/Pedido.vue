<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Pedidos</v-toolbar-title>
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
                    <v-autocomplete
                      v-model="idUsuario"
                      :items="usuarios"
                      item-text="apodo"
                      item-value="idUsuario"
                    >
                    </v-autocomplete>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-autocomplete
                      v-model="idSede"
                      :items="sedes"
                      item-text="idSede"
                      item-value="idSede"
                    >
                    </v-autocomplete>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="estado" label="Estado"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                   <v-date-picker v-model="fecha" ></v-date-picker>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="direccion" label="Direccion"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-autocomplete
                      v-model="idTransaccion"
                      :items="transacciones"
                      item-text="idTransaccion"
                      item-value="idTransaccion"
                    >
                    </v-autocomplete>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="subtotal" label="SubTotal"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="precioenvio" label="Precio de Envio"></v-text-field>
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
      <v-data-table :headers="headers" :items="pedidos" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
            <v-icon small class="mr-2" @click="deleteItem(props.item)">delete</v-icon>
          </td>
          <td>{{ props.item.usuario.apodo }}</td>
          <td>{{ props.item.sede.idSede }}</td>
          <td>{{ props.item.estado }}</td>
          <td>{{ props.item.fecha }}</td>
          <td>{{ props.item.direccion }}</td>
          <td>{{ props.item.transaccion.idTransaccion }}</td>
          <td>{{ props.item.subtotal }}</td>
          <td>{{ props.item.precioenvio }}</td>
          <td>{{ props.item.descuento }}</td>
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
      usuarios: [],
      sedes:[],
      transacciones:[],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Usuario", value: "usuario", sortable: true },
        { text: "Sede", value: "sede", sortable: true },
        { text: "Estado", value: "estado", sortable: true },
        { text: "Fecha", value: "fecha", sortable: true },
        { text: "Direccion", value: "direccion", sortable: true },
        { text: "Transaccion", value: "transaccion", sortable: true },
        { text: "SubTotal", value: "subtotal", sortable: true },
        { text: "Precio de envio", value: "precioenvio", sortable: true },
        { text: "Descuento", value: "descuento", sortable: true }
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      idPedido:"",
      usuario:"",
      sede:"",
      estado:"",
      fecha:new Date().toISOString().substr(0,10),
      direccion:"",
      transaccion:"",
      subtotal:"",
      precioenvio:"",
      descuento:"",

    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Pedido" : "Actualizar Pedido";
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
        .get("api/pedido")
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
      this.idPedido = item.idPedido;
      this.usuario = item.usuario;
      this.sede = item.sede;
      this.estado = item.estado;
      this.fecha = item.fecha;
      this.direccion = item.direccion;
      this.transaccion = item.transaccion;
      this.subtotal = item.subtotal;
      this.precioenvio = item.precioenvio;
      this.descuento = item.descuento;
      this.dialog = true;
      this.editedIndex = 1;
    },
    nuevoItem(){
      let me = this;
      this.editedIndex = -1;
      axios
        .get("api/usuario")
        .then(function(response) {
          //console.log(response);
          me.usuarios = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
      axios
        .get("api/sede")
        .then(function(response) {
          //console.log(response);
          me.sedes = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
        axios
        .get("api/transaccion")
        .then(function(response) {
          //console.log(response);
          me.transacciones = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    close() {
      this.dialog = false;
    },
    limpiar() {
      this.idPedido = "";
      this.usuario = "";
      this.sede = "";
      this.estado = "";
      this.fecha = "";
      this.direccion = "";
      this.transaccion = "";
      this.subtotal = "";
      this.precioenvio = "";
      this.descuento = "";
    },
    deleteItem(item){
        let me = this;

        axios
        .delete("api/pedido/"+item.idPedido)
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
          .put("api/pedido/"+me.idPedido, {
            idPedido: me.idPedido,
            idUsuario:me.idUsuario,
            idSede:me.idSede,
            estado:me.estado,
            fecha:me.fecha,
            direccion: me.direccion,
            idTransaccion:me.idTransaccion,
            subtotal:me.subtotal,
            precioenvio:me.precioenvio,
            descuento:me.descuento
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
          .post("api/pedido", {
            idUsuario:me.idUsuario,
            idSede:me.idSede,
            estado:me.estado,
            fecha:me.fecha,
            direccion: me.direccion,
            idTransaccion:me.idTransaccion,
            subtotal:me.subtotal,
            precioenvio:me.precioenvio,
            descuento:me.descuento
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
