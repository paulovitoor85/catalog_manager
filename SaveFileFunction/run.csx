#r "Microsoft.Azure.WebJobs.Extensions.Storage"

using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

public static async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
    [Blob("files/{rand-guid}.json", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream blob,
    ILogger log)
{
    using (var writer = new StreamWriter(blob))
    {
        await req.Body.CopyToAsync(writer.BaseStream);
    }
    
    return new OkObjectResult("Arquivo salvo com sucesso!");
}
