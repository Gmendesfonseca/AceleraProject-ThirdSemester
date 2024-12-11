using InnerAPI.Controllers;
using InnerAPI.Services;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseUrls("http://localhost:7258");

// Registra SharedService como um singleton
builder.Services.AddSingleton<SharedService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000", "http://localhost:5173") // Adicione aqui as origens do seu cliente
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
    options.AddPolicy("AnotherPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:5173") // Adicione aqui as origens do seu cliente
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Adiciona servi�os ao cont�iner.

builder.Services.AddControllers();
// Saiba mais sobre a configura��o do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();

// Obt�m as inst�ncias dos servi�os diretamente do cont�iner de servi�os
var sharedService = app.Services.GetRequiredService<SharedService>();

app.MapStudentEndpoint(sharedService);
app.MapBranchEndpoint(sharedService);
app.MapHeadOfficeEndpoint(sharedService);
app.MapProfessorEndpoint(sharedService);
app.MapLoginEndpoint(sharedService);
app.MapPostEndpoint(sharedService);
app.MapChatEndpoint(sharedService);
//app.MapCourseEndpoint(sharedService);


// Configura o pipeline de requisi��es HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

