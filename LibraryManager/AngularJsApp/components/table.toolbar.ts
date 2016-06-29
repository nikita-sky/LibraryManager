/// <reference path="../data/data.source.ts" />


module LM {
    const MODE_DEFAULT = "default";
    const MODE_SELECTION = "selection";
    const MODE_SEARCH_RESULT = "search";

    export class TableToolbar {
        static $name = "tableToolbar";
        static $factory(): angular.IComponentOptions {
            return {
                controller: TableToolbar,
                controllerAs: "vm",
                templateUrl: "/content/html/components/table.toolbar.html",
                bindings: {
                    title: "@",
                    ngDataSource: "<",
                    onSearch: "&",
                    onCreate: "&",
                    onEdit: "&"
                }
            }
        }

        onSearch: () => void;
        onCreate: () => void;
        onEdit: (item: any) => void;

        ngDataSource: DataSource<any, any, any>;

        get currentMode(): string {
            if (this.ngDataSource.selected.length)
                return MODE_SELECTION;

            if (this.ngDataSource.query)
                return MODE_SEARCH_RESULT;
            
            return MODE_DEFAULT;
        }  

        get selectedCount() {
            return this.ngDataSource.selected.length;
        }

        refresh() { this.ngDataSource.load(); }

        create() {
            if (this.selectedCount > 0 || !this.onCreate)
                return;
            this.onCreate();
        }

        search() {
            if (this.selectedCount > 0 || !this.onSearch)
                return;
            this.onSearch();
        }

        clearSearch() {
            this.ngDataSource.resetQuery();
        }

        edit() {
            if (this.selectedCount !== 1 || !this.onEdit)
                return;
            this.onEdit({ $item: this.ngDataSource.selected[0] });
        }

        delete() {
            if (!!this.selectedCount)
                return;
            this.ngDataSource.delete(this.ngDataSource.selected[0])
                .then(() => this.ngDataSource.selected = []);
        }
    }
}