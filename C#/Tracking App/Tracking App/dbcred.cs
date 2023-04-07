using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tracking_App
{

    
    class dbcred
    {
        //SQL connection
        public SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        public dbcred() {
            //Database credentials
            builder.DataSource = "DESKTOP-6ASKG74\\AJNURPROJECT";
            builder.UserID = "admin";
            builder.Password = "testadmin";
            builder.InitialCatalog = "maindb";

            
        }

        //Function that returns list for assiging text box values
        public List<string> elements(string ean)
        {
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {

                var temp = new List<string> { };

                //Opening connection
                connection.Open();
                //Querry
                String sql = "SELECT * FROM Tracking WHERE ean13=\'" + ean + "\'";
                //Read form DB get every element into list elements
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        { 
                            for (int i = 0; i < 8; i++)
                            {
                                temp.Add(String.Format("{0}", reader[i]));
                            }
                        }
                    }
                }
                //Closing connection
                connection.Close();

                //Return List
                return temp;
                
            }
        } 
        //Assigning ean13 code to package
        public void assignEan(string ean, string trnum)
        {
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                //Opening connection
                connection.Open();
                //Querry
                String sql = "UPDATE tracking SET ean13=\'" + ean.ToString() +"\'"+" WHERE tracking_number=\'"+trnum.ToString()+"\'" ;
                //Exectue command
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }
        //Re-write DB info on specific package indentified by ean13
        public void writeToDB( string package_name, string tracking_number, string sent_date, string deliver_date, string sent_location,  string deliver_location,  string current_location, string ean13)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    //Opening connection
                    connection.Open();
                    //Querry
                    string sql = string.Format("UPDATE tracking SET package_name = '{0}', tracking_number = '{1}', sent_date = '{2}', deliver_date = '{3}', sent_location = '{4}', deliver_location = '{5}', current_location = '{6}' WHERE ean13 = '{7}'", package_name, tracking_number, sent_date, deliver_date, sent_location, deliver_location, current_location, ean13);
                    //Execute command
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    //Success notification
                    MessageBox.Show("No error occured. Command Executed!", "Executed");
                }
            }
            catch {

                MessageBox.Show("Error occured writing to DB", "Error");

            }

        }

    }
}
