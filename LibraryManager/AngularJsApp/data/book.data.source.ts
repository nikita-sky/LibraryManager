/// <reference path="./book.data.service.ts" />
/// <reference path="./data.service.ts" />

module LM {
    export class BookDataSource extends DataSource<Book, string, BookDataService> {
        constructor(dataService: BookDataService) {
            super(dataService);
        }

        protected doQuery(query: string, page: number) {
            return this.$dataService.find(query, page);
        }
    }
}