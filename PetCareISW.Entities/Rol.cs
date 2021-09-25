using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace PetCareISW.Entities
{
    public class Rol:EntityBase
    {
        //      public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        public bool Publish { get; set; }
//        public IList<Account> Accounts { get; set; } = new List<Account>();

    }
}
