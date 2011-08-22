using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BikeFetchLib
{
    public class StationList
    {
        public DateTime FetchDate { get; private set; }
        public DateTime DataUpdateDate { get; private set; }
        public ReadOnlyCollection<Station> Stations { get; private set; }


        public StationList(DateTime fetchDate, DateTime dataUpdateDate, ReadOnlyCollection<Station> stations)
        {
            FetchDate = fetchDate;
            DataUpdateDate = dataUpdateDate;
            Stations = stations;
        }
    }
}
