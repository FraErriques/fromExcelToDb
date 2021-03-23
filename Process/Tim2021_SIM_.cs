using System;
using System.Collections.Generic;
using System.Text;

namespace Process
{


    public static class Tim2021_SIM_
    {

        public static void Tim2021_SIM_INSERT( string fullPath )
        {
            Entity.Entities.SIM_recordLayout_ simI = new Entity.Entities.SIM_recordLayout_(new string[2] { "aa", "bb" });
            Entity.InsertionManager.Dbdotazioni2021_InsertionManager_SIM_ sim_insertionManager = new Entity.InsertionManager.Dbdotazioni2021_InsertionManager_SIM_("Tim", fullPath);
        }// Tim2021_SIM_INSERT(


    }// class
}// nmsp
