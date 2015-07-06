module Cheetah.Services {
  export class RepositoryService {
    public static $inject = ["$injector"];

    public projects: Framework.LocalStorageEndPoint<Models.Project>;

    constructor(protected $injector: angular.auto.IInjectorService) {
      this.projects = new Framework.LocalStorageEndPoint<Models.Project>($injector, "project");
    }
  }

  angular.module("cheetah.services").service("RepositoryService", RepositoryService);
}
