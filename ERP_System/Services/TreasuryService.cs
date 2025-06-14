using ERP_System.Persistence;
using ERP_System.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP_System.Services
{
    public class TreasuryService (ApplicationDbContext context) : ITreasuryService
    {

        private readonly ApplicationDbContext _context = context;

        public IEnumerable<Treasury> GetAll()
        {
            return _context.Treasuries.ToList();
        }


        public Treasury? GetById(int id)
        {
            var treasure = _context.Treasuries.FirstOrDefault(x => x.TreasuryID == id);

            if (treasure == null)
            {
                return null; 
            }

            return treasure;
        }


        public Treasury Create(Treasury treasury)
        {
            _context.Add(treasury);
            _context.SaveChanges();

            return treasury;
        }
       

        public bool Update(int id, Treasury treasury)
        {
            var currentTreasury = _context.Treasuries.Find(id);

            if (currentTreasury == null)
                return false;

            currentTreasury.TreasuryName = treasury.TreasuryName;
            currentTreasury.InitialBalance = treasury.InitialBalance;
            currentTreasury.LastUpdatedOn = DateTime.Now;
            currentTreasury.IsActive = treasury.IsActive;

            _context.SaveChanges();


            return true;
        }


        public bool Delete(int id)
        {
            var Treasury = _context.Treasuries.Find(id);

            if (Treasury == null)
                return false;

            _context.Treasuries.Remove(Treasury);
            _context.SaveChanges();

            return true;
        }
    }
}
