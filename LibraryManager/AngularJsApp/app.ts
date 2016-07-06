/// <reference path="./components/table.toolbar.ts" />
/// <reference path="./pages/books.page.ts"/>
/// <reference path="./pages/library.card.page.ts" />
/// <reference path="./pages/registry.page.ts" />

module LM
{
    const moduleName = "lm.app";

    class ModuleConfig {
        static $inject = ["$routeProvider", "$mdDateLocaleProvider"];
        constructor (
            $routeProvider: angular.route.IRouteProvider, 
            $mdDateLocaleProvider: angular.material.IDateLocaleProvider) {
            const libraryCardPath = "/library-card";
            const registryPath = "/registry";
            const bookPath = "/book";

            $routeProvider
                .when(libraryCardPath, { template: "<library-card-page></library-card-page>" })
                .when(bookPath, { template: "<book-page></book-page>" })
                .when(registryPath, { template: "<registry-page></registry-page>" })
                .otherwise({ redirectTo: bookPath });

                const localeSettings = {
                    months: ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"],
                    shortMonths: ["янв", "фев", "март", "апр", "май", "июн", "июл", "авг", "сен", "окт", "ноя", "дек"],
                    days: ["Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресение"],
                    shortDays: ["Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс"],
                    firstDayOfWeek: 0,
                    weekNumberFormatter: (weekNumber: number) => `${weekNumber} неделя`
                };
                angular.extend($mdDateLocaleProvider, localeSettings);
        }
    }

    angular.module(moduleName, ["ngMaterial", "ngRoute", "md.data.table"])
        .service(BookDataService.$name, BookDataService)
        .service(LibraryCardDataServcie.$name, LibraryCardDataServcie)
        .service(ClientEntryDataService.$name, ClientEntryDataService)
        .component(TableToolbar.$name, TableToolbar.$factory())
        .component(RootPage.$name, RootPage.factory())
        .component(BookPage.$name, BookPage.factory())
        .component(LibraryCardPage.$name, LibraryCardPage.factory())
        .component(RegistryPage.$name, RegistryPage.$factory())
        .config(ModuleConfig);
    
}