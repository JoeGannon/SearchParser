using Fixie;
using System.Threading.Tasks;

namespace SearchParser.Tests.Conventions
{
    public class FixieSingleInstanceExecution : IExecution
    {
        public async Task Run(TestSuite testSuite)
        {
            foreach (var testClass in testSuite.TestClasses)
            {
                var instance = testClass.Construct();

                foreach (var test in testClass.Tests)
                {
                    await test.Run(instance);
                }
            }
        }
    }
}
