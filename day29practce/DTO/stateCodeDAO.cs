﻿using System;
using System.Collections.Generic;
using System.Text;

namespace day29practce.POCO
{
   public  class stateCodeDAO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;
        public stateCodeDAO(string v1,string v2,string v3,string v4)
        {
            this.serialNumber = Convert.ToInt32(v1);
            this.stateName = v2;
            this.tin = Convert.ToInt32(v3);
            this.stateCode = v4;
        }
    }
}
