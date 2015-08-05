module Cheetah {
  class Router {
    constructor(
      private $stateProvider: angular.ui.IStateProvider,
      private $urlRouterProvider: angular.ui.IUrlRouterProvider
      ) {
      this.defaultState("/");

      this.registerAuthArea();
      this.registerDashboardArea();
      this.registerProjectArea();
      this.registerProjectsArea();
    }

    private defaultState(state: string) {
      this.$urlRouterProvider.otherwise(state);
    }

    private registerAuthArea() {
      this.$stateProvider.state("signin", {
        url: "/signin",
        templateUrl: "app/areas/auth/SignIn.html",
        controller: "SignInController",
        controllerAs: "signInCtrl"
      }).state("signup", {
        url: "/signup",
        templateUrl: "app/areas/auth/SignUp.html",
        controller: "SignUpController",
        controllerAs: "signUpCtrl"
      }).state("forgot-password", {
        url: "/forgot-password",
        templateUrl: "app/areas/auth/ForgotPassword.html",
        controller: "ForgotPasswordController",
        controllerAs: "forgotPasswordCtrl"
      });
    }

    private registerDashboardArea() {
      this.$stateProvider.state("dashboard", {
        url: "/",
        templateUrl: "app/areas/dashboard/DashboardOverview.html",
        controller: "DashboardOverviewController",
        controllerAs: "dashboardCtrl"
      });
    }

    private registerProjectsArea() {
      this.$stateProvider.state("projectsOverview", {
        url: "/projects",
        templateUrl: "app/areas/projects/ProjectsOverview.html",
        controller: "ProjectsOverviewController",
        controllerAs: "projectsCtrl"
      });
    }

    private registerProjectArea() {
      this.$stateProvider.state("projectScrumboard", {
        url: "/project/:projectId/scrumboard",
        templateUrl: "app/areas/project/Scrumboard.html"
      });
    }
  };

  angular.module("cheetah").config(["$stateProvider", "$urlRouterProvider", ($stateProvider, $urlRouterProvider) => {
    new Router($stateProvider, $urlRouterProvider)
  }]);
}
