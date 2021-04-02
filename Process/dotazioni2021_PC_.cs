using System;
using System.Collections.Generic;
using System.Text;

namespace Process
{
    public static class dotazioni2021_PC_
    {

        public static void dotazioni2021_PC_INSERT( string fullPath )
        {
            Entity.InsertionManager.Dbdotazioni2021_InsertionManager_Multivalent_ pc_insertionManager =
                new Entity.InsertionManager.Dbdotazioni2021_InsertionManager_Multivalent_(
                    "PC", fullPath);//########  PC  ############
            int splittedRows = pc_insertionManager.splitterTest();
            int insertedRows = pc_insertionManager.insertionManager();
        }// dotazioni2021_PC_INSERT(

    }// class
}// nmsp
