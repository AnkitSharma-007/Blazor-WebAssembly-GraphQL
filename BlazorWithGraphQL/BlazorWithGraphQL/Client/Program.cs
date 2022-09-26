using BlazorWithGraphQL.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

/* We have registered the MovieClient via dependency injection and created the GraphQL server path by appending graphql to the base address of the application. 
 * This will make sure that we do not need to maintain separate URLs for different environments.
 */

string graphQLServerPath = builder.HostEnvironment.BaseAddress + "graphql";

builder.Services.AddEmployeeClient()
   .ConfigureHttpClient(client =>
   {
       client.BaseAddress = new Uri(graphQLServerPath);
   }
);

await builder.Build().RunAsync();
