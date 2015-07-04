module Cheetah.Directives.Tasks {
  angular.module("cheetah.directives").directive("tasks", () => {
    return {
      templateUrl: "app/directives/tasks/tasks.html",
      replace: true
    };
  });
}
