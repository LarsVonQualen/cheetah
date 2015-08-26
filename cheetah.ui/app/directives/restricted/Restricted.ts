module Cheetah.Directives.Restricted {
  interface IRestrictedScope extends angular.IScope {
    area: string;
  }

  class Restricted {
    public static $inject = ["$scope", "UserService"];

    public allowed: boolean = true;

    constructor(private $scope: IRestrictedScope, private userService: Services.UserService) {
      this.allowed = userService.isAuthed();

      $scope.$on(Enums.Events.Authenticated, event => this.allowed = userService.isAuthed());
    }
  }

  angular.module("cheetah.directives").directive("restricted", () => {
    return {
      restrict: "E",
      scope: {
        area: "@"
      },
      transclude: true,
      controller: Restricted,
      controllerAs: "restrictedCtrl",
      template: "<ng-transclude ng-if=\"restrictedCtrl.allowed\"></ng-transclude>"
    };
  });
}
