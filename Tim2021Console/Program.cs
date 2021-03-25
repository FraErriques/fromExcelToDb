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
            //string fullPath = basePath + "SIM_BBT_.txt"; // BBT
            //string fullPath = basePath + "SIM_TIM_.txt"; // TIM
            //string fullPath = basePath + "Panda_FR937FT_.txt"; // Panda 
            //string fullPath = basePath + "CellPhone_BBT_.txt"; // cellulari
            //string fullPath = basePath + "PC_BBT_.txt"; // PC
            //string fullPath = basePath + "accessori_BBT_.txt"; // PC
            string fullPath = basePath + "Panda_FM733KY_.txt";// for genericAuto
            ////
            //Process.dotazioni2021_PandaFR937FT_.dotazioni2021_PandaFR937FT_rowSplitTest( fullPath);
            //Process.dotazioni2021_PandaFR937FT_.dotazioni2021_PandaFR937FT_BULK_INSERT( fullPath);
            //Process.dotazioni2021_SIM_.dotazioni2021_SIM_BBT_INSERT( fullPath);
            //Process.dotazioni2021_Multivalent_.dotazioni2021_CellPhone_INSERT( fullPath);
            //Process.dotazioni2021_Multivalent_.dotazioni2021_PC_INSERT(fullPath);
            //Process.dotazioni2021_Multivalent_.dotazioni2021_accessori_INSERT(fullPath);
            //Process.dotazioni2021_genericaAuto_.dotazioni2021_genericaAuto_rowSplitTest(fullPath);
            Process.dotazioni2021_genericaAuto_.dotazioni2021_genericaAuto_BULK_INSERT( fullPath);
        }// main(


    }// class

}// nmsp
