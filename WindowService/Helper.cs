using WindowService.DB;
using System;
using System.Configuration;
using System.IO;

namespace WindowService
{
    public class  Helper
    {
        ApiHelper api = new ApiHelper();
        public static void WriteLog(string Message)
        {

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + " : " + Message);
                sw.Flush();
                sw.Close();
            }
            catch
            {

            }
        }

        public static string DigitalKey()
        {
            return ConfigurationManager.AppSettings["DigitalKey"].ToString();
        }

        public static long AmountConvertIntoCents(decimal Amount)
        {
            return Convert.ToInt64(Amount) * 100;
        }
        public static int RandomNumber()
        {
            Random random = new Random();
            return random.Next(1, 50000);
        }

        
        public void InsertLog(string Response, int ScheduleID, int DebtorID)
        {
            using (CollectexDBDataContext db = new CollectexDBDataContext())
            {
                Log l = new Log
                {
                    DebtorID = DebtorID,
                    Response = Response,
                    ScheduleID = ScheduleID
                };
                db.Logs.InsertOnSubmit(l);
                db.SubmitChanges();
            }
        }

    }
}
