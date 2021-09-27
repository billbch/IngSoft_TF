using System;
using System.Collections.Generic;
using System.Text;

namespace PetCareISW.DTO
{
   public class MedicalProfileDto
    {
        public int Id { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public double Lenght { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public int PetId { get; set; }
    }
}
