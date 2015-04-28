var mongoose = require("mongoose"),
    schema = require("../schemas/taskEvent");

module.exports = function () {
    console.log("Registering 'TaskEvent' model...");
    mongoose.model("TaskEvent", schema);
};
