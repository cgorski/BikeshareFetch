using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeFetchLib
{
    public class Station
    {
        public int RemoteId { get; private set; }
        public string CommonName { get; private set; }
        public int TerminalId { get; private set; }
        public Decimal Latitude { get; private set; }
        public Decimal Longitude { get; private set; }
        public bool Installed { get; private set; }
        public bool Locked { get; private set; }
        public DateTime? InstallDate { get; private set; }
        public DateTime? RemovalDate { get; private set; }
        public int NumberOfBikes { get; private set; }
        public int NumberOfEmptyDocks { get; private set; }

        public Station(int remoteId, string commonName, int terminalId, Decimal latitude, Decimal longitude,
            bool installed, bool locked, DateTime? installDate, DateTime? removalDate, int numberOfBikes, int numberOfEmptyDocks)
        {
            RemoteId = remoteId;
            CommonName = commonName;
            TerminalId = terminalId;
            Latitude = latitude;
            Longitude = longitude;
            Installed = installed;
            Locked = locked;
            InstallDate = installDate;
            RemovalDate = removalDate;
            NumberOfBikes = numberOfBikes;
            NumberOfEmptyDocks = numberOfEmptyDocks;
        }
    }
}
