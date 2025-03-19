import axios from "axios";
import { surisApi } from "../../config/api/surisApi"
import { Category } from "../../infrastructure/interfaces/categories"


export const getCategories = async () => {
    try {
        const { data } = await surisApi.get<Category[]>('/categories');
        // console.log('categorias: ',data)
        return data;
    } catch (error) {
        if(axios.isAxiosError(error)){
            console.error('error en Axios:',error.response?.data || error.message);
        } else {
            console.error('Error inesperado:', error);
        }
        return false;
    }
}