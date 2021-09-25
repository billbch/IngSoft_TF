using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PetCareISW.Entities
{
    public class Account:EntityBase
    {

        //     public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string User { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    //    public Rol Rol { get; set; }
        public int RolId { get; set; }
        public int Idf { get; set; }
  //      public PersonProfile PersonProfile { get; set; }

    //    public BusinessProfile BusinessProfile { get; set; }

    //    public int SubscriptionPlanId { get; set; }
    //    public SubscriptionPlan SubscriptionPlan { get; set; }


    }
}
