using LawStockAlert.Data;
using LawStockAlert.Models;
using LawStockAlert.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace LawStockAlert.Services
{
    public class LowStockAlertService : ILowStockAlertService
    {
        #region Varibale Declaration
        private readonly LowStockAlertContext _context;
        #endregion

        #region Cosntructor
        public LowStockAlertService(LowStockAlertContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<LowStockItemReqDto>> GetLowStockItemsAsync()
        {
            return await _context.InventoryItems
                .AsNoTracking()
                .Where(item => item.Quantity <= item.ReorderLevel)
                .Select(item => new LowStockItemReqDto
                {
                    id = item.Id,
                    itemName = item.ItemName,
                    category = item.Category,
                    quantityLeft = item.Quantity,
                    reorderLevel = item.ReorderLevel,
                    status = item.Quantity <= item.ReorderLevel * 0.5m
                        ? "Critical"
                        : "Warning"
                })
                .OrderBy(x => x.quantityLeft)
                .ToListAsync();
        }
    }
    #endregion
}

