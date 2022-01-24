using System;
using System.Collections.Generic;
using System.Text;
using day29practce.POCO;
using Newtonsoft.Json;

namespace day29practce
{
   public class CensusAnalyser
    {
        public enum Country
        {
            India,Us,Brazil
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country,string csvFilePath,string dataHeaders)
        {
            dataMap = new CsvAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
