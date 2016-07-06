module LM {
    export interface CreateClientEntryForm {
        takedAt: Date;
        returnAt: Date;
        libraryCardId: number;
        bookId: number;
    }
}