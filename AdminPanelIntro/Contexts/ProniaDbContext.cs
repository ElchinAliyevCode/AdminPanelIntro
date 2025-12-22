using AdminPanelIntro.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminPanelIntro.Contexts
{
    public class ProniaDbContext : DbContext
    {
        public ProniaDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ShippingItem> ShippingItems { get; set; }
    }
}
