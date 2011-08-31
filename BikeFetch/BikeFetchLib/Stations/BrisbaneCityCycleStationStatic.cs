using System;
using System.Globalization;

namespace BikeFetchLib.Stations
{
    public class BrisbaneCityCycleStationStatic : StationStatic
    {
        private readonly string _address;
        private readonly int _bonus;
        private readonly DateTime _fetchDate;
        private readonly string _fullAddress;
        private readonly Decimal _latitude;
        private readonly Decimal _longitude;
        private readonly string _name;
        private readonly int _number;
        private readonly int _open;


        public BrisbaneCityCycleStationStatic(string name, int number, string address, string fullAddress,
                                              Decimal latitude, Decimal longitude, int open, int bonus,
                                              DateTime fetchDate)
        {
            _name = name;
            _number = number;
            _address = address;
            _fullAddress = fullAddress;
            _latitude = latitude;
            _longitude = longitude;
            _open = open;
            _bonus = bonus;
            _fetchDate = fetchDate;
        }

        public override string PrimaryId
        {
            get { return _number.ToString(CultureInfo.InvariantCulture); }
        }

        public override string CommonName
        {
            get { return _address; }
        }

        public override string SecondaryId
        {
            get { return _name; }
        }

        public override decimal Latitude
        {
            get { return _latitude; }
        }

        public override decimal Longitude
        {
            get { return _longitude; }
        }

        public override DateTime? InstallDate
        {
            get { return null; }
        }

        public override DateTime? RemovalDate
        {
            get { return null; }
        }

        public override DateTime FetchDate
        {
            get { return _fetchDate; }
        }

        public override bool Installed
        {
            get { return true; }
        }

        public override bool Locked
        {
            get { return _open == 1; }
        }
    }
}