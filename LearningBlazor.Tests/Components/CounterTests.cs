using LearningBlazor.Pages;
using Microsoft.AspNetCore.Components.Testing;
using Xunit;

namespace LearningBlazor.Tests.Components
{
    public class CounterTests
    {
        private readonly TestHost host = new TestHost();

        [Fact]
        public void AddingComponent_CountIsZero()
        {
            var counter = host.AddComponent<Counter>();

            Assert.Equal("Current count: 0", counter.Find("p").InnerText);
        }

        [Fact]
        public void ClickingIncrementButton_CountIsIncremented()
        {
            var counter = host.AddComponent<Counter>();

            counter.Find("button").Click();

            Assert.Equal("Current count: 1", counter.Find("p").InnerText);
        }
    }
}
