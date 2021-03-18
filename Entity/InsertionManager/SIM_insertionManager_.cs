using System;
using System.Collections.Generic;
using System.Text;



namespace Entity.InsertionManager
{
    /// <summary>
    /// The classes of cathegory tableName_insertionManager_ are devoted to bulk insertion loops, while the 
    /// Entity classes, i.e. Dbname_Entityname represent a single row, which is a single record.
    /// The tableName_insertionManager_ is the vector of such records, with the code necessary for the insert operation.
    /// The seeking of the vector content is realized by means of the Entity.Parser.TxtFileParser which is able to interpret
    /// a text file, without knowing the record-layout, in terms of field separators only. The appropriate interpretation of each
    /// field is responsibility of the class Dbname_Entityname, which knows how many of them to expect, in which order; and so knows 
    /// the data-type of each one of them. So the application logic is:
    /// - from Process:: instantiate the appropriate insertionManager
    /// - this will get the Array of Records from Entity::Parser::TxtFileParser
    /// - the insertionManager will then loop on each scalar of the Record-Array, building an instance of the appropriate Entity for
    /// each row. Such instance will contain the appropriate interpretation of the fields and will be inserted by a StoredProcedure_Proxy.
    /// The loop of row-insertion is wrapped in a transaction, which will be committed or not by the insertionManager.
    /// </summary>
    public class SIM_insertionManager_
    {//NB. on db dotazioni2021  ################################
        // type
        private delegate int ProxyPointer(
			string beneficiario,
			string servizio,
			string numero,
			string PIN,
			string PUK,
			string ICCID,
			System.DateTime registrazione,
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
                    Common.Connection.TransactionManager.trxOpener("DbConnections/strings", "dotazioni2021");
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
                        ,currentRow.get_registrazione()
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
