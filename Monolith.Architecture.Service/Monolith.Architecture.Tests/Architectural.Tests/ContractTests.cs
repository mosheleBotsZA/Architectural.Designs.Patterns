using Monolithic.Architecture.API.Contracts.Common;
using NetArchTest.Rules;

namespace Architectural.Tests
{
    public class ContractTests
    {
        private readonly Assembly Presentation = typeof(Program).Assembly;
        [Fact]
        public void All_IRepository_Interfaces_Should_Have_IQueryable_Property()
        {
            var types = Types.InAssembly(Presentation)
                        .That()
                        .ImplementInterface(typeof(IRepository<>))
                        .GetTypes();
            foreach (var type in types)
            {
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                bool propertiesContainIQueryable = properties.Any(p => p.PropertyType.IsGenericType
                && p.PropertyType.GetGenericTypeDefinition() == typeof(IQueryable<>));
                Assert.False(!propertiesContainIQueryable, $"{type.Name} must have a public get property of type IQueryable<T>");
            }

        }
        [Fact]
        public void Should_Have_Interfaces_With_Interface_In_Their_Name()
        {
            var types = Types
            .InAssembly(Presentation)
            .That()
            .AreInterfaces()
            .GetTypes();
            var interfaces = types.Where(i => i.Name.EndsWith("Interface")).ToList();
            if (interfaces.Any())
            {
                string name = string.Join(", ", interfaces.Select(i => i.Name));
                string messages = string.Format("{0} contracts has 'Interface' as its suffix", name);
                Assert.False(true, messages);
            }
        }
        [Fact]
        public void All_Models_Should_Inherit_From_IAudit_Trail()
        {
            var entities = Types
            .InAssembly(Presentation)
            .That()
            .ResideInNamespace(nameof(Monolithic.Architecture.API.Data.Models))
            .And()
            .AreClasses()
            .GetTypes();

            var failedModels = entities.Where(entity => !typeof(IAuditTrail)
             .IsAssignableFrom(entity))
             .ToList();

            failedModels.ForEach((model) =>
            {
                Assert.False(true, $"{model.Name} model does not inherit model IAuditTrail.");
            });
        }
    }
}