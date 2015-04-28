var mongoose = require("mongoose"),
    schema = require("../schemas/taskEvent");

module.exports = mongoose.model("TaskEvent", schema);
