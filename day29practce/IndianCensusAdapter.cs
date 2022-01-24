﻿using day29practce.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace day29practce
{ 
   public class IndianCensusAdapter : censusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.Incorrect_Delimiter);
                }
                string[] column = data.Split(",");
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    dataMap.Add(column[1], new CensusDTO(new stateCodeDAO(column[0], column[1], column[2], column[3])));
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    dataMap.Add(column[0], new CensusDTO(new censusDataDAO(column[0], column[1], column[2], column[3])));
            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
