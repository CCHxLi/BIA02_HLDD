//
//  QueueReader
//
//  Description:    Demonstrates code used read a message queue with data for visualization
//
//  Author:         Hanxiang Li
//  Last Update:    3 Oct 2018
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Messaging;
using System.Data.SqlClient;
using System.Globalization;

namespace SampleQueueReader
{
    public partial class frmMain : Form
    {
        MessageQueue msmq = new MessageQueue();
        Boolean bRead = false;
        String queueName = "\\private$\\yoyo";
        public frmMain()
        {
            InitializeComponent();
            msmq.Formatter = new ActiveXMessageFormatter();
            msmq.MessageReadPropertyFilter.LookupId = true;
            msmq.SynchronizingObject = this;
            msmq.ReceiveCompleted += new ReceiveCompletedEventHandler(msmq_ReceiveCompleted);
        }

        private void ReadFromDatabase()
        {
            SqlConnection conn = new SqlConnection("Persist Security Info = False; User ID = sa; Initial Catalog = yoyoDB; Data Source = .;Password=Conestoga1;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM yoyoData",conn);
            
            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //listReadbox.Items.Add(rdr["SerialNumber"].ToString());
                    //string showLine = "";
                    //rdr.GetString(0);
                    //MessageBox.Show(rdr["SerialNumber"].ToString());
                    //string rdrString = "rdr.GetString(0)";
                    //MessageBox.Show(rdr.GetString(0) + ',' +
                    //                   rdr.GetString(1) + "," +
                    //                   rdr.GetString(2) + ',' +
                    //                   rdr.GetString(3) + ',' +
                    //                   rdr.GetString(4) + ',' +                                                                              
                    //                   rdr.GetDateTime(5) + "," +
                    //                   rdr.GetString(6));
                    lstReadData.Items.Add(rdr.GetString(0) + ',' +
                                       rdr.GetString(1) + "," +
                                       rdr.GetString(2) + ',' +
                                       rdr.GetString(3) + ',' +
                                       rdr.GetString(4) + ',' +
                                       rdr.GetDateTime(5) + "," +
                                       rdr.GetString(6));
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }

            finally
            {
                conn.Close();
            }
            
        }
        private void WriteToDatabase(string msgData)
        {
            //SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=yoyoDB;Persist Security Info=True;User ID=sa;Password=Conestoga1;");
            SqlConnection conn = new SqlConnection("Persist Security Info = False; User ID = sa; Initial Catalog = yoyoDB; Data Source = .;Password=Conestoga1;");
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;

            String[] parsedData = msgData.Split(',');
            string newInsert = "INSERT INTO yoyoData" +
                "(WorkArea, SerialNumber, Line, State, Reason, DateTimeStamp, ProductID)"
                + "VALUES" +
                "('" + parsedData[0] + "', " +
                "'" + parsedData[1] + "', " +
                "'" + parsedData[2] + "', " +
                "'" + parsedData[3] + "', " +
                "'" + parsedData[4] + "', " +
                "'" + Convert.ToDateTime(parsedData[5].ToString()) + "', " +
                "'" + parsedData[6].ToString() + "');";
            
            cmd.CommandText = newInsert;
            cmd.ExecuteNonQuery();      
            
            conn.Close();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstQueueData.Items.Clear();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtQueueServer.Text = System.Windows.Forms.SystemInformation.ComputerName;
            IsRunning(false);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtQueueServer.Text == "")
            {
                MessageBox.Show("Message Queue Server required");
            }
            else
            {
                msmq.Path = "Formatname:Direct=os:" + txtQueueServer.Text + queueName;
                bRead = true;
                msmq.BeginReceive();
                IsRunning(true);
            }

        }

        void msmq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                lstQueueData.Items.Insert(0,e.Message.Body.ToString());
                WriteToDatabase(e.Message.Body.ToString());
                msmq.EndReceive(e.AsyncResult);
                if (chkCount.Checked)
                {
                    txtRemaining.Text = GetMessageCount(msmq).ToString();
                }
                Application.DoEvents();
                if (bRead)
                {
                    msmq.BeginReceive();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unhandled Exception");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            bRead = false;
            IsRunning(false);
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            lstQueueData.Items.Clear();
        }

        private int GetMessageCount(MessageQueue m)
        {
            Int32 count = 0;
            MessageEnumerator msgEnum = m.GetMessageEnumerator2();
            while (msgEnum.MoveNext(new TimeSpan(0, 0, 0)))
            {
                count++;
            }
            return count;
        }

        private void IsRunning(Boolean state)
        {
            if (state == true)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnSingleRead.Enabled = false;
            }
            else
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false ;
                btnSingleRead.Enabled = true;
            }
        }

        private void btnSingleRead_Click(object sender, EventArgs e)
        {
            if (txtQueueServer.Text == "")
            {
                MessageBox.Show("Message Queue Server required");
            }
            else
            {
                msmq.Path = "Formatname:Direct=os:" + txtQueueServer.Text + queueName;
                try
                {
                    System.Messaging.Message msg = msmq.Receive(new TimeSpan(0));
                    if (msg != null)
                    {
                        lstQueueData.Items.Insert(0, msg.Body.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot read - probably empty queue or queue non existent");
                }
            }

        }

        private void btnPurgeQ_Click(object sender, EventArgs e)
        {
            msmq.Purge();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadFromDatabase();
        }
    }
}
