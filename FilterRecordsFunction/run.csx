#r "Microsoft.Azure.WebJobs.Extensions.CosmosDB"

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

public static IActionResult Run(
    [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req,
    [CosmosDB(databaseName: "CatalogDB", collectionName: "Catalog", ConnectionStringSetting = "CosmosDBConnection", SqlQuery = "SELECT * FROM c WHERE c.genre = {Query.genre}")] IEnumerable<dynamic> documents)
{
    return new OkObjectResult(documents);
}
