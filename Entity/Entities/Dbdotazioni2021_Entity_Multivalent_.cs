using System;
using System.Collections.Generic;
using System.Text;


namespace Entity.Entities
{

    /// <summary>
    /// This Entity is valid for: {cellPhone, PC, accessori} in db dotazioni2021.
    /// NB. do not put an unique key on matricola or on any other field that might be NULL. Sql allows
    /// only one row with NULL, since the unique stops the other. Only on NOT_NULL columns is usable a 
    /// unique key.
    /// </summary>
    public class Dbdotazioni2021_Entity_Multivalent_
    {
        // data
        //USE [dotazioni2021]
        //CREATE TABLE [dbo].[accessori](
        //    [id] [int] IDENTITY(1,1) NOT NULL,
        //    [beneficiario] [varchar](150) NULL,
        //    [oggetto] [varchar](350) NULL,
        //    [matricola] [varchar](200) NULL,
        //    [note] [text] NULL,
        //
        private const int cardActiveFields = 4;// all of them, except the [id], which is identity.
        private int id;//    [id] [int] IDENTITY(1,1) NOT NULL, ------- identity------
        private string beneficiario;//    [beneficiario] [varchar](150) NULL,
        private string oggetto;//    [oggetto] [varchar](350) NULL,
        private string matricola;//    [matricola] [varchar](200) NULL,
        private string note;//    [note] [text] NULL,


        // readonly-only wrapeprs
        public int get_id()
        {
            return this.id;
        }// readonly-only wrapeprs
        public string get_beneficiario()
        {
            return this.beneficiario;
        }// readonly-only wrapeprs
        public string get_oggetto()
        {
            return this.oggetto;
        }// readonly-only wrapeprs
        public string get_matricola()
        {
            return this.matricola;
        }// readonly-only wrapeprs
        public string get_note()
        {
            return this.note;
        }// readonly-only wrapeprs

        //Ctor
        /// <summary>
        /// Ctor
        /// takes a string[] and builds the instance of a single row of the file( and of the table, which is the same).
        /// Fields are private and readOnly visible and originate from a apecific filtering: Excel-cells set to "NULL" get to be a DbNull.
        /// </summary>
        public Dbdotazioni2021_Entity_Multivalent_( string[] aSingleTxtFileRow )
        {
            //if (Dbdotazioni2021_Entity_Multivalent_.cardActiveFields != aSingleTxtFileRow.Length)
            //{NB. sometimes Excel puts TABs for unexisting columns, after the last. In such case: disable this check.
            //    throw new System.Exception("Invalid record layout.");
            //}// else continue.
            // this.id = ; // [int] IDENTITY no [id] in the txtFile: it will be generated as a db-identity.
            this.beneficiario = Entity.Parser.FieldParser.stringFieldFilter( aSingleTxtFileRow[0]);
            this.oggetto = Entity.Parser.FieldParser.stringFieldFilter( aSingleTxtFileRow[1]);
            this.matricola = Entity.Parser.FieldParser.stringFieldFilter( aSingleTxtFileRow[2]);
            this.note = Entity.Parser.FieldParser.stringFieldFilter( aSingleTxtFileRow[3]);
            //
            this.id = -1;// only for the sake of not having a warning; [id] is a db-identity and is not available before insert.
        }// Ctor

        //Dtor : no Dtor, in a scalar Record. The homologous Dtor is in the Vector-shaped class:InsertionManager.

    }//class
}//nmsp
