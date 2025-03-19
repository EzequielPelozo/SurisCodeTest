import { create } from "zustand";
import {  Category } from "../../../infrastructure/interfaces/categories";
import { getCategories } from "../../../actions/categories/getCategories";

export interface CategoryState {

    categories: Category[];

    getAllCategory: () => Promise<Category[] | null>;
}

export const useCategoryStore = create<CategoryState>()((set) => (
    {
        categories: [],
        getAllCategory: async (): Promise<Category[] | null> => {
            const response = await getCategories();
            if (!response) {
                console.log('store category no response')
                return null;
            }
            set({ categories: response });
            // console.log('store category', response)
            return response;
        }
    }    
))