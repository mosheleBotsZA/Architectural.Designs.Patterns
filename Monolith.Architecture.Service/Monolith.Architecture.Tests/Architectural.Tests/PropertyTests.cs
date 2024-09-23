using NetArchTest.Rules;

namespace Architectural.Tests
{
    public class PropertyTests
    {
        private readonly Assembly Presentation = typeof(Program).Assembly;
        [Fact]
        public void PrivateReadonlyFields_Should_Have_Underscore_Prefix()
        {
            var types = Types
            .InAssembly(Presentation)
            .That()
            .AreClasses()
            .GetTypes();
            types.ToList().ForEach((type) =>
            {
                var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.IsInitOnly);

                foreach (var field in fields)
                {
                    Assert.False(!field.Name.StartsWith("_"),
                    $"Field '{field.Name}' in class '{type.Name}' should start with an underscore.");
                }
            });
        }
        [Fact]
        public void PrivateConstFields_Should_Be_All_Caps()
        {
            var types = Types
            .InAssembly(Presentation)
            .That()
            .AreClasses()
            .GetTypes();
            types.ToList().ForEach((type) =>
            {
                var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => !f.IsInitOnly && f.IsLiteral);

                foreach (var field in fields)
                {
                    Assert.False(!field.Name.All(char.IsUpper),
                    $"Field '{field.Name}' in class '{type.Name}' should be in all caps.");
                }
            });
        }
    }
}