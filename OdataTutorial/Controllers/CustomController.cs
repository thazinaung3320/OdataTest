using Microsoft.AspNetCore.Mvc;
using ODataTutorial.Data;
using System.Linq;
using ODataTutorial.Models;
using ODataTutorial.Data;
namespace ODataTutorial.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class CustomController : ControllerBase
{
    private readonly DataContext _db;

    private readonly ILogger<TodosController> _logger;

    public CustomController(DataContext dbContext, ILogger<TodosController> logger)
    {
        _logger = logger;
        _db = dbContext;
    }

    [Route("GetNotesByUser")]
    [HttpGet]
    public ActionResult<List<Note>> GetNotesByUser(String username)
    {
        IList<Note> notes = null;

        notes = _db.Notes.Select(n => new Note()
        {
            Id = n.Id,
            MessageNote = n.MessageNote,
            CreatedAt = n.CreatedAt
        }).ToList<Note>();

        if (notes.Count == 0)
        {
            return NotFound();
        }

        return Ok(notes);
    }
}
