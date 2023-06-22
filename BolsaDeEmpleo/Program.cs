using BolsaDeEmpleo;
using BolsaDeEmpleo.Data;
using BolsaDeEmpleo.Repositorio;
using BolsaDeEmpleo.Repository;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//servicio para relacionar la clase dbcontext con la cadena de conexion y el motor de db
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//servicio del mapeo de objetos e indicamos la clase que realiza el mapeo
builder.Services.AddAutoMapper(typeof(MappingConfig));

//servicio con alcance de crearse una vez por solicitud y luego se destruyen
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();

builder.Services.AddScoped<IApplicantSkillsRepository, ApplicantSkillsRepository>();

builder.Services.AddScoped<IOfferApplicants, OfferApplicantsRepository>();

builder.Services.AddScoped<IEducationRepository, EducationRepository>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

builder.Services.AddScoped<ISkillRepository, SkillRepository>();

builder.Services.AddScoped<IOfferRepository, OfferRepository>();

builder.Services.AddScoped<IOfferSkillsRepository, OfferSkillsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
