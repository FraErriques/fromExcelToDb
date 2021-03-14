using System;
using System.Collections.Generic;
using System.Text;

namespace Process
{

    public static class Tim2021_prova456_
    {


        public static void Tim2021_prova456_INSERT_( string fullPath )
        {
            Entity.InsertionManager.prova456_insertionManager_ prova456_insertionManager = new Entity.InsertionManager.prova456_insertionManager_(fullPath);
            // sim_insertionManager.insertionManager(); production
            int res = prova456_insertionManager.splitterTest();// test
            res = prova456_insertionManager.insertionManager();// production
        }// performSomeTestsFromProcess(


    }//
}// nmsp
