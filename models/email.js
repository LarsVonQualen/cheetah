var mongoose = require("mongoose"),
    schema = require("../schemas/email");

module.exports = function () {
    console.log("Registering 'Email' model...");
    mongoose.model("Email", schema);
};
