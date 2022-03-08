using Microsoft.AspNetCore.Mvc;

namespace ReportsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseApiController : Controller
{
}