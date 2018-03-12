(function ($) {
    $(function () {

        var resultado;

        var chatInput = $("#chat-input");
        var userName;
        var map;
        var chat = $.connection.recived;
        var chatWindow = $("#chat-window");
        var map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: -0.225219, lng: -78.5248 },
            zoom: 15
        });
        geoLocation(map);

        var iconCompetencia =
            {
                url: "../Content/images/trx_baja.png", // url
                size: new google.maps.Size(96, 96),
                scaledSize: new google.maps.Size(96, 96), // scaled size
                origin: new google.maps.Point(0, 0), // origin
                anchor: new google.maps.Point(48, 48) // anchor
            };

        var iconClientes =
            {
                //con el icono 
                url: "../Content/images/trx_media.png", // url
                size: new google.maps.Size(96, 96),
                scaledSize: new google.maps.Size(96, 96), // scaled size
                origin: new google.maps.Point(0, 0), // origin
                anchor: new google.maps.Point(48, 48) // anchor
            };
        markers = [];
        markersDelete = [];

        a = 0;
        markersAgentes = [];
        markersClientes = [];
        clientecarga();
        clientecargaBanRed();

        ///Se carga la información de los cajeros
        function clientecarga () {
            $.ajax({
                type: 'POST',
                url: '../CajeroCoopPolicias/GetCajeros',
                dataType: 'json',
                data: {},
                success: function (data) {
                    arreglo = data;

                }, complete: function (data) {

                    for (var i = 0; i < arreglo.length; i++) {

                        var marker;
                        var pos = { lat: arreglo[i].Latitud, lng: arreglo[i].Longitud };
                        var InformacionCliente =
                            {

                                Lat: arreglo[i].Latitud,
                                Lon: arreglo[i].Longitud,
                                Codigo: arreglo[i].Codigo,
                                Direccion: arreglo[i].Direccion,
                                Tipo: arreglo[i].Tipo,
                                Modelo: arreglo[i].Modelo,
                                TrxPropia: arreglo[i].TrxPropia,
                                TrxBanred: arreglo[i].TrxBanred,
                            }
                        var marker = new google.maps.Marker({
                            position: pos,
                            map: map,
                            title: InformacionCliente.Nombre,
                            icon: iconClientes,
                            

                        });


                        //marker.addListener('click', function () {
                        //    infowindow.open(map, marker);
                        //});
                        markersClientes.push({ marker, InformacionCliente });
                        //markersClientes[i].marker.setPosition(new google.maps.LatLng(InformacionCliente.Lat, InformacionCliente.Lon));


                        var contentString = '<div id="content">' +
                            '<div id="siteNotice">' +
                            '</div>' +
                            '<h4 id="firstHeading" class="firstHeading"><b>Cajero</b></h4>' +
                            '<img src="../Content/images/cajero.jpg" />' +                            '<legend></legend>' +
                            '<div id="bodyContent">' +
                            '<p><b>Codigo:&nbsp&nbsp</b>' + InformacionCliente.Codigo + '.</p>' +
                            '<p><b>Direccion:&nbsp&nbsp</b>' + InformacionCliente.Direccion + '.</p>' +
                            '<p><b>Tipo:&nbsp&nbsp</b>' + InformacionCliente.Tipo + '.</p>' +
                            '<p><b>Modelo:&nbsp&nbsp</b>' + InformacionCliente.Modelo + '.</p>' +
                            '<p><b>TrxPropia:&nbsp&nbsp</b>' + InformacionCliente.TrxPropia + '.</p>' +
                            '<p><b>TrxBanred:&nbsp&nbsp</b>' + InformacionCliente.TrxBanred + '.</p>' +

                            '</div>' +
                            '</div>';
                        var infowindow = new google.maps.InfoWindow();

                        google.maps.event.addListener(marker, "click", (function (marker, contentString, infowindow) {
                            // !!! PROBLEM HERE
                            return function (evt) {
                                
                                infowindow.setContent(contentString);
                                infowindow.open(map, marker);
                            }
                        })(marker, contentString, infowindow));
                        //markersClientes[i].marker.setListener('click', function () {
                        //    infowindow.open(map, markersClientes[i].marker);
                        //});

                    }
                },

                error: function (ex) {
                    alert('Failed to retrieve data.' + ex);
                }
            });
        };

        function clientecargaBanRed() {
            $.ajax({
                type: 'POST',
                url: '../CajeroCoopPolicias/GetCajerosBanRed',
                dataType: 'json',
                data: {},
                success: function (data) {
                    arreglo = data;

                }, complete: function (data) {

                    for (var i = 0; i < arreglo.length; i++) {

                        var marker;
                        var pos = { lat: arreglo[i].Altitud, lng: arreglo[i].Longitud };
                        var InformacionCliente =
                            {

                                Lat: arreglo[i].Altitud,
                                Lon: arreglo[i].Longitud,
                                Entidad: arreglo[i].Entidad,
                              
                            }
                        var marker = new google.maps.Marker({
                            position: pos,
                            map: map,
                            title: InformacionCliente.Entidad,
                            icon: iconCompetencia,


                        });


                        //marker.addListener('click', function () {
                        //    infowindow.open(map, marker);
                        //});
                        markersClientes.push({ marker, InformacionCliente });
                        //markersClientes[i].marker.setPosition(new google.maps.LatLng(InformacionCliente.Lat, InformacionCliente.Lon));


                        var contentString = '<div id="content">' +
                            '<div id="siteNotice">' +
                            '</div>' +
                            '<h4 id="firstHeading" class="firstHeading"><b>Cajero</b></h4>' +
                            '<img src="../Content/images/cajero.jpg" />' + '<legend></legend>' +
                            '<div id="bodyContent">' +
                            '<p><b>Codigo:&nbsp&nbsp</b>' + InformacionCliente.Codigo + '.</p>' +
                            '<p><b>Direccion:&nbsp&nbsp</b>' + InformacionCliente.Direccion + '.</p>' +
                            '<p><b>Tipo:&nbsp&nbsp</b>' + InformacionCliente.Tipo + '.</p>' +
                            '<p><b>Modelo:&nbsp&nbsp</b>' + InformacionCliente.Modelo + '.</p>' +
                            '<p><b>TrxPropia:&nbsp&nbsp</b>' + InformacionCliente.TrxPropia + '.</p>' +
                            '<p><b>TrxBanred:&nbsp&nbsp</b>' + InformacionCliente.TrxBanred + '.</p>' +

                            '</div>' +
                            '</div>';
                        var infowindow = new google.maps.InfoWindow();

                        google.maps.event.addListener(marker, "click", (function (marker, contentString, infowindow) {
                            // !!! PROBLEM HERE
                            return function (evt) {

                                infowindow.setContent(contentString);
                                infowindow.open(map, marker);
                            }
                        })(marker, contentString, infowindow));
                        //markersClientes[i].marker.setListener('click', function () {
                        //    infowindow.open(map, markersClientes[i].marker);
                        //});

                    }
                },

                error: function (ex) {
                    alert('Failed to retrieve data.' + ex);
                }
            });
        };



        //this is the function that's run when the "messageReceived" function is called from the server
        chat.client.messageReceived = function (livePositionRequest) {

            var pos = { lat: livePositionRequest.Lat, lng: livePositionRequest.Lon };

                var marker;
                if (markersAgentes.length == 0) {

                    var marker = new google.maps.Marker({
                        position: pos,
                        map: map,
                        title: livePositionRequest.Nombre,
                        icon: icon1
                    });

                    var localTime = moment.utc().toDate();
                    localTime = moment(localTime).format('DD-MM-YYYY hh:mm:ss A');
                    var contentString = '<div id="content">' +
                        '<div id="siteNotice">' +
                        '</div>' +
                        '<h4 id="firstHeading" class="firstHeading">Vendedor</h1>' +
                        '<div id="bodyContent">' +
                        '<p><b>Nombre del vendedor:</b>' + livePositionRequest.Nombre + '.</p>' +
                        '<p><b>Fecha:</b>' + localTime + '.</p>' +
                        '</div>' +
                        '</div>';
                    var infowindow = new google.maps.InfoWindow({
                        content: contentString
                    });
                    marker.addListener('click', function () {
                        infowindow.open(map, marker);
                    });
                    markersAgentes.push({ marker, livePositionRequest });
                } else {

                    var agenteId = livePositionRequest.AgenteId;
                    var positionArray = existeAgente(agenteId);
                    if (positionArray >= 0) {
                        markersAgentes[positionArray].marker.setPosition(new google.maps.LatLng(livePositionRequest.Lat, livePositionRequest.Lon));

                        var localTime = moment.utc().toDate();
                        localTime = moment(localTime).format('DD-MM-YYYY hh:mm:ss A');

                        var contentString = '<div id="content">' +
                            '<div id="siteNotice">' +
                            '</div>' +
                            '<h4 id="firstHeading" class="firstHeading">Vendedor</h1>' +
                            '<div id="bodyContent">' +
                            '<p><b>Nombre del vendedor:</b>' + livePositionRequest.Nombre + '.</p>' +
                            '<p><b>Fecha:</b>' + localTime + '.</p>' +
                            '</div>' +
                            '</div>';
                        var infowindow = new google.maps.InfoWindow({
                            content: contentString
                        });


                        markersAgentes[positionArray].marker.setListener('click', function () {
                            infowindow.open(map, markersAgentes[positionArray].marker);
                        });

                    }
                    else {

                        var marker = new google.maps.Marker({
                            position: pos,
                            map: map,
                            title: livePositionRequest.Nombre,
                            icon: icon1
                        });


                        var localTime = moment.utc().toDate();
                        localTime = moment(localTime).format('DD-MM-YYYY hh:mm:ss A');

                        var contentString = '<div id="content">' +
                            '<div id="siteNotice">' +
                            '</div>' +
                            '<h4 id="firstHeading" class="firstHeading">Vendedor</h1>' +
                            '<div id="bodyContent">' +
                            '<p><b>Nombre del vendedor:</b>' + livePositionRequest.Nombre + '.</p>' +
                            '<p><b>Fecha:</b>' + localTime + '.</p>' +
                            '</div>' +
                            '</div>';

                        var infowindow = new google.maps.InfoWindow({
                            content: contentString
                        });
                        marker.addListener('click', function () {
                            infowindow.open(map, marker);
                        });

                        markersAgentes.push({ marker, livePositionRequest });
                    }


                }
        };

        function existeAgente(agenteId) {
            var miresultado = -1;
            for (var i = 0; i < markersAgentes.length; i++) {
                if (markersAgentes[i].livePositionRequest.AgenteId == agenteId) {
                    miresultado = i;
                    break;
                }
            }
            return miresultado;
        };

        function obtenerInfo(contentString) {
            var localTime = moment.utc().toDate();
            localTime = moment(localTime).format('DD-MM-YYYY hh:mm:ss A');
            contentString = '<div id="content">' +
                '<div id="siteNotice">' +
                '</div>' +
                '<h4 id="firstHeading" class="firstHeading">City Park</h1>' +
                '<div id="bodyContent">' +
                '<p><b>Nombre del Agente:</b>' + mark.Nombre + '.</p>' +
                '<p><b>Latitud:</b>' + pos.lat + '.</p>' +
                '<p><b>Longitud:</b>' + pos.lng + '.</p>' +
                '<p><b>Fecha:</b>' + localTime + '.</p>' +
                '</div>' +
                '</div>';
            return contentString;
        };

        function geoLocation(map) {
            var infoWindow = new google.maps.InfoWindow({ map: map });
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    var pos = {
                        lat: position.coords.latitude,
                        lng: position.coords.longitude
                    };

                    infoWindow.setPosition(pos);
                    infoWindow.setContent('Posici&oacute;n actual');
                    map.setCenter(pos);
                }, function () {
                    handleLocationError(true, infoWindow, map.getCenter());
                });
            } else {
                // Browser doesn't support Geolocation
                handleLocationError(false, infoWindow, map.getCenter());
            }
        }
        function handleLocationError(browserHasGeolocation, infoWindow, pos) {
            infoWindow.setPosition(pos);
            infoWindow.setContent(browserHasGeolocation ?
                'Error: The Geolocation service failed.' :
                'Error: Your browser doesn\'t support geolocation.');
        };

        function setMapOnAll(map) {
            for (var i = 0; i < markersDelete.length; i++) {
                markersDelete[i].setMap(map);
            }
        };

        function myFunction() {
            myVar = setInterval(alertFunc, 5000);
        };
        function alertFunc() {
            deleteMarkers();
        }
        function deleteMarkers() {
            clearMarkers();
            markers = [];
        };
        function clearMarkers() {
            setMapOnAll(null);
        };
        function MostrarClientes(arreglo)
        {
            for (var i = 0; i < arreglo.length; i++) {

                var marker;
                var pos = { lat: arreglo[i].Lat, lng: arreglo[i].Lon };

                var marker = new google.maps.Marker({
                    position: pos,
                    map: map,
                    title: livePositionRequest.Nombre,
                    icon: icon1
                });

                var localTime = moment.utc().toDate();
                localTime = moment(localTime).format('DD-MM-YYYY hh:mm:ss A');
                var contentString = '<div id="content">' +
                    '<div id="siteNotice">' +
                    '</div>' +
                    '<h4 id="firstHeading" class="firstHeading">Digital Strategy</h1>' +
                    '<div id="bodyContent">' +
                    '<p><b>Nombre del vendedor:</b>' + livePositionRequest.Nombre + '.</p>' +
                    '<p><b>Fecha:</b>' + localTime + '.</p>' +
                    '</div>' +
                    '</div>';
                var infowindow = new google.maps.InfoWindow({
                    content: contentString
                });
                marker.addListener('click', function () {
                    infowindow.open(map, marker);
                });
                markersAgentes.push({ marker, livePositionRequest });

            }
        };
        $.connection.hub.start().done(function () {
            chatInput.keydown(function (e) {

                if (e.which === 13) {
                    var text = chatInput.val();

                    //empty the textbox
                    chatInput.val("");

                    //send the message to the server
                    chat.server.sendMessage(userName, text);

                    //focus cursor on the textbox for easy chatting!
                    self.focus();
                }
            });
        });
    });
})(jQuery);