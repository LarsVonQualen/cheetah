module Cheetah {
  class Bootstrap {
    constructor(
      private userService: Services.UserService,
      private $state: angular.ui.IStateService,
      private $rootScope: angular.IRootScopeService,
      private notificationService: Services.NotificationService,
      private $q: angular.IQService
      ) {
      this.setupRestrictionInterceptor();
    }

    private setupRestrictionInterceptor() {
      this.$rootScope.$on("$stateChangeStart", (event, toState) => {
        this.restrictionInterceptionHandler(event, toState);
        this.notificationService.triggerStateChangeNotifications();
      });
    }

    private restrictionInterceptionHandler(event, toState: angular.ui.IState) {
      if (!this.userService.canAccess(toState)) {
        event.preventDefault();

        this.authenticate().then(() => this.$state.go(toState.name, toState.params));
      }
    }

    private authenticate(): angular.IPromise<{}> {
      var deferred = this.$q.defer();

      this.userService.authenticate().then(deferred.resolve, () => {
        this.redirectToSignin();

        deferred.reject();
      })

      return deferred.promise;
    }

    private redirectToSignin() {
      this.notificationService.atNextStateChange(Enums.NotificationType.Danger, "You have to sign in!", "Whoops!");
      this.$state.go("signin");
    }
  }

  angular.module("cheetah").run((UserService, $state, $rootScope, NotificationService, $q) => new Bootstrap(UserService, $state, $rootScope, NotificationService, $q));
}
