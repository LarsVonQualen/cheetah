function HelloRoute(server, config, db) {
  server.get("/", function (req, res) {
    res.json(req.user);
  })

  server.get("/hello", function (req, res) {
    res.json({ hello: "world" })
  });

  server.get("/login", function (req, res) {
    res.json({ some: "login" })
  })
}

module.exports = HelloRoute;
