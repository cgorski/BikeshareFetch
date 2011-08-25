using System;

namespace BikeFetchLib.Interfaces
{
    public interface IStationVariable
    {
        int NumberOfBikes { get; }
        int NumberOfEmptyDocks { get; }
        DateTime FetchDate { get; }
    }
}