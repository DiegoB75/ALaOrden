<template>
<v-card width="350px">

        <v-card-title primary-title >
          <div>
                    <v-img
          src="https://cdn.vuetifyjs.com/images/cards/desert.jpg"
          
          aspect-ratio="2.75"
          height="70px"
          width="70px"
          style="display: block;"
        ></v-img>
            <h3 style="display: inline;" class="headline mb-0">Carrito Nombre</h3>
            <span style="display: inline;">    <v-btn fab dark small color="primary">
      <v-icon dark>remove</v-icon>
    </v-btn></span><div  style="display: inline;"> {{ cartItem.id }} </div><span style="display: inline;"><v-btn fab dark small color="primary">
      <v-icon dark>add</v-icon>
    </v-btn></span>
          <a>eliminar</a>
          </div>
        </v-card-title>

      
      </v-card>
</template>
<script>
  export default {
    data() {
    return {
      fav: true,
      menu: false,
      message: false,
      hints: true
      ,cartItem:{id:1}
    }},
    methods:{

    }
  }
</script>