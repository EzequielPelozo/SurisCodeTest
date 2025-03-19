import axios from "axios";
import { surisApi } from "../../config/api/surisApi"
import { Reservations } from "../../infrastructure/interfaces/reservation";


export const getReservations = async () => {
    try {
        const { data } = await surisApi.get<Reservations[]>('/reservations');
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