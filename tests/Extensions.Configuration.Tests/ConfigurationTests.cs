using Extensions.Configuration.Factory;
using Xunit;

namespace Extensions.Configuration.Tests
{
    public class ConfigurationTests
    {
        [Fact]
        public void ConfigurationTest()
        {
            var config = ConfigurationFactory.Instance.GetConfiguration();
            var value = config["ParentKey:ChildKey"];

            Assert.Equal("xxx", value);
        }
    }
}
