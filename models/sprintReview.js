var mongoose = require("mongoose"),
    schema = require("../schemas/sprintReview.js");

module.exports = mongoose.model("SprintReview", schema);
