var leafletManager = {
    marker: null,

    createMap: function (div, latlng) {
        var coordinates, gps;

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

        var map = L.map(div,
        {
            maxBounds: [[48.728209, 11.376253], [48.799446, 11.471378]],
            center: coordinates,
            minZoom: 14,
            zoom: 16,
            crs: L.CRS.EPSG900913,
            layers: [bayernAtlas]
        });

        map.locate({ setView: gps, enableHighAccuracy: true, timeout: 5000 });
        map.on("locationerror",
            function (e) {
                map.setView(coordinates, 16);
            });
        map.on("locationfound",
            function (e) {
                if (!map.getBounds().contains(e.latlng)) {
                    alert("NOOOO");
                    map.setView(coordinates, 16);

                }
            });
        map.on("click",
            function(e) {
                if (leafletManager.existsMarker()) {
                    leafletManager.editMarker(e.latlng);
                } else {
                    leafletManager.addMarker(e.latlng);
                }
            });

        L.control.layers(baseMaps).addTo(map);
        L.geoJson.css(habitats).addTo(map);
    },

    addMarker: function (latlng) {
        $("#Coordinates").val(latlng.lat + "," + latlng.lng);
        $("#Checkbox_Map").attr("src", "/Images/Common/Kästchen-mit-Haken.svg");
        this.marker = new L.Marker(latlng, { draggable: true });
        this.marker.addTo(map);
    },

    editMarker: function(latlng) {
        $("#Coordinates").val(latlng.lat + "," + latlng.lng);
        this.marker.setLatLng(latlng);
    },

    existsMarker: function() {
        if (this.marker == null) {
            return false;
        } else {
            return true;
        }
    }
}