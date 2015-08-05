module Cheetah.Services {
  export class UserService {
    public static $inject = ["RepositoryService", "$q"];

    private user: Models.User = null;
    private roles = {
      "anon": {
        "signin": true,
        "signup": true,
        "forgot-password": true,
        "projectsOverview": true,
        //"navbar": false,
        "projectScrumboard": true,
        "dashboard": true
      },
      "user": {
        "navbar": true
      }
    };

    constructor(
      private repo: Services.RepositoryService,
      private $q: angular.IQService) {

    }

    public authorize(username: string, password: string): angular.IPromise<Models.User> {
      return new this.$q<Models.User>((resolve, reject) => {
          this.repo
            .users
            .findWhere(user => _.isEqual(username.toLowerCase(), user.username.toLowerCase()) && _.isEqual(password, user.password))
            .then(user => {
              this.user = user;
              resolve(user);
            }, reject);
      });
    }

    public authorized(): boolean {
      return this.user !== undefined && this.user !== null;
    }

    public hasRole(role: string): boolean {
      return false;
    }

    public current(): Models.User {
      return this.user !== undefined && this.user !== null ? this.user : null;
    }

    public canAccessArea(area: string): boolean {
      var areaString: string;

      if (this.user === null) {
        areaString = `anon.${area}`;
      } else {
        areaString = `user.${area}`;
      }

      var canAccess = _.has(this.roles, areaString);

      console.log(areaString, canAccess);

      return canAccess;
    }
  }

  angular.module("cheetah.services").service("UserService", UserService);
}
