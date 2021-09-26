using System;


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetCareISW.DTO
{
    public class PersonProfileDTO
    {


        public int Id { get; set; }


        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public int Age { get; set; }
        public long Phone { get; set; }

        public string Password { get; set; }

        public string Rol { get; set; }
        public long Document { get; set; }

        public string Photo { get; set; }

    }

    //    public IList<Pet> Pets { get; set; } = new List<Pet>();
    //      public IList<PersonRequest> Requests { get; set; } = new List<PersonRequest>();
    //     public IList<Review> Reviews { get; set; } = new List<Review>();
}

