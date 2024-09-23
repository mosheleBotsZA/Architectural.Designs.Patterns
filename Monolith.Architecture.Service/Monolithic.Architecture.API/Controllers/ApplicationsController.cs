using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Monolithic.Architecture.API.Common.Config;
using Monolithic.Architecture.API.Contracts.Services;
using Monolithic.Architecture.API.Data.DTO;
using Monolithic.Architecture.API.Data.Response;

namespace Monolithic.Architecture.API.Controllers
{
    public class ApplicationsController : APIBaseController
    {
        private readonly IApplicationService _applicationService;
        private readonly IValidator<ApplicationDTO> _validator;

        public ApplicationsController(IApplicationService applicationService, IValidator<ApplicationDTO> validator)
        {
            _applicationService = applicationService;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> GetApplications([FromBody] ApplicationDTO application)
        {

            var results = await _validator.ValidateAsync(application);
            if (!results.IsValid)
            {
                var response = GenerateErrors(results.Errors, results.IsValid);
                return BadRequest(response);
            }
            application = await _applicationService.AddorUpdate(application);
            string message = string.Format("You have successfully created {0} application", application.Name);
            return Ok(new Response<ApplicationDTO> { Data = application, Message = message, Succeeded = true });
        }
    }
}