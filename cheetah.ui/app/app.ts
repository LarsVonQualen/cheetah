module Cheetah {
  angular.module("cheetah.areas", []);
  angular.module("cheetah.directives", []);
  angular.module("cheetah.services", []);
  angular.module("cheetah.animations", []);

  angular.module("cheetah", [
    "ui.router"
    , "ui.bootstrap"
    , "ngAnimate"
    , "LocalStorageModule"
    , "cheetah.areas"
    , "cheetah.directives"
    , "cheetah.services"
  ]);
}
