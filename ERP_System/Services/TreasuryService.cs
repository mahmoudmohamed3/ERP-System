using ERP_System.Persistence;
using ERP_System.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP_System.Services
{
    public class TreasuryService (ApplicationDbContext context) : ITreasuryService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Treasury>> GetAllAsync()
        {
            return await _context.Treasuries.ToListAsync();
        }

        public async Task<Treasury?> GetByIdAsync(int id)
        {
            var treasure = await _context.Treasuries.FirstOrDefaultAsync(x => x.TreasuryID == id);

            if (treasure == null)
            {
                return null; 
            }

            return treasure;
        }

        public async Task<Treasury> CreateAsync(Treasury treasury)
        {
            await _context.AddAsync(treasury);
            await _context.SaveChangesAsync();

            return treasury;
        }

        public async Task<bool> UpdateAsync(int id, Treasury treasury)
        {
            var currentTreasury = await _context.Treasuries.FindAsync(id);

            if (currentTreasury == null)
                return false;

            currentTreasury.TreasuryName = treasury.TreasuryName;
            currentTreasury.InitialBalance = treasury.InitialBalance;
            currentTreasury.LastUpdatedOn = DateTime.Now;
            currentTreasury.IsActive = treasury.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Treasury = await _context.Treasuries.FindAsync(id);

            if (Treasury == null)
                return false;

            _context.Treasuries.Remove(Treasury);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
