/// <reference path="./components/table.toolbar.ts" />
/// <reference path="./data/book.data.service.ts"/>
/// <reference path="./pages/books.page.ts"/>

module LM
{
    const moduleName = "lm.app";

    angular.module(moduleName, ["ngMaterial", "ngRoute", "md.data.table"])
        .service(BookDataService.$name, BookDataService)
        .component(TableToolbar.$name, TableToolbar.$factory())
        .component(RootPage.$name, RootPage.factory())
        .component(BookPage.$name, BookPage.factory())
}