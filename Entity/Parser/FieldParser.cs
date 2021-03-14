using System;
using System.Collections.Generic;
using System.Text;


namespace Entity.Parser
{

    
    public static class FieldParser
    {
        public struct Recognizer
        {//----################## just in case of need, where the first field is a "variant" one and the second works as a flag, to signal the need for a DbNull.
            public object the_field;
            public string hasValidContent;
        }// struct


        public static string stringFieldFilter( string fromExcel )
        {
            if (fromExcel.Trim().ToUpper() == "NULL")
                return null;// convert the Excel-empy-cell to DbNull
            else
                return fromExcel;
        }// stringFieldFilter

        /// <summary>
        /// NB. usare la convenzione SQL yyyy-mm--dd
        /// es. 2021-03-12 == 2021-marzo-12
        /// </summary>
        /// <param name="fromExcel"></param>
        /// <returns></returns>
        public static DateTime dateFieldFilter( string fromExcel )
        {
            DateTime res = new System.DateTime();
            bool hasToExit = false;
            if( null == fromExcel)
            {
                res = default(DateTime);// convert the Excel-empy-cell to default(DateTime)==0001-01-01
                hasToExit = true;
            }
            else if ("" == fromExcel.Trim().ToUpper())
            {
                res = default(DateTime);// convert the Excel-empy-cell to default(DateTime)==0001-01-01
                hasToExit = true;
            }
            else if("NULL"  == fromExcel.Trim().ToUpper()) 
            {
                res = default(DateTime);// convert the Excel-empy-cell to default(DateTime)==0001-01-01
                hasToExit = true;
            }
            //else continue.
            if (!hasToExit)
            {
                try
                {
                    string[] fromDataFile = fromExcel.Split(new char[] { '-', '.', '#', '_', '/', '\\' }, StringSplitOptions.None);// Do not remove empty entries.
                    if (3 != fromDataFile.Length)
                    {
                        throw new System.Exception("Parsing error on a date-field.");
                    }
                    else
                    {
                        int firstTokenLength = fromDataFile[0].Length;
                        int thirdTokenLength = fromDataFile[2].Length;
                        int yearTokenPosition;
                        int dayTokenPosition;
                        if (firstTokenLength > thirdTokenLength)
                        {// can be yyyy-mm-dd xor dd-mm-yyyy
                            yearTokenPosition = 0;
                            dayTokenPosition = 2;
                        }
                        else
                        {// month position is always [1] i.e. in the middle.
                            yearTokenPosition = 2;
                            dayTokenPosition = 0;
                        }
                        res = new DateTime(
                                            int.Parse(fromDataFile[yearTokenPosition]) // dd xor yyyy
                                        , int.Parse(fromDataFile[1]) //   mm
                                        , int.Parse(fromDataFile[dayTokenPosition]) // yyyy xor dd NB. order is reversed from C# to Sql.
                                        );
                    }
                }
                catch (System.Exception ex)
                {// something wen wrong, parsing the Excel-date. So go for DbNull.
                    string dbg = ex.Message;
                    res = default(DateTime);// convert the Excel-empy-cell to default(DateTime)==0001-01-01
                }
            }// end if (!hasToExit)
            // else exit now.
            return res;
        }// dateFieldFilter


        /// <summary>
        /// NB. the convention here adopted is: Double.NaN as invalidity-flag -> DbNull.
        /// </summary>
        /// <param name="fromExcel"></param>
        /// <returns></returns>
        public static double doubleFieldFilter( string fromExcel )
        {
            double res;//the try-catch block, devoted to Double.Parse(), will decide and init.
            try
            {
                res = Double.Parse(fromExcel);// throws
            }
            catch (System.Exception ex)
            {// something wen wrong, parsing the Excel-floating point rational. So go for DbNull.
                string dbg = ex.Message;
                res = Double.NaN;// init to invalid.
            }
            return res;// initialized in the try-catch block, devoted to Double.Parse().
        }// doubleFieldFilter


        /// <summary>
        /// NB. the convention here adopted is: Int64.MinValue as invalidity-flag -> DbNull.
        /// </summary>
        /// <param name="fromExcel"></param>
        /// <returns></returns>
        public static Int64 intFieldFilter( string fromExcel )
        {
            Int64 res;//the try-catch block, devoted to Int.Parse(), will decide and init.
            try
            {
                res = Int64.Parse( fromExcel);// throws
            }
            catch (System.Exception ex)
            {// something wen wrong, parsing the Excel-floating point rational. So go for DbNull.
                string dbg = ex.Message;
                res = Int64.MinValue;// init to invalid.
            }
            return res;// initialized in the try-catch block, devoted to Int.Parse().
        }// intFieldFilter





    }// class

}// nmsp
