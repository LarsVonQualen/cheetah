module Cheetah.Services {
  export class UserService {
    public static $inject = ["AccountApiService", "$q", "AccessTokenStoreService", "$rootScope", "RefreshTokenStoreService", "$state", "UserStoreService"];

    private allowAnon = ["signin", "signup", "forgot-password"];

    constructor(
      private account: Services.Api.AccountApiService,
      private $q: angular.IQService,
      private AccessTokenStoreService: AccessTokenStoreService,
      private $rootScope: angular.IRootScopeService,
      private RefreshTokenStoreService: RefreshTokenStoreService,
      private $state: angular.ui.IStateService,
      private UserStoreService: UserStoreService
    ) {

    }

    public me(): angular.IPromise<Models.User> {
      return new this.$q((resolve, reject) => {
        if (this.isAuthed()) {
          resolve(this.UserStoreService.get());
        } else {
          this.account.me().then(userInfo => resolve(userInfo.User), reject);
        }
      });
    }

    public canAccess(state: angular.ui.IState): boolean {
      return this.isAuthed() || _.contains(this.allowAnon, state.name);
    }

    public isAuthed() {
      return this.UserStoreService.exists() && this.RefreshTokenStoreService.exists() && this.AccessTokenStoreService.exists();
    }

    public register(username: string, password: string): angular.IPromise<Models.UserInfoViewModel> {
      return new this.$q((resolve, reject) => {
        var userViewModel = new Models.UserViewModel();
        userViewModel.Info = new Models.User();

        userViewModel.Info.Username = username;
        userViewModel.Password = password;


        this
          .account
          .register(userViewModel)
          .then(resolve, reject);
      })
    }

    public authorize(username: string, password: string): angular.IPromise<Models.UserInfoViewModel> {
      var deferred = this.$q.defer();

      deferred.notify("Authorizing");

      this
        .account
        .authorize(new Models.LocalAuthRequest(username, password))
        .then(authorizationGrant => {
          var refreshRequest = Models.RefreshRequest.map(authorizationGrant);
          this.RefreshTokenStoreService.set(authorizationGrant.RefreshToken);

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
                        this.UserStoreService.set(userInfo.User);

                        deferred.resolve(userInfo.User);
                        this.$rootScope.$emit(Enums.Events.Authenticated, userInfo.User);
                      }, deferred.reject);
                  } else {
                    deferred.reject("Invalid user.");
                  }
                });
            }, deferred.reject);
        }, deferred.reject);

      return deferred.promise;
    }

    public authenticate(): angular.IPromise<Models.AuthenticationResponse> {
      var deferred = this.$q.defer();

      if (!this.AccessTokenStoreService.exists()) {
        if (!this.RefreshTokenStoreService.exists() || !this.UserStoreService.exists()) {
          this.AccessTokenStoreService.clear();
          this.RefreshTokenStoreService.clear();
          this.UserStoreService.clear();

          deferred.reject();
        } else {
          var refreshRequest = new Models.RefreshRequest(this.UserStoreService.get().ClientId, this.RefreshTokenStoreService.get());

          this
            .account
            .refresh(refreshRequest)
            .then(accessToken => {
              this.AccessTokenStoreService.set(accessToken);
              this.$rootScope.$emit(Enums.Events.Authenticated, this.UserStoreService.get());
              deferred.resolve();
            }, deferred.reject);
        }
      } else {
        this
          .account
          .authenticate(this.AccessTokenStoreService.get())
          .then(
            authenticationResponse => {
              if (!authenticationResponse.IsValid) {
                this.AccessTokenStoreService.clear();
                this.RefreshTokenStoreService.clear();

                deferred.reject();
              } else {
                this.$rootScope.$emit(Enums.Events.Authenticated, this.UserStoreService.get());
                deferred.resolve();
              }
            },
            deferred.reject
          )
      }

      return deferred.promise;
    }

    public signout() {
      if (this.UserStoreService.exists()) {
        this
          .account
          .revoke(this.UserStoreService.get())
          .then(() => {
            this.UserStoreService.clear();
            this.AccessTokenStoreService.clear();
            this.RefreshTokenStoreService.clear();
            this.$state.go("signin");
          });
      }
    }
  }

  angular.module("cheetah.services").service("UserService", UserService);
}
