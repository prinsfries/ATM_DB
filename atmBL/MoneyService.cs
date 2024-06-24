using atmDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace atmBL
{
    public class MoneyService
    {
        SqlDbData sqlDbData = new SqlDbData();
        public void WITH(int moneymoney, int wd, string Pin)
        {
            Withdraw(moneymoney, wd, Pin);
        }
        public int Withdraw(int moneymoney, int wd, string Pin)
        {
            
            switch (wd)
            {
                case 1:
                    wd = 100;
                    if (moneymoney >= wd)
                    { 
                        int p = moneymoney-wd;
                        sqlDbData.TransacDB(p, Pin);
                        return p;
                    }
                    else
                    {
                        wd = 0;
                        return wd;
                    }
                    break;
                case 2:
                    wd = 200;
                    if (moneymoney >= wd)
                    {
                        int p = moneymoney - wd;
                        sqlDbData.TransacDB(p, Pin);
                        return p;
                    }
                    else
                    {
                        return moneymoney;
                    }
                    break;
                case 3:
                    wd = 500;
                    if (moneymoney >= wd)
                    {
                        int p = moneymoney - wd;
                        sqlDbData.TransacDB(p, Pin);
                        return p;
                    }
                    else
                    {
                        return moneymoney;
                    }
                    break;
                case 4:
                    wd = 1000;
                    if (moneymoney >= wd)
                    {
                        int p = moneymoney - wd;
                        sqlDbData.TransacDB(p, Pin);
                        return p;
                    }
                    else
                    {
                        return moneymoney;
                    }
                    break;
                case 5:
                    wd = 2000;
                    if (moneymoney >= wd)
                    {
                        int p = moneymoney - wd;
                        sqlDbData.TransacDB(p, Pin);
                        return p;
                    }
                    else
                    {
                        return moneymoney;
                    }
                    break;
                case 6:
                    wd = 5000;
                    if (moneymoney >= wd)
                    {
                        int p = moneymoney - wd;
                        sqlDbData.TransacDB(p, Pin);
                        return p;
                    }
                    else
                    {
                        return moneymoney;
                    }
                    break;
                case 7:
                    wd = 7500;
                    if (moneymoney >= wd)
                    {
                        int p = moneymoney - wd;
                        sqlDbData.TransacDB(p, Pin);
                        return p;
                    }
                    else
                    {
                        return moneymoney;
                    }
                    break;
                case 8:
                    wd = 10000;
                    if (moneymoney >= wd)
                    {
                        int p = moneymoney - wd;
                        sqlDbData.TransacDB(p, Pin);
                        return p;
                    }
                    else
                    {
                        return moneymoney;
                    }
                    break;
                case 9:
                    return customInputWith(moneymoney, wd, Pin);
                    break;
                default:
                    return moneymoney;
                    break;
            }
        }
        public void DEPO(int moneymoney, int wd, string Pin)
        {
            deposit(moneymoney, wd, Pin);   
        }
        public int deposit(int moneymoney, int wd, string Pin)
        {
            switch (wd)
            {
                case 1:
                    wd = 100;
                    int p = moneymoney + wd;
                    sqlDbData.TransacDB(p, Pin);
                    return p;
                    break;
                case 2:
                    wd = 200;
                    p = moneymoney + wd;
                    sqlDbData.TransacDB(p, Pin);
                    return p;
                    break;
                case 3:
                    wd = 500;
                    p = moneymoney + wd;
                    sqlDbData.TransacDB(p, Pin);
                    return p;
                    break;
                case 4:
                    wd = 1000;
                    p = moneymoney + wd;
                    sqlDbData.TransacDB(p, Pin);
                    return p;
                    break;
                case 5:
                    wd = 2000;
                    p = moneymoney + wd;
                    sqlDbData.TransacDB(p, Pin);
                    return p;
                    break;
                case 6:
                    wd = 5000;
                    p = moneymoney + wd;
                    sqlDbData.TransacDB(p, Pin);
                    return p;
                    break;
                case 7:
                    wd = 7500;
                    p = moneymoney + wd;
                    sqlDbData.TransacDB(p, Pin);
                    return p;
                    break;
                case 8:
                    wd = 10000;
                    p = moneymoney + wd;
                    sqlDbData.TransacDB(p, Pin);
                    return p;
                    break;
                case 9:
                    return customInputDepo(moneymoney, wd, Pin);
                    break;

                default:
                    return moneymoney;
                    break;
            }
        }
        public int customInputWith(int moneymoney, int input, string Pin)
        {
            if (input <= moneymoney)
            {
                //return moneymoney - input;
                int p = moneymoney - input;
                sqlDbData.TransacDB(p, Pin);
                return p;

            }
            else
            {
                moneymoney=0;
                return moneymoney;
            }
        }
        public int customInputDepo(int moneymoney, int input, string Pin)
        {
            int p = moneymoney + input;
            sqlDbData.TransacDB(p, Pin);
            return p;
        }
    }
}
