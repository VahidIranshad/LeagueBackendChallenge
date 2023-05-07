using LeagueBackendChallenge.Contract;

namespace LeagueBackendChallenge.Utility
{
    public class ReadDataFromExcel : IReadDataFromFile
    {
        public async Task<List<List<string>>> GetDataFromFile(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<List<List<long>>> GetNumbersFromFile(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
