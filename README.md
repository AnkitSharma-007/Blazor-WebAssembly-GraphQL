# Blazor-WebAssembly-GraphQL

A full stack application using Blazor Wasm, SQL Server and GraphQL. 

# Configure the Strawberry Shake CLI tools

We need to configure the Strawberry Shake tool which will help us create a GraphQL client. Navigate to the `BlazorWithGraphQL\Client` directory in your machine, open a command prompt, and run the following command:

```
dotnet new tool-manifest
```

Upon successful execution, it will add a `.config` folder in the `BlazorWithGraphQL\Client` directory. This folder will contain a `dotnet-tools.json` file.

Run the following command in the command prompt to install the Strawberry Shake tools.

```
dotnet tool install StrawberryShake.Tools -–local
```

For detailed steps, please refer to - [Get started with Strawberry Shake and Blazor](https://chillicream.com/docs/strawberryshake/v12/get-started)

# Demo

![](https://github.com/AnkitSharma-007/Blazor-WebAssembly-GraphQL/blob/main/Output/BlazorWasmGraphQLOutput.gif)

## Prerequisites
- Visual Studio 2022
- SQL Server
- SQL Server Management Studio (SSMS)
- .NET Core 6.0 SDK or above


## Steps to run the app

- Clone the Repo
- Scaffold and seed the initial data using the [DBScript](https://github.com/AnkitSharma-007/Blazor-WebAssembly-GraphQL/blob/main/BlazorWithGraphQL/DBScript/script.sql)
- Put your own connection string in the [appsettings.json](https://github.com/AnkitSharma-007/Blazor-WebAssembly-GraphQL/blob/main/BlazorWithGraphQL/BlazorWithGraphQL/Server/appsettings.json) file.
- Build and launch the application from Visual Studio.

# See Also

- https://github.com/suresh-mohan/Blazor-WebAssembly-GraphQL
- [A Full-Stack Web App Using Blazor WebAssembly and GraphQL](https://www.syncfusion.com/blogs/post/a-full-stack-web-app-using-blazor-webassembly-and-graphql-part-1.aspx)
