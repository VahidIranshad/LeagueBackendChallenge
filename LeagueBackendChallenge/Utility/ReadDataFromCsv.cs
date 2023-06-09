﻿using DataAccess;
using LeagueBackendChallenge.Contract;

namespace LeagueBackendChallenge.Utility
{
    public class ReadDataFromCsv : IReadDataFromFile
    {
        /// <summary>
        /// an async methode because there would be a solution to read async data
        /// this methode read data from the file 
        /// </summary>
        /// <param name="file"></param>
        /// <returns>List of String</returns>
        public async Task<List<List<string>>> GetDataFromFile(IFormFile file)
        {
            List<List<string>> result = new();
            List<Row> rows;
            try
            {
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    rows = DataTable.New.ReadLazy(streamReader.BaseStream, new string[1]).Rows.ToList();
                }
                foreach (var row in rows)
                {
                    if (row.Values.Count != rows.Count)
                    {
                        throw new Exception("The file is not square");
                    }
                    result.Add(row.Values.ToList());
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }

            return result;
        }


        /// <summary>
        /// an async methode because there would be a solution to read async data
        /// this methode read data from the file 
        /// </summary>
        /// <param name="file"></param>
        /// <returns>List of number</returns>
        public async Task<List<List<long>>> GetNumbersFromFile(IFormFile file)
        {
            List<List<long>> result = new();
            List<Row> rows;
            try
            {
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    rows = DataTable.New.ReadLazy(streamReader.BaseStream, new string[1]).Rows.ToList();
                }
                foreach (var row in rows)
                {
                    if (row.Values.Count != rows.Count)
                    {
                        throw new Exception("The file is not square");
                    }
                    List<long> numbers = new List<long>();
                    foreach (var value in row.Values)
                    {
                        long val;
                        if (long.TryParse(value, out val))
                        {
                            numbers.Add(val);
                        }
                        else
                        {
                            throw new Exception("The format of some data is not correct");
                        }
                        
                    }
                    result.Add(numbers);
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }

            return result;
        }
    }
}
