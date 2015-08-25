module Cheetah.Services {
  export class UserService {
    public static $inject = ["AccountApiService", "$q", "AccessTokenStoreService", "$rootScope"];

    private user: Models.User = null;
    private refreshToken: Models.RefreshToken = null;
    private allowAnon = ["signin", "signup", "forgot-password"];

    constructor(
      private account: Services.Api.AccountApiService,
      private $q: angular.IQService,
      private AccessTokenStoreService: AccessTokenStoreService,
      private $rootScope: angular.IRootScopeService
    ) {

    }

    public me(): angular.IPromise<Models.UserInfoViewModel> {
      return this.account.me();
    }

    public canAccess(state: angular.ui.IState): boolean {
      return this.isAuthed() || _.contains(this.allowAnon, state.name);
    }

    public isAuthed() {
      return (this.user !== null && this.refreshToken !== null);
    }

    public authorize(username: string, password: string): angular.IPromise<Models.UserInfoViewModel> {
      var deferred = this.$q.defer();

      deferred.notify("Authorizing");

      this
        .account
        .authorize(new Models.LocalAuthRequest(username, password))
        .then(authorizationGrant => {
          var refreshRequest = Models.RefreshRequest.map(authorizationGrant);
          this.refreshToken = authorizationGrant.RefreshToken;

          deferred.notify("Refresing access token");

          this
            .account
            .refresh(refreshRequest)
            .then(accessToken => {
              this.AccessTokenStoreService.set(accessToken);

              deferred.notify("Authenticating");

              this
                .account
                .authenticate(accessToken)
                .then(authenticationResponse => {
                  if (authenticationResponse.IsValid) {
                    deferred.notify("Fetching user info");

                    this
                      .account
                      .me()
                      .then(userInfo => {
                        this.user = userInfo.User;

                        deferred.resolve(this.user);
                        this.$rootScope.$emit(Enums.Events.Authenticated, this.user);
                      }, deferred.reject);
                  } else {
                    deferred.reject("Invalid user.");
                  }
                });
            }, deferred.reject);
        }, deferred.reject);

      return deferred.promise;
    }



  }

  angular.module("cheetah.services").service("UserService", UserService);
}
