using System;
using Firebase;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;




namespace SOSApp
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("YOUR_FIREBASE_LINK");

            public async Task AddRecord(int eld, int adlt, int child, int ttl , double lat, double longt, double alt, string stt)
        {
            await firebase
                .Child("SOSRecords")
                .PostAsync(new SOSRecord() { Elderly = eld, Adult = adlt, Children = child, Total = ttl, Latitude = lat, Longtitude = longt, Altitude = alt, Status = stt });
        }

        public async Task<List<SOSRecord>> GetAllSOSRecord()
        {
            return (await firebase
                .Child("SOSRecords")
                .OnceAsync<SOSRecord>()).Select(item => new SOSRecord
                {
                    Elderly = item.Object.Elderly,
                    Adult = item.Object.Adult,
                    Children = item.Object.Children,
                    Total = item.Object.Total,
                    Latitude = item.Object.Latitude,
                    Longtitude = item.Object.Longtitude,
                    Altitude = item.Object.Altitude,
                    Status = item.Object.Status
                }).ToList();
        }

        public async Task<List<SOSRecord>> GetFindRecord(string victimstatus)
        {
            var allSOSRecord = await GetAllSOSRecord();
            await firebase
              .Child("SOSRecords")
              .OnceAsync<SOSRecord>();
            return allSOSRecord.Where(a => a.Status == victimstatus).ToList();
        }



    }

}
