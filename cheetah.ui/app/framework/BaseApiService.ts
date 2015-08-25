module Cheetah.Framework {
  export class BaseApiService {
    protected defaultConfig: angular.IRequestShortcutConfig = {};

    constructor(
      protected $http: angular.IHttpService,
      protected $q: angular.IQService,
      protected endpoint: string,
      protected version: string = "api/v1",
      protected host: string = "",
      protected port: string = ""
    ) {}

    protected baseGet<TResponse>(url: string, config?: angular.IRequestShortcutConfig): angular.IPromise<TResponse> {
      return this.wrap(this.$http.get(this.buildUrl(url), this.getConfig(config)));
    }

    protected basePost<TResponse, TBody>(url: string, body: TBody, config?: angular.IRequestShortcutConfig): angular.IPromise<TResponse> {
      return this.wrap(this.$http.post(this.buildUrl(url), body, this.getConfig(config)));
    }

    protected basePut<TResponse, TBody>(url: string, body: TBody, config?: angular.IRequestShortcutConfig): angular.IPromise<TResponse> {
      return this.wrap(this.$http.put(this.buildUrl(url), body, this.getConfig(config)));
    }

    protected baseDelete<TResponse>(url: string, config?: angular.IRequestShortcutConfig): angular.IPromise<TResponse> {
      return this.wrap(this.$http.delete(this.buildUrl(url), this.getConfig(config)));
    }

    protected wrap<TResponse>(promise: angular.IHttpPromise<TResponse>): angular.IPromise<TResponse> {
      var deferred = this.$q.defer();

      promise.then(response => deferred.resolve(response.data), deferred.reject);

      return deferred.promise;
    }

    protected addHeader(key: string, value: string) {
      if (this.defaultConfig.headers === undefined) {
        this.defaultConfig.headers = {};
      }

      this.defaultConfig.headers[key] = value;
    }

    private getConfig(config?: angular.IRequestShortcutConfig): angular.IRequestShortcutConfig {
      if (!config) return undefined;

      return angular.extend({}, this.defaultConfig, config);
    }

    private buildUrl(url: string): string {
      return `${this.host}${this.port}/${this.version}/${this.endpoint}/${url}`;
    }
  }
}
