/// <reference path="../data/book.data.service.ts" />
/// <reference path="../data/client.entry.data.service.ts" />
/// <reference path="../data/library.card.data.service.ts" />
/// <reference path="./data.page.ts" />

module LM {
    export class RegistryPage extends DataPage<ClientEntry, FindClientEntryForm, ClientEntryDataService> {
        static $name = "registryPage";
        static $inject = ["$mdSidenav", ClientEntryDataService.$name, BookDataService.$name, LibraryCardDataServcie.$name]
        static $factory(): angular.IComponentOptions {
            return {
                controller: RegistryPage,
                controllerAs: "vm",
                templateUrl: "/content/html/pages/registry.html",
                require: {
                    rootPage: `^${RootPage.$name}`
                }
            }
        }

        constructor($mdSidenav: angular.material.ISidenavService, dataServcie: ClientEntryDataService,
            private bookDataServcie: BookDataService, private libraryCardDataServcie: LibraryCardDataServcie)
        {
            super($mdSidenav);
            this.dataSource = new ClientEntryDataSource(dataServcie);
        }

        searchBook(query: string): angular.IPromise<BookShort[]> {
            return this.bookDataServcie.search(query);
        }

        searchCard(query: string): angular.IPromise<LibraryCardShort[]> {
            return this.libraryCardDataServcie.search(query);
        }
    }
}