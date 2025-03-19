import { Category } from "./categories";

export interface Reservations {
    id:         number;
    categoryId: number;
    category:   Category;
    clientName: string;
    date:       Date;
}


