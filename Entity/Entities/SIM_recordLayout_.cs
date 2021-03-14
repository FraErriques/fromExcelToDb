using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{

    public class SIM_recordLayout_
    {
        // data in db
        //CREATE TABLE [dbo].[SIM_BBT](
        //    [id] [int] IDENTITY(1,1) NOT NULL,
        //    [beneficiario] [varchar](150) NULL,
        //    [servizio] [varchar](150) NULL,
        //    [numero] [varchar](30) NULL,
        //    [PIN] [varchar](4) NULL,
        //    [PUK] [varchar](8) NULL,
        //    [ICCID] [varchar](150) NULL,
        //    [registrazione] [datetime] NULL,
        //    [note] [text] NULL,
        // CONSTRAINT [pk_SIM] PRIMARY KEY CLUSTERED 
        //(
        //    [id] ASC
        //)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
        //) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
        //
        // replicated data, in application layer code.
        //    [id] [int] IDENTITY(1,1) NOT NULL, ----- Identity not available before insertion-----------------
        private string beneficiario;    //    [beneficiario] [varchar](150) NULL,
        private string servizio;        //    [servizio] [varchar](150) NULL,
        private string numero;          //     [numero] [varchar](30) NULL,
        private string PIN;             //     [PIN] [varchar](4) NULL,
        private string PUK;             //     [PUK] [varchar](8) NULL,
        private string ICCID;           //     [ICCID] [varchar](150) NULL,
        private DateTime registrazione; //   [registrazione] [datetime] NULL,  meglio [date] 
        private string note;            //    [note] [text] NULL,

        // readonly-only wrapeprs
        public string get_beneficiario()
        {
            return this.beneficiario;
        }// readonly-only wrapeprs
        public string get_servizio()
        {
            return this.servizio;
        }// readonly-only wrapeprs
        public string get_numero()
        {
            return this.numero;
        }// readonly-only wrapeprs
        public string get_PIN()
        {
            return this.PIN;
        }// readonly-only wrapeprs
        public string get_PUK()
        {
            return this.PUK;
        }// readonly-only wrapeprs
        public string get_ICCID()
        {
            return this.ICCID;
        }// readonly-only wrapeprs
        public DateTime get_registrazione()//---NB. Date------
        {
            return this.registrazione;
        }// readonly-only wrapeprs
        public string get_note()
        {
            return this.note;
        }// readonly-only wrapeprs

        /// <summary>
        /// Ctor
        /// takes a string[] and builds the instance of a single row of the file( and of the table, which is the same).
        /// Fields are private and readOnly visible and originate from a apecific filtering: Excel-cells set to "NULL" get to be a DbNull.
        /// </summary>
        public SIM_recordLayout_( string[] aSingleTxtFileRow)
        {
            if( 8 != aSingleTxtFileRow.Length)
            {
                throw new System.Exception("Invalid record layout.");
            }// else continue.
            this.beneficiario = Entity.Parser.FieldParser.stringFieldFilter( aSingleTxtFileRow[0]);
            this.servizio = Entity.Parser.FieldParser.stringFieldFilter( aSingleTxtFileRow[1]);
            this.numero = Entity.Parser.FieldParser.stringFieldFilter( aSingleTxtFileRow[2]);
            this.PIN = Entity.Parser.FieldParser.stringFieldFilter( aSingleTxtFileRow[3]);
            this.PUK = Entity.Parser.FieldParser.stringFieldFilter( aSingleTxtFileRow[4]);
            this.ICCID = Entity.Parser.FieldParser.stringFieldFilter( aSingleTxtFileRow[5]);
            this.registrazione = Entity.Parser.FieldParser.dateFieldFilter( aSingleTxtFileRow[6]);//---NB. Date------
            this.note = Entity.Parser.FieldParser.stringFieldFilter(aSingleTxtFileRow[7]);
        }// Ctor

  
    }// class

}// nmsp
