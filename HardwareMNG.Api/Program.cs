var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(op =>
{
    op.AddDefaultPolicy(build => build.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    //op.AddPolicy("DEV", build =>
    //    build.WithOrigins("https://localhost:44319")
    //        .AllowAnyMethod()
    //        .AllowAnyHeader()
    //    );
    
    //op.AddPolicy("PROD", build =>
    //    build.WithOrigins("https://hardwaremng.azurewebsites.net:443")
    //        .AllowAnyMethod()
    //        .AllowAnyHeader()
    //);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();