using Fixie;

namespace SearchParser.Tests.Conventions
{
    public class FixieProject : ITestProject
    {
        public void Configure(TestConfiguration configuration, TestEnvironment environment)
        {
            configuration.Conventions.Add<FixieSingleInstanceDiscovery, FixieSingleInstanceExecution>();
        }
    }
}
