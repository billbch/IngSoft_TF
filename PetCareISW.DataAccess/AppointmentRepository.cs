using Microsoft.EntityFrameworkCore;
using PetCareISW.DataAccess;

using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.Services
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;
        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Appointment Appointment)
        {
            await _context.Set<Appointment>().AddAsync(Appointment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            
            _context.Entry(new Appointment
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Appointment>> GetCollection(/*string filter*/)
        {
           var collection = await _context.Appointments/*
                .Where(c => c.Name.Contains(filter))*/
                .ToListAsync();

            return collection;

        }



        public async Task<Appointment> GetItem(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task Update(Appointment Appointment)
        {
            _context.Set<Appointment>().Attach(Appointment);
            _context.Entry(Appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }

       
    }
}
