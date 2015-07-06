module Cheetah.Directives.Userstory {
  class UserstoryController {
    public showTasks: boolean = true;

    constructor() {

    }

    public toggleTasks() {
      this.showTasks = !this.showTasks;
    }
  }

  angular.module("cheetah.directives").directive("userstory", () => {
    return {
      templateUrl: "app/directives/userstory/userstory.html",
      transclude: true,
      replace: true,
      controller: UserstoryController,
      controllerAs: "userstoryCtrl"
    };
  });
}
