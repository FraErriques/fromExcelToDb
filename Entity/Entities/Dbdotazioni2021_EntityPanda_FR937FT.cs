﻿using System;
using System.Collections.Generic;
using System.Text;


namespace Entity.Entities
{

    /// <summary>
    /// scalar Record of the table [dotazioni2021].[EntityPanda_FR937FT]
    /// The Record-Array will be built by the appropriate insertionManager, by means of Entity::Parser::TxtFileParser.
    /// </summary>
    public class Dbdotazioni2021_EntityPanda_FR937FT
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
        public Dbdotazioni2021_EntityPanda_FR937FT( string[] aSingleTxtFileRow )
        {
            if( 7 != aSingleTxtFileRow.Length)
            {
                throw new System.Exception("Invalid record layout.");
            }// else continue.
            // this.id = ; // [int] IDENTITY no [id] in the txtFile: it will be generated as a db-identity.
            this.Vettura = Entity.Parser.FieldParser.stringFieldFilter( aSingleTxtFileRow[0]);
            this.data = Entity.Parser.FieldParser.dateFieldFilter( aSingleTxtFileRow[1]);
            this.km = Entity.Parser.FieldParser.intFieldFilter( aSingleTxtFileRow[2]);
            this.intervento = Entity.Parser.FieldParser.stringFieldFilter(aSingleTxtFileRow[3]);
            this.litri = Entity.Parser.FieldParser.doubleFieldFilter( aSingleTxtFileRow[4]);
            this.euro = Entity.Parser.FieldParser.doubleFieldFilter(aSingleTxtFileRow[5]);
            this.gasolio_euro_litro = Entity.Parser.FieldParser.doubleFieldFilter( aSingleTxtFileRow[6]);
            //
            this.id = -1;// only for the sake of not having a warning; [id] is a db-identity and is not available before insert.
        }// Ctor


    }// class
}// nmsp
