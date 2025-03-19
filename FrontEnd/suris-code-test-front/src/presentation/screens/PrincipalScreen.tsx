import { useEffect, useState } from "react";
import { useCategoryStore } from "../store/categories/useCategoryStore";
import { useReservationStore } from "../store/reservations/useReservationStore.";

export const PrincipalScreen = () => {

    const { categories, getAllCategory } = useCategoryStore();
    const { reservations, getAllReservation, postReservation } = useReservationStore();

    const [clientName, setClientName] = useState("");
    const [selectedCategory, setSelectedCategory] = useState("");
    const [date, setDate] = useState("");

  useEffect(() => {
    getAllCategories();
    getAllReservations();
  },[])

  const getAllCategories = async() => {
    await getAllCategory();
  }

  const getAllReservations = async() => {
    await getAllReservation();
  }

  const handleReservation = async() => {
    if (!clientName || !selectedCategory || !date) {
      alert("Todos los campos son obligatorios.");
      return;
    }

    // Convierto la fecha ingresada a un objeto Date
    const selectedDate = new Date(date);    

     // Guardar la reserva
     const response = await postReservation(Number(selectedCategory), clientName, selectedDate);
    if (!response) {
      alert("Error al guardar la reserva.");
      return;
    }

    alert("Reserva realizada con éxito.");

    // Actualizar la lista de reservas
    await getAllReservation();

    // Resetear el formulario
    setClientName("");
    setSelectedCategory("");
    setDate("");
  };

  return (
      <div>
          <h2>Reservar Servicio</h2>

          <label>Nombre del Cliente:</label>

          <input
              type="text"
              value={clientName}
              onChange={(e) => setClientName(e.target.value)}
              placeholder="Ingrese su nombre"
          />

          <label>Seleccionar Servicio:</label>

          <select
              value={selectedCategory}
              onChange={(e) => setSelectedCategory(e.target.value)}
          >
              <option value="">Seleccione un servicio</option>
              {categories.map(cat => (
                  <option key={cat.id} value={cat.id}>{cat.name}</option>
              ))}
          </select>

          <label>Fecha y Hora:</label>
          <input
              type="datetime-local"
              value={date}
              onChange={(e) => setDate(e.target.value)}
          />

            <button onClick={handleReservation}>Reservar</button>


          <h3>Reservas Realizadas</h3>
          <ul>
              {reservations.map((res, index) => (
                  <li key={index}>
                      {res.clientName} - {res.category.name} - {new Date(res.date).toLocaleString()}
                  </li>
              ))}
          </ul>


      </div>
  )
}
