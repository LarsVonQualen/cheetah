module Cheetah.Framework {
  export interface IEndpoint<TResourceType> {
    resourceName: string;
    baseApiUrl: string;

    get<TPrimaryKey>(primaryKey: TPrimaryKey): angular.IPromise<TResourceType>;
    all(): angular.IPromise<Array<TResourceType>>;
    save(resource: TResourceType): angular.IPromise<TResourceType>;
    delete(resource: TResourceType): angular.IPromise<boolean>;
    findWhere(predicate: (resource: TResourceType) => boolean): angular.IPromise<TResourceType>;
  }
}
