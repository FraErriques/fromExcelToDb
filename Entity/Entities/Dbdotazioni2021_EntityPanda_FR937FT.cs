using System;
using System.Collections.Generic;
using System.Text;


namespace Entity.Entities
{
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
	    int id; // [int] IDENTITY(1,1) NOT NULL,
	    string Vettura;// [varchar](30) NULL,
	    DateTime data;// [date] NULL,
	    int km;// [int] NULL,
	    string intervento;// [varchar](330) NULL,
	    double litri;// [float] NULL, NB. db_float==application_double, where instead db_single==application_float. NB.
	    double euro;// [float] NULL,
        double gasolio_euro_litro;// [float] NULL, NB. in db_column_name it's gasolio_euro/litro; the slash has been replaced with underscore.


    }// class
}// nmsp
