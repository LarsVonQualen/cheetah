var mongoose = require("mongoose"),
    schema = require("../schemas/task");

module.exports = function () {
    console.log("Registering 'Task' model...");
    mongoose.model("Task", schema);
};
