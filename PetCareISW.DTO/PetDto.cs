using System;
using System.Collections.Generic;
using System.Text;

namespace PetCareISW.DTO
{
    public class PetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        public string Photo { get; set; }

        public bool Gender { get; set; }

        public int PersonProfileId { get; set; }
    }
}
