var mongoose = require("mongoose"),
    schema = require("../schemas/sprintRetrospective");

module.exports = function () {
    console.log("Registering 'SprintRetrospective' model...");
    mongoose.model("SprintRetrospective", schema);
};
