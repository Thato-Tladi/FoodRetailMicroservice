using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

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
