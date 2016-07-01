/// <reference path="./data.service.ts"/>
/// <reference path="./model/library.card.ts"/>
module LM {
    export class LibraryCardDataServcie extends DataService<LibraryCard> {
        static $name = "LibraryCardDataService";
        static $inject = ["$http"];

        constructor($http: angular.IHttpService) {
            super($http);
            this.url = "/api/libraryCard";
        }

        find(fullName: string, page: number): angular.IPromise<IQueryResult<LibraryCard>> {
            const config: angular.IRequestShortcutConfig = {
                params: { fullName: fullName, page: page }
            };
            return this.$http.get(this.url + "/find", config)
                .then(x => x.data);
        }
    }
}