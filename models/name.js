var mongoose = require("mongoose"),
    schema = require("../schemas/name");

module.exports = function () {
    console.log("Registering 'Name' model...");
    mongoose.model("Name", schema);
};
