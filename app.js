// Libs
var express = require("express"),
    server = express(),
    lodash = require("lodash"),
    bodyParser = require("body-parser"),
    passport = require("passport"),
    session = require("express-session");

// App
var routes = require("./routes/init"),
    mixins = require("./mixins/init");

function CheetahApp(config, db) {
    this._config = config;
    this._db = db;
}

CheetahApp.prototype.start = function (onComplete) {
    server.use(bodyParser.json());
    server.use(session({
        secret: "herp derp"
    }));
    server.use(passport.initialize());
    server.use(passport.session());

    mixins.bootstrap(this._config, this._db);
    routes.register(server, this._config, this._db);

    server.listen(this._config.server.port, onComplete);
};

module.exports = CheetahApp;
