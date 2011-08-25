using System;

namespace BikeFetchLib.Stations
{
    public class CapitalBikeshareStationVariable : StationVariable
    {
        private readonly DateTime _fetchDate;
        private readonly int _numberOfBikes;

        private readonly int _numberOfEmptyDocks;

        public CapitalBikeshareStationVariable(int numberOfBikes, int numberOfEmptyDocks, DateTime fetchDate)
        {
            _numberOfBikes = numberOfBikes;
            _numberOfEmptyDocks = numberOfEmptyDocks;
            _fetchDate = fetchDate;
        }

        public override int NumberOfBikes
        {
            get { return _numberOfBikes; }
        }

        public override int NumberOfEmptyDocks
        {
            get { return _numberOfEmptyDocks; }
        }

        public override DateTime FetchDate
        {
            get { return _fetchDate; }
        }
    }
}