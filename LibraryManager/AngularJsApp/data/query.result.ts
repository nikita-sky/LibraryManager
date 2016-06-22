module LM
{
    export interface IQueryResult<T> {
        id: number;
        count: number;
        total: number;
        items: T[];
    }
}