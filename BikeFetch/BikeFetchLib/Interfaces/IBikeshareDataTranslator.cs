using System.Collections.ObjectModel;

namespace BikeFetchLib.Interfaces
{
    public interface IBikeshareDataTranslator
    {
        ReadOnlyCollection<IStationDataPair> FetchCombinedList();
        ReadOnlyCollection<IStationStatic> FetchStaticList();
        IStationVariable FetchVariableData(string stationPrimaryId);
    }
}