 var coordinates, gps, map, marker;

 function addMarker(latlng) {
     $("#Coordinates").val(latlng.lat + "," + latlng.lng);
     $("#Checkbox_Map").attr("src", "/Images/Common/Kästchen-mit-Haken.svg");
     marker = new L.Marker(latlng, { draggable: true });
     marker.addTo(map);
 }

 function createMap(div, latlng) {
    if (typeof latlng === "undefined" || latlng === null) {
        coordinates = [48.764789, 11.424408];
        gps = true;
    } else {
        coordinates = latlng;
        gps = false;
    }

    var bayernAtlas = L.tileLayer.wms("http://www.geodaten.bayern.de/ogc/ogc_dop80_oa.cgi?",
    {
        layers: "by_dop80c",
        version: "1.1.1",
        format: "image/jpeg",
        crs: L.CRS.EPSG4326,
        transparent: true,
        styles: ""
    });

    var openStreetMap = L.tileLayer("http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
    {
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });

    var baseMaps = {
        "BayernAtlas": bayernAtlas,
        "OpenStreetMap": openStreetMap
    };

    map = L.map(div,
    {
        maxBounds: [[48.728209, 11.376253], [48.799446, 11.471378]],
        center: coordinates,
        minZoom: 12,
        zoom: 14,
        crs: L.CRS.EPSG900913,
        layers: [bayernAtlas]
    });

    map.on("click", onClick);
    map.on("locationerror", onLocationError);
    map.on("locationfound", onLocationFound);

    map.locate({ setView: gps, enableHighAccuracy: true, timeout: 5000 });

    L.control.layers(baseMaps).addTo(map);
    L.geoJson.css(habitats).addTo(map);
 }

 function editMarker(latlng) {
    $("#Coordinates").val(latlng.lat + "," + latlng.lng);
    marker.setLatLng(latlng);
}

 function existsMarker() {
     if (typeof marker === "undefined" || marker === null) {
         return false;
     } else {
         return true;
     }
 }

function onClick(e) {
    if (existsMarker()) {
        editMarker(e.latlng);
    } else {
        addMarker(e.latlng);
    }
}

function onLocationError(e) {
    map.setView(coordinates, 16);
}

function onLocationFound(e) {
    if (!map.getBounds().contains(e.latlng)) {
        map.setView(coordinates, 16);

    }
}