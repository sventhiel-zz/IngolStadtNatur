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
        coordinates = [48.765610, 11.423719];
        gps = true;
    } else {
        coordinates = latlng;
        gps = false;
    }

    var bayernAtlas = L.tileLayer.wms("https://geoservices.bayern.de/wms/v1/ogc_dop80_oa.cgi?",
        {
            layers: "by_dop80c",
            version: "1.1.1",
            format: "image/jpeg",
            crs: L.CRS.EPSG4326,
            transparent: true,
            styles: ""
        });

    var openStreetMap = L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
        {
            attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a>'
        });

    var baseMaps = {
        "BayernAtlas": bayernAtlas,
        "OpenStreetMap": openStreetMap
    };

    observationalMap = L.map(div,
    {
        maxBounds: [[48.778076, 11.397803], [48.750424, 11.453432]],
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