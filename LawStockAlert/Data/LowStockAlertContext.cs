using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using LawStockAlert.Models;

namespace LawStockAlert.Data
{
    public class LowStockAlertContext : DbContext
    {
        public LowStockAlertContext(DbContextOptions<LowStockAlertContext> options) : base(options) { }

        public DbSet<InvetoryItemReqDto> InventoryItems => Set<InvetoryItemReqDto>();
    }
}
