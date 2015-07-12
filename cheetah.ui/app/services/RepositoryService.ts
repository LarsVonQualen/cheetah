module Cheetah.Services {
  export class RepositoryService {
    public static $inject = ["$q", "localStorageService"];

    public projects: Framework.IApiEndpoint<Models.Project>;
    public users: Framework.IApiEndpoint<Models.User>;

    constructor(
      protected $q: angular.IQService,
      protected localStorageService: angular.local.storage.ILocalStorageService) {
      this.setupProjects();
      this.setupUsers();
    }

    private setupProjects() {
      this.projects = this.factory<Models.Project>("projects");
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
