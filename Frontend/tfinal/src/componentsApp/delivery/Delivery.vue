<template>
<v-container>
    <v-layout row>
  <h1 class="text-center" >Seleccione Dirección de Envío</h1>
    </v-layout>
<v-layout row>
    <v-text-field
     id="autocomplete"
      v-model="direccion1"
      label="Direccion"
      required
    ></v-text-field>
</v-layout>
    <v-layout row>
    <v-text-field
      v-model="direccion2"
      label="(Opcional)"
    ></v-text-field>
    </v-layout>
    <v-flex id="map" style="height:300px">
    </v-flex>

</v-container>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      //TODO:Model
        direccion1:'',
        direccion2:'',
        latitud:'',
        longitud:''
    };
  },
  computed: {
   
  },

  watch: {
    
  },
  created() {
    //TODO
    this.renderMap();
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

    },initMap(){
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
                                me.direccion1 = results[0].formatted_address;
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
