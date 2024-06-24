using ATMMODEL;
using System.Data;
using System.Data.SqlClient;

namespace atmDL
{
    public class SqlDbData
    {
        static string connectionString
        = "Data Source =PRINS\\SQLEXPRESS; Initial Catalog = ATM; Integrated Security = True;";

        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        public static List<EWallet> GetEW()
        {
            string selectStatement = "SELECT name, EWPin FROM EWallet";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            List<EWallet> ews = new List<EWallet>();

            while (reader.Read())
            {
                string namee = reader["name"].ToString();
                string ewpin = reader["ewpin"].ToString();

                EWallet readUser = new EWallet();
                readUser.name = namee;
                readUser.EWPin = ewpin;

                ews.Add(readUser);
            }

            sqlConnection.Close();

            return ews;
        }
        public int AddUser(string name, string pin)
        {
            int success, k;
            k = 1000;
            string insertStatement = "INSERT INTO EWallet VALUES (@Name, @EWPin, @Money)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Name", name);
            insertCommand.Parameters.AddWithValue("@EWPin", pin);
            insertCommand.Parameters.AddWithValue("@Money", k);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public void DelUser(string pin)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM EWallet WHERE EWPin=" + pin, sqlConnection);
            SqlParameter pinparam;
            pinparam = new SqlParameter("@EWPin", pin);

            cmd.Parameters.Add(pinparam);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                sqlConnection.Close();
            }
            else
            {
                sqlConnection.Close();
            }
            //int success;
            //string insertStatement = "DELETE FROM EWallet WHERE EWPin="+pin;
            //SqlCommand cmd = new SqlCommand(insertStatement, sqlConnection);

            //cmd.Parameters.AddWithValue("@EWPin", pin);
            //sqlConnection.Open();

            //success = cmd.ExecuteNonQuery();


            //sqlConnection.Close();

            //return success;
        }
        public void VerifyDB(string EWPin)
        {
            SqlCommand cmd = new SqlCommand("SELECT EWPin FROM EWallet WHERE EWPin=" + EWPin, sqlConnection);
            SqlParameter pinparam;
            pinparam = new SqlParameter("@EWPin", EWPin);

            cmd.Parameters.Add(pinparam);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                sqlConnection.Close();
                GetEWalletDB(EWPin);
            }
            else
            {
                sqlConnection.Close();
                Console.WriteLine("\nNot found");
            }

        }
        public EWallet GetEWalletDB(string EWPin)
        {
            SqlCommand cmd = new SqlCommand("SELECT Name,EWPin,Money FROM EWallet WHERE EWPin=" + EWPin, sqlConnection);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            EWallet readUser = new EWallet();
            if (dr.Read())
            {
                string namee = dr["name"].ToString();
                string ewpin = dr["ewpin"].ToString();
                int monkey = Convert.ToInt32(dr["money"].ToString());

                readUser.name = namee;
                readUser.EWPin = ewpin;
                readUser.money = monkey;
            }
            sqlConnection.Close();
            return readUser;
        }

        public void TransacDB(int p, string EWPin)
        {
            SqlCommand cmd = new SqlCommand("UPDATE EWallet SET Money =" + p + " WHERE EWPin=" + EWPin, sqlConnection);
            SqlParameter pinparam, pparam;
            pinparam = new SqlParameter("@EWPin", EWPin);
            pparam = new SqlParameter("@Money", p);
            cmd.Parameters.Add(pinparam);
            cmd.Parameters.Add(pparam);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            sqlConnection.Close();
        }

    }
}
