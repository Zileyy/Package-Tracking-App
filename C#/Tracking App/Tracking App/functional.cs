using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tracking_App
{
    public partial class functional : Form
    {
        public functional()
        {
            InitializeComponent();
        }

        //Function that writes data from databse for provided Tracking Number
        public void getDBInfoo(string ean)
        {

            //Get info for tracking number from DB, assign values to list reader
            dbcred cred = new dbcred();
            var reader = cred.elements(ean);

            Console.Write("aa");

            //Assign values from list to their text boxes
            cargofield.Text = String.Format("{0}", reader[1]);
            trnumfield.Text = String.Format("{0}", reader[2]);
            sentdatefield.Text = String.Format("{0}", reader[3]);
            deliverdatefield.Text = String.Format("{0}", reader[4]);
            sentlocfield.Text = String.Format("{0}", reader[5]);
            dellocfield.Text = String.Format("{0}", reader[6]);
            curlocfield.Text = String.Format("{0}", reader[7]);
            currentdatefield.Text = DateTime.Today.ToString();

        }

        

        private void functional_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        // Recieve info button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ean = eanfield.Text.ToString();
                getDBInfoo(ean);
            }
            catch
            {
                MessageBox.Show("Error occured reading DB", "Error");
                
            }
        

        }

        // Assign EAN-13 to package button
        private void eanassign_Click(object sender, EventArgs e)
        {
            dbcred cred = new dbcred();
            cred.assignEan(ean_assign.Text.ToString(), trnum_assign.Text.ToString());
        }

        private void write_eanfield_TextChanged(object sender, EventArgs e)
        {

        }

        private void sentlocfield_TextChanged(object sender, EventArgs e)
        {

        }

        private void writeBtn_Click(object sender, EventArgs e)
        {

            try
            {
                string format = "yyyy-MM-dd";
                DateTime datesent = Convert.ToDateTime(write_sentdatefield.Text.ToString());
                DateTime datedeliver = Convert.ToDateTime(write_deliverdatefield.Text.ToString());



                dbcred cred = new dbcred();
                cred.writeToDB(
                    write_cargofield.Text.ToString(),
                    write_trnumfield.Text.ToString(),
                    datesent.ToString(format),
                    datedeliver.ToString(format),
                    write_sentlocfield.Text.ToString(),
                    write_dellocfield.Text.ToString(),
                    write_curlocfield.Text.ToString(),
                    write_eanfield.Text.ToString()
                    );

                
            }
            catch
            {

            }
        }
    }
}
