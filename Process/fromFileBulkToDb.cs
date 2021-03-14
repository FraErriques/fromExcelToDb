using System;
using System.Collections.Generic;
using System.Text;


namespace Process
{

    public static class fromFileBulkToDb
    {




        /// <summary>
        /// returns all of the rows of a data file.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        private static string[] fileParser( string fullPath )
        {
            string[] res = null;
            System.IO.StreamReader txtBuf = new System.IO.StreamReader(fullPath);
            System.Collections.ArrayList theRows = new System.Collections.ArrayList();// string[3];// TODO
            if (null == txtBuf) { return null; }// else continue.
            string tmp = null;
            int c = 0;
            for (; ; c++)
            {
                tmp = txtBuf.ReadLine();
                theRows.Add(tmp);// keep the last row "null", as marker.
                if (null == tmp)
                {
                    break;
                }// else continue.
            }// for
            txtBuf.Close();
            txtBuf = null;//gc
            res = new string[c];
            for (int d = 0; ; d++)
            {
                tmp = (string)(theRows[d + 1]);// NB. start from 1 to skip the titles. Si TITLES are compulsory, in the file.!
                if (null == tmp)// means EOF
                {
                    break;
                }// else continue.
                res[d] = tmp;
            }// for
            return res;
        }// fileParser()

        /// <summary>
        /// returns all of the columns of a single row.
        /// </summary>
        /// <param name="theRow"></param>
        /// <returns></returns>
        private static string[] rowSplitter( string theRow )
        {
            string[] res = theRow.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return res;
        }// rowSplitter(



    }// class

}// nmsp
