using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace PetCareISW.Entities
{
    public abstract class Profile:EntityBase
    {
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
        public long Document { get; set; }
        [Required]
        [StringLength(100)]
        public string Photo { get; set; }

    //    public Account Account { get; set; }
   //     public int AccountId { get; set; }
    }
}
