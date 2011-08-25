using System.Collections.ObjectModel;

namespace BikeFetchLib.Interfaces
{
    public interface IStationDataPair
    {
        IStationStatic StationStaticData { get; }
        ReadOnlyCollection<IStationVariable> StationVariableDataList { get; }
    }
}