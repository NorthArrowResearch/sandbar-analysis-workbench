// This is a REALLY simple nodejs web server.
// It is written using Node.js
// The main purpose is to get around the cross site scripting
// when debugging this map widget in a standalone browser.
//
// To run it just type `node server.js <port>`
// --------------------------------------------------------

var http = require("http"),
    url = require("url"),
    path = require("path"),
    fs = require("fs")
    port = process.argv[2] || 8888;
 
http.createServer(function(request, response) {
 
  var uri = url.parse(request.url).pathname
    , filename = path.join(process.cwd(), uri);
  
  path.existsSync(filename, function(exists) {
    if(!exists) {
      response.writeHead(404, {"Content-Type": "text/plain"});
      response.write("404 Not Found\n");
      response.end();
      return;
    }
 
    if (fs.statSync(filename).isDirectory()) filename += '/index.html';
 
    fs.readFile(filename, "binary", function(err, file) {
      if(err) {        
        response.writeHead(500, {"Content-Type": "text/plain"});
        response.write(err + "\n");
        response.end();
        return;
      }

      // Switch on content type
      var contentType = 'text/html';
      var extname = path.extname(filename);
      console.log("SERVING::    " + filename);
      switch (extname) {
        case '.js':
            contentType = 'text/javascript';
            break;
        case '.json':
            contentType = 'application/javascript';
            break;
        case '.css':
            contentType = 'text/css';
            break;
        case '.png':
            contentType = 'image/png';
            break;         
      }
       
      response.writeHead(200, {"Content-Type": contentType});
      response.write(file, "binary");
      response.end();
    });
  });
}).listen(parseInt(port, 10));
 
console.log("Static file server running at\n  => http://localhost:" + port + "/\nCTRL + C to shutdown");