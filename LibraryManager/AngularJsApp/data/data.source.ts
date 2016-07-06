module LM {
    const LOAD_FAILED_MESSAGE = "Ошибка при загрузке";
    const UPDATE_FAILED_MESSAGE = "Ошибка при сохранении";
    const DELETE_FAILED_MESSAGE = "Ошибка при удалении";
    const UPDATE_SCCESS_MESSAGE = "Сохранено";

    export abstract class DataSource<TData extends Entity, TQuery, TDataServcie extends DataService<TData>> {
        private _total = 0;
        private _page = 1;
        private _query: TQuery = null;
        private _promise: angular.IPromise<any> = null;

        constructor(protected $dataService: TDataServcie) { }

        selected: TData[] = [];
        items: TData[] = [];
        get total() { return this._total; }

        get promise(): angular.IPromise<any> { return this._promise; }

        get page() { return this._page; }
        set page(value: number) {
            value = Math.floor(value);
            if (this._page === value)
                return;

            this._page = Math.max(1, value);
            this.load();
        }

        set query(value: TQuery) {
            if (this.query === value)
                return;

            this._query = value;
            this._page = 1;
            this.load();
        }

        get query() { return this._query; }

        load(): angular.IPromise<any> {
            this._promise = this._query
                ? this.doQuery(this._query, this._page)
                : this.$dataService.get(this._page);

            return this._promise
                .then(x => this.onLoadComplete(x));
        }

        add(item: TData): angular.IPromise<void> {
            return this.$dataService.create(item)
                .then(x => this.load());
        }

        update(item: TData): angular.IPromise<any> {
            return this.$dataService.update(item)
                .then(() => this.load());
        }
        
        delete(item: TData): angular.IPromise<void> {
            return this.$dataService.delete(item.id)
                .then(x => this._total--)
                .then(x => this.removeItem(item));
        }

        resetQuery() { this.query = null; }

        protected abstract doQuery(query: TQuery, page: number): angular.IPromise<IQueryResult<TData>>;

        private removeItem(item: TData) {
            var i = this.items.indexOf(item);
            if (i < 0)
                return;
            this.items.splice(i, 1);
        }

        private onLoadComplete(queryResult: IQueryResult<TData>) {
            this._total = queryResult.total;
            angular.copy(queryResult.items, this.items);

            if (!this.items.length)
                this.selected.length = 0;

            if (!this.selected.length)
                return;

            var selectedItem = this.selected[0];
            for (var i = 0; i < this.items.length; i++ ) {
                var item = this.items[i];
                if (item.id !== selectedItem.id)
                    continue;

                angular.extend(selectedItem, item);
                break;
            }
            //this.items = queryResult.items;
        }
    }
}