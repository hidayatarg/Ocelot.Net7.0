using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new List<string> { "Ahmet", "Osman", "Ezgi", "Mehmet" });
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(new List<string> { "Ahmet", "Osman", "Ezgi", "Mehmet" }[id]);
    }

    [HttpDelete("[action]")]
    public IActionResult Delete()
    {
        return Ok("Silme işlemi başarılı.");
    }
}