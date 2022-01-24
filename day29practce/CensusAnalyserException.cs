using System;
using System.Collections.Generic;
using System.Text;

namespace day29practce
{
   public class CensusAnalyserException : Exception
    {
        public enum ExceptionType
        {
            File_Not_Found,Invalid_File_Type,Incorrect_Delimiter, Incorrect_Header,No_Such_Country
        }
        public ExceptionType eType;
        public CensusAnalyserException(string message,ExceptionType exceptionType) : base(message)
        {
            this.eType = exceptionType;
        }
    }
}
