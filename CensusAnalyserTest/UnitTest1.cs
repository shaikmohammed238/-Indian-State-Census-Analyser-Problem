using day29practce;
using day29practce.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using static day29practce.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\SHAIK\Desktop\practice\day29practce\CensusAnalyserTest\CsvFiles\IndiaStateCensusData (1).csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\SHAIK\Desktop\practice\day29practce\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData (1).csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\SHAIK\Desktop\practice\day29practce\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\My Laptop\Desktop\BrProjects\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\SHAIK\Desktop\practice\day29practce\CensusAnalyserTest\CsvFiles\IndianStateCensus.txt";
        static string indianStateCodeFilePath = @"C:\Users\SHAIK\Desktop\practice\day29practce\CensusAnalyserTest\CsvFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\SHAIK\Desktop\practice\day29practce\CensusAnalyserTest\CsvFiles\WrongTypeIndiaStateCodes.txt";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\SHAIK\Desktop\practice\day29practce\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\SHAIK\Desktop\practice\day29practce\CensusAnalyserTest\CsvFiles\WrongIndiaStateCode.csv";

        day29practce.CensusAnalyser CensusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            CensusAnalyser = new day29practce.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = CensusAnalyser.LoadCensusData(Country.India, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = CensusAnalyser.LoadCensusData(Country.India, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => CensusAnalyser.LoadCensusData(Country.India, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => CensusAnalyser.LoadCensusData(Country.India, wrongIndianStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.File_Not_Found, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.File_Not_Found, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => CensusAnalyser.LoadCensusData(Country.India, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => CensusAnalyser.LoadCensusData(Country.India, wrongIndianStateCensusFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Invalid_File_Type, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Invalid_File_Type, stateException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenDelimiterNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => CensusAnalyser.LoadCensusData(Country.India, delimiterIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => CensusAnalyser.LoadCensusData(Country.India, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Incorrect_Delimiter, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Incorrect_Delimiter, stateException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => CensusAnalyser.LoadCensusData(Country.India, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => CensusAnalyser.LoadCensusData(Country.India, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Incorrect_Header, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Incorrect_Header, stateException.eType);
        }

    }

}