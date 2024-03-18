using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog API", Description = "Write your story with passion", Version = "v1" });
});

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsHistoryTable("__EFMigrationsHistory", builder.Configuration.GetSection("Schema").GetSection("dataSchema").Value)));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API v1");
});

/*app.MapGet("/", () => "Hello World!");
app.MapControllerRoute(name: "articles.getall", pattern: "articles", defaults: new { controller = "ArticlesController", Action = "GetAll" });
app.MapGet("/articles", async (AppDbContext db) => await db.Articles.ToListAsync());
app.MapGet("/articles/{id}", async (AppDbContext db, int id) => await db.Articles.FindAsync(id));
app.MapPost("/articles", async (AppDbContext db, Article article) => {
    // Temp force value
    article.CreatedAt = DateTime.Now;
    article.UpdatedAt = null;

    await db.Articles.AddAsync(article);
    await db.SaveChangesAsync();
    return Results.Created($"/articles/{article.Id}", article);
});*/

app.MapControllers();

app.Run();
