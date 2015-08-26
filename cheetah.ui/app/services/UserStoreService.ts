module Cheetah.Services {
  export class UserStoreService extends Framework.BaseStore<Models.User> {
    public static $Inject = ["localStorageService"];
    public user: Models.User = null;

    constructor(
      protected localStorageService: angular.local.storage.ILocalStorageService
    ) {
      super(localStorageService, "user", Models.User.map);
    }
  }

  angular.module("cheetah.services").service("UserStoreService", UserStoreService);
}
