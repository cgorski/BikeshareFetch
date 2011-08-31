using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BikeFetchLib.Enums;
using BikeFetchLib.Interfaces;

namespace BikeFetchLibTest
{
    public class TestBrisbaneCityCycleProvider : IBikeshareDataProvider
    {

        
      

        public Tuple<ProviderReturnType, byte[]> FetchStaticData()
        {
            using (var fileStream = new FileStream(@"C:\Users\cgorski\BikeshareFetch\BikeFetch\BikeFetchLibTest\RawStationData\BrisbaneCityCycleStaticTestData.xml", FileMode.Open))
            {
                using (var memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    return new Tuple<ProviderReturnType, byte[]>(ProviderReturnType.StaticDataOnly,
                                                         memoryStream.ToArray());
                }
            }
 
        }

        public byte[] FetchVariableData(string primaryId)
        {
            if(primaryId != "27" )
                return new byte[0];
            using (var fileStream = new FileStream(@"C:\Users\cgorski\BikeshareFetch\BikeFetch\BikeFetchLibTest\RawStationData\BrisbaneCityCycleVariableTestData.xml", FileMode.Open))
            {
                using (var memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
