using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeFetchLib
{
    public interface IBikeshareDataProvider
    {
        /// <summary>
        /// Fetch raw bikeshare data 
        /// </summary>
        /// <returns>Raw bikeshare data</returns>
        string Fetch();
    }
}
