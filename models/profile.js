var mongoose = require("mongoose"),
    schema = require("../schemas/profile");

module.exports = function () {
    console.log("Registering 'Profile' model...");
    mongoose.model("Profile", schema);
};
