using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Monolithic.Architecture.API.Data.Response;

namespace Monolithic.Architecture.API.Common.Config
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIBaseController : ControllerBase
    {
        protected ErrorResponse GenerateErrors(List<ValidationFailure> failures, bool status)
        {
            var messages = failures.Select((f) => f.ErrorMessage).ToList();
            return new() { Errors = messages, Succeeded = status };
        }
    }
}