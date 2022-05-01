using System;
using System.Collections.Generic;
using System.Text;

namespace SOSApp
{
    public interface IFileHelper
    {

        void SaveLastUpdatedDateTimeForData(DateTime dateTime);

        DateTime GetLastUpdatedDateTimeForData();

    }

    public class SOSRecord
    {
        public static DateTime Now { get; set; }
        public int Elderly { get; set; }
        public int Adult { get; set; }
        public int Children { get; set; }
        public int Total{ get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public double Altitude { get; set; }
        public string Status { get; set; }
    }
}
