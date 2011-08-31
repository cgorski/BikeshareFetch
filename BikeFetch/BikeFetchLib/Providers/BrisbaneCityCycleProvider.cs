using System;
using BikeFetchLib.Enums;

namespace BikeFetchLib.Providers
{
    public class BrisbaneCityCycleProvider : BikeshareDataProvider
    {
        private readonly Uri _staticProviderUri;
        private readonly Uri _variableProviderUri;

        public BrisbaneCityCycleProvider(Uri staticProviderUri, Uri variableProviderUri)
        {
            _staticProviderUri = staticProviderUri;
            _variableProviderUri = variableProviderUri;
        }

        public override Tuple<ProviderReturnType, byte[]> FetchStaticData()
        {
            return new Tuple<ProviderReturnType, byte[]>(ProviderReturnType.StaticDataOnly,
                                                         GetDataViaHttp(_staticProviderUri));
        }

        public override byte[] FetchVariableData(string primaryId)
        {
            string newUri = String.Format("{0}/{1}", _variableProviderUri, primaryId);
            return GetDataViaHttp(new Uri(newUri));
        }
    }
}