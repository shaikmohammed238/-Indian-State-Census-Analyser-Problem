using System;
using System.Collections.Generic;
using System.Text;

namespace day29practce.POCO
{
   public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double popularDensity;
        public double housingDensity;

        public CensusDTO(stateCodeDAO stateCodeDao)
        {
            this.serialNumber = stateCodeDao.serialNumber;
            this.stateName = stateCodeDao.stateName;
            this.tin = stateCodeDao.tin;
            this.stateCode = stateCodeDao.stateCode;
        }
        public CensusDTO(censusDataDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.area = censusDataDao.area;
            this.density = censusDataDao.density;
        }
        //public CensusDTO(USCensusDao USCensusDao)
        //{
        //    this.stateCode = USCensusDao.stateCode;
        //    this.stateName = USCensusDao.stateName;
        //    this.population = USCensusDao.population;
        //    this.housingUnits = USCensusDao.housingUnits;
        //    this.totalArea = USCensusDao.totalArea;
        //    this.waterArea = USCensusDao.waterArea;
        //    this.landArea = USCensusDao.landArea;
        //    this.popularDensity = USCensusDao.popularDensity;
        //    this.housingDensity = USCensusDao.housingDensity;
        //}
    }
}
