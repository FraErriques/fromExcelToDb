using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Tim2021Console
{


    class Program
    {

        

        static void Main( string[] args )
        {
            string basePath = ConfigurationLayer.ConfigurationService.GetSingleVoice("datafilePaths/path", "produzione");
            basePath += "\\";
            ////
            //int res_BBT = Process.fromFileBulkToDb.fromFileBulk_SIMBBT_service( basePath + "SIM_BBT_.prn"); // BBT
            //int res_TIM = Process.fromFileBulkToDb.originalTIM_service( basePath + "SIM_TIM_.prn"); // TIM
            ////
            Process.Tim2021_prova456_.Tim2021_prova456_INSERT_( basePath + "esperimento_2021#03#14_W02_.txt"); // BBT
        }// main(


    }// class

}// nmsp
