module Cheetah.Directives.Navbar {
  class NotificationsController {
    public static $inject = ["RepositoryService"];
    public projects: Array<Models.Domain.Project> = [];

    constructor(RepositoryService: Services.RepositoryService) {
      RepositoryService.projects.all().then(projects => this.projects = projects);
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
