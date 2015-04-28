var mongoose = require("mongoose"),
    schema = require("../schemas/userStory");

module.exports = function () {
    console.log("Registering 'UserStory' model...");
    mongoose.model("UserStory", schema);
};
