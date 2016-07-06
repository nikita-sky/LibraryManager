module LM {
    const URL = "/api/clientEntry";

    interface ServerClientEntry {
        id: number;
        book: { id: number; title: string };
        libraryCard: { id: number; fullName: string };
        takedAt: string;
        returnAt: string;
    }

    export class ClientEntryDataService extends DataService<ClientEntry> {
        static $inject = ["$http"];
        static $name = "clientEntryDataService";

        constructor($http: angular.IHttpService) {
            super($http);
            this.url = URL;
        }

        create(data: ClientEntry): angular.IPromise<IQueryResult<ClientEntry>> {
            const form = this.mapToCreateForm(data);
            return this.$http.put(this.url, form)
                .then(x => x.data);
        }

        update(data: ClientEntry): angular.IPromise<number> {
            const form = this.mapToUpdateForm(data);
            return this.$http.post(this.url, form)
                .then(x => x.status);
        }

        find(form: FindClientEntryForm, page: number): angular.IPromise<IQueryResult<ClientEntry>> {
            angular.extend(form, { page: page });
            const config = this.createRequestConfig(form);
            return this.$http.get(`${this.url}/find`, config)
                .then(x => <IQueryResult<ServerClientEntry>>x.data)
                .then(x => this.parseServerResponse(x));
        }

        get(page: number): angular.IPromise<IQueryResult<ClientEntry>> {
            const config = this.createRequestConfig( { page: page } );
            return this.$http.get(this.url, config)
                .then(x => <IQueryResult<ServerClientEntry>>x.data)
                .then(x => this.parseServerResponse(x));
        }

        private parseServerResponse(source: IQueryResult<ServerClientEntry>): IQueryResult<ClientEntry> {
            return {
                total: source.total,
                count: source.count,
                id: source.id,
                items: source.items.map(x => toClientEntry(x))
            };

            function toClientEntry(x: ServerClientEntry): ClientEntry {
                return {
                    id: x.id,
                    book: x.book,
                    libraryCard: x.libraryCard,
                    takedAt: new Date(x.takedAt),
                    returnAt: new Date(x.returnAt)
                };
            }
        }

        private mapToCreateForm(data: ClientEntry): CreateClientEntryForm {
            return {
                bookId: data.book.id,
                libraryCardId: data.libraryCard.id,
                takedAt: data.takedAt,
                returnAt: data.returnAt
            };
        }

        private mapToUpdateForm(data: ClientEntry): UpdateClientEntryForm {
            var result: any = this.mapToCreateForm(data);
            result.id = data.id;
            return result;
        }
    }
}