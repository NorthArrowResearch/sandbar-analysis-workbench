'use strict'
// http://localhost:8080/?lat=-111.616905212&lng=36.8412017822
$(document).ready(function() {
  var siteLat = getUrlParameter('siteLat'); 
  var siteLng = getUrlParameter('siteLng'); 
  var map;
  var latlng = L.latLng(parseFloat(siteLng), parseFloat(siteLat));
  map = L.map('map', {
    center: latlng,
    zoom: 18,
    attributionControl: false
  });
  
  var baseLayer = L.tileLayer('https://services.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}.png').addTo(map);
  // L.esri.dynamicMapLayer("http://arcweb.wr.usgs.gov/ArcGIS/rest/services/MapServiceImageryMay2009RGB/MapServer", {
  //    opacity: 1
  //  }).addTo(map); 
  var marker = L.marker(latlng).addTo(map);
  // map.setView(latlng, 7);
  return map;

});

/**
 * Pull a parameter out of the url
 * @param  {[type]} sParam [description]
 * @return {[type]}        [description]
 */
var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};