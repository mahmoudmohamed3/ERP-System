using ERP_System.Persistence.Entities;

namespace ERP_System.Services
{
    public interface ITreasuryService
    {
        IEnumerable<Treasury> GetAll();
        Treasury? GetById(int id);
        Treasury Create(Treasury treasury);
        bool Update(int id, Treasury treasury);
        bool Delete(int id);
    }
}
