using System;
using System.Collections.Generic;
using System.Text;


namespace Entity.Parser
{

    /// <summary>
    /// NB.: salvare tutti i fogli Excel con separatore TAB_only, ovvero *.txt testo delimitato da TAB
    /// evitare il salvataggio in *.prn delimitato da spazi, perche' gli spazi intracella si confondono con gli spazi intercella e il 
    /// parser separa il contenuto di ogni singola cella in piu' stringhe. Questo rendeva necessario l'uso dell'underscore, per sostituire
    /// gli spazi intracella. Con la delimitazine intercella con soli TAB il problema e' rispolto, in quanto non possono esserci TAB intracella.
    /// 
    /// TODO provvisorio : re-pars e inserire in new_db_dotazioni2021 : NB. attenzione alla denominazione dei vincoli primary_key pk_* per tabelle col medesimo
    /// tracciato record, in quanto si rischia la duplicazione di nomi di chiavi primarie, editando i vecchi script.
    /// </summary>
    public class TxtFileParser
    {
        // data
        private string fullPath = null;
        private string[] allRows = null;
        
        

        /// <summary>
        /// Ctor
        /// TxtFileParser is actually a row-parser, which loops on the txt-file-rows and gets a string from each of them( i.e. txtBuf.ReadLine()).
        /// After the loop is complete, the field this.allRows contains all of the txt-file-rows. Such parsing is completely independent of the record layout;
        /// it makes use of the field delimitation-criteria only. NB. the method rowSplitter contains an important note about how to choose about the treatment of empty 
        /// columns.
        /// </summary>
        /// <param name="fullPath"></param>
        public TxtFileParser( string fullPath )
        {            
            this.fullPath = fullPath;
            this.allRows = this.fileParser( this.fullPath);// this method fills the this.allRows.
        }// Ctor


        /// <summary>
        /// Dtor
        /// </summary>
        ~TxtFileParser()
        {//-------------------------------gc------------------------------
            this.fullPath = null;
            this.allRows = null;
        }// Dtor


        /// <summary>
        ///  a public read-only helper, to get tha matrix of prsed rows.
        /// </summary>
        /// <returns></returns>
        public string[] get_allRows()
        {
            return this.allRows;
        }// a public read-only helper.


        /// <summary>
        /// Returns all of the rows of a data file, as a string-array, i.e. string[].
        /// The data file is required to have a first row as header. Such row is compulsory, beyond usefull to understand the data.
        /// If such row is absent, the first data-row is gonna be cut off.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        private string[] fileParser( string fullPath )
        {
            string[] res = null;
            System.IO.StreamReader txtBuf = new System.IO.StreamReader(fullPath);
            if (null == txtBuf) { return null; }// else continue.
            System.Collections.ArrayList theRows = new System.Collections.ArrayList();// not knowing the #rows yet.
            int c = 0;
            for (; ; c++)
            {
                theRows.Add(txtBuf.ReadLine()); // keep the last row "null", as marker.
                if (null == theRows[theRows.Count-1])// the last one inserted, zero-based.
                {
                    break;
                }// else continue.
            }// for
            txtBuf.Close();
            txtBuf = null;//------gc-------
            res = new string[c];// now convert the ArrayList to a string vector, i.e string[] 
            int d = 0;
            for( ; ; d++)
            {//NB.############################################## HEADERS ########################################################
                res[d] = (string)(theRows[d + 1]);// NB. start from 1 to skip the titles( i.e. headers). The TITLES are compulsory, in the file.!
                if (null == res[d])// means EOF
                {
                    break;// stop converting the ArrayList, on the first null row. So, no empty lines are allowed, in the text file.
                }// else continue.
            }// for
            theRows = null;// ---gc----ArrayList, since it's been transferred in a string[].
            return res;
        }// fileParser()




        /// <summary>
        /// Returns all of the columns of a single row. Allowed separators are blank and TAB.
        /// NB. It has to be public, since it gets calld from each tableName_insertionManager_ class.
        /// </summary>
        /// <param name="theRow"></param>
        /// <returns></returns>
        public string[] rowSplitter( string theRow )
        {
            //string[] res = theRow.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); this splits on both space and TAB.
            string[] res = theRow.Split(new char[] { '\t' }, StringSplitOptions.None );// NB. split on TAB only, in Excel. It means
            // only TAB between columns and only spaces inside the columns. Never a TAB inside a cell. This guarantees the usability of cells 
            // containing spaces. 
            // NB. the usage of the option StringSplitOptions.None causes the individuation od empty columns, which are saved from Excel as \T\T. This way there's
            // no need to fill up the empty columns with NULL or other spaceholders. If instead the option "StringSplitOptions.RemoveEmptyEntries" is used, then the 
            // presence of  \T\T in the text-file is interpreted as "cut off this column". The choice is completely up to the application logic.
            return res;
        }// rowSplitter(



    }// class
}// nmsp
