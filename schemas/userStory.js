var mongoose = require("mongoose"),
    Schema = mongoose.Schema,
    ObjectId = Schema.ObjectId,
    taskSchema = require("./task");

var schema = new Schema({
    createdAt: Date,
    createdBy: ObjectId,
    updatedAt: Date,
    updatedBy: ObjectId,
    story: String,
    description: String,
    businessValue: Number,
    tasks: [taskSchema]
});

module.exports = schema;
