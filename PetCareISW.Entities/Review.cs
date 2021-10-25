using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareISW.Entities
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Qualification { get; set; }

        [Required]
        [StringLength(100)]
        public string Comment { get; set; }

        [Required]
        public int PersonProfileId { get; set; }

        //public PersonProfile PersonProfile { get; set; }

        [Required]
        public int BusinessId { get; set; }

        public Business Business { get; set; }
    }
}
