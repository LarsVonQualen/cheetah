module Cheetah.Framework {
  export class ApiEndpoint<TResourceType> implements IApiEndpoint<TResourceType> {
    protected resource: angular.resource.IResourceClass<angular.resource.IResource<TResourceType>>

    constructor(public $injector: angular.auto.IInjectorService, public resourceName: string, public baseApiUrl?: string, actions?: any, options?: angular.resource.IResourceOptions) {
      this.resource = $injector.get("$resource")(`${baseApiUrl}/${resourceName}/:resourceId`, { resourceId: "@Id" }, actions, options);
    }

    public get<TPrimaryKey>(primaryKey: TPrimaryKey): angular.IPromise<TResourceType> {
      const d: angular.IDeferred<TResourceType> = this.$injector.get("$q");

      this.resource.get({ resourceId: primaryKey }, d.resolve, d.reject);

      return d.promise;
    }

    public all(): angular.IPromise<Array<TResourceType>> {
      const d: angular.IDeferred<Array<TResourceType>> = this.$injector.get("$q");

      this.resource.query({}, d.resolve, d.reject);

      return d.promise;
    }

    public save(resource: TResourceType): angular.IPromise<TResourceType> {
      const d: angular.IDeferred<TResourceType> = this.$injector.get("$q");

      this.resource.save(resource, d.resolve, d.reject);

      return d.promise;
    }

    public delete(resource: TResourceType): angular.IPromise<TResourceType> {
      const d: angular.IDeferred<TResourceType> = this.$injector.get("$q");

      this.resource.delete(resource, d.resolve, d.reject);

      return d.promise;
    }
  }
}
