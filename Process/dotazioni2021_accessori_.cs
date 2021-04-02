using System;
using System.Collections.Generic;
using System.Text;

namespace Process
{

    public static class dotazioni2021_accessori_
    {

        public static void dotazioni2021_accessori_INSERT( string fullPath )
        {
            Entity.InsertionManager.Dbdotazioni2021_InsertionManager_Multivalent_ accessori_insertionManager =
                new Entity.InsertionManager.Dbdotazioni2021_InsertionManager_Multivalent_(
                    "accessori", fullPath);//########  accessori  ############
            int splittedRows = accessori_insertionManager.splitterTest();
            int insertedRows = accessori_insertionManager.insertionManager();
        }// dotazioni2021_accessori_insertionManager_INSERT(

    }// class
}// nmsp
