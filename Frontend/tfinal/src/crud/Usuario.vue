<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Usuarios</v-toolbar-title>
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
                    <v-text-field v-model="apodo" label="Apodo" :rules="nameRules"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="hashContrasena" label="Contrasena" :append-icon="show2 ? 'visibility' : 'visibility_off'" :type="show2 ? 'text' : 'password'" @click:append="show2 = !show2" ></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="email" label="Email" :rules="emailRules"></v-text-field>
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
      <v-data-table :headers="headers" :items="usuarios" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
            <v-icon small class="mr-2" @click="deleteItem(props.item)">delete</v-icon>
          
          </td>
          <td>{{ props.item.apodo }}</td>
          <td>{{ props.item.sal }}</td>
          <td>{{ props.item.email }}</td>
          <td>{{ props.item.emailValidado }}</td>
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
      show2:false,
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Apodo", value: "apodo" },
        { text: "Sal", value: "sal", sortable: false   },
        { text: "Email", value: "email"  },
        { text: "Email Validado", value: "emailValidado"  }
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      idUsuario: "",
      apodo: "",
      hashContrasena: "",
      sal: "%$#\"#$!",
      email: "",
      emailValidado:'',
      emailRules: [
        v => !!v || 'E-mail is required',
        v => /.+@.+/.test(v) || 'E-mail must be valid'
      ],nameRules: [
        v => !!v || 'Name is required',
        v => v.length <= 10 || 'Name must be less than 10 characters'
      ]

    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Usuario" : "Actualizar Usuario";
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
        .get("api/usuario")
        .then(function(response) {
          //console.log(response);
          me.usuarios = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    editItem(item) {
      //TODO
      this.show2 = false;
      this.idUsuario = item.idUsuario;
      this.apodo = item.apodo;
      this.sal = item.sal;
      this.hashContrasena = item.hashContrasena;
      this.emailValidado = item.emailValidado;
      this.email = item.email;
      this.dialog = true;
      this.editedIndex = 1;
    },deleteItem(item){
      let me = this;

      axios
        .delete("api/usuario/"+item.idUsuario)
        .then(function(response) {
          //console.log(response);
          me.close();
          me.limpiar();
          me.listar();
        })
        .catch(function(error) {
          console.log(error);
        });
    },nuevoItem(){
      
      this.emailValidado = false;
      this.editedIndex = -1;

    },
    close() {
      this.dialog = false;
    },
    limpiar() {
      this.id = "";
      this.apodo = "";
      this.hashcontrasena = "";
      this.sal="%$#\"#$!";
      this.email = "";
      this.editedIndex = -1;
    },
    guardar() {
     //TODO
     if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/usuario/"+me.idUsuario, {
            idUsuario: me.idUsuario,
            apodo:me.apodo,
            email:me.email,
            hashContrasena:me.hashContrasena,
            emailValidado:me.emailValidado,
            sal:me.sal
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
          .post("api/usuario", {
            apodo:me.apodo,
            email:me.email,
            hashContrasena:me.hashContrasena,
            emailValidado:me.emailValidado,
            sal:me.sal
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
