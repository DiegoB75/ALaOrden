<template>
  <v-stepper v-model="st" vertical>
    
    <v-stepper-step :complete="st > 1" step="1">
      Seleccione dirección de envio
    </v-stepper-step>
    <v-stepper-content step="1">
      <router-view>
        
      </router-view>
    </v-stepper-content>

    <v-stepper-step :complete="st > 2" step="2">
      Elejir lugar de compra
    </v-stepper-step>
    <v-stepper-content step="2">
      <!-- QUOTATION --->
    </v-stepper-content>

    <v-stepper-step :complete="st > 3" step="3">
      Realizar pago
    </v-stepper-step>
    <v-stepper-content step="3">
      <!-- PAYMENT -->
    </v-stepper-content>

  </v-stepper>
</template>
<script>
  export default {
    data () {
      return {
        st: this.$store.state.step
      }
    }
  }
</script>