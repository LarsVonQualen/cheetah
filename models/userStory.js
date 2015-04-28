var mongoose = require("mongoose"),
    schema = require("../schemas/userStory.js");

module.exports = mongoose.model("UserStory", schema);
