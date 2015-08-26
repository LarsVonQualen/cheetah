module Cheetah.Areas.Auth {
  interface ISignUpFormController extends angular.IFormController {}

  class SignUpController {
    public static $inject = ["$state", "UserService", "NotificationService"];

    public form: ISignUpFormController;

    public username: string;
    public password: string;
    public passwordConfirmation: string;
    public loading: boolean = false;

    public constructor(
      protected $state: angular.ui.IStateService,
      protected userService: Services.UserService,
      protected notificationService: Services.NotificationService
    ) {}

    public submit() {
      if (this.password === this.passwordConfirmation) {
        this.loading = true;

        this
          .userService
          .register(this.username, this.password)
          .then(() => {
            this.notificationService.atNextStateChange(Enums.NotificationType.Success, "Account created!", "Nice!", Enums.NotificationLifecycle.Transient);
            this.$state.go("signin");
          }, () => {
            this.notificationService.transient(Enums.NotificationType.Danger, "Something went wrong!", "Whoops!");
          })
          .finally(() => this.loading = false);
      }
    }
  }

  angular.module("cheetah.areas").controller("SignUpController", SignUpController);
}
