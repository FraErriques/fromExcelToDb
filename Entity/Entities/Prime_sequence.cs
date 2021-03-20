﻿using System;
using System.Collections.Generic;
using System.Text;



namespace Entity.Entities
{


    ///
    // An Entity class is a mirror af a Sql-Relational-Db table. The class data fields match the columns of
    // the record-layout of the table.
    // An instance of an Entity class represents a single row, and is to be considered a scalar record.
    // To manage an array of them, there's an appropriate class, generally called InsertionManager, which loops on rows
    // and instantiates the matching Entity for each row.
    public class Prime_sequence
    {
        // original db record layout.
        private Int64 ordinal;    // [ordinal] [bigint] IDENTITY(1,1) NOT NULL,
        private Int64 prime;      // [prime] [bigint] NOT NULL,
        //
        private Int64 min, max;
        // generic P[i] element.
        public struct SelectedCouple
        {
            public Int64 Prime;
            public Int64 atOrdinal;
        }//


        public Int64 getCurrentOrdinal()
        {
            return this.ordinal;
        }


        public Int64 getCurrentPrime()
        {
            return this.prime;
        }




        public Prime_sequence( )
        {
        }//



        public Prime_sequence(
            Int64 requiredordinal
          )
        {
            this.ordinal = requiredordinal;
        }//




        public Prime_sequence(
            Int64 rangeMin,
            Int64 rangeMax
          )
        {
            this.min = rangeMin;
            this.max = rangeMax;
        }//




        public Int64 GetActualOrdinal()
        {
            System.Data.DataTable lastCouple =
                Entity.Proxies.volatile_Prime_sequence_LOAD_atMaxOrdinal_SERVICE.volatile_Prime_sequence_LOAD_atMaxOrdinal();
            try
            {
                this.prime = (Int64)(lastCouple.Rows[0]["prime"]);
                this.ordinal = (Int64)(lastCouple.Rows[0]["ordinal"]);
            }
            catch (System.Exception ex)
            {
                LogSinkFs.Wrappers.LogWrappers.SectionContent("failed trying to connect to db. Ex=" + ex.Message,0);
            }
            //
            return this.ordinal;
        }//


        public void dbSeekingEngine( Int64 specifiedOrdinal)
        {
            System.Data.DataTable specifiedCouple =
            Entity.Proxies.volatile_Prime_sequence_LOAD_SINGLE_SERVICE.volatile_Prime_sequence_LOAD_SINGLE(
                specifiedOrdinal );
            //
            this.prime = (Int64)(specifiedCouple.Rows[0]["prime"]);
            this.ordinal = (Int64)(specifiedCouple.Rows[0]["ordinal"]);
        }//



        /// <summary>
        /// NB. to use this method, instantiate by the ctor
        /// 
        ///  public Prime_sequence(
        ///    Int64 rangeMin,
        ///    Int64 rangeMax       )
        /// 
        /// </summary>
        /// <returns></returns>
        public SelectedCouple[] LoadRange(
          )
        {
            SelectedCouple[] theRange = null;
            System.Data.DataTable theSequence =
                Entity.Proxies.volatile_Prime_sequence_LOAD_MULTI_SERVICE.volatile_Prime_sequence_LOAD_MULTI(
                    min, max);
            if (null == theSequence)
            {
                theRange = new SelectedCouple[0];
                return theRange;
            }
            else
            {
                int theSequence_Rows_Count = theSequence.Rows.Count;
                theRange = new SelectedCouple[ theSequence_Rows_Count];
                for (int c = 0; c < theSequence_Rows_Count; c++)
                {
                    theRange[c].Prime = (Int64)(theSequence.Rows[c]["prime"]);
                    theRange[c].atOrdinal = (Int64)(theSequence.Rows[c]["ordinal"]);
                }
            }
            // ready
            return theRange;
        }//


    }//


}
