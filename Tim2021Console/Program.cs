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
            string basePath = ConfigurationLayer.ConfigurationService.GetSingleVoice("datafilePaths/path", "NO_Git_local_");
            basePath += "\\";
            string fullPath_SIMBBT = basePath + "SIM_BBT_.txt"; // BBT
            string fullPath_cellPhone = basePath + "CellPhone_BBT_.txt"; // cellulari
            string fullPath_PC = basePath + "PC_BBT_.txt"; // PC
            string fullPath_sccessori = basePath + "accessori_BBT_.txt"; // PC

            //string fullPath = basePath + "SIM_TIM_.txt"; // contratto TIM utenze verificate da TIM.
            //string fullPath = basePath + "Panda_FR937FT_.txt"; // Panda 
            //string fullPath = basePath + "Panda_FM180KE_.txt";// for genericAuto
            //string fullPath = basePath + "wholeAuto_.txt";// mixed PKW
            //string fullPath = basePath + "wholeAuto_2021#03#30_.txt";// mixed PKW
            ////
            //Process.dotazioni2021_PandaFR937FT_.dotazioni2021_PandaFR937FT_rowSplitTest( fullPath);
            //Process.dotazioni2021_PandaFR937FT_.dotazioni2021_PandaFR937FT_BULK_INSERT( fullPath);
            //Process.dotazioni2021_genericaAuto_.dotazioni2021_genericaAuto_rowSplitTest(fullPath);
            //Process.dotazioni2021_genericaAuto_.dotazioni2021_genericaAuto_BULK_INSERT( fullPath);
            //
            Process.dotazioni2021_SIMcensimentoBBT_.dotazioni2021_SIMcensimentoBBT_INSERT( fullPath_SIMBBT);
            Process.dotazioni2021_cellPhone_.dotazioni2021_cellPhone_INSERT(fullPath_cellPhone);
            Process.dotazioni2021_PC_.dotazioni2021_PC_INSERT(fullPath_PC);
            Process.dotazioni2021_accessori_.dotazioni2021_accessori_INSERT(fullPath_sccessori);
        }// main(


    }// class

}// nmsp
