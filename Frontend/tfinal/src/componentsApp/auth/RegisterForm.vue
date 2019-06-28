<template>
<v-form
    ref="form"
    v-model="valid"
    @onSubmit="validar"
  >
  <h3>Sign In</h3>
    <v-text-field
      v-model="user.apodo"
      :counter="10"
      :rules="nameRules"
      label="UserName"
      required
    ></v-text-field>

    <v-text-field
      v-model="user.email"
      :rules="emailRules"
      label="E-mail"
      required
    ></v-text-field>

      <v-text-field v-model="user.hashContrasena" label="Password" 
     :append-icon="show2 ? 'visibility' : 'visibility_off'" 
     :type="show2 ? 'text' : 'password'" @click:append="show2 = !show2" ></v-text-field>

            <v-text-field v-model="user.hashContrasena" label="Confirmar Password" 
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
      user:{apodo:'',hashContrasena:'',email:''},
      show2:false,
      valid:false,
      nameRules: [
        v => !!v || 'User name is required',
        v => (v && v.length <= 10) || 'Name must be less than 10 characters'
      ],emailRules: [
        v => !!v || 'E-mail is required',
        v => /.+@.+/.test(v) || 'E-mail must be valid'
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
