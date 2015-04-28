var configs = require("./config"),
    target = process.env.TARGET || "dev",
    config = configs[target],
    db = require("./db"),
    CheetahApp = require("./app");

db.connect([config.mongo.connection, config.mongo.db].join("/"), function () {
    var app = new CheetahApp(config, db);
    app.start(function () {
        console.log("Cheetah API up and running!")
    });
});
