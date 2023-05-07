using LeagueBackendChallenge.Contract;
using Microsoft.AspNetCore.Mvc;

namespace LeagueBackendChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MainController : Controller
    {
        private readonly IReadDataFromFile _readDataFromFile;
        public MainController(IReadDataFromFile readDataFromFile)
        {
            _readDataFromFile = readDataFromFile;
        }


        /// <summary>
        /// Get Data From File
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost("Echo")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> Echo(IFormFile file)
        {
            try
            {
                var result = string.Empty;
                var rows = await _readDataFromFile.GetDataFromFile(file);
                foreach (var row in rows)
                {
                    result = string.Format("{0}{1}\n", result, string.Join(",", row));
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"error {ex.Message}");
            }
        }

        /// <summary>
        /// Get Invert Data From File
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost("Invert")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> Invert(IFormFile file)
        {
            try
            {
                var rows = await _readDataFromFile.GetDataFromFile(file);
                var result = string.Empty;
                for (int i = 0; i < rows.Count; i++)
                {
                    for (int j = 0; j < rows[i].Count; j++)
                    {
                        //for last column of each line we do not need "," 
                        result += rows[j][i].ToString() + (j == rows.Count - 1 ? "" : ",");
                    }
                    result += "\n";
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"error {ex.Message}");
            }
        }

        /// <summary>
        /// Get Flat Data From File
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost("Flatten")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> Flatten(IFormFile file)
        {
            try
            {
                var rows = await _readDataFromFile.GetDataFromFile(file);
                var result = string.Empty;
                for (int i = 0; i < rows.Count; i++)
                {
                    var row = rows[i];
                    var format = "{0}{1},";

                    //for last row we do not need a "," for the end
                    if (i == rows.Count - 1)
                    {
                        format = "{0}{1}";
                    }
                    result = string.Format(format, result, string.Join(",", row));
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"error {ex.Message}");
            }
        }

        /// <summary>
        /// Get Sum Data From File
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost("Sum")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<long>> Sum(IFormFile file)
        {
            try
            {
                var rows = await _readDataFromFile.GetDataFromFile(file);
                long result = 0;
                foreach (var row in rows)
                {
                    result += row.Select(p => Convert.ToInt64(p)).Sum();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"error {ex.Message}");
            }
        }

        /// <summary>
        /// Get Multiply Data From File
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost("Multiply")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<long>> Multiply(IFormFile file)
        {
            try
            {
                var rows = await _readDataFromFile.GetDataFromFile(file);
                //First value must be set by one
                long result = 1;
                foreach (var row in rows)
                {
                    foreach (var value in row)
                    {
                        result *= Convert.ToInt64(value);
                    }
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"error {ex.Message}");
            }
        }


    }

}

