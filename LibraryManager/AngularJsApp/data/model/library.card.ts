module LM
{
    export interface LibraryCardShort extends Entity {
        fullName: string;
    }

    export interface LibraryCard extends LibraryCardShort {
        phone: string;
    }
}