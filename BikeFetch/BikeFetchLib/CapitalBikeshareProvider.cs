using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BikeFetchLib
{
    public class CapitalBikeshareProvider : IBikeshareDataProvider
    {
        public Uri ProviderUri { get; private set; }
        public CapitalBikeshareProvider(Uri providerUri)
        {
            ProviderUri = providerUri;
        }
        
        public string Fetch()
        {           
            try
            {
                var request = WebRequest.Create(ProviderUri);
                using(var response = (HttpWebResponse) request.GetResponse())
                {
                    using (var dataStream = response.GetResponseStream())
                    {
                        if (response.StatusCode == HttpStatusCode.OK && dataStream != null)
                        {
                            using (var reader = new StreamReader(dataStream))
                            {
                                string responseFromServer = reader.ReadToEnd();
                                return responseFromServer;
                            }                         
                        }
                        throw new FetchFailedException(response.StatusDescription);
                    }
                }
                
            }
            catch(System.Net.ProtocolViolationException ex)
            {
                throw new FetchFailedException("System.Net.ProtocolViolationException", ex);
            }
        }
    }
}
