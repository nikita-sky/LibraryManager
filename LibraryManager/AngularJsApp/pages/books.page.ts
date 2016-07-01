/// <reference path="./root.page.ts"/>
/// <reference path="./data.page.ts" />
/// <reference path="../data/book.data.service.ts"/>
/// <reference path="../data/book.data.source.ts" />

module LM {
    export class BookPage extends DataPage<Book, string, BookDataService> {
        static $inject = ["$mdSidenav", BookDataService.$name];
        static $name = "bookPage";
        static factory(): angular.IComponentOptions {
            const component: angular.IComponentOptions = {
                controllerAs: "vm",
                controller: BookPage,
                templateUrl: "/content/html/pages/book.html",
                require: {
                    rootPage: `^${RootPage.$name}`
                }
            };
            return component;
        }

        constructor(
            $mdSidenav: angular.material.ISidenavService,
            dataService: BookDataService) {
            super($mdSidenav);
            this.dataSource = new BookDataSource(dataService)
        }
    }
}