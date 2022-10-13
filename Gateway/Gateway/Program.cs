using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

//var builder = WebApplication.CreateBuilder(args);
//builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile("ocelot.json", true, true).AddEnvironmentVariables();

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName.ToLower()}.json", true, true).AddEnvironmentVariables();
});



IConfiguration configuration = builder.Configuration;

// Add services to the container.

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowOrigin",
//        builder => builder.WithOrigins("https://localhost:1005", "http://localhost:7231", "http://localhost:7257"));
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
SymmetricSecurityKey signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenOptions:SecurityKey"]));

//var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
string authenticationProviderKey = "MGLCORE";
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidIssuer = configuration["TokenOptions:Issuer"],
        ValidAudience = configuration["TokenOptions:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = signInKey
    };
});
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseCors(builder => builder.WithOrigins("https://localhost:7054", "http://localhost:7231", "http://localhost:7257").AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseOcelot();
app.MapControllers();


app.Run();
