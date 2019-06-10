var marker;
var marker2;
var map;
var geocoder;
var infowindow;

var point1;
var point2;

google.maps.event.addDomListener(window, "load", function () {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var directionsService = new google.maps.DirectionsService;
            var directionsDisplay = new google.maps.DirectionsRenderer;


    
            var onChangeHandler = function() {
              calculateAndDisplayRoute(directionsService, directionsDisplay);
            };
          
    
          function calculateAndDisplayRoute(directionsService, directionsDisplay) {
            directionsService.route({
              origin: point1,
              destination: point2,
              travelMode: 'DRIVING'
            }, function(response, status) {
              if (status === 'OK') {
                directionsDisplay.setDirections(response);
              } else {
                window.alert('Directions request failed due to ' + status);
              }
            });
        }
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            geocoder = new google.maps.Geocoder;
            infowindow = new google.maps.InfoWindow;
            map = new google.maps.Map(document.getElementById("map"), {
                center: {
                    lat: pos.lat,
                    lng: pos.lng
                },
                zoom: 20
            });
            point2 = pos;
            point1 = pos;
            directionsDisplay.setMap(map);
            marker = new google.maps.Marker({
                position: pos,
                map: map,
                draggable: false,
                animation: google.maps.Animation.DROP
            });
            marker2 = new google.maps.Marker({
                position: pos,
                map: map,
                draggable: false,
                animation: google.maps.Animation.DROP
            });
            geocodeLatLng(pos,3);

            function addMarker(location, map,caso) {
                if(caso==1){
                marker.setMap(null);
                marker = new google.maps.Marker({
                    position: location,
                    map: map,
                    draggable: false,
                    animation: google.maps.Animation.DROP
                });
                map.setCenter(location);
                map.setZoom(18);
                }else{
                    marker2.setMap(null);
                    marker2 = new google.maps.Marker({
                        position: location,
                        map: map,
                        draggable: false,
                        animation: google.maps.Animation.DROP
                    });
                    map.setCenter(location);
                    map.setZoom(18); 
                }
            }


            var autocomplete = document.getElementById('autocomplete');
            const search = new google.maps.places.Autocomplete(autocomplete);
            search.bindTo("bounds", map);
            search.addListener('place_changed', function () {
                var place = search.getPlace();
                if (!place.geometry.viewport) {
                    window.alert("Error al mostrar el lugar");
                    return;
                }
                if (place.geometry.viewport) {
                    map.fitBounds(place.geometry.viewport);
                    geocodeLatLng(place.geometry.location,1);
                } else {
                    geocodeLatLng(place.geometry.location,1);
                }
                point1 = place.geometry.location;
                if(point1!=null && point2!=null){
                onChangeHandler();
                }
            });
            var autocomplete2 = document.getElementById('autocomplete2');
            const search2 = new google.maps.places.Autocomplete(autocomplete2);
            search2.bindTo("bounds", map);
            search2.addListener('place_changed', function () {
                var place = search2.getPlace();
                if (!place.geometry.viewport) {
                    window.alert("Error al mostrar el lugar");
                    return;
                }
                if (place.geometry.viewport) {
                    map.fitBounds(place.geometry.viewport);
                    geocodeLatLng(place.geometry.location, 2);
                } else {
                    geocodeLatLng(place.geometry.location, 2);
                }
                point2 = place.geometry.location;
                if(point1!=null && point2!=null){ 
                onChangeHandler();
                }
            });
           
            function geocodeLatLng(longitud,caso) {
                var latlng = longitud;
                geocoder.geocode({
                    'location': latlng
                }, function (results, status) {
                    if (status === 'OK') {
                        if (results[0]) {
                            addMarker(longitud, map,caso);
                            infowindow.setContent(results[0].formatted_address);
                            infowindow.open(map, marker);
                            if(caso==1){
                            if (document.getElementById("autocomplete"))
                                document.getElementById("autocomplete").value = results[0].formatted_address;
                            }else if(caso==2){
                                if (document.getElementById("autocomplete2"))
                                document.getElementById("autocomplete2").value = results[0].formatted_address;
                            }else{
                                if (document.getElementById("autocomplete"))
                                document.getElementById("autocomplete").value = results[0].formatted_address;
                                if (document.getElementById("autocomplete2"))
                                document.getElementById("autocomplete2").value = results[0].formatted_address;
                            }
                        } else {
                            window.alert('No results found');
                        }
                    } else {
                        window.alert('Geocoder failed due to: ' + status);
                    }
                });
            }
        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        handleLocationError(false, infoWindow, map.getCenter());
    }



});

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
        'Error: The Geolocation service failed.' :
        'Error: Your browser doesn\'t support geolocation.');
}