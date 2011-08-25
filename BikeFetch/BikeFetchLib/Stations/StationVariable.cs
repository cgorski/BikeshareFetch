using System;
using BikeFetchLib.Interfaces;

namespace BikeFetchLib.Stations
{
    public abstract class StationVariable : IStationVariable
    {
        #region IStationVariable Members

        public abstract int NumberOfBikes { get; }
        public abstract int NumberOfEmptyDocks { get; }
        public abstract DateTime FetchDate { get; }

        #endregion
    }
}