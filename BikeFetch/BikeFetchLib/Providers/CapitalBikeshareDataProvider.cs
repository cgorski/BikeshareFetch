using System;
using BikeFetchLib.Enums;
using BikeFetchLib.Providers;

namespace BikeFetchLib
{
    public class CapitalBikeshareDataProvider : BikeshareDataProvider
    {
        public CapitalBikeshareDataProvider(Uri providerUri)
        {
            ProviderUri = providerUri;
        }

        public Uri ProviderUri { get; private set; }


        public override Tuple<ProviderReturnType, byte[]> FetchStaticData()
        {
            return new Tuple<ProviderReturnType, byte[]>(ProviderReturnType.StaticAndVariableData,
                                                         GetDataViaHttp(ProviderUri));
        }

        public override byte[] FetchVariableData(string primaryId)
        {
            throw new InvalidOperationException("Capital Bikeshare returns static and variable data together.");
        }
    }
}