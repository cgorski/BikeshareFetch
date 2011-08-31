using System;
using BikeFetchLib.Interfaces;

namespace BikeFetchLib.Stations
{
    public abstract class StationStatic : IEquatable<StationStatic>, IStationStatic
    {
        #region IEquatable<StationStatic> Members

        public bool Equals(StationStatic other)
        {
            return !ReferenceEquals(null, other);
        }

        #endregion

        #region IStationStatic Members

        public abstract bool Installed { get; }
        public abstract bool Locked { get; }

        public abstract string PrimaryId { get; }
        public abstract string CommonName { get; }
        public abstract string SecondaryId { get; }
        public abstract decimal Latitude { get; }
        public abstract decimal Longitude { get; }
        public abstract DateTime? InstallDate { get; }
        public abstract DateTime? RemovalDate { get; }
        public abstract DateTime FetchDate { get; }

        #endregion

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (StationStatic)) return false;
            return Equals((StationStatic) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public static bool operator ==(StationStatic left, StationStatic right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(StationStatic left, StationStatic right)
        {
            return !Equals(left, right);
        }
    }
}