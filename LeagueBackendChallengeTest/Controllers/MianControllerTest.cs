using Newtonsoft.Json;
using System.Text;

namespace LeagueBackendChallengeTest.Controllers
{
    public class MianControllerTest : BaseControllerTest
    {
        #region StaticData
        private static readonly List<List<string>> CsvDataForTest1 = new() { new() { "1" } };
        private static readonly List<List<string>> CsvDataForTest2 = new() { new() { "1", "2" }, new() { "3", "4" } };
        private static readonly List<List<string>> CsvDataForTest3 = new() { new() { "1", "2", "3" }, new() { "4", "5", "6" }, new() { "7", "8", "9" } };
        #endregion

        public MianControllerTest(CustomWebApplicationFactory<Program> factory) : base(factory)
        {

        }

        /// <summary>
        /// Check Echo
        /// Result == Expected
        /// Check StatusCode = "OK"
        /// </summary>
        /// <param name="data"></param>
        /// <param name="expected"></param>
        /// <returns>true</returns>
        [Theory]
        [MemberData(nameof(GetDataForEcho))]
        public async Task Echo_DifferentData_SameExpected(List<List<string>> data, string expected)
        {

            var client = this.GetNewClient();
            var content = CreateCsvContentForTest(data);
            var response = await client.PostAsync("/api/Main/Echo", content);
            response.EnsureSuccessStatusCode();
            var statusCode = response.StatusCode.ToString();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<string>(stringResponse);

            Assert.Equal("OK", statusCode);
            Assert.Equal(result, expected);
        }
        private static IEnumerable<object[]> GetDataForEcho()
        {
            return new List<object[]>
            {
                new object[] {CsvDataForTest1,"1\n"},
                new object[] {CsvDataForTest2,"1,2\n3,4\n"},
                new object[] {CsvDataForTest3, "1,2,3\n4,5,6\n7,8,9\n" }
            };
        }



        /// <summary>
        /// Check Invert
        /// Result == Expected
        /// Check StatusCode = "OK"
        /// </summary>
        /// <param name="data"></param>
        /// <param name="expected"></param>
        /// <returns>true</returns>
        [Theory]
        [MemberData(nameof(GetDataForInvert))]
        public async Task Invert_DifferentData_SameExpected(List<List<string>> data, string expected)
        {

            var client = this.GetNewClient();
            var content = CreateCsvContentForTest(data);
            var response = await client.PostAsync("/api/Main/Invert", content);
            response.EnsureSuccessStatusCode();
            var statusCode = response.StatusCode.ToString();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<string>(stringResponse);

            Assert.Equal("OK", statusCode);
            Assert.Equal(result, expected);
        }
        private static IEnumerable<object[]> GetDataForInvert()
        {
            return new List<object[]>
            {
                new object[] {CsvDataForTest1,"1\n"},
                new object[] {CsvDataForTest2,"1,3\n2,4\n"},
                new object[] {CsvDataForTest3, "1,4,7\n2,5,8\n3,6,9\n" }
            };
        }




        /// <summary>
        /// Check Flatten
        /// Result == Expected
        /// Check StatusCode = "OK"
        /// </summary>
        /// <param name="data"></param>
        /// <param name="expected"></param>
        /// <returns>true</returns>
        [Theory]
        [MemberData(nameof(GetDataForFlatten))]
        public async Task Flatten_DifferentData_SameExpected(List<List<string>> data, string expected)
        {

            var client = this.GetNewClient();
            var content = CreateCsvContentForTest(data);
            var response = await client.PostAsync("/api/Main/Flatten", content);
            response.EnsureSuccessStatusCode();
            var statusCode = response.StatusCode.ToString();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<string>(stringResponse);

            Assert.Equal("OK", statusCode);
            Assert.Equal(result, expected);
        }
        private static IEnumerable<object[]> GetDataForFlatten()
        {
            return new List<object[]>
            {
                new object[] {CsvDataForTest1,"1"},
                new object[] {CsvDataForTest2,"1,2,3,4"},
                new object[] {CsvDataForTest3, "1,2,3,4,5,6,7,8,9" }
            };
        }



        /// <summary>
        /// Check Sum
        /// Result == Expected
        /// Check StatusCode = "OK"
        /// </summary>
        /// <param name="data"></param>
        /// <param name="expected"></param>
        /// <returns>true</returns>
        [Theory]
        [MemberData(nameof(GetDataForSum))]
        public async Task Sum_DifferentData_SameExpected(List<List<string>> data, long expected)
        {

            var client = this.GetNewClient();
            var content = CreateCsvContentForTest(data);
            var response = await client.PostAsync("/api/Main/Sum", content);
            response.EnsureSuccessStatusCode();
            var statusCode = response.StatusCode.ToString();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<long>(stringResponse);

            Assert.Equal("OK", statusCode);
            Assert.Equal(result, expected);
        }
        private static IEnumerable<object[]> GetDataForSum()
        {
            return new List<object[]>
            {
                new object[] {CsvDataForTest1,1},
                new object[] {CsvDataForTest2,10},
                new object[] {CsvDataForTest3, 45 }
            };
        }


        /// <summary>
        /// Check Multiply
        /// Result == Expected
        /// Check StatusCode = "OK"
        /// </summary>
        /// <param name="data"></param>
        /// <param name="expected"></param>
        /// <returns>true</returns>
        [Theory]
        [MemberData(nameof(GetDataForMultiply))]
        public async Task Multiply_DifferentData_SameExpected(List<List<string>> data, long expected)
        {

            var client = this.GetNewClient();
            var content = CreateCsvContentForTest(data);
            var response = await client.PostAsync("/api/Main/Multiply", content);
            response.EnsureSuccessStatusCode();
            var statusCode = response.StatusCode.ToString();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<long>(stringResponse);

            Assert.Equal("OK", statusCode);
            Assert.Equal(result, expected);
        }
        private static IEnumerable<object[]> GetDataForMultiply()
        {
            return new List<object[]>
            {
                new object[] {CsvDataForTest1,1},
                new object[] {CsvDataForTest2,24},
                new object[] {CsvDataForTest3, 362880 }
            };
        }


        /// <summary>
        /// Check For Worng Data that is not Square
        /// error == Expected
        /// </summary>
        [Fact]
        public async Task Echo_WrongData_GetErrorNotSquare()
        {

            var client = this.GetNewClient();
            var content = CreateCsvContentForTest(new List<List<string>> { new List<string> { "1", "2" } });
            var response = await client.PostAsync("/api/Main/Echo", content);
            var statusCode = response.StatusCode.ToString();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<string>(stringResponse);
            
            Assert.Equal("BadRequest", statusCode);
            Assert.Equal("error The file is not square", result);
        }


        private MultipartFormDataContent CreateCsvContentForTest(List<List<string>> rows)
        {
            byte[] result;
            MemoryStream stream = new MemoryStream();
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                for (int row = 0; row < rows.Count; row++)
                {
                    for (int col = 0; col < rows[row].Count; col++)
                    {
                        writer.Write(rows[row][col]);

                        if (col < rows[row].Count - 1)
                            writer.Write(",");
                    }

                    // Add a new line after each row
                    writer.WriteLine();
                }
            }
            result = stream.ToArray();

            var content = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(result);
            content.Add(fileContent, "file", "matrix.csv");
            return content;
        }

    }
}
