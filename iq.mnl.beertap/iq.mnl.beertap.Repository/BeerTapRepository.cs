using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using iq.mnl.beertap.Repository.Context;
using iq.mnl.beertap.Repository.ModelDto;

namespace iq.mnl.beertap.Repository
{
    public class BeerTapRepository : IBeerTapRepository
    {
        private readonly IBeerTapContext _context;

        public BeerTapRepository(IBeerTapContext context)
        {
            _context = context;
        }

        public BeerTapDto Get(int id)
        {
            return _context.BeerTaps.FirstOrDefault(x => x.Id == id);
        }

        public BeerTapDto Save(BeerTapDto entity)
        {
            _context.BeerTaps.AddOrUpdate(entity);
            _context.SaveDbChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            _context.BeerTaps.Remove(Get(id));
            _context.SaveDbChanges();
            return true;
        }
        
        public IEnumerable<BeerTapDto> GetAllByOfficeId(int officeId)
        {
            return _context.BeerTaps.AsNoTracking().Where(x => x.OfficeId == officeId).ToList();
        }
    }
}
