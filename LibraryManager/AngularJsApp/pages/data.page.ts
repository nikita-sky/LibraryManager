module LM {
    const SIDENAV_EDIT = "edit";
    const SIDENAV_SEARCH = "search";

    export abstract class DataPage<TModel extends Entity, TQuery, TDataService extends DataService<TModel>> extends Page {
        constructor(
            $mdSidenav: angular.material.ISidenavService
        ) {
            super($mdSidenav);
         }

        dataSource: DataSource<TModel, TQuery, TDataService>;
        editableItem: TModel;
        query: TQuery;
        formEdit: angular.IFormController;

        $onInit() {
            this.load();
        }

        load() {
            return this.dataSource.load()
                .catch(() => this.notify("Ошибка при загрузке"));
        }

        edit(item: TModel) {
            this.formEdit.$setPristine();
            this.editableItem = item;
            this.openSidenav(SIDENAV_EDIT);
        }

        create() {
            this.edit(null);
        }

        endEdit() {
            this.editableItem = null;
            this.closeSidenav(SIDENAV_EDIT);
        }

        save() {
            this.rootPage.showBusyIndicator("Сохранение...");
            const promise = !this.editableItem.id
                ? this.dataSource.add(this.editableItem)
                : this.dataSource.update(this.editableItem);

            promise
                .then(x => this.closeSidenav(SIDENAV_EDIT))
                .catch(() => this.notify("Ошибка"))
                .finally(() => this.rootPage.isBusy = false);
        }

        search() {
            this.openSidenav(SIDENAV_SEARCH);
        }

        doSearch() {
            this.dataSource.query = this.query;
            this.dataSource.promise
                .catch(() => this.notify("Ошибка"))
                .finally(() => this.endSearch());
        }

        endSearch() {
            this.closeSidenav(SIDENAV_SEARCH);
        }
    }
}