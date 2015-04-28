var mongoose = require("mongoose"),
    Schema = mongoose.Schema,
    ObjectId = Schema.ObjectId;

var schema = new Schema({
    createdAt: Date,
    createdBy: ObjectId,
    state: String
});

module.exports = schema;
