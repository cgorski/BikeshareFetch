using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using BikeFetchLib.Interfaces;
using BikeFetchLib.Providers;
using BikeFetchLib.Translators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeFetchLibTest
{
    [TestClass]
    public class BrisbaneCityCycleTranslatorTest
    {
        [TestMethod]
        public void FetchStaticDataAndOneStationTest()
        {
            var provider = new TestBrisbaneCityCycleProvider();
            var translator = new BrisbaneCityCycleTranslator(provider);
            var stationList = translator.FetchStaticList();

            Assert.AreEqual(44, stationList.Count);
            Assert.AreEqual("Molesworth Street", stationList[2].CommonName);
            Assert.AreEqual(null, stationList[2].InstallDate);
            Assert.AreEqual(null, stationList[2].RemovalDate);
            Assert.AreEqual(new Decimal(53.341288), stationList[2].Latitude);
            Assert.AreEqual(new Decimal(-6.258117), stationList[2].Longitude);      
            Assert.AreEqual("MOLESWORTH STREET", stationList[2].SecondaryId);
            Assert.AreEqual(null, stationList[2].RemovalDate);
            Assert.AreEqual("27", stationList[2].PrimaryId);

            var variableData = translator.FetchVariableData("27");
            Assert.AreEqual(22, variableData.NumberOfBikes);
            Assert.AreEqual(8, variableData.NumberOfEmptyDocks);
        }

        [TestMethod]
        public void FetchStationListTestLive()
        {
            var provider =
                new BrisbaneCityCycleProvider(
                    new Uri("https://abo-brisbane.cyclocity.fr/service/carto"), new Uri("https://abo-brisbane.cyclocity.fr/service/stationdetails"));
            var translator = new BrisbaneCityCycleTranslator(provider);
            var stationList = translator.FetchStaticList();
            Assert.AreNotEqual(0, stationList.Count);
            var variableData = stationList.AsParallel().Select(station => translator.FetchVariableData(station.PrimaryId)).ToList();
            Assert.AreEqual(stationList.Count, variableData.Count);
        }
    }
}
