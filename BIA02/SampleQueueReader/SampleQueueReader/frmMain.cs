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
        String[,] productNameArr = { {"1","Original Sleeper" }, {"2","Black Beauty" }, {"3","Firecraker" },
                                        {"4", "Lemon Yellow" }, {"5","Midnight Blue" }, {"6","Screaming Orange" },
                                        {"7", "Gold Glitter" },{"8","White Lightening" },{"9","All" } };
        String [,] state = {{"0","MOLD"}, //0
                            {"0","QUEUE_INSPECTION_1" }, //1
                            {"0","INSPECTION_1" }, //2
                            {"0","INSPECTION_1_SCRAP" }, //3
                            {"0","QUEUE_PAINT" }, //4
                            {"0","PAINT" }, //5
                            {"0","QUEUE_INSPECTION_2" }, //6
                            {"0","INSPECTION_2" }, //7
                            {"0","INSPECTION_2_REWORK" }, //8
                            {"0","INSPECTION_2_SCRAP" }, //9
                            {"0","QUEUE_ASSEMBLY" }, //10
                            {"0","ASSEMBLY" }, //11
                            {"0","QUEUE_INSPECTION_3" }, //12
                            {"0","INSPECTION_3" }, //13
                            {"0","INSPECTION_3_REWORK" }, //14
                            {"0","INSPECTION_3_SCRAP" }, //15
                            {"0","PACKAGE"} }; //16

        int ProductID = 0;
        public frmMain()
        {
            InitializeComponent();
            msmq.Formatter = new ActiveXMessageFormatter();
            msmq.MessageReadPropertyFilter.LookupId = true;
            msmq.SynchronizingObject = this;
            msmq.ReceiveCompleted += new ReceiveCompletedEventHandler(msmq_ReceiveCompleted);
            lstBoxProductInit();
        }

        private void lstBoxProductInit()
        {
            for (int i = 0; i < productNameArr.Length / 2; i++)
            {
                lstBoxProduct.Items.Add(productNameArr[i, 1].ToString());
            }
        }

        private void lstBoxProduct_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < productNameArr.Length / 2; i++)
            {
                if (lstBoxProduct.SelectedItem.ToString() == productNameArr[i, 1].ToString())
                {
                    string product = lstBoxProduct.SelectedItem.ToString();
                    ProductID = i+1;
                    //test for yoyo name and ProductID bounding
                    //MessageBox.Show(product + " - " + ProductID + " has been selected");
                    lstBoxProductSelector(ProductID);
                }
            }
        }
        private void lstBoxProductSelector(int productID)
        {
            //clear the storage of state for last yoyo

            for (int i = 0; i < state.Length / 2; i++)
            {
                state[i, 0] = "0";
            }
            //clear the storage of list for next yoyo
            lstWriteData.Items.Clear();

            //prepare init sql string and connection string
            SqlConnection conn = new SqlConnection("Persist Security Info = False; User ID = sa; Initial Catalog = yoyoDB; Data Source = .;Password=Conestoga1;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM yoyoData WHERE ProductID = " + productID, conn);
            //change to select all option sql
            if (productID == 9)
            {
                cmd = new SqlCommand("SELECT * FROM yoyoData", conn);
            }
            
            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int moldCount = 0;

                while (rdr.Read())
                {
                    lstWriteData.Items.Add(rdr.GetString(0) + ',' +
                                       rdr.GetString(1) + "," +
                                       rdr.GetString(2) + ',' +
                                       rdr.GetString(3) + ',' +
                                       rdr.GetString(4) + ',' +
                                       rdr.GetDateTime(5) + "," +
                                       rdr.GetString(6));

                    moldCount = rdr.GetString(1).Count();

                    for (int i = 0; i < state.Length /2; i++)
                    {
                        if (rdr.GetString(3) == state[i, 1].ToString())
                        {
                            state[i, 0] = (Convert.ToInt32(state[i, 0]) + 1).ToString();
                        }                       
                    }
                }

                // analysis data
                String total = lstWriteData.Items.Count.ToString();
                int totalFinal = Int32.Parse(total);
                double parsedDoubleYieldMold;                  
                //double parsedDoubleTotal;
                double parseDoublePainted;
                double parseDoubleMolded;
                double parseDoubleAssembled;
                double parseDoublePakage;                

                if (ProductID != 0)
                {
                    txtBTotalPartsMolded.Text = totalFinal.ToString();

                    txtBTotalPartSuccessfullyMolded.Text = state[0, 0].ToString();
                    
                    double.TryParse(state[0, 0].ToString(), out parseDoubleMolded);
                    ////double.TryParse(moldCount.ToString(), out parsedDoubleTotal);                                        
                    parsedDoubleYieldMold = (Math.Round(((parseDoubleMolded / totalFinal) * 100),2));
                    txtBYieldMold.Text = parsedDoubleYieldMold.ToString() +"%"; 



                    txtBTotalPartsSuccessfullyPainted.Text = state[5, 0].ToString();

                    double.TryParse(state[5, 0].ToString(), out parseDoublePainted);
                    //double.TryParse(state[5, 0].ToString(), out parseDoubleMolded);                    
                    txtBYieldPaint.Text = ( Math.Round(((parseDoublePainted / parseDoubleMolded) *100),2).ToString() + "%");

                    txtBTotalPartsSuccessfullyAssembled.Text = state[11, 0].ToString();


                    double.TryParse(state[11, 0].ToString(), out parseDoubleAssembled);                    
                    txtBYieldAssembly.Text = ( Math.Round(((parseDoubleAssembled / parseDoublePainted)*100),2).ToString() + "%");
                    
                    txtBTotalPartsPackaged.Text = state[16, 0].ToString();

                    double.TryParse(state[16, 0].ToString(), out parseDoublePakage);
                    txtBTotalYield.Text = ( Math.Round(((parseDoublePakage / parseDoubleMolded) *100),2).ToString() + "%");
                }

                //test for yoyo amount
                //MessageBox.Show("Amount - " + lstWriteData.Items.Count.ToString());
                //test for show the yoyo name and state
                //for (int i = 0; i < state.Length / 2; i++)
                //{
                //    MessageBox.Show(state[i, 1].ToString() + " - " + state[i, 0].ToString());
                //}

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "s");
            }

            finally
            {
                conn.Close();
            }
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
                    lstWriteData.Items.Add(rdr.GetString(0) + ',' +
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

        private void btnClearList_Click(object sender, EventArgs e)
        {
            lstWriteData.Items.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
