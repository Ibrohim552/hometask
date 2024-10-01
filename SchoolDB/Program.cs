using SchoolDB.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IStudent, StudentServices>();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();