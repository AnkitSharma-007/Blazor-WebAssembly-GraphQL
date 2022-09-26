using BlazorWithGraphQL.Server.DataAccess;
using BlazorWithGraphQL.Server.GraphQL;
using BlazorWithGraphQL.Server.Interfaces;
using BlazorWithGraphQL.Server.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContextFactory<EmployeeDBContext>
    (options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmployee, EmployeeDataAccessLayer>();

builder.Services.AddGraphQLServer()
    .AddQueryType<EmployeeQueryResolver>()
    .AddMutationType<EmployeeMutationResolver>()
    .AddFiltering();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.MapFallbackToFile("index.html");

app.Run();
