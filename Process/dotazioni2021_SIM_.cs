using System;
using System.Collections.Generic;
using System.Text;

namespace Process
{


    public static class dotazioni2021_SIM_
    {

        public static void dotazioni2021_SIM_INSERT( string fullPath )
        {
//Entity.Entities.SIM_recordLayout_ simI = new Entity.Entities.SIM_recordLayout_(new string[2] { "aa", "bb" });
            Entity.InsertionManager.SIM_insertionManager_ sim_insertionManager =
                new Entity.InsertionManager.SIM_insertionManager_("BBT", fullPath);//########  BBT   ############
            sim_insertionManager.splitterTest();
            int insertedRows = sim_insertionManager.insertionManager();
        }// dotazioni2021_SIM_INSERT( BBT xor TIM


    }// class
}// nmsp
