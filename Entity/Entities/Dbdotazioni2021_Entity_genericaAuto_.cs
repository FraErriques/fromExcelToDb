using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{

    /// <summary>
    /// scalar Record of the table [dotazioni2021].[genericaAuto]
    /// The Record-Array will be built by the appropriate insertionManager, by means of Entity::Parser::TxtFileParser.
    /// In this table [dotazioni2021].[genericaAuto] the column [Vettura] assumes crucial role, to distinguish a car from another.
    /// The idea is to use the common record layout, for registering the data from all of the cars, by means of a single Entity.
    /// This way there's no need of a function pointer, to select the appropriate Proxy; there's only one, on a single table.
    /// </summary>
    public class Dbdotazioni2021_Entity_genericaAuto_
    {
        // data (original from db)
        //[id] [int] IDENTITY(1,1) NOT NULL,
        //[Vettura] [varchar](30) NULL,
        //[data] [date] NULL,
        //[km] [int] NULL,
        //[intervento] [varchar](330) NULL,
        //[litri] [float] NULL,
        //[euro] [float] NULL,
        //[gasolio_euro/litro] [float] NULL,
        // 
        // data, in application layer.
        private int         id; // [int] IDENTITY(1,1) NOT NULL,
        private string      Vettura;// [varchar](30) NULL,
        private DateTime    data;// [date] NULL,
        private int         km;// [int] NULL,
        private string      intervento;// [varchar](330) NULL,
        private double      litri;// [float] NULL, NB. db_float==application_double, where instead db_single==application_float. NB.
        private double      euro;// [float] NULL,
        private double      gasolio_euro_litro;// [float] NULL, NB. in db_column_name it's gasolio_euro/litro; the slash has been replaced with underscore.

       // readonly-only wrapeprs
        public int get_id()
        {
            return this.id;
        }// readonly-only wrapeprs
        public string get_Vettura()
        {
            return this.Vettura;
        }// readonly-only wrapeprs
        public DateTime get_data()
        {
            return this.data;
        }// readonly-only wrapeprs
        public int get_km()
        {
            return this.km;
        }// readonly-only wrapeprs
        public string get_intervento()
        {
            return this.intervento;
        }// readonly-only wrapeprs
        public double get_litri()
        {
            return this.litri;
        }// readonly-only wrapeprs
        public double get_euro()
        {
            return this.euro;
        }// readonly-only wrapeprs
        public double get_gasolio_euro_litro()
        {
            return this.gasolio_euro_litro;
        }// readonly-only wrapeprs

        /// <summary>
        /// Ctor
        /// takes a string[] and builds the instance of a single row of the file( and of the table, which is the same).
        /// Fields are private and readOnly visible and originate from a apecific filtering: Excel-cells set to "NULL" get to be a DbNull.
        /// </summary>
        public Dbdotazioni2021_Entity_genericaAuto_( string[] aSingleTxtFileRow )
        {
            if (7 > aSingleTxtFileRow.Length)// Excel may add empty columns.
            {// but with genericAuto there meight also be empty rows, between one car and the other.
                this.Vettura = "";
                this.data = DateTime.Today;
                this.km = 0;
                this.intervento = "RIGA SEPARATRICE";
                this.litri = 0.0;
                this.euro = 0.0;
                this.gasolio_euro_litro = 0.0;
            }// else continue.
            else// we have a regular row.
            {
                // this.id = ; // [int] IDENTITY no [id] in the txtFile: it will be generated as a db-identity. #######
                this.Vettura = Entity.Parser.FieldParser.stringFieldFilter(aSingleTxtFileRow[0]);
                this.data = Entity.Parser.FieldParser.dateFieldFilter(aSingleTxtFileRow[1]);
                this.km = Entity.Parser.FieldParser.intFieldFilter(aSingleTxtFileRow[2]);
                this.intervento = Entity.Parser.FieldParser.stringFieldFilter(aSingleTxtFileRow[3]);
                this.litri = Entity.Parser.FieldParser.doubleFieldFilter(aSingleTxtFileRow[4]);
                this.euro = Entity.Parser.FieldParser.doubleFieldFilter(aSingleTxtFileRow[5]);
                this.gasolio_euro_litro = Entity.Parser.FieldParser.doubleFieldFilter(aSingleTxtFileRow[6]);
            }
            // anyway set the [id];
            this.id = -1;// only for the sake of not having a warning; [id] is a db-identity and is not available before insert.
        }// Ctor


    }// class
}// nmsp
