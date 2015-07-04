module Cheetah.Framework {
  export class LocalStorageEndPoint<TResourceType> implements IApiEndpoint<TResourceType> {
    protected localStorage: angular.local.storage.ILocalStorageService;

    constructor(public $injector: angular.auto.IInjectorService, public resourceName: string, public baseApiUrl?: string, actions?: any, options?: angular.resource.IResourceOptions) {
      this.localStorage = $injector.get("LocalStorageService");
    }

    get<TPrimaryKey>(primaryKey: TPrimaryKey): angular.IPromise<TResourceType> {
      const d: angular.IDeferred<TResourceType> = this.$injector.get("$q");

      var collection = this.getCollectionAs<Array<IHasPrimaryKey<TPrimaryKey>>>();
      var item = _.findWhere(collection, (val: IHasPrimaryKey<TPrimaryKey>) => val.getPrimaryKey() === primaryKey);

      if (item !== undefined && item !== null) {
        d.resolve(item);
      } else {
        d.reject();
      }

      return d.promise;
    }
    all(): angular.IPromise<Array<TResourceType>> {
      const d: angular.IDeferred<Array<TResourceType>> = this.$injector.get("$q");

      var collection = this.getCollection();

      d.resolve(collection);

      return d.promise;
    }
    save(resource: TResourceType): angular.IPromise<TResourceType> {
      const d: angular.IDeferred<TResourceType> = this.$injector.get("$q");

      var collection = this.getCollection();
      collection.push(resource);
      this.saveCollection(collection);

      d.resolve(resource);

      return d.promise;
    }
    delete(resource: TResourceType): angular.IPromise<TResourceType> {
      return null;
    }

    private saveCollection(collection: Array<TResourceType>) {
      this.localStorage.set(this.resourceName, collection);
    }

    private getCollection(): Array<TResourceType> {
      return this.localStorage.get<Array<TResourceType>>(this.resourceName);
    }

    private getCollectionAs<TCollectionType>() {
      return this.localStorage.get<TCollectionType>(this.resourceName);
    }
  }
}
