using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    class prova456_recordLayout_
    {
        // data in db
        //CREATE TABLE [dbo].[prova456](
        //    [id] [int] IDENTITY(1,1) NOT NULL,
        //    [un_razionale] [float] NULL,
        //    [un_intero] [int] NULL,
        //    [una_data_senzaOra] [date] NULL,
        // CONSTRAINT [pk_dbTim2021_table_prova456] PRIMARY KEY CLUSTERED 
        //(
        //    [id] ASC
        //)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
        //) ON [PRIMARY] -- NB. when no string or text columns are in the record-layout, there's no involvment of TEXTIMAGE.
        // replicated data, in application layer code.
        //    [id] [int] IDENTITY(1,1) NOT NULL, ----- Identity not available before insertion-----------------
        private double un_razionale;         //    [un_razionale] [float] NULL,
        private Int64 un_intero;             //    [un_intero] [int] NULL,
        private DateTime una_data_senzaOra;  //  [una_data_senzaOra] [date] NULL,

        // readonly-only wrapeprs
        public double get_un_razionale()
        {
            return this.un_razionale;
        }// readonly-only wrapeprs
        public Int64 get_un_intero()
        {
            return this.un_intero;
        }// readonly-only wrapeprs
        public DateTime get_una_data_senzaOra()
        {
            return this.una_data_senzaOra;
        }// readonly-only wrapeprs


        /// <summary>
        /// Ctor
        /// takes a string[] and builds the instance of a single row of the file( and of the table, which is the same).
        /// Fields are private and readOnly visible and originate from a apecific filtering: Excel-cells set to "NULL" get to be a DbNull.
        /// </summary>
        public prova456_recordLayout_( string[] aSingleTxtFileRow )
        {
            if( 3 != aSingleTxtFileRow.Length)//---####### NB. there is intentionally a skipped field.
            {
                throw new System.Exception("Invalid record layout.");
            }// else continue.
            this.un_razionale = Entity.Parser.FieldParser.doubleFieldFilter( aSingleTxtFileRow[0]);
            this.un_intero = Entity.Parser.FieldParser.intFieldFilter( aSingleTxtFileRow[1]);
            this.una_data_senzaOra = Entity.Parser.FieldParser.dateFieldFilter( aSingleTxtFileRow[2]);
        }// Ctor

  
    }// class

}// nmsp
