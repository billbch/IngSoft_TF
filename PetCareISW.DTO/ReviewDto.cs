using System;
using System.Collections.Generic;
using System.Text;

namespace PetCareISW.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int Qualification { get; set; }
        public string Comment { get; set; }
        public int PersonProfileId { get; set; }
        public int BusinessId { get; set; }
    }
}
