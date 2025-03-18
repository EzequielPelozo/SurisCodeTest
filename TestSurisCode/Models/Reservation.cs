using System.ComponentModel.DataAnnotations;

namespace TestSurisCode.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; } // Relación con el servicio al que llame categoria
        public Category Category { get; set; }

        [Required]
        [MaxLength(100)]
        public string ClientName { get; set; } // Guardo el nombre del input. Podria hacer una entidad para el Cliente pero no lo requiere el caso

        [Required]
        public DateTime Date { get; set; } // Fecha y hora de la reserva

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
