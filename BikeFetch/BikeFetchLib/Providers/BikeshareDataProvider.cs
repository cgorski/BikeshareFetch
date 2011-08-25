using System;
using System.IO;
using System.Net;
using BikeFetchLib.Enums;

namespace BikeFetchLib.Providers
{
    public abstract class BikeshareDataProvider : IBikeshareDataProvider
    {
        #region IBikeshareDataProvider Members

        public abstract Tuple<ProviderReturnType, byte[]> FetchStaticData();
        public abstract byte[] FetchVariableData(string primaryId);

        #endregion

        protected byte[] ByteArrayOfStream(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.GetBuffer();
            }
        }

        protected byte[] GetDataViaHttp(Uri providerUri)
        {
            try
            {
                WebRequest request = WebRequest.Create(providerUri);
                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        if (response.StatusCode == HttpStatusCode.OK && dataStream != null)
                        {
                            return ByteArrayOfStream(dataStream);
                        }
                        throw new FetchFailedException(response.StatusDescription);
                    }
                }
            }
            catch (ProtocolViolationException ex)
            {
                throw new FetchFailedException("System.Net.ProtocolViolationException", ex);
            }
        }
    }
}