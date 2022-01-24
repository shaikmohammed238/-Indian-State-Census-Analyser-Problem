using System;
using System.Collections.Generic;
using System.Text;
using day29practce.POCO;

namespace day29practce
{
   public class CsvAdapterFactory
    {
        public Dictionary<string,CensusDTO>LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case(CensusAnalyser.Country.India):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                //case (CensusAnalyser.Country.Us):
                //    return new UsCensusAdapter().LoadUSCensusData(csvFilePath,dataHeaders); 
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.No_Such_Country);
            }
        }
    }
}
