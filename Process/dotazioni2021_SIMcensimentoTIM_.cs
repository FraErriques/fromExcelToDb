using System;
using System.Collections.Generic;
using System.Text;

namespace Process
{

    public static class dotazioni2021_SIMcensimentoTIM_
    {


        /// <summary>
        /// da censimento TIM
        /// </summary>
        /// <param name="fullPath"></param>
        public static void dotazioni2021_SIMcensimentoTIM_INSERT( string fullPath )
        {
            Entity.InsertionManager.Dbdotazioni2021_InsertionManager_SIM_ sim_insertionManager =
                new Entity.InsertionManager.Dbdotazioni2021_InsertionManager_SIM_("TIM", fullPath);//########  BBT   ############
            sim_insertionManager.splitterTest();
            int insertedRows = sim_insertionManager.insertionManager();
        }// dotazioni2021_SIM_INSERT( BBT xor TIM : TIM.


    }// class
}// nmsp
