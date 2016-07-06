/// <reference path="query.result.ts"/>

module LM
{
    export abstract class DataService<T> {
        constructor(protected $http: angular.IHttpService) { }

        protected url: string;

        update(data: T): angular.IPromise<number> {
            return this.$http.post(this.url, data)
                .then(x => x.status);
        }

        get(page: number = 1): angular.IPromise<IQueryResult<T>> {
            const config = this.createRequestConfig({page: page});
            return this.$http.get(this.url, config)
                .then(x => x.data);
        }

        create(data: T): angular.IPromise<IQueryResult<T>> {
            return this.$http.put(this.url, data)
                .then(x => x.data);
        }

        delete(id: number): angular.IPromise<number> {
            return this.$http.delete(`${this.url}/${id}`)
                .then(x => x.status);
        }

        protected createRequestConfig(data: any): angular.IRequestShortcutConfig {
            return { params: data }
        };
    }
}