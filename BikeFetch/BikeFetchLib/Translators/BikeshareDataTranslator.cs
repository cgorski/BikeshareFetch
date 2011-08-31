using System;
using System.Collections.ObjectModel;
using System.Globalization;
using BikeFetchLib.Interfaces;

namespace BikeFetchLib.Translators
{
    public abstract class BikeshareDataTranslator : IBikeshareDataTranslator
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        #region IBikeshareDataTranslator Members

        public abstract ReadOnlyCollection<IStationDataPair> FetchCombinedList();
        public abstract ReadOnlyCollection<IStationStatic> FetchStaticList();
        public abstract IStationVariable FetchVariableData(string stationPrimaryId);

        #endregion

        protected static DateTime? UnixTimeInMsToNullableDateTime(string time)
        {
            if (time.Trim().Length > 0)
                return Epoch.AddMilliseconds(UInt64.Parse(time, CultureInfo.InvariantCulture));
            return null;
        }
    }
}