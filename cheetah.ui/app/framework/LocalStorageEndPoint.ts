module Cheetah.Framework {
  export class LocalStorageEndPoint<TResourceType> implements IApiEndpoint<TResourceType> {
    constructor(
      public $q: angular.IQService,
      public localStorageService: angular.local.storage.ILocalStorageService,
      public resourceName: string,
      public baseApiUrl?: string) {

    }

    public get<TPrimaryKey>(primaryKey: TPrimaryKey): angular.IPromise<TResourceType> {
      const d: angular.IDeferred<TResourceType> = this.$q.defer();

      var collection = this.getCollectionAs<Array<TResourceType>>();
      var item = _.findWhere(collection, (val: any) => val.Id === primaryKey);

      if (item !== undefined && item !== null) {
        d.resolve(item);
      } else {
        d.reject();
      }

      return d.promise;
    }

    public all(): angular.IPromise<Array<TResourceType>> {
      const d: angular.IDeferred<Array<TResourceType>> = this.$q.defer();

      var collection = this.getCollection();

      d.resolve(collection);

      return d.promise;
    }

    public save(resource: TResourceType): angular.IPromise<TResourceType> {
      const d: angular.IDeferred<TResourceType> = this.$q.defer();

      var collection = this.getCollection();

      var resourceId = (<any>resource).Id;

      if (resourceId === undefined || resourceId === null || resourceId === 0) {
        (<any>resource).Id = Math.random().toString(36).substring(7);
      }

      collection.push(resource);
      this.saveCollection(collection);

      d.resolve(resource);

      return d.promise;
    }

    public delete(resource: TResourceType): angular.IPromise<TResourceType> {
      return null;
    }

    private saveCollection(collection: Array<TResourceType>) {
      this.localStorageService.set(this.resourceName, collection);
    }

    private getCollection(): Array<TResourceType> {
      var collection = this.localStorageService.get<Array<TResourceType>>(this.resourceName);

      return collection !== undefined && collection !== null ? collection : [];
    }

    private getCollectionAs<TCollectionType>() {
      return this.localStorageService.get<TCollectionType>(this.resourceName);
    }
  }
}
