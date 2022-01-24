using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace day29practce
{
   public abstract class censusAdapter
    {
        protected string[] GetCensusData(string csvFilePath,string dataHeaders)
        {
            string[] censusData;
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.File_Not_Found);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.Invalid_File_Type);
            }
            censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect Header In Data ", CensusAnalyserException.ExceptionType.Incorrect_Header);
            }
            return censusData;
        }
    }
}
