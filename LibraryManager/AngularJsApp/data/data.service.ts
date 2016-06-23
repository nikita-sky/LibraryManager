module LM
{
    export abstract class DataService<T> {
        constructor(protected $http: angular.IHttpService) { }

        protected url: string;

        update<T>(data: T): angular.IPromise<number> {
            return this.$http.post(this.url, data)
                .then(x => x.status);
        }

        get<T>(page: number = 1): angular.IPromise<IQueryResult<T>> {
            const requestConfig: angular.IRequestShortcutConfig = {
                params: { page: page }
            };
            return this.$http.get(this.url, requestConfig)
                .then(x => x.data);
        }

        create<T>(data: T): angular.IPromise<IQueryResult<T>> {
            return this.$http.put(this.url, data)
                .then(x => x.data);
        }

        delete(id: number): angular.IPromise<IQueryResult<T>> {
            return this.$http.delete(this.url + "/" + id)
                .then(x => x.data);
        }
    }
}