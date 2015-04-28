var Activity = require("./activity"),
    Sprint = require("./sprint"),
    SprintRetrospective = require("./sprintRetrospective"),
    SprintReview = require("./sprintReview"),
    Task = require("./task"),
    TaskEvent = require("./taskEvent"),
    User = require("./user"),
    UserStory = require("./userStory"),
    Profile = require("./profile"),
    Name = require("./name"),
    Email = require("./email");

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
    Profile();
    Name();
    Email();
    console.log("Stop initing models...");
};
