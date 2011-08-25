using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BikeFetchLib.DataPairs;
using BikeFetchLib.Enums;
using BikeFetchLib.Exceptions;
using BikeFetchLib.Interfaces;
using BikeFetchLib.Stations;

namespace BikeFetchLib
{
    public class CapitalBikeshareTranslator : IBikeshareDataTranslator
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly IBikeshareDataProvider _provider;

        public CapitalBikeshareTranslator(IBikeshareDataProvider provider)
        {
            _provider = provider;
        }

        #region IBikeshareDataTranslator Members

        public ReadOnlyCollection<IStationDataPair> FetchStationList()
        {
            Tuple<ProviderReturnType, byte[]> fetchResponse = _provider.FetchStaticData();
            if (fetchResponse.Item1 == ProviderReturnType.StaticDataOnly)
                throw new InvalidProviderResponseException(
                    "Capital Bikeshare translator requires static and variable data together.");
            byte[] rawServerData = fetchResponse.Item2;
            using (var memoryStream = new MemoryStream(rawServerData))
            {
                XDocument xmlData = XDocument.Load(memoryStream);
                DateTime fetchDate = DateTime.UtcNow;
                List<StationDataPair> stations = (from s in xmlData.Element("stations").Descendants("station")
                                                  select
                                                      new StationDataPair(
                                                      new CapitalBikeshareStationStatic(
                                                          id:
                                                              Int32.Parse(s.Element("id").Value,
                                                                          CultureInfo.InvariantCulture),
                                                          commonName: s.Element("name").Value,
                                                          terminalId:
                                                              Int32.Parse(s.Element("terminalName").Value,
                                                                          CultureInfo.InvariantCulture),
                                                          latitude:
                                                              Decimal.Parse(s.Element("lat").Value,
                                                                            CultureInfo.InvariantCulture),
                                                          longitude:
                                                              Decimal.Parse(s.Element("long").Value,
                                                                            CultureInfo.InvariantCulture),
                                                          installed: bool.Parse(s.Element("installed").Value),
                                                          locked: bool.Parse(s.Element("locked").Value),
                                                          installDate:
                                                              UnixTimeInMsToNullableDateTime(
                                                                  s.Element("installDate").Value),
                                                          removalDate:
                                                              UnixTimeInMsToNullableDateTime(
                                                                  s.Element("removalDate").Value),
                                                          fetchDate: fetchDate),
                                                      new CapitalBikeshareStationVariable(
                                                          numberOfBikes:
                                                              Int32.Parse(s.Element("nbBikes").Value,
                                                                          CultureInfo.InvariantCulture),
                                                          numberOfEmptyDocks:
                                                              Int32.Parse(s.Element("nbEmptyDocks").Value,
                                                                          CultureInfo.InvariantCulture),
                                                          fetchDate: fetchDate))).
                    ToList();

                var underlyingList = new List<IStationDataPair>(stations);
                var stationList = new ReadOnlyCollection<IStationDataPair>(underlyingList);
                return stationList;
            }
        }

        #endregion

        private static DateTime? UnixTimeInMsToNullableDateTime(string time)
        {
            if (time.Trim().Length > 0)
                return Epoch.AddMilliseconds(UInt64.Parse(time, CultureInfo.InvariantCulture));
            return null;
        }
    }
}