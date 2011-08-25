using System.Collections.ObjectModel;
using BikeFetchLib.Interfaces;

namespace BikeFetchLib
{
    public interface IBikeshareDataTranslator
    {
        ReadOnlyCollection<IStationDataPair> FetchStationList();
    }
}