module Cheetah.Services {
  export class AccessTokenStoreService extends Framework.BaseStore<Models.AccessToken> {
    public static $Inject = ["localStorageService"];
    private accessToken: Models.AccessToken = null;

    constructor(
      protected localStorageService: angular.local.storage.ILocalStorageService
    ) {
      super(localStorageService, "accessToken", Models.AccessToken.map);
    }
  }

  angular.module("cheetah.services").service("AccessTokenStoreService", AccessTokenStoreService);
}
