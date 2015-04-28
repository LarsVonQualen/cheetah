var activityRoute = require("./activity"),
    authRoute = require("./auth")
    sprintRoute = require("./sprint"),
    sprintRetrospectiveRoute = require("./sprintRetrospective"),
    sprintReviewRoute = require("./sprintReview"),
    taskRoute = require("./task"),
    taskEventRoute = require("./taskEvent"),
    userRoute = require("./user"),
    userStoryRoute = require("./taskEvent"),
    helloRoute = require("./hello");

module.exports = {
    register: function (server, config, db) {
        activityRoute(server, config, db);
        authRoute(server, config, db);
        sprintRoute(server, config, db);
        sprintRetrospectiveRoute(server, config, db);
        sprintReviewRoute(server, config, db);
        taskRoute(server, config, db);
        taskEventRoute(server, config, db);
        userRoute(server, config, db);
        userStoryRoute(server, config, db);
        helloRoute(server, config, db);
    }
}
