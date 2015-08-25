module Cheetah.Areas.Auth {
  interface ISignUpFormController extends angular.IFormController {}

  class SignUpController {
    public static $inject = ["$state"];

    public form: ISignUpFormController;

    public constructor(
      protected $state: angular.ui.IStateService
    ) {}

    public submit() {

    }
  }

  angular.module("cheetah.areas").controller("SignUpController", SignUpController);
}
