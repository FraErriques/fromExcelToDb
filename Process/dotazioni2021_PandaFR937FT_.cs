using System;
using System.Collections.Generic;
using System.Text;


namespace Process
{


    public static class dotazioni2021_PandaFR937FT_
    {

        public static void dotazioni2021_PandaFR937FT_BULK_INSERT( string fullPath )
        {
            Entity.InsertionManager.Dbdotazioni2021_InsertionManager_FR937FT_ PandaFR937FT_insertionManager =
                new Entity.InsertionManager.Dbdotazioni2021_InsertionManager_FR937FT_( fullPath);// of txtFile
            int insertedRows = PandaFR937FT_insertionManager.insertionManager();
        }//


        public static void dotazioni2021_PandaFR937FT_rowSplitTest( string fullPath )
        {
            Entity.InsertionManager.Dbdotazioni2021_InsertionManager_FR937FT_ PandaFR937FT_insertionManager =
                new Entity.InsertionManager.Dbdotazioni2021_InsertionManager_FR937FT_(fullPath);// of txtFile
            int res = PandaFR937FT_insertionManager.splitterTest();
        }//

    }// class
}// nmsp
