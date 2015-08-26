module Cheetah.Services {
  export class NotificationService {
    public static $Inject = ["$rootScope"];
    private notificationBuffer: Array<Models.Notification> = [];

    constructor(
      private $rootScope: angular.IRootScopeService
    ) {}

    public transient(type: Enums.NotificationType, body: string, title: string = "") {
      this.imediate(type, body, title, Enums.NotificationLifecycle.Transient);


    }

    public persistent(type: Enums.NotificationType, body: string, title: string = "") {
      this.imediate(type, body, title, Enums.NotificationLifecycle.Persistent);
    }

    public atNextStateChange(type: Enums.NotificationType, body: string, title: string = "", lifeCycle: Enums.NotificationLifecycle = Enums.NotificationLifecycle.Transient) {
      var notification = new Models.Notification(type, body, title, lifeCycle);

      this.notificationBuffer.push(notification);
    }

    public triggerStateChangeNotifications() {
      this.emit(this.notificationBuffer.slice(0));
      this.notificationBuffer = [];
    }

    private imediate(type: Enums.NotificationType, body: string, title: string, lifeCycle: Enums.NotificationLifecycle) {
      var notification = new Models.Notification(type, body, title, lifeCycle);

      this.emit([notification]);
    }

    private emit(notifications: Array<Models.Notification>) {
      this.$rootScope.$emit(Enums.Events.Notification, notifications);
    }
  }

  angular.module("cheetah.services").service("NotificationService", NotificationService);
}
