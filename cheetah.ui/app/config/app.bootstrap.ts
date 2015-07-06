module Cheetah {
  class Bootstrap {
    public static $inject = ["RepositoryService"];

    constructor(protected RepositoryService: Services.RepositoryService) {
      this.seedProjectCollection();
    }

    private seedProjectCollection() {
      var projectsRepo = this.RepositoryService.projects;

      projectsRepo.all().then(projects => {
        if (!projects.length) {
          var enplan = new Models.Project<string>("EnPlan", "Some system", new Date(), "lvq");
          var dms = new Models.Project<string>("DMS", "Some system", new Date(), "lvq");

          projectsRepo.save(enplan);
          projectsRepo.save(dms);
        }
      });
    }
  }

  angular.module("cheetah").run((RepositoryService: Services.RepositoryService) => new Bootstrap(RepositoryService));
}
