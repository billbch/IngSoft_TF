using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetCareISW.Entities
{
    public class PersonProfile {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(40)]
        public string LastName { get; set; }
        [Required]
        [StringLength(40)]
        public string Email { get; set; }
        public int Age { get; set; }
        public long Phone { get; set; }
        [Required]
        [StringLength(15)]
        public string Password { get; set; }
        [Required]
        [StringLength(15)]
        public string Rol { get; set; }
        public long Document { get; set; }
        [Required]
        [StringLength(100)]
        public string Photo { get; set; }

    }

    //    public IList<Pet> Pets { get; set; } = new List<Pet>();
    //      public IList<PersonRequest> Requests { get; set; } = new List<PersonRequest>();
    //     public IList<Review> Reviews { get; set; } = new List<Review>();
}

