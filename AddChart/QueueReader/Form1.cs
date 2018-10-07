﻿using System;
using System.Data;
using System.Linq;
using System.Messaging;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace QueueReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTable dt = null;
        MessageQueue msmq = new MessageQueue();
        Boolean bRead = false;
        String queueName = "\\private$\\yoyo";
        String[,] productNameArr = { {"1","Original Sleeper" }, {"2","Black Beauty" }, {"3","Firecraker" },
                                        {"4", "Lemon Yellow" }, {"5","Midnight Blue" }, {"6","Screaming Orange" },
                                        {"7", "Gold Glitter" },{"8","White Lightening" },{"9","All" } };
        String[,] state = {{"0","MOLD"}, //0
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public frmMain()
    {
        InitializeComponent();
        msmq.Formatter = new ActiveXMessageFormatter();
        msmq.MessageReadPropertyFilter.LookupId = true;
        msmq.SynchronizingObject = this;
        msmq.ReceiveCompleted += new ReceiveCompletedEventHandler(msmq_ReceiveCompleted);
        lstBoxProductInit();

        dt = new DataTable("ParetoData");
        BindingSource bs = new BindingSource();
        DataColumn dc1 = new DataColumn("State", Type.GetType("System.String"));
        DataColumn dc2 = new DataColumn("Sum", Type.GetType("System.Int32"));
        dt.Columns.Add(dc1);
        dt.Columns.Add(dc2);
        bs.DataSource = dt;
        chPareto.DataSource = dt;
        SetupParto();

        Timer timer = new Timer();
        timer.Interval = (1 * 15);
        timer.Tick += new EventHandler(timer1_Tick);
        timer.Start();
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
                ProductID = i + 1;
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
        //lstWriteData.Items.Clear();

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

                for (int i = 0; i < state.Length / 2; i++)
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

                //i
                txtBTotalPartsMolded.Text = totalFinal.ToString();

                //ii
                txtBTotalPartSuccessfullyMolded.Text = state[0, 0].ToString();
                double.TryParse(state[0, 0].ToString(), out parseDoubleMolded);
                //iii                                     
                parsedDoubleYieldMold = (Math.Round(((parseDoubleMolded / totalFinal) * 100), 2));
                txtBYieldMold.Text = parsedDoubleYieldMold.ToString() + "%";

                //iv
                txtBTotalPartsSuccessfullyPainted.Text = state[5, 0].ToString();
                double.TryParse(state[5, 0].ToString(), out parseDoublePainted);
                //v                  
                txtBYieldPaint.Text = (Math.Round(((parseDoublePainted / parseDoubleMolded) * 100), 2).ToString() + "%");
                //vi
                txtBTotalPartsSuccessfullyAssembled.Text = state[11, 0].ToString();

                //vii
                double.TryParse(state[11, 0].ToString(), out parseDoubleAssembled);
                txtBYieldAssembly.Text = (Math.Round(((parseDoubleAssembled / parseDoublePainted) * 100), 2).ToString() + "%");

                //viii
                txtBTotalPartsPackaged.Text = state[16, 0].ToString();

                //xi
                double.TryParse(state[16, 0].ToString(), out parseDoublePakage);
                txtBTotalYield.Text = (Math.Round(((parseDoublePakage / totalFinal) * 100), 2).ToString() + "%");

            }

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
        SqlCommand cmd = new SqlCommand("SELECT * FROM yoyoData", conn);

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

    private void SetupParto()
    {

        // Make sure the first part is a Column type
        chPareto.Series[0].ChartType = SeriesChartType.Column;

        // Add the series for the accumulcated percentage
        chPareto.Series.Add(new Series());

        //Set up the Line Chart portion 2nd series
        chPareto.Series[1].ChartType = SeriesChartType.Line;
        chPareto.Series[1].BorderWidth = 1;

        // Assign chart area for the Column chart to the Line chart
        chPareto.Series[1].ChartArea = chPareto.Series[0].ChartArea;

        // Use the right axis for the values in the second series
        chPareto.Series[1].YAxisType = AxisType.Secondary;

        // Set the maximum of the right axis to 100 (for percentage)
        chPareto.ChartAreas[0].AxisY2.Maximum = 100;

        // Format as a number, but depending on the values, this could
        // be more elaborate
        chPareto.ChartAreas[0].AxisY2.LabelStyle.Format = "0";

        // Enable the second axis (so it can be seen)
        chPareto.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;



    }
    private void btnClearList_Click(object sender, EventArgs e)
    {
        lstWriteData.Items.Clear();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        lstBoxProductSelector(ProductID);
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        // chart


        SqlConnection conn = new SqlConnection("Persist Security Info = False; User ID = sa; Initial Catalog = yoyoDB; Data Source = .;Password=Conestoga1;");
        SqlCommand cmd = new SqlCommand("SELECT state, productID From yoyoData WHERE state IN ('INSPECTION_2_REWORK','INSPECTION_3_REWORK' ); ", conn);
        conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT count(*) From yoyoData WHERE state IN ('INSPECTION_2_REWORK','INSPECTION_3_REWORK' );";
        Int32 rewrok = (Int32)cmd.ExecuteScalar();

        cmd.CommandText = "SELECT count (*)From yoyoData Where state IN('INSPECTION_1_SCRAP','INSPECTION_2_SCRAP','INSPECTION_3_SCRAP');";
        Int32 scap = (Int32)cmd.ExecuteScalar();
        conn.Close();


        DataRow dr1 = dt.NewRow();
        dr1[0] = "Rework";
        dr1[1] = rewrok;


        DataRow dr2 = dt.NewRow();
        dr2[0] = "Scap";
        dr2[1] = scap;

        dt.Rows.Add(dr1);
        dt.Rows.Add(dr2);

        // For the purposes of this exercise, simple require at least data points

        // First we need to calculate the total
        int Total = 0;
        foreach (DataRow dr in dt.Rows)
        {
            Total += (int)dr[1];
        }

        // Set Left axis to maximum value (Total)
        chPareto.ChartAreas[0].AxisY.Maximum = Total;

        // Clear the data points to redraw the chart
        chPareto.Series[0].Points.Clear();
        chPareto.Series[1].Points.Clear();

        // In the loop, set the data points for the columns to
        // be the original values, including the names for each defect.
        // The second series uses the accumulated sum, and divides by Total to getmutithreading
        // percentage.

        // A DataView is used here to sort the data in the data table.
        // There are other ways you can sort the data. This is just one.
        DataView dv = new DataView(dt);
        dv.Sort = "Sum DESC";

        int cusum = 0;
        foreach (DataRowView dr in dv)
        {
            chPareto.Series[0].Points.AddXY(dr[0], dr[1]);
            cusum += (int)dr[1];
            chPareto.Series[1].Points.AddY((cusum * 100) / Total);
        }
    }
}