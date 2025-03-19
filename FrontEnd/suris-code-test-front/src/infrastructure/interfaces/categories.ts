export interface Category {
    id:           number;
    name:         string;
    creationDate: Date;
}

export interface CategoriesGetResponse {
    categories: Category[];
}
