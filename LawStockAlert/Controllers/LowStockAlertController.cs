using LawStockAlert.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LawStockAlert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LowStockAlertController : ControllerBase
    {
        #region Variable Declaration
        private readonly ILowStockAlertService _lowStockAlertService;
        #endregion

        #region Constructor
        public LowStockAlertController(ILowStockAlertService lowStockAlertService)
        {
            _lowStockAlertService = lowStockAlertService;
        }
        #endregion

        #region Methods
        [HttpGet("lowstock")]
        public async Task<IActionResult> GetLowStockItems()
        {
            try
            {
                var items = await _lowStockAlertService.GetLowStockItemsAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Failed to retrieve low stock items.",
                    error = ex.Message
                });
            }
        }
        #endregion
    }
}
