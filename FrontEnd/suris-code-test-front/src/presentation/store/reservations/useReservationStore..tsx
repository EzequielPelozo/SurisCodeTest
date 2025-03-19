import { create } from "zustand";
import { Reservations } from "../../../infrastructure/interfaces/reservation";
import { getReservations } from "../../../actions/reservations/getReservations";
import { postReservations } from "../../../actions/reservations/postReservation";

export interface ReservationState {

    reservations: Reservations[];


    getAllReservation: () => Promise<Reservations[] | null>;
    postReservation: (categoryId: number, clientName: string, date: Date,) => Promise<Reservations | null>;

}

export const useReservationStore = create<ReservationState>()((set,) => (
    {
        reservations: [],

        getAllReservation: async (): Promise<Reservations[] | null> => {
            const response = await getReservations();
            if (!response) {
                // console.log('store reservation no response')
                alert("Ocurrió un error al procesar la reserva.");
                return null;
            }
            set({ reservations: response });
            // console.log('store reservation', response)
            return response;
        },

        postReservation: async (categoryId: number, clientName: string, date: Date,): Promise<Reservations | null> => {
            const response = await postReservations(categoryId, clientName, date);
            if (!response) {
                console.log('store reservation no response en Post')
                return null;
            }
            console.log('store reservation', response)
            return response;
        }
    }    
))