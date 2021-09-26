using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetCareISW.Entities
{
    public class MedicalProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double Lenght { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public int PetId { get; set; }

        public Pet Pet { get; set; }
    }
}
