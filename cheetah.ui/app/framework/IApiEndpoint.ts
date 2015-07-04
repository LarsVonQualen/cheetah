module Cheetah.Framework {
  export interface IApiEndpoint<TResourceType> {
    $injector: angular.auto.IInjectorService;
    resourceName: string;
    baseApiUrl: string;

    get<TPrimaryKey>(primaryKey: TPrimaryKey): angular.IPromise<TResourceType>;
    all(): angular.IPromise<Array<TResourceType>>;
    save(resource: TResourceType): angular.IPromise<TResourceType>;
    delete(resource: TResourceType): angular.IPromise<TResourceType>;
  }
}
