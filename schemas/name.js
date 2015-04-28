var mongoose = require("mongoose"),
    Schema = mongoose.Schema,
    ObjectId = Schema.ObjectId;

var schema = new Schema({
    familyName: String,
    givenName: String,
    middleName: String
});

module.exports = schema;
