using System;


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetCareISW.DTO
{
    public class AppointmentDTO
    {


      
        public int Id { get; set; }

 
        public DateTime CreatedAt { get; set; }

      
        public string StartTime { get; set; }

       
        public Boolean Status { get; set; }

       
        public string EndTime { get; set; }

        
        public string Veteryname { get; set; }

      
        public string ProductTypeName { get; set; }

    }

    //    public IList<Pet> Pets { get; set; } = new List<Pet>();
    //      public IList<PersonRequest> Requests { get; set; } = new List<PersonRequest>();
    //     public IList<Review> Reviews { get; set; } = new List<Review>();
}

