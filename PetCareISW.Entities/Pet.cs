using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetCareISW.Entities
{
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [StringLength(20)]
        public string Breed { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public int PersonProfileId { get; set; }

        public PersonProfile PersonProfile { get; set; }

    }
}

