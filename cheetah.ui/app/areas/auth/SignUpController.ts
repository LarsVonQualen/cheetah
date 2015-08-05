module Cheetah.Areas.Auth {
  interface ISignUpFormController extends angular.IFormController {}

  class SignUpController {
    public static $inject = ["RepositoryService", "$state"];

    public user: Models.User = new Models.User("", "", "", "", "", null, "", "");
    public form: ISignUpFormController;

    public constructor(
      protected RepositoryService: Services.RepositoryService
      , protected $state: angular.ui.IStateService
    ) {}

    public submit() {
      if (this.form.$valid) {
        this.RepositoryService.users.save(this.user).then(user => {
          this.$state.go("signin");
        });
      }
    }
  }

  angular.module("cheetah.areas").controller("SignUpController", SignUpController);
}
