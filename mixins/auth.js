var passport = require('passport'),
    FacebookStrategy = require('passport-facebook').Strategy,
    mongoose = require("mongoose");

function AuthMixin(config, db) {
    var facebook = new FacebookStrategy({
        clientID: config.secret.facebook.clientID,
        clientSecret: config.secret.facebook.clientSecret,
        callbackURL: config.secret.facebook.callbackURL
    }, function(accessToken, refreshToken, profile, done) {
        var UserModel = mongoose.model("User");

        UserModel.findOne({
            email: profile.emails[0].value
        }, function (err, user) {
            if (err) done(err);

            if (user !== undefined && user !== null) {
                done(null, user);
            } else {
                UserModel.create({
                    firstname: profile.name.givenName,
                    lastname: profile.name.familyName,
                    email: profile.emails[0].value
                }, function (err, user) {
                    if (err || user === undefined || user === null) done(err);

                    if (user !== undefined && user !== null) {
                        done(null, user);
                    }
                });
            }
        });
    });

    passport.serializeUser(function(user, done) {
        done(null, user);
    });

    passport.deserializeUser(function(user, done) {
        done(null, user);
    });

    passport.use(facebook);
}

module.exports = AuthMixin;
