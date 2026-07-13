using Infrastructure;

var builder = WebApplication.CreateBuilder(args);       //valorizza services e configuration, crea un oggetto builder che contiene i servizi e la configurazione dell'applicazione.

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);  //passo 2 cose, con gli extension method il primo parametro è implicito.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>                                         //per React. CORS significa Cross-Origin Resource Sharing, è un meccanismo di sicurezza dei browser che permette a un server di dichiarare quali origini web possono accedere alle sue risorse tramite JavaScript.
{
    options.AddPolicy("ReactApp", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")                           //autorizza il dominio del front-end React a fare richieste al back-end ASP.NET Core.
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();

//app.UseHttpsRedirection();            //commento per evitare problemi con http

app.UseCors("ReactApp");                //per React
app.UseAuthorization();

app.MapControllers();

app.Run();
