import axios from "axios";
import { surisApi } from "../../config/api/surisApi"
import { Reservations } from "../../infrastructure/interfaces/reservation";


export const postReservations = async (
    categoryId: number,
    clientName: string,
    date: Date,
 
) => {
    try {
        const { data } = await surisApi.post<Reservations>('/reservations',{
            CategoryId: categoryId,
            ClientName: clientName,
            Date: date,
        });
        // console.log('reservation: ',data)
        return data;
    } catch (error) {
        if(axios.isAxiosError(error)){
            console.error('error en Axios:',error.response?.data || error.message);
            alert('error en Axios:' + error.response?.data || error.message)
        } else {
            // console.error('Error inesperado:', error);
            alert(error || "Error desconocido al hacer la reserva.");
        }
        return false;
    }
}