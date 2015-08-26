module Cheetah.Directives.Navbar {
  class NotificationsController {
    public static $Inject = ["$rootScope", "$timeout"];
    public notifications: Array<Models.Notification> = [];

    constructor(
      private $rootScope: angular.IRootScopeService,
      private $timeout: angular.ITimeoutService
    ) {
      $rootScope.$on(Enums.Events.Notification, (event, notifications: Array<Models.Notification>) => {
        this.handleTransient(notifications.filter(notification => notification.lifeCycle === Enums.NotificationLifecycle.Transient));
        this.handlePersistent(notifications.filter(notification => notification.lifeCycle === Enums.NotificationLifecycle.Persistent));
      });
    }

    public remove(notification: Models.Notification) {
      var index = this.notifications.indexOf(notification);

      if (index > -1) {
        this.notifications.splice(index, 1);
      }
    }

    private handleTransient(notifications: Array<Models.Notification>) {
      notifications.forEach(notification => {
        this.notifications.push(notification);

        this.$timeout(() => {
          this.remove(notification);
        }, 5000);
      });
    }

    private handlePersistent(notifications: Array<Models.Notification>) {
      notifications.forEach(notification => this.notifications.push(notification));
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
