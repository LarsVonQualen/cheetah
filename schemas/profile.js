var mongoose = require("mongoose"),
    Schema = mongoose.Schema,
    ObjectId = Schema.ObjectId;

var schema = new Schema({
    provider: String,
    id: String,
    displayName: String,
    name: { type: ObjectId, ref: 'Name' },
    emails: { type: ObjectId, ref: 'Email' }
});

module.exports = schema;
