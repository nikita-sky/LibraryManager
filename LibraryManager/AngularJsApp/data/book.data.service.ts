/// <reference path="./data.service.ts"/>
/// <reference path="./model/book.ts"/>

module LM
{
    export class BookDataService extends DataService<Book> {
        static $name = "BookDataService";
        static $inject = ["$http"];

        constructor ($http: angular.IHttpService) {
            super($http);
            this.url = "/api/book";
        }

        find(title: string, page: number): angular.IPromise<IQueryResult<Book>> {
            const config: angular.IRequestShortcutConfig = {
                params: { title: title, page: page }
            };
            return this.$http.get(`${this.url}/find`, config)
                .then(x => x.data);
        }

        search(query: string): angular.IPromise<BookShort[]> {
            const config = this.createRequestConfig( { query: query } );
            return this.$http.get(`${this.url}/search`, config)
                .then(x => x.data);
        }
    }
}