using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using BikeFetchLib.Enums;
using BikeFetchLib.Interfaces;

namespace BikeFetchLibTest
{
    public class TestCapitalBikeshareProvider : IBikeshareDataProvider
    {
        private const string RawStationData =
            @"<?xml version='1.0' encoding='UTF-8'?><stations lastUpdate=""1314031223378"" version=""2.0""><station><id>1</id><name>20th &amp; Bell St</name><terminalName>31000</terminalName><lat>38.8561</lat><long>-77.0512</long><installed>true</installed><locked>false</locked><installDate /><removalDate /><temporary>false</temporary><nbBikes>3</nbBikes><nbEmptyDocks>8</nbEmptyDocks></station><station><id>2</id><name>12th &amp; Hayes St</name><terminalName>31001</terminalName><lat>38.8621</lat><long>-77.06</long><installed>true</installed><locked>false</locked><installDate>1284989400000</installDate><removalDate /><temporary>false</temporary><nbBikes>5</nbBikes><nbEmptyDocks>14</nbEmptyDocks></station><station><id>3</id><name>20th &amp; Crystal Dr</name><terminalName>31002</terminalName><lat>38.8564</lat><long>-77.0492</long><installed>true</installed><locked>false</locked><installDate>1284464580000</installDate><removalDate /><temporary>false</temporary><nbBikes>6</nbBikes><nbEmptyDocks>5</nbEmptyDocks></station><station><id>4</id><name>15th &amp; Crystal Dr</name><terminalName>31003</terminalName><lat>38.8603</lat><long>-77.0496</long><installed>true</installed><locked>false</locked><installDate>1284464880000</installDate><removalDate /><temporary>false</temporary><nbBikes>6</nbBikes><nbEmptyDocks>5</nbEmptyDocks></station><station><id>5</id><name>18th &amp; Hayes St</name><terminalName>31004</terminalName><lat>38.8573</lat><long>-77.0574</long><installed>true</installed><locked>false</locked><installDate>1284464880000</installDate><removalDate /><temporary>false</temporary><nbBikes>6</nbBikes><nbEmptyDocks>5</nbEmptyDocks></station><station><id>6</id><name>15th &amp; Hayes St</name><terminalName>31005</terminalName><lat>38.8604</lat><long>-77.0603</long><installed>true</installed><locked>false</locked><installDate>1284464940000</installDate><removalDate /><temporary>false</temporary><nbBikes>3</nbBikes><nbEmptyDocks>8</nbEmptyDocks></station><station><id>7</id><name>S Joyce &amp; Army Navy Dr</name><terminalName>31006</terminalName><lat>38.8637</lat><long>-77.0633</long><installed>true</installed><locked>false</locked><installDate>1284464940000</installDate><removalDate /><temporary>false</temporary><nbBikes>1</nbBikes><nbEmptyDocks>10</nbEmptyDocks></station></stations>";
        public string Fetch()
        {

            return RawStationData;
        }

        public Tuple<ProviderReturnType, byte[]> FetchStaticData()
        {
            return new Tuple<ProviderReturnType, byte[]>(ProviderReturnType.StaticAndVariableData,
                                                         Encoding.UTF8.GetBytes(RawStationData));
        }

        public byte[] FetchVariableData(string primaryId)
        {
            throw new InvalidOperationException("Capital Bikeshare returns static and variable data together.");
        }
    }
}
