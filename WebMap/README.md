# Sandbar Analysis Webmap

We're taking the code from:

http://www.gcmrc.gov/sandbar/surveys/site/34/

And loading up a simple map with one point specifying the site.

This is a proof of concept for a leaflet plugin loading KML and XML files

### Grunt

Grunt is used to handle all the JS and SCSS compilation as well as copying bower libs and packaging everything up. The following targets were implemented:

### `grunt build`
### `grunt dev`

*NB: This requires the grunt-cli node module.*

### Server.js

`Server.js` is a tiny little web server used to serve `CrossSectionMap.html` while developing this app in a browser. It is here for convenience only. 

To run it first makes sure you have NodeJS installed then type:

```
$ node server.js <port>
```