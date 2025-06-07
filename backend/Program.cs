using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using backend.Data;
using backend.Helpers;
using backend.Mapping;
using backend.Repositories.StudentRepo;
using backend.Repositories.TeacherRepo;
using backend.Repositories.user;
using backend.Services.UserServices;
using backend.Services.StudentServices;
using backend.Services.TeacherServices;
using backend.Repositories.StudentFileRepo;
using backend.Repositories.TeacherFileRepo;
using backend.Services.TeacherFileServices;
using backend.Services.StudentFileServices;

var builder = WebApplication.CreateBuilder(args);

// MySQL config
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))));
builder.Services.AddAutoMapper(typeof(MappingProfile));
// CORS config
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()      // Or use .WithOrigins("http://localhost:3000") for production
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// JWT config
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers();

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI services
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStudentFileRepository, StudentFileRepository>();
builder.Services.AddScoped<ITeacherFileRepository, TeacherFileRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentFileService, StudentFileService>();
builder.Services.AddScoped<ITeacherFileService, TeacherFileService>();

builder.Services.AddSingleton<JwtTokenGenerator>();

// === File Upload ===
builder.Services.AddHttpContextAccessor();  // Needed for some file operations

var app = builder.Build();

// Enable Swagger only in Development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll"); // <-- Add CORS middleware BEFORE auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
