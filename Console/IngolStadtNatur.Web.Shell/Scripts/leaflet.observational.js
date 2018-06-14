var coordinates, gps, observationalMap, observationalMarkers;

function addObservationalMarkers(latlngs) {
    observationalMarkers.clearLayers();

    for (var i = 0; i < latlngs.length; i++) {
        new L.Marker([latlngs[i][0], latlngs[i][1]]).addTo(observationalMarkers);
    }
}

function addObservationalMarker(latlng) {
    observationalMarkers.clearLayers();

    new L.Marker(latlng).addTo(observationalMarkers);
}

function createObservationalMap(div, latlng) {
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

    observationalMap = L.map(div,
    {
        maxBounds: [[48.817759, 11.341906], [48.631214, 11.520903]],
        center: coordinates,
        minZoom: 14,
        zoom: 20,
        crs: L.CRS.EPSG900913,
        layers: [bayernAtlas]
    });

    observationalMarkers = L.layerGroup().addTo(observationalMap);
    L.control.layers(baseMaps).addTo(observationalMap);
    L.geoJson.css(habitats).addTo(observationalMap);
}