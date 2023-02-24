using FlexiFlow.Infrastructure.Jwt;
using FlexiFlow.Repository.Interface;
using FlexiFlow.Repository.ListRepository;
using FlexiFlow.Service;
using FlexiFlow.Service.Implementation;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IUserRepository, UserListRepository>();
builder.Services.AddSingleton<IOrganizationRepository, OrganizationRepository>();

builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IOrganizationService, OrganizationService>();

builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<IJwtUtils, JwtUtils>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Development",
        policy => { policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod(); });
});

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();
app.UseCors();
app.UseSwaggerUI();
app.UseSwaggerUI();
app.UseMiddleware<JwtMiddleware>();
app.UseEndpoints(endpoints => { endpoints.MapControllers();});

app.Run();