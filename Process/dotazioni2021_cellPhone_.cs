using System;
using System.Collections.Generic;
using System.Text;

namespace Process
{
    public static class dotazioni2021_cellPhone_
    {

        public static void dotazioni2021_cellPhone_INSERT( string fullPath )
        {
            Entity.InsertionManager.Dbdotazioni2021_InsertionManager_Multivalent_ cellPhone_insertionManager =
                new Entity.InsertionManager.Dbdotazioni2021_InsertionManager_Multivalent_(
                    "cellPhone", fullPath);//########  cellPhone  ############
            int splittedRows = cellPhone_insertionManager.splitterTest();
            int insertedRows = cellPhone_insertionManager.insertionManager();
        }// dotazioni2021_cellPhone_INSERT(

    }// class
}// nmsp
