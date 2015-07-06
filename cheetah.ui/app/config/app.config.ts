module Cheetah {
  class Config {
    constructor(private localStorageServiceProvider: angular.local.storage.ILocalStorageServiceProvider) {
      localStorageServiceProvider.setPrefix("cheetah");
    }
  };

  angular.module("cheetah")
    .config([
        "localStorageServiceProvider",
        (localStorageServiceProvider: angular.local.storage.ILocalStorageServiceProvider) => {
          new Config(localStorageServiceProvider)
        }
    ]);
}
