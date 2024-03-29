using MyClasses.Interfaces;
using MyClasses.Implementations;
using DependencyInjection.Tools;
using FluentAssertions;

namespace UnitTests
{
    [TestClass]
    public class RegisterSingletonTests
    {
        [TestMethod]
        public void GetSingleton_Should_BeSameObject()
        {
            var container = new DIContainer();
            container.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();
            container.RegisterSingleton<IDummyService, DummyTwoService>();
            var provider = container.GetProvider();

            var firstObject = provider.GetService<IDummyService>();
            var secondObject = provider.GetService<IDummyService>();

            firstObject.Should().BeSameAs(secondObject);
        }
    }
}