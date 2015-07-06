module Cheetah.Directives.Navbar {
  class NavbarController {
    public static $inject = ["RepositoryService"];
    public projects: Array<Models.Project> = [];

    constructor(RepositoryService: Services.RepositoryService) {
      RepositoryService.projects.all().then(projects => this.projects = projects);
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
