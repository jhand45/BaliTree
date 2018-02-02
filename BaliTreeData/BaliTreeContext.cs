using BaliTreeData.Models;
using Microsoft.EntityFrameworkCore;

namespace BaliTreeData
{
    public class BaliTreeContext : DbContext
    {
        public BaliTreeContext(DbContextOptions options) : base(options) { }

        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<StockOrder> StockOrders { get; set; }
        public DbSet<StockType> StockTypes { get; set; }
        public DbSet<StockEvent> StockEvents { get; set; }

    }
}
