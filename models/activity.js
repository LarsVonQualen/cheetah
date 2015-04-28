var mongoose = require("mongoose"),
    schema = require("../schemas/activity");

module.exports = mongoose.model("Activity", schema);
