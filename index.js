var configs = require("./configs"),
    secrets = require("./secrets")
    target = process.env.TARGET || "dev",
    config = configs[target],
    secret = secrets[target],
    db = require("./db"),
    CheetahApp = require("./app");

// Concat secrets onto config
config.secret = secret;

db.connect([config.mongo.connection, config.mongo.db].join("/"), function () {
    var app = new CheetahApp(config, db);
    app.start(function () {
        console.log("Cheetah API up and running!")
    });
});
