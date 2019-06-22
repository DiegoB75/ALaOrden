<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Sedes</v-toolbar-title>
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
        <v-dialog v-model="dialog" >
          <v-btn slot="activator" color="primary" dark class="mb-2" @click.native="nuevoItem">Nuevo</v-btn>
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text style="height:500px">
              <v-container grid-list-md>
                <v-layout wrap>
                  <v-flex xs12 sm12 md12>
                    <v-autocomplete
                      v-model="idFranquicia"
                      :items="franquicias"
                      item-text="nombre"
                      item-value="idFranquicia"
                    >
                    </v-autocomplete>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="direccion" id="autocomplete" ></v-text-field>
                  </v-flex>
                  <v-flex id="map" style="height:300px">
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
      <v-data-table :headers="headers" :items="sedes" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
            <v-icon small class="mr-2" @click="deleteItem(props.item)">delete</v-icon>
          
          </td>
          <td>{{ props.item.direccion }}</td>
          <td>{{ props.item.idFranquicia }}</td>
          <td>{{ props.item.longitud }}</td>
          <td>{{ props.item.latitud }}</td>
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
      sedes: [],
      franquicias:[],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Direccion", value: "direccion", sortable: true },
        { text: "Franquicia", value: "franquicia", sortable: true },
        { text: "Longitud", value: "longitud", sortable: true },
        { text: "Latitud", value: "latitud", sortable: true }
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      idSede:"",
      direccion:"",
      idFranquicia:"",
      longitud:"",
      latitud:"",
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nueva Sede" : "Actualizar Sede";
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
    this.renderMap();
  },
  methods: {
    listar() {
      //TODO
      let me = this;

      axios
        .get("api/sede")
        .then(function(response) {
          //console.log(response);
          me.sedes = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    editItem(item) {
      //TODO
      this.idSede = item.idSede;
      this.direccion = item.direccion;
      this.longitud = item.longitud;
      this.latitud = item.latitud;
      this.idFranquicia = item.idFranquicia;
      this.dialog = true;
      this.editedIndex = 1;
    },
    close() {
      this.dialog = false;
    },
    nuevoItem(){
      let me = this;
      this.editedIndex = -1;
      axios
        .get("api/franquicia")
        .then(function(response) {
          //console.log(response);
          me.franquicias = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    }
    ,
    limpiar() {
      this.idSede = "";
      this.idFranquicia = "";
      this.editedIndex = -1;
    },deleteItem(item){
        let me = this;

        axios
        .delete("api/sede/"+item.idSede)
        .then(function(response) {
          //console.log(response);
          me.close();
          me.listar();
          me.limpiar();
        })
        .catch(function(error) {
          console.log(error);
        });
    }
    ,
    guardar() {
       if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/sede/"+me.idSede, {
            idSede: me.idSede,
            direccion:me.direccion,
            longitud:me.longitud,
            latitud:me.latitud,
            idFranquicia:me.idFranquicia
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
          .post("api/sede", {
            direccion: me.direccion,
            longitud:me.longitud,
            latitud:me.latitud,
            idFranquicia:me.idFranquicia,
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
    },
    initMap(){
var marker;
var map;
var geocoder;
var infowindow;
var me = this;
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            me.latitud = position.coords.latitude;
            me.longitud = position.coords.longitud;
            geocoder = new window.google.maps.Geocoder;
            infowindow = new window.google.maps.InfoWindow;
            map = new window.google.maps.Map(document.getElementById("map"), {
                center: {
                    lat: pos.lat,
                    lng: pos.lng
                },
                zoom: 20
            });

            marker = new window.google.maps.Marker({
                position: pos,
                map: map,
                draggable: false,
                animation: window.google.maps.Animation.DROP
            });
            geocodeLatLng(pos,2);

            function addMarker(location, map) {
                marker.setMap(null);

                marker = new window.google.maps.Marker({
                    position: location,
                    map: map,
                    draggable: false,
                    animation: window.google.maps.Animation.DROP
                });
                map.setCenter(location);
                map.setZoom(18);
            }
            var autocomplete = document.getElementById('autocomplete');
            const search = new window.google.maps.places.Autocomplete(autocomplete);
            search.bindTo("bounds", map);
            search.addListener('place_changed', function () {
                var place = search.getPlace();
                if (!place.geometry.viewport) {
                    window.alert("Error al mostrar el lugar");
                    return;
                }
                if (place.geometry.viewport) {
                    map.fitBounds(place.geometry.viewport);
                    geocodeLatLng(place.geometry.location);
                } else {
                    geocodeLatLng(place.geometry.location);
                }

            });

            function geocodeLatLng(longitud,flag=1) {
                var latlng = longitud;
                if(flag==1){
                me.latitud = longitud.lat();
                me.longitud = longitud.lng();
                }else{
                me.latitud = longitud.lat;
                me.longitud = longitud.lng;  
                }
                geocoder.geocode({
                    'location': latlng
                }, function (results, status) {
                    if (status === 'OK') {
                        if (results[0]) {
                            addMarker(longitud, map);
                            infowindow.setContent(results[0].formatted_address);
                            infowindow.open(map, marker);
                            if (document.getElementById("autocomplete")){
                                document.getElementById("autocomplete").value = results[0].formatted_address;
                                me.direccion = results[0].formatted_address;
                                }
                        } else {
                            window.alert('No results found');
                        }
                    } else {
                        window.alert('Geocoder failed due to: ' + status);
                    }
                });
            }
            
            window.google.maps.event.addListener(map, 'click', function (event) {
                geocodeLatLng(event.latLng);
            });
        }, function () {
            handleLocationError(true, infowindow, map.getCenter());
        });
    } else {
        handleLocationError(false, infowindow, map.getCenter());
    }

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
        'Error: The Geolocation service failed.' :
        'Error: Your browser doesn\'t support geolocation.');
}
    },
    renderMap(){
        loadScript("https://maps.googleapis.com/maps/api/js?key=AIzaSyDzB-76_WJJt-fAqyqnT23jyCpNwm3jqcg&libraries=places&callback=initMap");
        window.initMap = this.initMap;
    }
  }
};
function loadScript(url){
    var script = window.document.createElement("script");
    var index = window.document.getElementsByTagName("script")[0];
    script.src = url;
    script.async = true;
    script.defer = true;
    index.parentNode.insertBefore(script,index);
}
</script>
