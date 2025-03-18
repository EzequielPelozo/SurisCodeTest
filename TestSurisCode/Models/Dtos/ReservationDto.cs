using System.ComponentModel.DataAnnotations;

namespace TestSurisCode.Models.Dtos
{
    public class ReservationDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre del cliente no puede superar los 100 caracteres.")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "La fecha y hora de la reserva son obligatorias.")]
        public DateTime Date { get; set; }
    }    
}
