var mongoose = require("mongoose"),
    schema = require("../schemas/sprintRetrospective");

module.exports = mongoose.model("SprintRetrospective", schema);
