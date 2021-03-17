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
            string basePath = ConfigurationLayer.ConfigurationService.GetSingleVoice("datafilePaths/path", "test");
            basePath += "\\";
            string fullPath = basePath + "SIM_BBT_.txt"; // BBT
            // string fullPath = basePath + "SIM_TIM_.txt"; // TIM
            ////
            Process.dotazioni2021_SIM_.dotazioni2021_SIM_INSERT( fullPath);
        }// main(


    }// class

}// nmsp
