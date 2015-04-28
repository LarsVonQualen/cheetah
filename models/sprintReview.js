var mongoose = require("mongoose"),
    schema = require("../schemas/sprintReview");

module.exports = mongoose.model("SprintReview", schema);
