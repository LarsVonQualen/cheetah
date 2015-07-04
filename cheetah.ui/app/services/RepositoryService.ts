module Cheetah.Services {
  class RepositoryService<TResource> {
    public static $inject = [];

    constructor() {

    }

    public get<TPrimaryKey>(primaryKey: TPrimaryKey): angular.IPromise<TResource> {
      return null;
    }

    public all(): angular.IPromise<Array<TResource>> {
      return null;
    }

    public save(resource: TResource): angular.IPromise<TResource> {
      return null;
    }

    public delete(resource: TResource): angular.IPromise<TResource> {
      return null;
    }
  }

  angular.module("cheetah.services").service("RepositoryService", RepositoryService);
}
