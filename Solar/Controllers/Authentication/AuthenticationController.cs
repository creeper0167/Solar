using Microsoft.AspNetCore.Mvc;

namespace Solar.Api.Controllers.Authentication;

public class AuthenticationController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}