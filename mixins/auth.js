var passport = require('passport'),
    FacebookStrategy = require('passport-facebook').Strategy,
    mongoose = require("mongoose"),
    UserModel = mongoose.model("User"),
    Profile = mongoose.model("Profile"),
    Name = mongoose.model("Name"),
    Email = mongoose.model("Email");

function AuthMixin(config, db) {
    var facebook = new FacebookStrategy({
        clientID: config.secret.facebook.clientID,
        clientSecret: config.secret.facebook.clientSecret,
        callbackURL: config.secret.facebook.callbackURL
    }, function(accessToken, refreshToken, profile, done) {
        UserModel
        .findOne({
            id: profile.id
        })
        .populate("profile")
        .exec(function (err, user) {
            if (err) done(err);

            if (user !== null) {
                done(null, user);
            } else {
                UserModel.create({
                    id: profile.id
                }, function (err, user) {
                    if (err) done(err);

                    if (user !== null) {
                        Profile.create(profile, function (err, p) {
                            user.profile = p;
                            user.save(function (err, u) {
                                done(null, u);
                            });


                        });


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
