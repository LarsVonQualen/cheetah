// Bring Mongoose into the app
var mongoose = require( 'mongoose' ),
    lodash = require("lodash");

// If the connection throws an error
mongoose.connection.on('error',function (err) {
  console.log('Mongoose default connection error: ' + err);
});

// When the connection is disconnected
mongoose.connection.on('disconnected', function () {
  console.log('Mongoose default connection disconnected');
});

// If the Node process ends, close the Mongoose connection
process.on('SIGINT', function() {
  mongoose.connection.close(function () {
    console.log('Mongoose default connection disconnected through app termination');
    process.exit(0);
  });
});

// BRING IN YOUR SCHEMAS & MODELS // For example
//require('./../model/team');

module.exports = {
  connect: function connect(uri, onConnected) {
    console.log("Mongoose connecting to " + uri);

    mongoose.connect(uri);

    mongoose.connection.on('connected', function () {
      console.log('Mongoose default connection open to ' + uri);

      if (lodash.isFunction(onConnected)) {
        onConnected();
      }
    });
  }
};
