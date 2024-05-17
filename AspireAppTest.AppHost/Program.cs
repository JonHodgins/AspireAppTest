var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

// Automatically provision an Application Insights resource
var insights = builder.AddAzureApplicationInsights("MyApplicationInsights");


var apiService = builder.AddProject<Projects.AspireAppTest_ApiService>("apiservice").WithReference(insights);

builder.AddProject<Projects.AspireAppTest_Web>("webfrontend")
	.WithExternalHttpEndpoints()
	.WithReference(cache)
	.WithReference(apiService)
	.WithReference(insights);

builder.Build().Run();
