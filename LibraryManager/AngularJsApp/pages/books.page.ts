/// <reference path="./root.page.ts"/>
/// <reference path="./page.base.ts"/>
/// <reference path="../data/book.data.service.ts"/>
/// <reference path="../data/book.data.source.ts" />

module LM
{
    export class BookPage extends Page {
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
            private $dataService: BookDataService) {
            super($mdSidenav);
        }

        dataSource: BookDataSource = new BookDataSource(this.$dataService);
        editableItem: Book = null;
        formEdit: angular.IFormController = null;
        searchString: string;

        $onInit() {
            this.rootPage.title = "Книги";
            this.load();
        }

        load() {
           return this.dataSource.load().catch(() => this.notify("Ошибка при загрузке"));
        }

        edit(item: Book) {
            this.editableItem = item;
            this.openSidenav("edit");
        }

        create() {
            this.formEdit.$setPristine();
            this.editableItem = null;
            this.openSidenav("edit");
        }

        endEdit() {
            this.editableItem = null;
            this.closeSidenav("edit");
        }

        save() {
            this.rootPage.showBusyIndicator("Сохранение...");
            var promise = !this.editableItem.id
                ? this.dataSource.add(this.editableItem)
                : this.dataSource.update(this.editableItem);

            promise
                .then(x => this.closeSidenav("edit"))
                .catch(() => this.notify("Ошибка"))
                .finally(() => this.rootPage.isBusy = false);
        }

        search() {
            this.openSidenav("search");
        }

        doSearch() {
            this.dataSource.query = this.searchString;
            this.dataSource.promise.then(() => this.endSearch());
        }

        endSearch() {
            this.closeSidenav("search");
        }
    }
}