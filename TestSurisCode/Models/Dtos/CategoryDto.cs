using System.ComponentModel.DataAnnotations;

namespace TestSurisCode.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        [MaxLength(100, ErrorMessage = "The Character Max length is 100")]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
