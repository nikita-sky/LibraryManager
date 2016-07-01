/// <reference path="./library.card.data.service.ts" />
/// <reference path="./data.service.ts" />
module LM {
    export class LibraryCardDataSource extends DataSource<LibraryCard, string, LibraryCardDataServcie> {
        constructor(dataServcie: LibraryCardDataServcie) {
            super(dataServcie);
        }

        protected doQuery(query: string, page: number) {
            return this.$dataService.find(query, page);
        }
    }
}