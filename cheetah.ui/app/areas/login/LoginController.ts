module Cheetah.Controllers {
  class LoginController {
    public static $inject = ["UserService"];
  }

  angular.module("cheetah.controllers").controller("LoginController", LoginController);
}
