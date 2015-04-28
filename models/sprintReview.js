var mongoose = require("mongoose"),
    schema = require("../schemas/sprintReview");

module.exports = function () {
    console.log("Registering 'SprintReview' model...");
    mongoose.model("SprintReview", schema);
};
