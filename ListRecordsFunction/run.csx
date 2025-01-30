#r "Microsoft.Azure.WebJobs.Extensions.CosmosDB"

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

public static IActionResult Run(
    [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req,
    [CosmosDB(databaseName: "CatalogDB", collectionName: "Catalog", ConnectionStringSetting = "CosmosDBConnection")] IEnumerable<dynamic> documents)
{
    return new OkObjectResult(documents);
}
