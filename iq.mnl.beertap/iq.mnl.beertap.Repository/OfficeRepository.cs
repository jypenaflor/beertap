using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using iq.mnl.beertap.Repository.Context;
using iq.mnl.beertap.Repository.ModelDto;

namespace iq.mnl.beertap.Repository
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly IBeerTapContext _context;

        public OfficeRepository(IBeerTapContext context)
        {
            _context = context;
        }
        
        public OfficeDto Get(int id)
        {
            return _context.Offices.FirstOrDefault(x => x.Id == id);
        }

        public OfficeDto Save(OfficeDto entity)
        {
            _context.Offices.AddOrUpdate(entity);
            _context.SaveDbChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            _context.Offices.Remove(Get(id));
            _context.SaveDbChanges();
            return true;
        }

        public bool Delete(OfficeDto entity)
        {
            _context.Offices.Remove(entity);
            _context.SaveDbChanges();
            return true;
        }

        public IEnumerable<OfficeDto> GetAll()
        {
            return _context.Offices.AsNoTracking().ToList();
        }
    }
}
