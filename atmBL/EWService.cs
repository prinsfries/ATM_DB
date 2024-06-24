using atmDL;
using ATMMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atmBL
{
    public class EWService
    {
        //public bool VerifyPin(string EWPin)
        //{
        //    EWDataServices eWDataService = new EWDataServices();
        //    //var result = eWDataService.GetEWallet(EWPin);
        //    return result.EWPin != null ? true : false;
        //}
        public EWallet VerifyPinDB(string EWPin)
        {
            SqlDbData db = new SqlDbData();
            db.VerifyDB(EWPin);
            EWallet toReturn = db.GetEWalletDB(EWPin);
            return toReturn;
        }
        public void AddNewUser(string Name, string EWPin)
        {
            SqlDbData db = new SqlDbData();
            db.AddUser(Name,EWPin);
        }
        public void DeleteUser(string EWPin)
        {
            SqlDbData db = new SqlDbData();
            db.DelUser(EWPin);
        }
    }

    
}
