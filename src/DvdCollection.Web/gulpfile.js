'use strict';

const { series, parallel } = require('gulp');

var paths = {
  scss: './scss/**/*.scss'
};

function clean(cb) {
  // body omitted
  cb();
}

function css(cb) {
  //console.log(paths.scss);
  cb();
}

function js(cb) {
  // body omitted
  cb();
}

function cssMinify(cb) {
  // body omitted
  cb();
}

function jsMinify(cb) {
  // body omitted
  cb();
}

function build(cb) {  
  series(
    clean,
    parallel(css, js),
    parallel(cssMinify, jsMinify)
  );
  
  cb();
}
exports.build = build;

function watch(cb) {
  // body omitted
  cb();
}

exports.default = series(build, watch);