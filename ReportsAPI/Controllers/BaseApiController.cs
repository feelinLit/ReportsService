using Microsoft.AspNetCore.Mvc;

namespace ReportsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
}