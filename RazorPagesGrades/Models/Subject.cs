using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesGrades.Models
{
    public class Subject
    {
        /// <summary>
        /// Zkratka předmětu - MAT
        /// </summary>
        [Key]
        [Required]
        [StringLength(3, ErrorMessage = "Název tvoří právě 3 znaky", MinimumLength = 3)]
        public string Acronym { get; set; }

        /// <summary>
        /// Celý název předmětu - Matematika
        /// </summary>
        public string Name { get; set; }
    }
}
