module Cheetah.Directives.Navbar {
  class NavbarController {
    public static $inject = [];
    public projects = [];

    constructor() {

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
