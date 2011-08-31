using System;
using System.Globalization;

namespace BikeFetchLib.Stations
{
    public class CapitalBikeshareStationStatic : StationStatic
    {
        private readonly string _commonName;
        private readonly DateTime _fetchDate;

        private readonly int _id;
        private readonly DateTime? _installDate;

        private readonly bool _installed;
        private readonly decimal _latitude;

        private readonly bool _locked;
        private readonly decimal _longitude;

        private readonly DateTime? _removalDate;
        private readonly int _terminalId;


        public CapitalBikeshareStationStatic(int id, string commonName, int terminalId, Decimal latitude,
                                             Decimal longitude,
                                             bool installed, bool locked, DateTime? installDate, DateTime? removalDate,
                                             DateTime fetchDate)
        {
            _id = id;
            _commonName = commonName;
            _terminalId = terminalId;
            _latitude = latitude;
            _longitude = longitude;
            _installed = installed;
            _locked = locked;
            _installDate = installDate;
            _removalDate = removalDate;
            _fetchDate = fetchDate;
        }

        public override string PrimaryId
        {
            get { return _terminalId.ToString(CultureInfo.InvariantCulture); }
        }

        public override string CommonName
        {
            get { return _commonName; }
        }

        public override string SecondaryId
        {
            get { return _id.ToString(CultureInfo.InvariantCulture); }
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
            get { return _installDate; }
        }

        public override DateTime? RemovalDate
        {
            get { return _removalDate; }
        }

        public override DateTime FetchDate
        {
            get { return _fetchDate; }
        }

        public override bool Installed
        {
            get { return _installed; }
        }

        public override bool Locked
        {
            get { return _locked; }
        }
    }
}