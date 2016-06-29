module LM
{
    export interface ClientEntry  extends Entity {
        takedAt: Date;
        returnAt: Date;
        book: {
            id: number;
            title: string;
        };
        libraryCard: {
            id: number;
            fullName: string;
        }
    }
}