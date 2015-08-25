module Cheetah.Directives.Navbar {
  class NotificationsController {
    public static $inject = [];
    public projects = [];

    constructor() {

    }
  }

  angular.module("cheetah.directives").directive("notifications", () => {
    return {
      templateUrl: "app/directives/notifications/notifications.html",
      replace: true,
      controller: NotificationsController,
      controllerAs: "notificationsCtrl"
    };
  });
}
