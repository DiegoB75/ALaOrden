<template>
  <!-- HEADER (eliga producto bla bla...) -->

  <v-container>
    <v-expansion-panel>
    <v-expansion-panel-content :v-for="proforma in proformaList">
      <template v-slot:header>
        <v-layout justify-space-between>
          <v-flex class="franchise-name">
            <div>{{proforma.sede.franquicia.nombre}}</div>
          </v-flex>
          <v-flex class="franchise-logo">
            <img :src="'img/franchises/' + proforma.sede.franquicia.logo"/>
          </v-flex>
          <v-flex class="proforma-subtotal">
            <v-chip>{{proforma.subTotal}}</v-chip>
          </v-flex>
        </v-layout>
      </template>
      <v-layout child-flex>
        <v-card>
          <v-data-table :headers="headers" :items="proforma.detallesPedidos" class="elevation-1">
            <template v-slot:items="props">
              <td>{{ props.item.producto.marca.nombre + " " + props.item.producto.nombre }}</td>
              <td class="text-xs-right">{{ props.item.precio }}</td>
              <td class="text-xs-right">{{ props.item.cantidad }}</td>
              <td class="text-xs-right">{{ props.item.precio * props.item.cantidad }}</td>
            </template>
          </v-data-table>
          <v-card-actions>
            <!--PICK BUTTON-->
            <v-btn flat color="orange">Comprar aquí</v-btn>
          </v-card-actions>
        </v-card>
      </v-layout>
    </v-expansion-panel-content>
  </v-expansion-panel>
  <v-layout>
    <v-flex>
      <v-btn block color="orange">Siguiente</v-btn>
      <v-btn block>Cancelar</v-btn>
    </v-flex>
    <v-flex></v-flex>
  </v-layout>
  </v-container>
</template>
<script>
import logoDir from "../../assets/img/franchises/"
export default {
  data() {
    return {
      proformaList = 
[ {
    "idPedido": 1,
    "idUsuario": 2,
    "usuario": null,
    "idSede": 2,
    "sede": {
        "idSede": 2,
        "direccion": "AV. ABTAO 1260 TDA 101 G, La Victoria 15033, Perú",
        "idFranquicia": 2,
        "franquicia": {
            "idFranquicia": 2,
            "nombre": "jgnfaj",
            "webUrl": "olrgjnog",
            "apiUrl": "wlrgjnwog",
            "logo": "dfbsg",
            "sedes": []
        },
        "longitud": -77.02194693948951,
        "latitud": -12.07354620714524
    },
    "estado": "d",
    "fecha": "2019-03-12T00:00:00",
    "direccion": "agafgdgadf",
    "idTransaccion": 1,
    "transaccion": {
        "idTransaccion": 1,
        "cardNumber": "1251251352513"
    },
    "subTotal": 134,
    "precioEnvio": 1231,
    "descuento": 12,
    "cupones": [],
    "detallesPedidos": [
        {
            "idPedido": 1,
            "idProducto": 11,
            "producto": {
    "idProducto": 11,
    "idCategoria": 13,
    "categoria": {
        "idCategoria": 13,
        "nombre": "etydyhd",
        "idCategoriaPadre": null,
        "categoriaPadre": null,
        "productos": [],
        "subCategorias": null
    },
    "idMarca": 6,
    "marca": {
        "idMarca": 6,
        "nombre": "Oreo",
        "productos": []
    },
    "nombre": "sfa<sf",
    "presentacion": "asfasf",
    "cantidad": 123,
    "magnitud": 241,
    "unidad": "adsfasf",
    "descripcion": "asfasfas",
    "imagen": "asfasfa",
    "productoFranquicias": [
        {
            "idProducto": 11,
            "idFranquicia": 2,
            "franquicia": null,
            "codReferencia": "12"
        }
    ]
},
            "precio": 12,
            "cantidad": 12
        }
    ]
} ],

      headers: [
        {
          text: "Producto",
          align: "left",
          sortable: false
        },
        { text: "Precio unit.", value: "" },
        { text: "Cantidad", value: "" },
        { text: "Precio total", value: "" }
      ]
    };
  },
  computed: {
    
  },
  methods: {

  }
};
</script>
