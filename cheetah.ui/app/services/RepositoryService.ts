module Cheetah.Services {
  export class RepositoryService {
    public static $inject = ["$q", "localStorageService"];

    public projects: Framework.LocalStorageEndPoint<Models.Project>;

    constructor(
      protected $q: angular.IQService,
      protected localStorageService: angular.local.storage.ILocalStorageService) {
      this.setupProjects();
    }

    private setupProjects() {
      this.projects = new Framework.LocalStorageEndPoint<Models.Project>(this.$q, this.localStorageService, "project");
    }
  }

  angular.module("cheetah.services").service("RepositoryService", RepositoryService);
}
