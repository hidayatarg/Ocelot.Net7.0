using Microsoft.AspNetCore.Mvc;

namespace Product.API.Controllers;
[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new List<string> { "Kalem", "Kitap", "Silgi", "Defter" });
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(new List<string> { "Kalem", "Kitap", "Silgi", "Defter" }[id]);
    }

    [HttpDelete("[action]")]
    public IActionResult Delete()
    {
        return Ok("Silme işlemi başarılı.");
    }
}