var mongoose = require("mongoose"),
    schema = require("../schemas/task");

module.exports = mongoose.model("Task", schema);
