module LM
{
    export abstract class TableDataSource<T> {
        promise: angular.IPromise<IQueryResult<T>>;

        page: number = 1;

        abstract onPaginate(page: number);
        abstract load();
    } 
}