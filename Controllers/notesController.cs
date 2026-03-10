using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecurityDemo.Models;

namespace SecurityDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly AppDbContext _context;

    public NotesController(AppDbContext context)
    {
        _context = context;
    }

    // SÅRBAR ENDPOINT
    [HttpGet("{id}")]
    public async Task<IActionResult> GetNote(int id)
    {
        var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

        if (note == null) return NotFound();
        return Ok(note);
    }
    [HttpGet("allNotes")]
    public async Task<IActionResult> GetAllNotes()
    {
        var allNotes = await _context.Notes.ToListAsync();
        return Ok(allNotes);
    }
    [HttpGet("admin/all")]
    public async Task<IActionResult> GetAllNotesForAdmin()
    {
        var userName = Request.Headers["X-User"].ToString();

        bool isAdmin = userName == "Admin";

        if (!isAdmin) 
        {
            return Forbid(); 
        }

        var allNotes = await _context.Notes.ToListAsync();
        return Ok(allNotes);
    }
}