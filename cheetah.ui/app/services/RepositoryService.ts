module Cheetah.Services {
  export class RepositoryService {
    public static $inject = ["$q", "localStorageService"];

    public projects: Framework.IEndpoint<Models.Domain.Project>;
    public users: Framework.IEndpoint<Models.User>;

    constructor(
      protected $q: angular.IQService,
      protected localStorageService: angular.local.storage.ILocalStorageService) {
      this.setupProjects();
      this.setupUsers();
    }

    private setupProjects() {
      this.projects = this.factory<Models.Domain.Project>("projects");
    }

    public setupUsers() {
      this.users = this.factory<Models.User>("users");
    }

    public factory<TResource>(endpoint: string): Framework.LocalStorageEndPoint<TResource> {
      return new Framework.LocalStorageEndPoint<TResource>(this.$q, this.localStorageService, endpoint);
    }
  }

  angular.module("cheetah.services").service("RepositoryService", RepositoryService);
}
