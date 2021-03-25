using System;
using System.Collections.Generic;
using System.Text;

namespace Process
{
 

    public static class dotazioni2021_genericaAuto_
    {

        public static void dotazioni2021_genericaAuto_BULK_INSERT( string fullPath )
        {
            Entity.InsertionManager.Dbdotazioni2021_InsertionManager_genericaAuto_ genericaAuto_insertionManager =
                new Entity.InsertionManager.Dbdotazioni2021_InsertionManager_genericaAuto_( fullPath);// of txtFile
            int insertedRows = genericaAuto_insertionManager.insertionManager();
        }// BULK_INSERT


        public static void dotazioni2021_genericaAuto_rowSplitTest( string fullPath )
        {
            Entity.InsertionManager.Dbdotazioni2021_InsertionManager_genericaAuto_ genericaAuto_splitter =
                new Entity.InsertionManager.Dbdotazioni2021_InsertionManager_genericaAuto_( fullPath);// of txtFile
            int cardTestedRows = genericaAuto_splitter.splitterTest();
        }//

    }// class
}// nmsp
