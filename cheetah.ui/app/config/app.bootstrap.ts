module Cheetah {
  class Bootstrap {
    constructor(
      protected RepositoryService: Services.RepositoryService,
      private userService: Services.UserService,
      private $state: angular.ui.IStateService,
      private $rootScope: angular.IRootScopeService) {
      this.setupRestrictionInterceptor();
      this.seedProjectsCollection();
      this.seedUsersCollection();
    }

    private seedProjectsCollection() {
      var projectsRepo = this.RepositoryService.projects;

      projectsRepo.all().then(projects => {
        if (!projects.length) {
          var enplan = new Models.Domain.Project("PLN", "EnPlan", "Some system", "lvq");
          var dms = new Models.Domain.Project("DMS", "DMS Dyreregistrering", "Some system", "lvq");

          projectsRepo.save(enplan);
          projectsRepo.save(dms);
        }
      });
    }

    private seedUsersCollection() {
      var usersRepo = this.RepositoryService.users;

      usersRepo.all().then(users => {
        if (!users.length) {
          var test = new Models.User("test", "testesen", "test", "password", "Aarhus", new Date(), "test@test.org", "En meget fin herre..");

          usersRepo.save(test);
        }
      });
    }

    private setupRestrictionInterceptor() {
      this.$rootScope.$on("$stateChangeStart", (event, toState) => {
        this.restrictionInterceptionHandler(event, toState);
      });
    }

    private restrictionInterceptionHandler(event, toState) {
      if (!this.userService.canAccessArea(toState.name)) {
        event.preventDefault();

        this.$state.go("login");
      }
    }
  }

  angular.module("cheetah").run((RepositoryService, UserService, $state, $rootScope) => new Bootstrap(RepositoryService, UserService, $state, $rootScope));
}
