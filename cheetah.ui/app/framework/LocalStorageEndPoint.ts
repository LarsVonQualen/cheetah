module Cheetah.Framework {
  export class LocalStorageEndPoint<TResourceType> implements IApiEndpoint<TResourceType> {
    constructor(
      public $q: angular.IQService,
      public localStorageService: angular.local.storage.ILocalStorageService,
      public resourceName: string,
      public baseApiUrl?: string) {

    }

    public get<TPrimaryKey>(primaryKey: TPrimaryKey): angular.IPromise<TResourceType> {
      return this.findWhere((val: any) => val.Id === primaryKey);
    }

    public all(): angular.IPromise<Array<TResourceType>> {
      return new this.$q<Array<TResourceType>>((resolve, reject) => {
        var collection = this.getCollection();

        resolve(collection);
      });
    }

    public save(resource: TResourceType): angular.IPromise<TResourceType> {
      return new this.$q<TResourceType>((resolve, reject) => {
        var collection = this.getCollection();

        var resourceId = (<any>resource).Id;

        if (resourceId === undefined || resourceId === null || resourceId === 0) {
          (<any>resource).Id = Math.random().toString(36).substring(7);
        }

        collection.push(resource);
        this.saveCollection(collection);

        resolve(resource);
      });
    }

    public delete(resource: TResourceType): angular.IPromise<boolean> {
      return new this.$q<boolean>((resolve, reject) => {
        resolve(true);
      });
    }

    public findWhere(predicate: (resource: TResourceType) => boolean): angular.IPromise<TResourceType> {
      return new this.$q<TResourceType>((resolve, reject) => {
        var collection = this.getCollection();

        var item = _.findWhere(collection, predicate);

        if (item !== undefined && item !== null) {
          resolve(item);
        } else {
          reject();
        }
      });
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
