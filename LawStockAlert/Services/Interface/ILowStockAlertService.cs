using LawStockAlert.Models;

namespace LawStockAlert.Services.Interface
{
    public interface ILowStockAlertService
    {
       Task<IEnumerable<LowStockItemReqDto>> GetLowStockItemsAsync();
    }
}
