using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.InsertionManager
{


    public class prova456_insertionManager_
    {
        // data
        private string[] allRows = null;
        private string[] curRowSplitted = null;
        Entity.Parser.TxtFileParser txtParser = null;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="inWhichTable"></param>
        public prova456_insertionManager_( string fullPath )
        {
            // get the parsed rows.
            this.txtParser = new Entity.Parser.TxtFileParser( fullPath);// the tableName_insertionManager needs an instance of the TxtFileParser, to perform the row-splitting in columns.
            this.allRows = txtParser.get_allRows();// now the class has been Constructed, via TxtFileParser. The insertion will happen via Entity.Entities.tableName_insertionManager_, which calls
            // Entity.Entities.TxtFileParser txtParser.rowSplitter i.e. Entity::Entities::TxtFileParser::rowSplitter
        }// Ctor


        /// <summary>
        /// Dtor
        /// </summary>
        ~prova456_insertionManager_()
        {
            this.curRowSplitted = null;
        }// Dtor


        public int splitterTest()
        {// just a test for the splitter, without db-insertion.
            int cardInsertedRows = 0;//  #insertedRows
            int d = 0;
            for (; null != this.allRows[d]; d++)
            {
                this.curRowSplitted = this.txtParser.rowSplitter(this.allRows[d]);// get all columns of a single row, by means of this.rowSplitter(
                //this.curRowSplitted = null; on dbg 
            }// for
            return cardInsertedRows;//  #Inserted_rows
        }// splitterTest(


        public int insertionManager()
        {// TODO insert into originale TIM : parametrize for both.           
            int cardInsertedRows = 0;//  #insertedRows
            int insertionResultOnCurRow = -1;
            System.Data.SqlClient.SqlTransaction bulk_prova456_trx = null;// // ---###################################### transaction ################################
            //
            if (null != this.allRows)
            {// open transaction
                //<DbConnections>
                //   <strings>
                //     <add key="kkkey_key"   value="0"/>
                //     <add key="vkkey_key"   value="0"/>
                //     <add key="Tim2021"   value="Database=Tim2021;Server=ITBZOW1422\SqlExpress;user=sa;pwd=M1 Sxpdx;"/>
                //   </strings>
                bulk_prova456_trx =
                    Common.Connection.TransactionManager.trxOpener("DbConnections/strings", "Tim2021");
            }
            else return cardInsertedRows;//  #insertedRows
            for (int d = 0; null != this.allRows[d]; d++)
            {
                this.curRowSplitted = this.txtParser.rowSplitter(this.allRows[d]);// get all columns of a single row, by means of this.rowSplitter(
                //-----################### TODO customize the following row ######################################################################################################
                Entity.Entities.prova456_recordLayout_ currentRow = new Entity.Entities.prova456_recordLayout_( this.curRowSplitted);// pass the current row.

                // NB. currentRow private fields, with public readers.-------##################################################
                insertionResultOnCurRow = Entity.Proxies.usp_prova456_INSERT_SERVICE.usp_prova456_INSERT(//-----################### TODO customize the following row #############
                        currentRow.get_un_razionale()
                        ,currentRow.get_un_intero()
                        ,currentRow.get_una_data_senzaOra()
                        , bulk_prova456_trx // ---###################################### transaction ################################
                      );
                if (0 == insertionResultOnCurRow)// retval==0 means Proxy has succeeded in insert.
                {
                    cardInsertedRows++;// another row inserted correctly.
                } // else skip 
                this.curRowSplitted = null;// gc
            }// for
            Common.Connection.TransactionManager.trxCloser(bulk_prova456_trx, true);// Commit
            // ready.
            return cardInsertedRows;//  #Inserted_rows
        }// insertionManager(


    }// class
}// nmsp
