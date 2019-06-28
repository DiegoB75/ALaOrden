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
            <img :src="'img/franchises/'+proforma.sede.franquicia.logo"/>
          </v-flex>
          <v-flex class="proforma-subtotal">
            <v-chip>{{proforma.subtotal}}</v-chip>
          </v-flex>
        </v-layout>
      </template>
      <v-layout child-flex>
        <v-card>
          <v-data-table :headers="headers" :items="proforma.detallePedido" class="elevation-1">
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
      proformaList = [
        {
          sede: {
            franquicia: {
              nombre: '',
            }
          },
          detallepedido
        }
      ],

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
