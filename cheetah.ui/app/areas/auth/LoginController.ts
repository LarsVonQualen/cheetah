module Cheetah.Controllers {
  class LoginController {
    public static $inject = ["UserService"];
  }

  angular.module("cheetah.areas").controller("LoginController", LoginController);
}
