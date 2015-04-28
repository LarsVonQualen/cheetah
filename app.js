var express = require("express"),
    server = express(),
    lodash = require("lodash"),
    activityRoute = require("./routes/activity"),
    sprintRoute = require("./routes/sprint"),
    sprintRetrospectiveRoute = require("./routes/sprintRetrospective"),
    sprintReviewRoute = require("./routes/sprintReview"),
    taskRoute = require("./routes/task"),
    taskEventRoute = require("./routes/taskEvent"),
    userRoute = require("./routes/user"),
    userStoryRoute = require("./routes/taskEvent");

function CheetahApp(config, db) {
    this._config = config;
    this._db = db;
}

CheetahApp.prototype.start = function (onComplete) {
    activityRoute(server, this._config, this._db);
    sprintRoute(server, this._config, this._db);
    sprintRetrospectiveRoute(server, this._config, this._db);
    sprintReviewRoute(server, this._config, this._db);
    taskRoute(server, this._config, this._db);
    taskEventRoute(server, this._config, this._db);
    userRoute(server, this._config, this._db);
    userStoryRoute(server, this._config, this._db);

    server.listen(this._config.server.port, onComplete);
};

module.exports = CheetahApp;
