module Cheetah {
  class Bootstrap {
    constructor(
      private userService: Services.UserService,
      private $state: angular.ui.IStateService,
      private $rootScope: angular.IRootScopeService,
      private notificationService: Services.NotificationService
      ) {
      this.setupRestrictionInterceptor();
    }



    private setupRestrictionInterceptor() {
      this.$rootScope.$on("$stateChangeStart", (event, toState) => {
        this.restrictionInterceptionHandler(event, toState);
        this.notificationService.triggerStateChangeNotifications();
      });
    }

    private restrictionInterceptionHandler(event, toState) {
      if (!this.userService.canAccess(toState)) {
        event.preventDefault();
        this.notificationService.atNextStateChange(Enums.NotificationType.Danger, "You have to sign in!", "Whoops!")
        this.$state.go("signin");
      }
    }
  }

  angular.module("cheetah").run((UserService, $state, $rootScope, NotificationService) => new Bootstrap(UserService, $state, $rootScope, NotificationService));
}
