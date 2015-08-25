module Cheetah.Services {
  export class AccessTokenStoreService {
    public static $Inject = ["localStorageService"];
    private accessToken: Models.AccessToken = null;

    constructor(
      protected localStorageService: angular.local.storage.ILocalStorageService
    ) {

    }

    public hasAccessToken() {
      return this.localStorageService.get<Models.AccessToken>("accessToken") !== null || this.accessToken !== null;
    }

    public get(): Models.AccessToken {
      if (this.accessToken === null) {
        this.accessToken = Models.AccessToken.map(this.localStorageService.get<Models.AccessToken>("accessToken"));
      }

      return this.accessToken;
    }

    public set(accessToken: Models.AccessToken) {
      this.localStorageService.set("accessToken", accessToken);
      this.accessToken = accessToken;
    }
  }

  angular.module("cheetah.services").service("AccessTokenStoreService", AccessTokenStoreService);
}
