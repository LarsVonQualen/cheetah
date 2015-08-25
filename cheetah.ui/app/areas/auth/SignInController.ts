module Cheetah.Controllers {
  class SignInController {
    public static $inject = ["UserService", "NotificationService", "$log", "$state"];

    public username: string;
    public password: string;
    public progress: string;
    public loading: boolean;

    constructor(
      private userService: Services.UserService,
      private notificationService: Services.NotificationService,
      private $log: angular.ILogService,
      private $state: angular.ui.IStateService
    ) {}

    public signin() {
      this.loading = true;
      this.progress = "Authorizing";

      this.userService
        .authorize(this.username, this.password)
        .then(
          userInfo => {
            this.notificationService.transient(Enums.NotificationType.Success, "Successfully authenticated.", "Great!");
            this.$state.go("dashboard");
          },
          reason => {
            this.notificationService.transient(Enums.NotificationType.Warning, "Something went wrong during the authentication process, please try agin.", "Whoops!");
            this.$log.warn(reason);
          },
          state => this.progress = state)
        .finally(
          () => this.loading = false
        );
    }
  }

  angular.module("cheetah.areas").controller("SignInController", SignInController);
}
