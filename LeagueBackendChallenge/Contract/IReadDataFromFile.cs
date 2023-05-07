

namespace LeagueBackendChallenge.Contract
{
    public interface IReadDataFromFile
    {
        public Task<List<List<string>>> GetDataFromFile(IFormFile file);
        public Task<List<List<long>>> GetNumbersFromFile(IFormFile file);
    }
}
