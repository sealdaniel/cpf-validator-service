using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

public static class ValidateCpfFunction
{
    [FunctionName("ValidateCpf")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        string cpf = req.Query["cpf"];

        if (string.IsNullOrEmpty(cpf) || !IsValidCpf(cpf))
        {
            return new BadRequestObjectResult("Invalid CPF.");
        }

        return new OkObjectResult("Valid CPF.");
    }

    private static bool IsValidCpf(string cpf)
    {
        cpf = Regex.Replace(cpf, "[^0-9]", "");

        if (cpf.Length != 11) return false;

        // Implemente a validação real de CPF aqui.
        return true;
    }
}
