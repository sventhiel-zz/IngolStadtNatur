var coordinates, gps, map, marker;

function addInteractiveMarker(latlng) {
    $("#Coordinates").val(latlng.lat + "," + latlng.lng);
    $("#Checkbox_Map").attr("src", "/Images/Common/Kästchen-mit-Haken.svg");

    marker = new L.Marker(latlng, { draggable: true });
    marker.addTo(map);
}

function createInteractiveMap(div, latlng) {
    if (typeof latlng === "undefined" || latlng === null) {
        coordinates = [48.659590, 11.465875];
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
        maxBounds: [[48.817759, 11.341906], [48.631214, 11.520903]],
        center: coordinates,
        minZoom: 14,
        zoom: 20,
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

function editInteractiveMarker(latlng) {
    $("#Coordinates").val(latlng.lat + "," + latlng.lng);
    marker.setLatLng(latlng);
}

function existsInteractiveMarker() {
    if (typeof marker === "undefined" || marker === null) {
        return false;
    } else {
        return true;
    }
}

function onClick(e) {
    if (existsInteractiveMarker()) {
        editInteractiveMarker(e.latlng);
    } else {
        addInteractiveMarker(e.latlng);
    }
}

function onLocationError(e) {
    map.setView(coordinates, 14);
}

function onLocationFound(e) {
    if (!map.getBounds().contains(e.latlng)) {
        map.setView(coordinates, 14);
    }
}