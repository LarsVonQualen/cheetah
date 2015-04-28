var auth = require("./auth.js");

module.exports = {
    bootstrap: function (config, db) {
        auth(config);
    }
}
