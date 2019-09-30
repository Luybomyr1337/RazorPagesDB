using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesGrades.Models
{
    public class Grade
    {
        /// <summary>
        ///   GUID jako string System.Guid.NewGuid().ToString("N");
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        ///   Předmět
        /// </summary>
        [Required]
        public Subject Subject { get; set; }

        /// <summary>
        ///   Známka
        /// </summary>
        [Required]
        [Range(1, 5, ErrorMessage = "Známka musí být mezi {1} a {2}.")]
        public double Value { get; set; }

        /// <summary>
        ///   Váha známky
        /// </summary>
        [Required]
        [Range(1, 10, ErrorMessage = "Hodnota {0} musí být mezi {1} a {2}.")]
        public int Weight { get; set; }
    }
}
