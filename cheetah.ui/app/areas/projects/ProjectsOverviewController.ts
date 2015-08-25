module Cheetah.Areas.Projects {
  class ProjectsOverviewController {
    public static $inject = [];
    public projects = [];

    constructor() {

    }
  }

  angular.module("cheetah.areas").controller("ProjectsOverviewController", ProjectsOverviewController);
}
