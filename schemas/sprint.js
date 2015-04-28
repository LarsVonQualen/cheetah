var mongoose = require("mongoose"),
    Schema = mongoose.Schema,
    ObjectId = Schema.ObjectId,
    userStorySchema = require("./userStory.js");

var schema = new Schema({
    startedAt: Date,
    startedBy: ObjectId,
    endedAt: Date,
    endedBy: ObjectId,
    updatedAt: Date,
    updatedBy: ObjectId,
    createdAt: Date,
    createdBy: ObjectId,
    goal: String,
    velocity: Number,
    sprintRetrospective: ObjectId,
    sprintReview: ObjectId,
    userStories: [userStorySchema]
});

module.exports = schema;
