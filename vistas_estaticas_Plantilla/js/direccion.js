var marker;
var map;
var geocoder;
var infowindow;
google.maps.event.addDomListener(window, "load", function () {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
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

            marker = new google.maps.Marker({
                position: pos,
                map: map,
                draggable: false,
                animation: google.maps.Animation.DROP
            });
            geocodeLatLng(pos);

            function addMarker(location, map) {
                marker.setMap(null);
                marker = new google.maps.Marker({
                    position: location,
                    map: map,
                    draggable: false,
                    animation: google.maps.Animation.DROP
                });
                map.setCenter(location);
                map.setZoom(18);
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
                    geocodeLatLng(place.geometry.location, map);
                } else {
                    geocodeLatLng(place.geometry.location, map);
                }

            });

            function geocodeLatLng(longitud) {
                var latlng = longitud;
                geocoder.geocode({
                    'location': latlng
                }, function (results, status) {
                    if (status === 'OK') {
                        if (results[0]) {
                            addMarker(longitud, map);
                            infowindow.setContent(results[0].formatted_address);
                            infowindow.open(map, marker);
                            if (document.getElementById("autocomplete"))
                                document.getElementById("autocomplete").value = results[0].formatted_address;
                        } else {
                            window.alert('No results found');
                        }
                    } else {
                        window.alert('Geocoder failed due to: ' + status);
                    }
                });
            }
            google.maps.event.addListener(map, 'click', function (event) {
                geocodeLatLng(event.latLng);
            });
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