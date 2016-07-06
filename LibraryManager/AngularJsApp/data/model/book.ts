module LM
{
    export interface BookShort extends Entity {
        title: string;
    } 

    export interface Book extends BookShort {
        author: string;
        isbn: string;
    }
}