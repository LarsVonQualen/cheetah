var mongoose = require("mongoose"),
    schema = require("../schemas/sprintRetrospective.js");

module.exports = mongoose.model("SprintRetrospective", schema);
