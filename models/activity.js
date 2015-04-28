var mongoose = require("mongoose"),
    schema = require("../schemas/activity.js");

module.exports = mongoose.model("Activity", schema);
