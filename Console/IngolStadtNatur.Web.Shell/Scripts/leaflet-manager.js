var leafletManager = {
    marker: null,
    map: null,

    createMap: function(div, latlng) {
        var gps = false;
        if (latlng == null) {
            gps = true;
            latlng = [48.764789, 11.424408];
        }

        var bayernAtlas = L.tileLayer.wms('http://www.geodaten.bayern.de/ogc/ogc_dop80_oa.cgi?',
        {
            layers: 'by_dop80c',
            version: '1.1.1',
            format: 'image/jpeg',
            crs: L.CRS.EPSG4326,
            transparent: true,
            styles: ''
        });

        var openStreetMap = L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
        {
            attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
        });

        var baseMaps = {
            "BayernAtlas": bayernAtlas,
            "OpenStreetMap": openStreetMap
        };

        this.map = L.map(div,
        {
            maxBounds: [[48.728209, 11.376253], [48.799446, 11.471378]],
            center: latlng,
            minZoom: 14,
            zoom: 16,
            crs: L.CRS.EPSG900913,
            layers: [bayernAtlas]
        });

        this.map.locate({ setView: gps, enableHighAccuracy: true, timeout: 5000 });
        this.map.on('locationerror',
            function(e) {
                map.setView(latlng, 16);
            });
        this.map.on('click',
            function(e) {
                if (leafletManager.existsMarker()) {
                    leafletManager.editMarker(e.latlng);
                } else {
                    leafletManager.addMarker(e.latlng);
                }
            });

        L.control.layers(baseMaps).addTo(this.map);
        L.geoJson.css(habitats).addTo(this.map);
    },

    addMarker: function (latlng) {
        $("#Coordinates").val(latlng.lat + "," + latlng.lng);
        $("#Checkbox_Map").attr("src", "/Content/icons/common/Kästchen-mit-Haken.svg");
        this.marker = new L.Marker(latlng, { draggable: true });
        this.marker.addTo(this.map);
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