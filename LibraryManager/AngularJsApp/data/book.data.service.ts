/// <reference path="./data.service.ts"/>

module LM
{
    export class BookDataService extends DataService<Book> {
        static $inject = ["$http"];

        constructor ($http: angular.IHttpService) {
            super($http);
            this.url = "/api/book";
        }

        find(title: string, page: number): angular.IPromise<IQueryResult<Book>> {
            const config: angular.IRequestShortcutConfig = {
                params: { title: title, page: page }
            };
            return this.$http.get(this.url + "/find", config);
        }
    }
}