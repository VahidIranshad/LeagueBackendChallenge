
namespace LeagueBackendChallengeTest
{
    public class BaseControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public BaseControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        /// <summary>
        /// Get Default Client
        /// </summary>
        /// <returns></returns>
        public HttpClient GetNewClient()
        {
            var newClient = _factory.WithWebHostBuilder(builder =>
            {
                _factory.CustomConfigureServices(builder);
            }).CreateClient();

            /*Here we can have set some properties such as authorization for httpclient*/

            return newClient;
        }
    }
}
