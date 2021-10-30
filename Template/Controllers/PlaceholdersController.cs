using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Template.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using System.Globalization;

namespace Template.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlaceholdersController : ControllerBase
  {
    private readonly TemplateContext _db;

    public PlaceholdersController(TemplateContext db)
    {
      _db = db;
    }

    [HttpGet("load")]
    public async Task<ActionResult<IEnumerable<Placeholder>>> LoadPlaceholders()
    {
      using (var streamReader = new StreamReader("./Models/SeedData/file_name.csv"))
      {
        using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
        {
          csvReader.Context.RegisterClassMap<PlaceholderMap>();
          var PlaceholderRecords = csvReader.GetRecords<Placeholder>().ToList();
          
          _db.Placeholders.AddRange(PlaceholderRecords);
          _db.SaveChanges();
        }
      }

      return await _db.Placeholders.ToListAsync();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Placeholder>>> GetPlaceholders(string type, int minScore, int maxScore, bool sorted = false)
    {
      var query = _db.Placeholders.AsQueryable();

      if(type != null)
      {
        query = query.Where(Placeholder => Placeholder.Type == type);
      }
      if(minScore != 0)
      {
        query = query.Where(Placeholder => Placeholder.Score >= minScore);
      }
      if(maxScore != 0)
      {
        query = query.Where(Placeholder => Placeholder.Score <= maxScore);
      }
      if(sorted)
      {
        query = query.OrderByDescending(Placeholder => Placeholder.Score);
      }
      return await query.ToListAsync();
    }
    
    [HttpPost]
    public async Task<ActionResult<Placeholder>> Post([FromBody] Placeholder Placeholder)
    {
      _db.Placeholders.Add(Placeholder);
      
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = Placeholder.PlaceholderId }, Placeholder);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Placeholder>> GetPlaceholder(int id)
    {
      var Placeholder = await _db.Placeholders.FindAsync(id);

      if (Placeholder == null)
      {
        return NotFound();
      }

      return Placeholder;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlaceholder(int id)
    {
      var PlaceholderToDelete = await _db.Placeholders.FirstOrDefaultAsync(entry => entry.PlaceholderId == id);
      if (PlaceholderToDelete == null)
      {
        return NotFound();
      }

      _db.Placeholders.Remove(PlaceholderToDelete);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPlaceholder(int id, [FromBody]Placeholder Placeholder)
    {
      if (id != Placeholder.PlaceholderId)
      {
        return BadRequest();
      }
    
      _db.Entry(Placeholder).State = EntityState.Modified;
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}