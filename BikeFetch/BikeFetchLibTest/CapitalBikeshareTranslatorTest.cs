using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
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
            var translator = new BikeFetchLib.CapitalBikeshareTranslator(provider);
            var stationList = translator.FetchStationList();
            Assert.AreEqual(7, stationList.Stations.Count);
            Assert.AreEqual("20th & Crystal Dr",stationList.Stations[2].CommonName);
        }

        [TestMethod]
        public void FetchStationListTestLive()
        {
            var provider =
                new BikeFetchLib.CapitalBikeshareProvider(
                    new Uri("http://www.capitalbikeshare.com/stations/bikeStations.xml"));
            var translator = new BikeFetchLib.CapitalBikeshareTranslator(provider);
            var stationList = translator.FetchStationList();
            Assert.AreNotEqual(0,stationList.Stations.Count);
        }

    }
}
