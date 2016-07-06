/// <reference path="./client.entry.data.service.ts" />
/// <reference path="./data.service.ts" />
module LM {
    export class ClientEntryDataSource extends DataSource<ClientEntry, FindClientEntryForm, ClientEntryDataService> {
        constructor (dataService: ClientEntryDataService) {
            super(dataService);
        }

        protected doQuery(query: FindClientEntryForm, page: number) {
            return this.$dataService.find(query, page);
        }
    }
}