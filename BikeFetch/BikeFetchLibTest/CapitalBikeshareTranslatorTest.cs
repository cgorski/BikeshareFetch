using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using BikeFetchLib.Providers;
using BikeFetchLib.Translators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeFetchLibTest
{
    [TestClass]
    public class CapitalBikeshareTranslatorTest
    {
        [TestMethod]
        public void FetchStationListTestStatic()
        {
            var provider = new TestCapitalBikeshareProvider();
            var translator = new CapitalBikeshareTranslator(provider);
            var stationList = translator.FetchCombinedList();
            Assert.AreEqual(7, stationList.Count);
            Assert.AreEqual("20th & Crystal Dr",stationList[2].StationStaticData.CommonName);
            Assert.AreEqual(new DateTime(2010,9,14,11,43,00),stationList[2].StationStaticData.InstallDate);
            Assert.AreEqual(null, stationList[2].StationStaticData.RemovalDate);
            Assert.AreEqual(new Decimal(38.8564), stationList[2].StationStaticData.Latitude);
            Assert.AreEqual(new Decimal(-77.0492), stationList[2].StationStaticData.Longitude);
            Assert.AreEqual(6,stationList[2].StationVariableDataList[0].NumberOfBikes);
            Assert.AreEqual(5,stationList[2].StationVariableDataList[0].NumberOfEmptyDocks);
            Assert.AreEqual("3", stationList[2].StationStaticData.SecondaryId);
            Assert.AreEqual(null,stationList[2].StationStaticData.RemovalDate);
            Assert.AreEqual("31002", stationList[2].StationStaticData.PrimaryId);
        }

        [TestMethod]
        public void FetchStationListTestLive()
        {
            var provider =
                new CapitalBikeshareDataProvider(
                    new Uri("http://www.capitalbikeshare.com/stations/bikeStations.xml"));
            var translator = new CapitalBikeshareTranslator(provider);
            var stationList = translator.FetchCombinedList();
            Assert.AreNotEqual(0,stationList.Count);
        }

    }
}
