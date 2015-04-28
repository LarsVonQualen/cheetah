var mongoose = require("mongoose"),
    schema = require("../schemas/user");

module.exports = function () {
    console.log("Registering 'User' model...");
    mongoose.model("User", schema);
};
