var gulp = require('gulp'),
    debug = require('gulp-debug'),
    inject = require('gulp-inject'),
    tsc = require('gulp-typescript'),
    tslint = require('gulp-tslint'),
    sourcemaps = require('gulp-sourcemaps'),
    del = require('del'),
    wiredep = require('wiredep'),
    less = require('gulp-less-sourcemap'),
    GulpConfig = require("./config/gulp"),
    debug = require("gulp-debug");

var config = new GulpConfig();

gulp.task("compile-less", function () {
  gulp.src(config.less.main)
    .pipe(less())
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
    .pipe(inject(
      gulp.src(config.typescript.all.js, { read: false }), {
        addRootSlash: false,
        transform: function(filePath, file, i, length) {
          return '<script src="' + filePath.replace('', '') + '"></script>';
        }
    }))
    .pipe(gulp.dest(config.app.path));
});

gulp.task("default", ["compile-less", "index"]);

gulp.task("watch", ["default"], function () {
  gulp.src(config.watch.files.all).pipe(debug({title: "watch"}));
  gulp.watch(config.watch.files.all, ["default"]);
});
