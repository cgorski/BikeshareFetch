using System;

namespace BikeFetchLib.Interfaces
{
    public interface IStationStatic
    {
        string PrimaryId { get; } // Primary ID on remote system - should be unique
        string CommonName { get; } // Common name - typically description of location of station
        string SecondaryId { get; } // Secondary ID on remote system - may not be unique
        Decimal Latitude { get; }
        Decimal Longitude { get; }
        DateTime? InstallDate { get; }
        DateTime? RemovalDate { get; }
        DateTime FetchDate { get; }
    }
}