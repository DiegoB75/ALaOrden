<template>
 <v-card>
            <v-list dense>
              <v-card-title primary-title >
          <div>
            <v-img
             src="https://cdn.vuetifyjs.com/images/cards/desert.jpg"
             aspect-ratio="2.75"
             width="200px"
             height="150px"
            ></v-img>
          
            <h3 class="headline mb-0">{{producto.nombre}}</h3>
         
          <v-text-field v-model="quantity" type="number" label="Quantity" :rules="quantityRules"></v-text-field>
          <a>eliminar</a>
           
          </div>
        </v-card-title>
            </v-list>
          </v-card>
</template>
<script>
import Catalog from './Catalog.vue';
  export default {
    props:['producto'],
    data() {
    return {
     quantity:0,
      quantityRules: [
        v => !!v || 'Number is required',
        v => v >= 0 || 'Number must be greater than 0',
        v => v <= 99 || 'Number must be less than 100'
      ]
    }},
    methods:{
      validar(){
        let q = parseInt(this.quantity);
        if(q < 0){
          this.quantity = 0;
        }else if(q > 99){
          this.quantity = 99;
        }
      }
    },
    watch:{
        quantity(){
          this.validar();
        }
    },  components: {
    Catalog,
  },
  }

</script>