var mongoose = require("mongoose"),
    schema = require("../schemas/taskEvent.js");

module.exports = mongoose.model("TaskEvent", schema);
