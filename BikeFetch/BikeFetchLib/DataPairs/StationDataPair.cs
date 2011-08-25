using System.Collections.Generic;
using System.Collections.ObjectModel;
using BikeFetchLib.Interfaces;

namespace BikeFetchLib.DataPairs
{
    public class StationDataPair : IStationDataPair
    {
        public StationDataPair(IStationStatic stationStaticData, List<IStationVariable> stationVariableData)
        {
            StationStaticData = stationStaticData;
            StationVariableDataList = new ReadOnlyCollection<IStationVariable>(stationVariableData);
        }

        public StationDataPair(IStationStatic stationStaticData, IStationVariable stationVariableData)
        {
            StationStaticData = stationStaticData;
            var list = new List<IStationVariable>();
            list.Add(stationVariableData);
            StationVariableDataList = new ReadOnlyCollection<IStationVariable>(list);
        }

        #region IStationDataPair Members

        public IStationStatic StationStaticData { get; private set; }
        public ReadOnlyCollection<IStationVariable> StationVariableDataList { get; private set; }

        #endregion
    }
}