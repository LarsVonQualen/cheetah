module Cheetah.Directives.Navbar {
  angular.module("cheetah.directives").directive("navbar", () => {
    return {
      templateUrl: "app/directives/navbar/navbar.html",
      replace: true
    };
  });
}
