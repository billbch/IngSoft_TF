using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetCareISW.Entities
{
    public class Business
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public long RUC { get; set; }

        [Required]
        [StringLength(30)]
        public string BusinessName { get; set; }

        [Required]
        [StringLength(20)]
        public string District { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(30)]
        public string email { get; set; }

        [Required]
        public float Score { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }
    }
}
