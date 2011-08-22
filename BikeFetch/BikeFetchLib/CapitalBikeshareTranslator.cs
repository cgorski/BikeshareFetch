using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BikeFetchLib
{
    public class CapitalBikeshareTranslator : IBikeshareDataTranslator
    {
        private readonly IBikeshareDataProvider _provider;
        public CapitalBikeshareTranslator(IBikeshareDataProvider provider)
        {
            _provider = provider;
        }

        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static DateTime? UnixTimeInMsToNullableDateTime(string time)
        {
            if(time.Trim().Length>0)
                return Epoch.AddMilliseconds(UInt64.Parse(time,CultureInfo.InvariantCulture));
            return null;
        }
        public StationList FetchStationList()
        {
            var rawServerData = _provider.Fetch();
            var xmlData = XDocument.Parse(rawServerData);
            var stations = (from s in xmlData.Element("stations").Descendants("station")
                           select new Station(remoteId: Int32.Parse(s.Element("id").Value, CultureInfo.InvariantCulture),
                                              commonName: s.Element("name").Value,
                                              terminalId: Int32.Parse(s.Element("terminalName").Value, CultureInfo.InvariantCulture),
                                              latitude: Decimal.Parse(s.Element("lat").Value,CultureInfo.InvariantCulture),
                                              longitude: Decimal.Parse(s.Element("long").Value,CultureInfo.InvariantCulture),
                                              installed: bool.Parse(s.Element("installed").Value),
                                             locked: bool.Parse(s.Element("locked").Value),
                                              installDate:
                                                  UnixTimeInMsToNullableDateTime(s.Element("installDate").Value),
                                              removalDate:
                                                  UnixTimeInMsToNullableDateTime(s.Element("removalDate").Value),
                                              numberOfBikes: Int32.Parse(s.Element("nbBikes").Value, CultureInfo.InvariantCulture),
                                              numberOfEmptyDocks: Int32.Parse(s.Element("nbEmptyDocks").Value,CultureInfo.InvariantCulture))).ToList();
            var stationList = new StationList(DateTime.UtcNow,
                                              UnixTimeInMsToNullableDateTime(xmlData.Element("stations").Attribute("lastUpdate").Value).Value,
                                              new ReadOnlyCollection<Station>(stations));
            return stationList;


        }
    }
}
