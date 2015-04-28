var passport = require("passport");

function AuthRoute(server, config, db) {
  // Redirect the user to Facebook for authentication.  When complete,
  // Facebook will redirect the user back to the application at
  //     /auth/facebook/callback
  server.get('/auth/facebook', passport.authenticate('facebook', { scope: "email" }));

  // Facebook will redirect the user to this URL after approval.  Finish the
  // authentication process by attempting to obtain an access token.  If
  // access was granted, the user will be logged in.  Otherwise,
  // authentication has failed.
  server.get('/auth/facebook/callback', passport.authenticate('facebook', {
    successRedirect: config.security.redirect.success,
    failureRedirect: config.security.redirect.failure
  }));
}

module.exports = AuthRoute;