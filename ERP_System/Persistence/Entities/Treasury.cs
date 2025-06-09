namespace ERP_System.Persistence.Entities
{
    public class Treasury
    {
        public int TreasuryID { get; set; }
        public string TreasuryName { get; set; } = string.Empty;
        public decimal InitialBalance { get; set; } = 0;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastUpdatedOn { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
