<template>
    <v-data-table :headers="headers" :items="proforma" class="elevation-1">
            <template v-slot:items="props">
              <td>{{ props.item.producto.marca.nombre + " " + props.item.producto.nombre }}</td>
              <td class="text-xs-right">{{ props.item.precio }}</td>
              <td class="text-xs-right">{{ props.item.cantidad }}</td>
              <td class="text-xs-right">{{ props.item.precio * props.item.cantidad }}</td>
            </template>
          </v-data-table>
</template>
<script>
export default {
    data() {
        return {
        }
    },
    computed: {

    }
}
</script>
