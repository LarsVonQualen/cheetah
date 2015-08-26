module Cheetah.Services.Api {
  export class AccountApiService extends Framework.BaseApiService {
    public static $Inject = ["$http, $q", "AccessTokenStoreService"];

    constructor(
      protected $http: angular.IHttpService,
      protected $q: angular.IQService,
      protected AccessTokenStoreService: AccessTokenStoreService
    ) {
      super($http, $q, "account");
    }

    public register(userViewModel: Models.UserViewModel): angular.IPromise<Models.UserInfoViewModel> {
      return new this.$q((resolve, reject) => {
        super
          .basePost<Models.UserInfoViewModel, Models.UserViewModel>("register", userViewModel)
          .then(response => resolve(Models.UserInfoViewModel.map(response)), reject);
      });
    }

    public me(): angular.IPromise<Models.UserInfoViewModel> {
      return new this.$q((resolve, reject) => {
        var token = this.AccessTokenStoreService.exists() ? this.AccessTokenStoreService.get().Token : "MISSING";
        var authHeaderContent = ["Bearer ", token].join("");

        super
          .baseGet<Models.UserInfoViewModel>("me", {
            headers: {
              Authorization: authHeaderContent
            }
          })
          .then(response => resolve(Models.UserInfoViewModel.map(response)), reject);
      });
    }

    public authorize(localAuthRequest: Models.LocalAuthRequest): angular.IPromise<Models.AuthorizationGrant> {
      return new this.$q((resolve, reject) => {
        super
          .basePost("authorize", localAuthRequest)
          .then(response => resolve(Models.AuthorizationGrant.map(response)), reject);
      });
    }

    public refresh(refreshRequest: Models.RefreshRequest): angular.IPromise<Models.AccessToken> {
      return new this.$q((resolve, reject) => {
        super
          .basePost("refresh", refreshRequest)
          .then(response => resolve(Models.AccessToken.map(response)), reject);
      });
    }

    public authenticate(accessToken: Models.AccessToken): angular.IPromise<Models.AuthenticationResponse> {
      return new this.$q((resolve, reject) => {
        super
          .basePost("authenticate", accessToken)
          .then(response => resolve(Models.AuthenticationResponse.map(response)), reject);
      });
    }

    public revoke(user: Models.User): angular.IPromise<{}> {
      return new this.$q((resolve, reject) => {
        super
          .baseGet(`revoke/${user.UserId}`)
          .then(resolve, reject);
      })
    }
  }

  angular.module("cheetah.services").service("AccountApiService", AccountApiService);
}
