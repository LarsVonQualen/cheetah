var mongoose = require("mongoose"),
    schema = require("../schemas/task.js");

module.exports = mongoose.model("Task", schema);
