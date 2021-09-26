using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetCareISW.Entities
{
    public class VaccinationRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }

        [Required]
        public string VetName { get; set; }

        [Required]
        public int MedicalProfileId { get; set; }

        public MedicalProfile MedicalProfile { get; set; }
    }
}
