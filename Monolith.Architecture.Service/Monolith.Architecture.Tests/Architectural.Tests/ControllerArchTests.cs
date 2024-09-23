using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monolithic.Architecture.API.Common.Config;
using Monolithic.Architecture.API.Contracts.Common;
using NetArchTest.Rules;
namespace Architectural.Tests
{
    public class ControllerArchTests
    {
        private static readonly Assembly Presentation = typeof(Program).Assembly;
        [Fact]
        public void Endpoints_ShouldInherit_APIBaseController()
        {
            var results = Types
            .InAssembly(Presentation)
            .That()
            .ResideInNamespace(nameof(Monolithic.Architecture.API.Controllers))
            .And()
            .HaveNameEndingWith("Controller")
            .Should()
            .Inherit(typeof(APIBaseController))
            .GetResult();
            if (results.FailingTypeNames is not null)
            {
                if(results.FailingTypeNames.Any())
                {
                    string failedControllers = string.Join(", ", results.FailingTypeNames);
                    string message = $"The following controllers do not inherit from APIBaseController: {failedControllers}";
                    Assert.False(false, message);
                }
            }
        }
        [Fact]
        public void Methods_Returning_Task_IActionResult_Should_Contain_IResponse_Value()
        {
            var types = Types.InAssembly(typeof(APIBaseController).Assembly)
            .That()
            .Inherit(typeof(APIBaseController))
            .And()
            .AreClasses()
            .GetTypes();

            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.Public);
                methods.ToList().ForEach((method) =>
                {
                    if (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                    {
                        var endpointInstance = Activator.CreateInstance(type);
                        var result = method.Invoke(endpointInstance, null) as IActionResult;
                        Assert.False(result is not ObjectResult objectResult, "The value returned by {method.Name} in {type.Name} should either be Response<T> or Error Response");
                    }
                });
            }
        }
        [Fact]
        public void Controllers_Should_Not_Inject_DataAccess_Layer_or_IMapper()
        {
            var types = Types.InAssembly(typeof(APIBaseController).Assembly)
           .That()
           .Inherit(typeof(APIBaseController))
           .And().AreClasses()
           .GetTypes();
            types.ToList().ForEach((type) =>
            {
                var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
                foreach (var constructor in constructors)
                {
                    var parameters = constructor.GetParameters();
                    foreach (var parameter in parameters)
                    {
                        if (typeof(DbContext).IsAssignableFrom(parameter.ParameterType) ||
                            parameter.ParameterType.IsGenericType &&
                             parameter.ParameterType.GetGenericTypeDefinition() == typeof(IRepository<>) ||
                            parameter.ParameterType == typeof(IMapper))
                        {
                            Assert.False(true, $"Controller {type.Name} should not inject {parameter.ParameterType.Name} in its constructor.");
                        }
                    };
                }
            });
        }
    }
}