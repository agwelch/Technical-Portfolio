using System.Collections.Generic;
using System.Linq;

namespace BuffTeksApartment
{
    public class ResidentManager
    {
        private readonly ApplicationDbContext _context;

        public ResidentManager()
        {
            _context = new ApplicationDbContext();
            _context.Database.EnsureCreated();
        }

        public List<Resident> GetResidents()
        {
            return _context.Residents.ToList();
        }
    }
}
