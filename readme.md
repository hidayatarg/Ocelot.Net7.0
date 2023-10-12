## Ocelot .NET Core 7.0

Welcome to the Ocelot .NET Core 7.0. In this document, we will discuss what Ocelot is and how to use it in your project. Ocelot is a library that simplifies API Gateway implementation in microservices architectures.

### What is Ocelot?

Ocelot is an open-source API Gateway for .NET. It acts as a reverse proxy that routes incoming HTTP requests to a set of microservices based on the request's URL and other factors. It provides features like routing, load balancing, request/response transformation, and security features, making it a valuable tool for managing your microservices.

### Usage

#

### 1. Installation

To use Ocelot in your .NET Core 7.0 project, you need to add the Ocelot NuGet package. You can do this via the command line using the following command:

`bash dotnet add package Ocelot`

### 2. Configuration

In your project, create a ocelot.json configuration file. This file defines routing rules and other configuration options for Ocelot. Here's a basic example of an ocelot.json file:

```json
{
	"Routes": [
		{
			"DownstreamPathTemplate": "/api/product",
			"DownstreamScheme": "https",
			"DownstreamHostAndPorts": [
				{
					"Host": "localhost",
					"Port": 5002
				}
			],
			"UpstreamPathTemplate": "/api/gateway/product",
			"Priority": 1,
			"UpstreamHttpMethod": ["Get"]
		},
		{
			"DownstreamPathTemplate": "/api/customer",
			"DownstreamScheme": "https",
			"DownstreamHostAndPorts": [
				{
					"Host": "localhost",
					"Port": 5001
				}
			],
			"UpstreamPathTemplate": "/api/gateway/customer",
			"Priority": 0,
			"UpstreamHttpMethod": ["Get"]
		}
	],
	"GlobalConfiguration": {
		"BaseUrl": "https://localhost:5005"
	}
}
```

This example defines a route that forwards requests to the product and customer services based on the path.

### 3. Middleware Configuration

In .Net Core 7.0, your Program.cs file, configure Ocelot as middleware:

```csharp
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1. add Configuration
builder.Configuration.AddJsonFile("ocelot.json", false, true);
builder.Services.AddOcelot();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 2. add OcelotMiddleware
await app.UseOcelot();

app.UseAuthorization();
app.MapControllers();
app.Run();
```

### 4. Run Your Project

Now you can run your .NET Core 7.0 project. Ocelot will act as an API Gateway, forwarding requests to the appropriate microservices according to the ocelot.json configuration.

## Documentation

For more detailed information on Ocelot and its features, please refer to the official documentation: Ocelot Documentation

## Contributions

We welcome contributions to this project. If you encounter any issues or want to contribute to its development, please check out our GitHub repository: Ocelot GitHub Repository

## License

This project is licensed under the MIT License. For more information, please refer to the LICENSE file.

Don't forget to stare this repository if you find it useful!

Feel free to add to this project.

Hidayat Arghandabi

Senior Full Stack Software Engineer

12 October 2023
