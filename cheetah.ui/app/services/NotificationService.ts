module Cheetah.Services {
  export class NotificationService {
    public transient(type: Enums.NotificationType, body: string, title?: string) {

    }

    public persistent(type: Enums.NotificationType, body: string, title?: string) {

    }
  }

  angular.module("cheetah.services").service("NotificationService", NotificationService);
}
