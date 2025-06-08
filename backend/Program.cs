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
using backend.Services.TeacherEnrollmentServices;
using backend.Repositories.TeacherEnrollmentRepo;
using backend.Repositories.StudentEnrollmentRepo;
using backend.Services.StudentEnrollmentServices;

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
        policy.AllowAnyOrigin()      
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
builder.Services.AddScoped<ITeacherEnrollmentRepository, TeacherEnrollmentRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<ITeacherEnrollmentService, TeacherEnrollmentService>();

builder.Services.AddSingleton<JwtTokenGenerator>();


var app = builder.Build();

// Enable Swagger only in Development environment
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll"); // <-- Add CORS middleware BEFORE auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
