module Cheetah.Services {
  export class NotificationService {
    public transient(type: Enums.NotificationType, body: string, title?: string) {

    }

    public persistent(type: Enums.NotificationType, body: string, title?: string) {

    }

    public atNextStateChange(type: Enums.NotificationType, body: string, title?: string, lifeCycle: Enums.NotificationLifecycle = Enums.NotificationLifecycle.Transient) {

    }

    public triggerStateChangeNotifications() {

    }
  }

  angular.module("cheetah.services").service("NotificationService", NotificationService);
}
