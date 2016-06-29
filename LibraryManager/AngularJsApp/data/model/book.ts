module LM
{
    export interface Book extends Entity {
        title: string;
        author: string;
        isbn: string;
    }
}