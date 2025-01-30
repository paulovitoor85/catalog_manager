#r "Microsoft.Azure.WebJobs.Extensions.CosmosDB"

using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
    [CosmosDB(databaseName: "CatalogDB", collectionName: "Catalog", ConnectionStringSetting = "CosmosDBConnection")] IAsyncCollector<dynamic> documents)
{
    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    var data = JsonConvert.DeserializeObject<dynamic>(requestBody);
    
    await documents.AddAsync(data);

    return new OkObjectResult("Registro salvo no CosmosDB!");
}
