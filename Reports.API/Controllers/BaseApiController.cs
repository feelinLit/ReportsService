using Microsoft.AspNetCore.Mvc;

namespace Reports.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
}