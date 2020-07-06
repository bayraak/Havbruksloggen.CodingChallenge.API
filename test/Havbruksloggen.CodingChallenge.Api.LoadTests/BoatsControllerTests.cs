using Xunit;

namespace Havbruksloggen.CodingChallenge.Api.LoadTests
{
    public class BoatsControllerTests : LoadTestsBase
    {
        protected override string ResourceUrl => "api/cars";

        [Fact]
        public void GetAll_load_test()
        {
            ExecuteLoadTest(action: "/");
        }
    }
}
