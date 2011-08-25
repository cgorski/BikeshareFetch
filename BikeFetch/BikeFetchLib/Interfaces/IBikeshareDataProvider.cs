using System;
using BikeFetchLib.Enums;

namespace BikeFetchLib
{
    public interface IBikeshareDataProvider
    {
        /// <summary>
        /// Fetch raw bikeshare data.  Some providers (i.e. Capital BikeShare) return static and variable data together.  Others (i.e. Brisbane CityCycle) require individual
        /// requests for each station.
        /// </summary>
        /// <returns>Byte array of the raw bikeshare data, and indication if variable data is returned or if only static data.</returns>
        Tuple<ProviderReturnType, byte[]> FetchStaticData();

        /// <summary>
        /// Fetch raw bikeshare data for a particular station. Some providers (i.e. Capital BikeShare) return static and variable data together.  Others (i.e. Brisbane CityCycle) require individual
        /// requests for each station. 
        /// </summary>
        /// <param name="primaryId">Primary Id of the station requested</param>
        /// <returns>Byte array of the raw variable data.</returns>
        byte[] FetchVariableData(string primaryId);
    }
}