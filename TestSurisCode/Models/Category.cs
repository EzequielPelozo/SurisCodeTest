﻿using System.ComponentModel.DataAnnotations;

namespace TestSurisCode.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
