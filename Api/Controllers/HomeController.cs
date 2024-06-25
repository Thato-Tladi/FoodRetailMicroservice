using Microsoft.AspNetCore.Mvc;

namespace FoodRetailer.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> GetApiStatus()
    {
        return Ok("FoodRetailer is up and ready to go!");
    }
}
