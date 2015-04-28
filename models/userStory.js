var mongoose = require("mongoose"),
    schema = require("../schemas/userStory");

module.exports = mongoose.model("UserStory", schema);
