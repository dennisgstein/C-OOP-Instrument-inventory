using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace oopFinalProject
{
    class Instrument
    {
        
            //private fields
            private string _companyname = "";
            private string _instrumentname = "";
            private string _instrumenttype = "";
            private string _countrybuild = "";
            private int _builddate = 0;

            //public fields
            public string CompanyName { get { return _companyname; } }
            public string InstrumentName { get { return _instrumentname; } }
            public string InstrumentType { get { return _instrumenttype; } }
            public string CountryBuild { get { return _countrybuild; } }
            public int BuildDate { get { return _builddate; } }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="companyname">Company Name</param>
        /// <param name="instrumentname">Instrument Name</param>
        /// <param name="instrumenttype">Instrument Type</param>
        /// <param name="countrybuild">Country Build</param>
        /// <param name="builddate">Build Date</param>
        public Instrument(string companyname, string instrumentname, string instrumenttype, string countrybuild, int builddate)

        {
            _companyname = companyname;
            _instrumentname = instrumentname;
            _instrumenttype = instrumenttype;
            _countrybuild = countrybuild;
            _builddate = builddate;
        }
    }
}
