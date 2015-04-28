var mongoose = require("mongoose"),
    schema = require("../schemas/sprint");

module.exports = function () {
    console.log("Registering 'Sprint' model...");
    mongoose.model("Sprint", schema);
};
