/// <reference path="./components/table.toolbar.ts" />
/// <reference path="./data/book.data.service.ts"/>
/// <reference path="./pages/books.page.ts"/>
/// <reference path="./pages/library.card.page.ts" />


module LM
{
    const moduleName = "lm.app";

    class RouteConfig {
        static $inject = ["$routeProvider"];
        constructor ($routeProvider: angular.route.IRouteProvider) {
            const libraryCardPath = "/library-card";
            const bookPath = "/book";

            $routeProvider
                .when(libraryCardPath, { template: "<library-card-page></library-card-page>" })
                .when(bookPath, { template: "<book-page></book-page>" })
                .otherwise({ redirectTo: bookPath });
        }
    }

    angular.module(moduleName, ["ngMaterial", "ngRoute", "md.data.table"])
        .service(BookDataService.$name, BookDataService)
        .service(LibraryCardDataServcie.$name, LibraryCardDataServcie)
        .component(TableToolbar.$name, TableToolbar.$factory())
        .component(RootPage.$name, RootPage.factory())
        .component(BookPage.$name, BookPage.factory())
        .component(LibraryCardPage.$name, LibraryCardPage.factory())
        .config(RouteConfig);
    
}