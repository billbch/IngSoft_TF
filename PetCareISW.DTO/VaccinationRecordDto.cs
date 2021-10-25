using System;

namespace PetCareISW.DTO
{
    public class VaccinationRecordDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VetName { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
