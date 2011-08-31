using System;
using BikeFetchLib.Enums;

namespace BikeFetchLib.Providers
{
    public class CapitalBikeshareDataProvider : BikeshareDataProvider
    {
        private readonly Uri _providerUri;

        public CapitalBikeshareDataProvider(Uri providerUri)
        {
            _providerUri = providerUri;
        }


        public override Tuple<ProviderReturnType, byte[]> FetchStaticData()
        {
            return new Tuple<ProviderReturnType, byte[]>(ProviderReturnType.StaticAndVariableData,
                                                         GetDataViaHttp(_providerUri));
        }

        public override byte[] FetchVariableData(string primaryId)
        {
            throw new InvalidOperationException("Capital Bikeshare returns static and variable data together.");
        }
    }
}