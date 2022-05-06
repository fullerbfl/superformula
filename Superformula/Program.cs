using Superformula.Persistence.Repository;
using Superformula.Service;
using Superformula.Service.Interface;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IInsurancePolicyService, InsurancePolicyService>();
builder.Services.AddScoped<StateRegulationService, StateRegulationService>();
// add singleton so it persists - this should not be used in prod, though ;)
builder.Services.AddSingleton<InsurancePolicyRepository, InsurancePolicyRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
