

namespace LeagueBackendChallenge.Contract
{
    public interface IReadDataFromFile
    {
        public Task<List<List<string>>> GetDataFromFile(IFormFile file);
    }
}
