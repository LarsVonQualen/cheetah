var mongoose = require("mongoose"),
    schema = require("../schemas/sprint.js");

module.exports = mongoose.model("Sprint", schema);
