using Ramboe.MinimalApis;

var builder = WebApplication.CreateBuilder(args);

//dunno

//endpoints
var isDev = builder.Environment.IsDevelopment();
builder.Services.AddEndpoints<Program>(builder.Configuration, isDev);

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseEndpoints<Program>();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
