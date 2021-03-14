﻿using System;
using System.Collections.Generic;
using System.Text;



namespace Entity.InsertionManager
{

    public class SIM_insertionManager_
    {
        // type
        private delegate int ProxyPointer(
            string beneficiario,
            string servizio,
            string numero,
            string PIN,
            string PUK,
            string ICCID,
            string note,
            System.Data.SqlClient.SqlTransaction trx		//
        );
        // data
        private ProxyPointer theSelectdProxy = null;
        private string[] allRows = null;
        private string[] curRowSplitted = null;
        Entity.Parser.TxtFileParser txtParser = null;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="inWhichTable"></param>
        public SIM_insertionManager_( string inWhichTable, string fullPath )
        {   // first selet which table, when there are more than one with the same record-layout.
            if (inWhichTable.Trim().ToUpper() == "BBT")
            {
                theSelectdProxy = new ProxyPointer(Proxies.usp_SIM_BBT_INSERT_SERVICE.usp_SIM_BBT_INSERT);
            }
            else if (inWhichTable.Trim().ToUpper() == "TIM")
            {
                theSelectdProxy = new ProxyPointer(Proxies.usp_SIM_TIM_INSERT_SERVICE.usp_SIM_TIM_INSERT);
            }
            else
            {
                throw new System.Exception("Invalid parameter: inWhichTable must be in {BBT, TIM}.");
            }
            // then get the parsed rows.
            this.txtParser = new Entity.Parser.TxtFileParser( fullPath);// the tableName_insertionManager needs an instance of the TxtFileParser, to perform the row-splitting in columns.
            this.allRows = txtParser.get_allRows();// now the class has been Constructed, via TxtFileParser. The insertion will happen via Entity.Entities.SIM_insertionManager_, which calls
            // Entity.Entities.TxtFileParser txtParser.rowSplitter i.e. Entity::Entities::TxtFileParser::rowSplitter
        }// Ctor


        /// <summary>
        /// Dtor
        /// </summary>
        ~SIM_insertionManager_()
        {
            this.curRowSplitted = null;
            this.theSelectdProxy = null;
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
            System.Data.SqlClient.SqlTransaction bulk_SIM_trx = null;// trx
            //
            if (null != this.allRows)
            {// open transaction
                //<DbConnections>
                //   <strings>
                //     <add key="kkkey_key"   value="0"/>
                //     <add key="vkkey_key"   value="0"/>
                //     <add key="Tim2021"   value="Database=Tim2021;Server=ITBZOW1422\SqlExpress;user=sa;pwd=M1 Sxpdx;"/>
                //   </strings>
                bulk_SIM_trx =//---################### NB. customize the transaction ###################################
                    Common.Connection.TransactionManager.trxOpener("DbConnections/strings", "Tim2021");
            }
            else return cardInsertedRows;//  #insertedRows
            for (int d = 0; null != this.allRows[d]; d++)
            {
                this.curRowSplitted = this.txtParser.rowSplitter(this.allRows[d]);// get all columns of a single row, by means of this.rowSplitter(
                Entity.Entities.SIM_recordLayout_ currentRow = new Entity.Entities.SIM_recordLayout_(this.curRowSplitted);

                // NB. currentRow private fields, with public readers.-------##################################################
                insertionResultOnCurRow =
                    this.theSelectdProxy( //-------------------------------- either BBT xor TIM xor draft-------------------------------
                        currentRow.get_beneficiario()   // beneficiario, filtered as provided from class SIM_recordLayout
                        ,currentRow.get_servizio()
                        ,currentRow.get_numero()
                        ,currentRow.get_PIN()
                        , currentRow.get_PUK()
                        ,currentRow.get_ICCID()
                        , currentRow.get_note()
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
