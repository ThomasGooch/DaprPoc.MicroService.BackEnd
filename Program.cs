var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7172")
                          .WithMethods("POST")
                          .WithHeaders("Content-Type");
                      });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapPost("/greetings", (NameService name) =>
{
    Console.WriteLine("Hello : " + name);
    return name;
});
app.UseCors(MyAllowSpecificOrigins);
await app.RunAsync();

public record NameService(string Name);