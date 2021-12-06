using System;
using System.Collections.Generic;
using System.Text;

namespace Process
{
    public static class dotazioni2021_getCardSIMTIMnonAttiveInBBT_READ_
    {

        public static System.Data.DataTable dotazioni2021_getCardSIMTIMnonAttiveInBBT_READ_method()
        {
            System.Data.DataTable res = Entity.Proxies.usp_SIMTIMnonAttiveInBBT_LOAD_SERVICE.usp_SIMTIMnonAttiveInBBT_LOAD();
            return res;
        }// dotazioni2021_getCardSIMTIMnonAttiveInBBT_READ_method

    }
}
