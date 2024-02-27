using BookStoreBL.Manager.Author;
using BookStoreBL.Manager.Book;
using BookStoreDAL.Auth.TokenSetting;
using BookStoreDAL.Context;
using BookStoreDAL.Repos.Author_Repo;
using BookStoreDAL.Repos.BookRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DataBase
var connectionString = builder.Configuration.GetConnectionString("BookDbContext");
builder.Services.AddDbContext<BookDbContext>(options => options.UseSqlServer(connectionString));
#endregion
#region Repos
builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();
builder.Services.AddScoped<IBookRepo, BookRepo>();
#endregion
#region Managers
builder.Services.AddScoped<IAuthorManager, AuthorManager>();
builder.Services.AddScoped<IBookManager, BookManager>();
#endregion
#region Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Default";
    options.DefaultChallengeScheme = "Default";
}
)
    .AddJwtBearer("Default", options =>
    {
        var jwtsettings = builder.Configuration.GetSection("JWTSetting").Get<JWTSetting>()
        ?? throw new Exception("No JWTSetting Found ");
        var getKey = Encoding.UTF8.GetBytes(jwtsettings.Key);
        var key = new SymmetricSecurityKey(getKey);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtsettings.Issuer,
            ValidAudience = jwtsettings.Audicne,
            IssuerSigningKey = key
        };
    });
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
