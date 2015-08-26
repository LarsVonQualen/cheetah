module Cheetah.Directives.Navbar {
  class NavbarController {
    public static $inject = ["$rootScope", "UserService", "NotificationService"];
    public user: Models.User = null;

    constructor(
      private $rootScope: angular.IRootScopeService,
      private userService: Services.UserService,
      private notificationService: Services.NotificationService
    ) {
      this.userService.me().then(user => {
        this.user = user;
      });

      $rootScope.$on(Enums.Events.Authenticated, (event, user) => {
        this.user = user;
      });
    }

    public signout() {
      this.userService.signout();
    }
  }

  angular.module("cheetah.directives").directive("navbar", () => {
    return {
      templateUrl: "app/directives/navbar/navbar.html",
      replace: true,
      controller: NavbarController,
      controllerAs: "navbarCtrl"
    };
  });
}
