module Cheetah.Directives.Restricted {
  interface IRestrictedScope extends angular.IScope {
    area: string;
  }

  class Restricted {
    public static $inject = ["$scope", "UserService"];

    public allowed: boolean = false;

    constructor(private $scope: IRestrictedScope, private userService: Services.UserService) {
      this.allowed = this.userService.canAccessArea(this.$scope.area);
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
