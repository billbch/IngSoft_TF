using System;
using System.Collections.Generic;
using System.Text;

namespace PetCareISW.DTO
{
    public class BusinessDto
    {
        public int Id { get; set; }
        public long RUC { get; set; }
        public string BusinessName { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string email { get; set; }
        public float Score { get; set; }
        public string Description { get; set; }
    }
}
