var observationalMap, observationalMarkers;

function addObservationalMarkers(coordinates) {
    observationalMarkers.clearLayers();

    for (var i = 0; i < coordinates.length; i++) {
        new L.Marker([coordinates[i][0], coordinates[i][1]]).addTo(observationalMarkers);
    }
}

function createObservationalMap(div) {
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
    maxBounds: [[48.728209, 11.376253], [48.799446, 11.471378]],
    center: [48.764789, 11.424408],
    minZoom: 14,
    zoom: 14,
    crs: L.CRS.EPSG900913,
    layers: [bayernAtlas]
});

    observationalMarkers = L.layerGroup().addTo(observationalMap);
    L.control.layers(baseMaps).addTo(observationalMap);
    L.geoJson.css(habitats).addTo(observationalMap);
}