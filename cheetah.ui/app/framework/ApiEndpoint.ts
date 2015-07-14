module Cheetah.Framework {
  export class ApiEndpoint<TResourceType> implements IEndpoint<TResourceType> {
    protected resource: angular.resource.IResourceClass<angular.resource.IResource<TResourceType>>;

    constructor(
      protected $q: angular.IQService,
      protected $resource: angular.resource.IResourceService,
      public resourceName: string,
      public baseApiUrl?: string,
      actions?: any,
      options?: angular.resource.IResourceOptions) {
      this.resource = $resource(`${baseApiUrl}/${resourceName}/:resourceId`, { resourceId: "@Id" }, actions, options);
    }

    public get<TPrimaryKey>(primaryKey: TPrimaryKey): angular.IPromise<TResourceType> {
      const d: angular.IDeferred<TResourceType> = this.$q.defer();

      this.resource.get({ resourceId: primaryKey }, d.resolve, d.reject);

      return d.promise;
    }

    public all(): angular.IPromise<Array<TResourceType>> {
      const d: angular.IDeferred<Array<TResourceType>> = this.$q.defer();

      this.resource.query({}, d.resolve, d.reject);

      return d.promise;
    }

    public save(resource: TResourceType): angular.IPromise<TResourceType> {
      const d: angular.IDeferred<TResourceType> = this.$q.defer();

      this.resource.save(resource, d.resolve, d.reject);

      return d.promise;
    }

    public delete(resource: TResourceType): angular.IPromise<boolean> {
      const d: angular.IDeferred<boolean> = this.$q.defer();

      this.resource.delete(resource, d.resolve, d.reject);

      return d.promise;
    }

    public findWhere(predicate: (resource: TResourceType) => boolean): angular.IPromise<TResourceType> {
      return null;
    }
  }
}
