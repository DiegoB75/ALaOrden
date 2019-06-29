<template>
<v-form
    ref="form"
    v-model="valid"
    @onSubmit="validar"
  >
  <h3 class="text-center">Iniciar Sesión</h3>
    <v-text-field
      v-model="user.apodo"
      :counter="10"
      :rules="nameRules"
      label="UserName"
      required
    ></v-text-field>

     <v-text-field v-model="user.hashContrasena" label="Password" 
     :append-icon="show2 ? 'visibility' : 'visibility_off'" 
     :type="show2 ? 'text' : 'password'" @click:append="show2 = !show2" ></v-text-field>

    <v-btn
      color="info"
      @click="cancelar"
    >
      Cancelar
    </v-btn>
    <v-btn
      color="success"
      @click="validate"
    >
      Iniciar Sesion
    </v-btn>
  </v-form>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      authentication: false
      //TODO:Model
      ,
      user:{apodo:'',hashContrasena:''},
      show2:false,
      valid:false,
      nameRules: [
        v => !!v || 'User name is required',
        v => (v && v.length <= 10) || 'Name must be less than 10 characters'
      ]
    };
  },
  computed: {
   
  },

  watch: {
    
  },
  created() {
    //TODO

  },
  methods: {
    listar() {
      //TODO
    },
    editItem(item) {
    },
    close() {
    },
    limpiar() {
    },
    deleteItem(){
    }
    ,
    guardar() {
    },
    validar(){

    }
  }
};
</script>
