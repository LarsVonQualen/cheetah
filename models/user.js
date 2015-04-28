var mongoose = require("mongoose"),
    schema = require("../schemas/user");

module.exports = mongoose.model("User", schema);
