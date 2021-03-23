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
            string fullPath = basePath + "SIM_BBT_.txt"; // BBT
            //string fullPath = basePath + "SIM_TIM_.txt"; // TIM
            //string fullPath = basePath + "Panda_FR937FT_.txt"; // Panda 
            ////
            //Process.dotazioni2021_PandaFR937FT_.dotazioni2021_PandaFR937FT_rowSplitTest( fullPath);
            //Process.dotazioni2021_PandaFR937FT_.dotazioni2021_PandaFR937FT_BULK_INSERT( fullPath);
            Process.dotazioni2021_SIM_.dotazioni2021_SIM_BBT_INSERT( fullPath);
        }// main(


    }// class

}// nmsp
