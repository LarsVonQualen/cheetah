module Cheetah.Services {
  export class RefreshTokenStoreService extends Framework.BaseStore<Models.RefreshToken> {
    public static $Inject = ["localStorageService"];

    constructor(
      protected localStorageService: angular.local.storage.ILocalStorageService
    ) {
      super(localStorageService, "refreshToken", Models.RefreshToken.map);
    }
  }

  angular.module("cheetah.services").service("RefreshTokenStoreService", RefreshTokenStoreService);
}
