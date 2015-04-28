var Activity = require("./activity"),
    Sprint = require("./sprint"),
    SprintRetrospective = require("./sprintRetrospective"),
    SprintReview = require("./sprintReview"),
    Task = require("./task"),
    TaskEvent = require("./taskEvent"),
    User = require("./user"),
    UserStory = require("./userStory");

exports.init = function () {
    console.log("Start initing models...");
    Activity();
    Sprint();
    SprintRetrospective();
    SprintReview();
    Task();
    TaskEvent();
    User();
    UserStory();
    console.log("Stop initing models...");
};
