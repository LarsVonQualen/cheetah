module Cheetah.Controllers {
  class SignInController {
    public static $inject = ["UserService"];
  }

  angular.module("cheetah.areas").controller("SignInController", SignInController);
}
