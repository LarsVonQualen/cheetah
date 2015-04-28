var mongoose = require("mongoose"),
    schema = require("../schemas/sprint");

module.exports = mongoose.model("Sprint", schema);
