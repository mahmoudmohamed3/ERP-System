using ERP_System.Persistence.Entities;

namespace ERP_System.Services
{
    public interface ITreasuryService
    {
        Task<IEnumerable<Treasury>> GetAllAsync();
        Task<Treasury?> GetByIdAsync(int id);
        Task<Treasury> CreateAsync(Treasury treasury);
        Task<bool> UpdateAsync(int id, Treasury treasury);
        Task<bool> DeleteAsync(int id);
    }
}
