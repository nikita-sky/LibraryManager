/// <reference path="./data.page.ts" />
/// <reference path="../data//model/library.card.ts" />
/// <reference path="../data/library.card.data.service.ts" />

module LM {
    export class LibraryCardPage extends DataPage<LibraryCard, string, LibraryCardDataServcie> {
        static $name = "libraryCardPage";
        static $inject = ["$mdSidenav", LibraryCardDataServcie.$name];
        static factory(): angular.IComponentOptions {
            return {
                controller: LibraryCardPage,
                controllerAs: "vm",
                templateUrl: "/content/html/pages/library.card.html",
                require: {
                    rootPage: `^${RootPage.$name}`
                }
            };
        }

        constructor($mdSidenav: angular.material.ISidenavService, dataService: LibraryCardDataServcie) {
            super($mdSidenav);
            this.dataSource = new LibraryCardDataSource(dataService);
        }
    }
}