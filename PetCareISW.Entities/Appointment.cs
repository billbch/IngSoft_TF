using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetCareISW.Entities
{
    public class Appointment
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }


        [Required]
        [StringLength(20)]
        public string StartTime { get; set; }

        [Required]
        public Boolean Status { get; set; }

        [Required]
        [StringLength(40)]
        public string EndTime { get; set; }

        [Required]
        [StringLength(40)]
        public string Veteryname { get; set; }

        [Required]
        [StringLength(15)]
        public string ProductTypeName { get; set; }

        [Required]
        public int BusinessId { get; set; }

        public Business Business { get; set; }

        [Required]
        public int PersonProfileId { get; set; }

        public PersonProfile PersonProfile { get; set; }


    }

    //    public IList<Pet> Pets { get; set; } = new List<Pet>();
    //      public IList<PersonRequest> Requests { get; set; } = new List<PersonRequest>();
    //     public IList<Review> Reviews { get; set; } = new List<Review>();
}

