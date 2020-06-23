using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RankkerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return new OkObjectResult("Call Successful");
        }
    }
}