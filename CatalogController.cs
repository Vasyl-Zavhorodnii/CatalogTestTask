using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CatalogController : Controller
{
    private readonly CatalogDbContext _context;

    public CatalogController(CatalogDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Catalog>> GetCatalogs()
    {
        var catalogs = _context.Catalogs.ToList();
        return Ok(catalogs);
    }

    [HttpGet("{id}")]
    public ActionResult<Catalog> GetCatalog(int id)
    {
       return _context.Catalogs.Find(id);
        
    }

}
