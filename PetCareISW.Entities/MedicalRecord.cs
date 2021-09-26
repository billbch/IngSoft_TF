using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetCareISW.Entities
{
    public class MedicalRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Action { get; set; }

        [Required]
        [StringLength(20)]
        public string VetName { get; set; }

        [Required]
        public string AttendantName { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public int MedicalProfileId { get; set; }

        public MedicalProfile MedicalProfile { get; set; }
    }
}
