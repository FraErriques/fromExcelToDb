using System;
using System.Collections.Generic;
using System.Text;


namespace Entity.InsertionManager
{


    public class Dbdotazioni2021_InsertionManager_genericaAuto_
    {
        // data
        private string[] allRows = null;
        private string[] curRowSplitted = null;
        Entity.Parser.TxtFileParser txtParser = null;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="fullPath"></param>
        public Dbdotazioni2021_InsertionManager_genericaAuto_( string fullPath )
        {
            // then get the parsed rows.
            this.txtParser = new Entity.Parser.TxtFileParser(fullPath);// the tableName_insertionManager needs an instance of the TxtFileParser, to perform the row-splitting in columns.
            this.allRows = txtParser.get_allRows();// now the class has been Constructed, via TxtFileParser. The insertion will happen via Entity.Entities.SIM_insertionManager_, which calls
            // Entity.Entities.TxtFileParser txtParser.rowSplitter i.e. Entity::Entities::TxtFileParser::rowSplitter
        }// Ctor

        /// <summary>
        /// Dtor
        /// </summary>
        ~Dbdotazioni2021_InsertionManager_genericaAuto_()
        {
            this.allRows = null;// proncipale gc action.
            this.curRowSplitted = null;
        }// Dtor


        /// <summary>
        /// a record layout comprehension test, without db-insertion.
        /// </summary>
        /// <returns> #(splitted rows).</returns>
        public int splitterTest()
        {// just a test for the splitter, without db-insertion.
            int d = 0;// #(splitted rows).
            for (; null != this.allRows[d]; d++)
            {
                this.curRowSplitted = this.txtParser.rowSplitter(this.allRows[d]);// get all columns of a single row, by means of this.rowSplitter(
                //this.curRowSplitted = null; on dbg it's easier to visualize data in the debugger, qithout gc.
            }// for
            return d;//  #Read_rows
        }// splitterTest(


        public int insertionManager()
        {//
            int cardInsertedRows = 0;//  #insertedRows
            int insertionResultOnCurRow = -1;
            System.Data.SqlClient.SqlTransaction bulk_SIM_trx = null;// trx
            //
            if (null != this.allRows)
            {// open transaction
                //<DbConnections>
                //   <strings>
                //     <add key="kkkey_key"   value="0"/>
                //     <add key="vkkey_key"   value="0"/>
                //     <add key="Tim2021"   value="Database=dotazioni2021;Server=ITBZOW1422\SqlExpress;user=sa;pwd=M1 Sxpdx;"/>
                //   </strings>
                bulk_SIM_trx =//---################### NB. customize the transaction ###################################
                    Common.Connection.TransactionManager.trxOpener("DbConnections/strings", "dotazioni2021");
            }
            else return cardInsertedRows;//  #insertedRows
            for (int d = 0; null != this.allRows[d]; d++)
            {
                this.curRowSplitted = this.txtParser.rowSplitter(this.allRows[d]);// get all columns of a single row, by means of this.rowSplitter(
                Entity.Entities.Dbdotazioni2021_Entity_genericaAuto_ currentRow = new Entities.Dbdotazioni2021_Entity_genericaAuto_( this.curRowSplitted);
                // NB. currentRow private fields, with public readers.-------##################################################
                insertionResultOnCurRow =
                    Entity.Proxies.usp_genericaAuto_INSERT_SERVICE.usp_genericaAuto_INSERT(
                        // id identity
                        currentRow.get_Vettura()
                        ,currentRow.get_data()
                        ,currentRow.get_km()
                        ,currentRow.get_intervento()
                        ,currentRow.get_litri()
                        ,currentRow.get_euro()
                        ,currentRow.get_gasolio_euro_litro()
                        , bulk_SIM_trx//----########################################## transaction ####################################################
                      );
                if (0 == insertionResultOnCurRow)// retval==0 means Proxy has succeeded in insert.
                {
                    cardInsertedRows++;// another row inserted correctly.
                } // else skip 
                this.curRowSplitted = null;// gc
            }// for
            Common.Connection.TransactionManager.trxCloser(bulk_SIM_trx, true);// Commit
            // ready.
            return cardInsertedRows;//  #Inserted_rows
        }// insertionManager(


    }// class
}// nmsp
