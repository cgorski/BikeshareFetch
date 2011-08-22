using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeFetchLib
{
    public interface IBikeshareDataTranslator
    {
        StationList FetchStationList();
    }
}
