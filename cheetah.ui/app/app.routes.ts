module Cheetah {
  class Router {
    constructor(private $stateProvider: angular.ui.IStateProvider, private $urlRouterProvider: angular.ui.IUrlRouterProvider) {
      this.defaultState("/");

      this.registerDashboardArea();
      this.registerProjectArea();
    }

    private defaultState(state: string) {
      this.$urlRouterProvider.otherwise(state);
    }

    private registerDashboardArea() {
      this.$stateProvider.state("dashboard", {
        url: "/",
        templateUrl: "app/areas/dashboard/DashboardOverview.html",
        controller: "DashboardOverviewController",
        controllerAs: "dashboardCtrl"
      });
    }

    private registerProjectArea() {
      this.$stateProvider.state("projectScrumboard", {
        url: "/project/:projectId/scrumboard",
        templateUrl: "app/areas/project/scrumboard.html"
      });
    }
  };

  angular.module("cheetah").config(["$stateProvider", "$urlRouterProvider", ($stateProvider, $urlRouterProvider) => {
    new Router($stateProvider, $urlRouterProvider)
  }]);
}
