'use strict';

module.exports = function () {
  var self = this;

  this.app = {};
  this.app.path = "./";

  this.less = {};
  this.less.path = this.app.path + "less/";
  this.less.main = this.less.path + "app.less";
  this.less.all = this.less.path + "**/*.less";

  this.css = {};
  this.css.path = this.app.path + "css/";
  this.css.main = this.css.path + "app.css";

  this.typescript = {};
  this.typescript.path = this.app.path + "app/";
  this.typescript.all = {
    js: this.typescript.path + "**/*.js",
    ts: this.typescript.path + "**/*.ts"
  };

  this.typings = {};
  this.typings.path = "typings/";
  this.typings.all = this.typings.path + "**/*.d.ts";
  this.typings.app = this.typings.path + "app.d.ts";

  this.javascript = {};
  this.javascript.path = this.app.path + "js/";
  this.javascript.main = this.javascript.path + "app.js";
  this.javascript.all = this.javascript.path + "**/*.js";

  this.vendor = {};
  this.vendor.path = this.app.path + "vendor/";
  this.vendor.all = [
    this.vendor.path + "**/*.js",
    this.vendor.path + "**/*.css"
  ];

  this.index = {};
  this.index.path = this.app.path + "";
  this.index.main = this.index.path + "index.html";

  this.watch = {};
  this.watch.files = {};
  this.watch.files.all = ["app", "less"].map(function (val) {
    return self.app.path + val + "/**/*.*";
  });
};
