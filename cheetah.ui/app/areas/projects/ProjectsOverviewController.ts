module Cheetah.Areas.Projects {
  class ProjectsOverviewController {
    public static $inject = ["RepositoryService"];
    public projects: Array<Models.Domain.Project> = [];

    constructor(private RepositoryService: Services.RepositoryService) {
      RepositoryService.projects.all().then(projects => this.projects = projects);
    }
  }

  angular.module("cheetah.areas").controller("ProjectsOverviewController", ProjectsOverviewController);
}
