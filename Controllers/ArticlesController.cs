using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

[Route("[controller]")]
[ApiController]
public class ArticlesController : ControllerBase {
    [HttpGet]
    public async Task<IEnumerable<Article>> GetAll(AppDbContext db) {
        return await db.Articles.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetById(AppDbContext db, int id) {
        var res = await db.Articles.FindAsync(id);
        if (res == null) {
            return NotFound();
        }
        return Ok(res);
    }

    [HttpPost]
    public async Task<ActionResult<Article>> Create(AppDbContext db, Article article) {
        // Temp force value
        article.CreatedAt = DateTime.Now;
        article.UpdatedAt = null;

        await db.Articles.AddAsync(article);
        await db.SaveChangesAsync();
        return Created($"/articles/{article.Id}", article);
    }
}