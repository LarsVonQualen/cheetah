var mongoose = require("mongoose"),
    Schema = mongoose.Schema,
    ObjectId = Schema.ObjectId;

var schema = new Schema({
    username: String,
    firstname: String,
    lastname: String,
    email: String,
    createdAt: Date,
    updatedAt: Date,
    lastActiveAt: Date
});

module.exports = schema;
