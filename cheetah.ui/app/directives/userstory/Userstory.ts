module Cheetah.Directives.Userstory {
  angular.module("cheetah.directives").directive("userstory", () => {
    return {
      templateUrl: "app/directives/userstory/userstory.html",
      transclude: true,
      replace: true
    };
  });
}
