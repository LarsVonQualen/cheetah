var mongoose = require("mongoose"),
    schema = require("../schemas/activity");

module.exports = function () {
    console.log("Registering 'Activity' model...");
    mongoose.model("Activity", schema);
};
