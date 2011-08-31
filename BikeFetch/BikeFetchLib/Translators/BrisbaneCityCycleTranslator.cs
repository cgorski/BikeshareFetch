using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BikeFetchLib.Enums;
using BikeFetchLib.Exceptions;
using BikeFetchLib.Interfaces;
using BikeFetchLib.Stations;

namespace BikeFetchLib.Translators
{
    public class BrisbaneCityCycleTranslator : BikeshareDataTranslator
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly IBikeshareDataProvider _provider;

        public BrisbaneCityCycleTranslator(IBikeshareDataProvider provider)
        {
            _provider = provider;
        }

        public override ReadOnlyCollection<IStationDataPair> FetchCombinedList()
        {
            throw new InvalidOperationException(
                "BrisbaneCityCycle doesn't support combined static and variable data fetch.");
        }

        public override ReadOnlyCollection<IStationStatic> FetchStaticList()
        {
            Tuple<ProviderReturnType, byte[]> fetchResponse = _provider.FetchStaticData();
            if (fetchResponse.Item1 == ProviderReturnType.StaticAndVariableData)
                throw new InvalidProviderResponseException(
                    "Brisbane CityCycle translator requires static and variable data separate.");
            byte[] rawServerData = fetchResponse.Item2;
            using (var memoryStream = new MemoryStream(rawServerData))
            {
                XDocument xmlData = XDocument.Load(memoryStream);
                DateTime fetchDate = DateTime.UtcNow;
                var stations = new List<IStationStatic>(
                    (from s in xmlData.Element("carto").Element("markers").Descendants("marker")
                     select
                         new BrisbaneCityCycleStationStatic(
                         number:
                             Int32.Parse(s.Attribute("number").Value,
                                         CultureInfo.InvariantCulture),
                         name: s.Attribute("name").Value,
                         address:
                             s.Attribute("address").Value,
                         fullAddress:
                             s.Attribute("fullAddress").Value,
                         latitude:
                             Decimal.Parse(s.Attribute("lat").Value,
                                           CultureInfo.InvariantCulture),
                         longitude:
                             Decimal.Parse(s.Attribute("lng").Value,
                                           CultureInfo.InvariantCulture),
                         open:
                             Int32.Parse(s.Attribute("open").Value,
                                         CultureInfo.InvariantCulture),
                         bonus:
                             Int32.Parse(s.Attribute("number").Value,
                                         CultureInfo.InvariantCulture),
                         fetchDate: fetchDate)));
                return new ReadOnlyCollection<IStationStatic>(stations);
            }
        }

        public override IStationVariable FetchVariableData(string stationPrimaryId)
        {
            byte[] rawServerData = _provider.FetchVariableData(stationPrimaryId);
            using (var memoryStream = new MemoryStream(rawServerData))
            {
                XDocument xmlData = XDocument.Load(memoryStream);
                DateTime fetchDate = DateTime.UtcNow;
                var stationData =
                    new BrisbaneCityCycleStationVariable(
                        numberOfBikes:
                            Int32.Parse(xmlData.Element("station").Element("available").Value,
                                        CultureInfo.InvariantCulture),
                        numberOfEmptyDocks:
                            Int32.Parse(xmlData.Element("station").Element("free").Value,
                                        CultureInfo.InvariantCulture),
                        fetchDate: fetchDate);
                return stationData;
            }
        }
    }
}