var gulp = require('gulp'),
    debug = require('gulp-debug'),
    inject = require('gulp-inject'),
    tsc = require('gulp-typescript'),
    tslint = require('gulp-tslint'),
    sourcemaps = require('gulp-sourcemaps'),
    del = require('del'),
    wiredep = require('wiredep'),
    less = require('gulp-less'),
    GulpConfig = require("./config/gulp"),
    debug = require("gulp-debug"),
    naturalSort = require("gulp-natural-sort"),
    angularSort = require("gulp-angular-filesort"),
    through = require("through");

require('natural-compare-lite');


function cheetahSort(order) {
  var files = [];

  function compare(a, b) {
      if (a > b) return +1;
      if (a < b) return -1;
      return 0;
  }

  function onFile(file) {
    files.push(file);
  }

  function onEnd() {
    require('natural-compare-lite');
    var _this = this;

    files.sort(function(a, b) {
      return compare(a.relative.toLowerCase(), b.relative.toLowerCase()); //String.naturalCompare(a.relative.toLowerCase(), b.relative.toLowerCase());
    });

    if(order === 'desc') {
      files.reverse();
    }

    files.forEach(function(file) {
      _this.emit('data', file);
    });

    return this.emit('end');
  }

  return through(onFile, onEnd);
}


var config = new GulpConfig();

gulp.task("compile-less", function () {
  gulp.src(config.less.main)
    .pipe(debug({ title: "less" }))
    .pipe(sourcemaps.init())
    .pipe(less())
    .pipe(sourcemaps.write("../css"))
    .pipe(gulp.dest(config.css.path));
});

gulp.task('gen-ts-refs', function () {
    var target = gulp.src(config.typings.app);
    var sources = gulp.src(config.typescript.all.ts, {read: false});

    return target.pipe(inject(sources, {
        starttag: '//{',
        endtag: '//}',
        transform: function (filepath) {
            return '/// <reference path="..' + filepath + '" />';
        }
    })).pipe(gulp.dest(config.typings.path));
});

gulp.task('compile-ts', ["gen-ts-refs"], function () {
    var sourceTsFiles = [config.typescript.all.ts,  //path to typescript files
                         config.typings.all,        //reference to library .d.ts files
                         config.typings.main];      //reference to app.d.ts files

    var tsResult = gulp.src(sourceTsFiles)
                       .pipe(sourcemaps.init())
                       .pipe(tsc({
                           target: 'ES5',
                           declarationFiles: false,
                           noExternalResolve: true
                       }));

        tsResult.dts.pipe(gulp.dest(config.javascript.path));
        return tsResult.js
                        .pipe(sourcemaps.write('.'))
                        .pipe(gulp.dest(config.javascript.path));
});

gulp.task('vendor-scripts', function () {
  return gulp.src(wiredep().js)
    .pipe(gulp.dest(config.vendor.path));
});

gulp.task('vendor-css', function () {
  return gulp.src(wiredep().css !== undefined ? wiredep().css : [])
    .pipe(gulp.dest(config.vendor.path));
});

gulp.task("vendor-clean", function (cb) {
  del(config.vendor.all, cb);
});

gulp.task("vendor", ["vendor-clean", "vendor-scripts", "vendor-css"])

gulp.task('index', ["vendor"], function () {
  return gulp.src(config.index.main)
    .pipe(wiredep.stream({
      fileTypes: {
        html: {
          replace: {
            js: function(filePath) {
              if (filePath.indexOf("/bootstrap/") > -1) {
                return "";
              }

              return '<script src="' + 'vendor/' + filePath.split('/').pop() + '"></script>';
            },
            css: function(filePath) {
              return '<link rel="stylesheet" href="' + 'vendor/' + filePath.split('/').pop() + '"/>';
            }
          }
        }
      }
    }))
    .pipe(inject(gulp.src(config.typescript.all.js).pipe(cheetahSort("asc")), {
        addRootSlash: false,
        transform: function(filePath, file, i, length) {
          return '<script src="' + filePath.replace('', '') + '"></script>';
        }
    }))
    .pipe(gulp.dest(config.app.path));
});

gulp.task("clean-app-js", function (cb) {
  gulp.src([config.typescript.all.js, config.typescript.all.map])
    .pipe(debug({title: "clean-app-js"}));

  del(config.typescript.all.js, function () {
    del(config.typescript.all.map, cb);
  });
});

gulp.task("default", ["compile-less", "index"]);

gulp.task("proxy", function () {
  var proxy = require('express-http-proxy');
  var express = require('express');
  var app = express();

  app.use(config.proxy.path, proxy(config.proxy.target, {
    forwardPath: function(req, res) {
      return require('url').parse(req.url).path;
    }
  }));

  app.use("/", express.static(__dirname));

  app.listen(config.proxy.port);
});

gulp.task("watch", ["default"], function () {
  gulp.src(config.watch.files.all).pipe(debug({title: "watch"}));
  gulp.watch(config.watch.files.all, ["default"]);
});
