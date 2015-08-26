module Cheetah.Framework {
  export class BaseStore<TValue> {
    protected cache: TValue = null;

    constructor(
      protected localStorageService: angular.local.storage.ILocalStorageService,
      protected key: string,
      protected mapper: (model: any) => TValue
    ) {}

    public get(): TValue {
      if (this.cache === null) {
        this.cache = this.mapper(this.localStorageService.get<TValue>(this.key));
      }

      return this.cache;
    }

    public set(value: TValue) {
      this.localStorageService.set(this.key, value);
      this.cache = value;
    }

    public clear() {
      this.localStorageService.remove(this.key);
      this.cache = null;
    }

    public exists(): boolean {
      return this.localStorageService.get(this.key) !== null || this.cache !== null;
    }
  }
}
