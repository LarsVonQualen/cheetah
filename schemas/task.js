var mongoose = require("mongoose"),
    Schema = mongoose.Schema,
    ObjectId = Schema.ObjectId,
    taskEventSchema = require("./taskEvent");

var schema = new Schema({
    createdAt: Date,
    createdBy: ObjectId,
    updatedAt: Date,
    updatedBy: ObjectId,
    summary: String,
    description: String,
    pointEstimate: Number,
    remainingPoints: Number,
    taskEvents: [taskEventSchema]
});

module.exports = schema;
