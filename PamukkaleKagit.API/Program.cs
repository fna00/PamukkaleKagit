using PamukkaleKagit.Application;
using PamukkaleKagit.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDatabaseConfiguration(configuration);
builder.Services.AddMediatR(); // MediatR kayd�n� ekleyin
builder.Services.AddAutoMapper();
//builder.Services.AddUnitWork(); // Unit of Work
builder.Services.AddIRepository(); // Repository'ler


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// CORS Middleware
app.UseCors(); // Gelen isteklerin izinlerini burada ayarlay�n.

//// Exception handler middleware
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts(); // HSTS Middleware (g�venlik i�in)
//}

// HTTPS y�nlendirme
//app.UseHttpsRedirection();

// Static files (wwwroot gibi static dosyalara eri�im)
app.UseStaticFiles();

// Routing Middleware
app.UseRouting();

// Authentication Middleware (Kimlik do�rulama)
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();