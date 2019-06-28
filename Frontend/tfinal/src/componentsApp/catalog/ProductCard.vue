<template>
        <v-flex
        md6
        >
<v-card>

        <v-card-title primary-title >
          <div>
            <v-container>
         <v-img
          src="https://cdn.vuetifyjs.com/images/cards/desert.jpg"
          aspect-ratio="2.75"
        ></v-img>
              
        </v-container>
          <v-container>
            <h3 class="headline mb-0">Nombre del Producto</h3>

              </v-container>
          <v-container>
          <v-text-field v-model="quantity" type="number" label="Quantity" :rules="quantityRules"></v-text-field>
          <a>eliminar</a>
        </v-container>
          
          </div>
        </v-card-title>

      
      </v-card>
        </v-flex>
</template>
<script>
  export default {
      name:'product-card',
    data() {
    return {
     result:{id:1},
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
    }
  }

</script>