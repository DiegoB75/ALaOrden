<template>
<div>
    <v-overflow-btn v-if="authentication==true"
          :items="dropdown_text"
          label="Perfil      "
          target="#dropdown-example"
        ></v-overflow-btn>
    <v-btn v-else @onClick="authentication=!authentication" large color="primary">Primary</v-btn>
</div>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      authentication: true
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
      ],
      dropdown_text: [
        { text: 'list', callback: () => console.log('list') },
        { text: 'favorite', callback: () => console.log('favorite') },
        { text: 'delete', callback: () => console.log('delete') }
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

    },autenticar(){
        this.authentication = true;
        
    }
  }
};
</script>
