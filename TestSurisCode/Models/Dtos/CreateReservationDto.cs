using System.ComponentModel.DataAnnotations;

namespace TestSurisCode.Models.Dtos
{
    public class CreateReservationDto
    {
        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public int CategoryId { get; set; }
        // public Category Category { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre del cliente no puede superar los 100 caracteres.")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "La fecha y hora de la reserva son obligatorias.")]
        [FutureDate(ErrorMessage = "La fecha debe ser futura.")]
        public DateTime Date { get; set; }
    }

    /// <summary>
    /// Atributo personalizado para validar que la fecha sea futura.
    /// </summary>
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime <= DateTime.UtcNow)
                {
                    return new ValidationResult(ErrorMessage ?? "La fecha debe ser futura.");
                }
            }
            return ValidationResult.Success;
        }
    }
}

