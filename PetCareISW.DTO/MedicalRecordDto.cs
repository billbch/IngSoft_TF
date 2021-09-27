using System;
using System.Collections.Generic;
using System.Text;

namespace PetCareISW.DTO
{
    public class MedicalRecordDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public string VetName { get; set; }
        public string AttendantName { get; set; }
        public bool Gender { get; set; }
        public DateTime CreateAt { get; set; }
        public int MedicalProfileId { get; set; }
    }
}
