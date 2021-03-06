﻿namespace SampleQueueReader
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnStart = new System.Windows.Forms.Button();
            this.lstQueueData = new System.Windows.Forms.ListBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQueueServer = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemaining = new System.Windows.Forms.TextBox();
            this.chkCount = new System.Windows.Forms.CheckBox();
            this.btnSingleRead = new System.Windows.Forms.Button();
            this.btnPurgeQ = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lstWriteData = new System.Windows.Forms.ListBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lstBoxProduct = new System.Windows.Forms.ListBox();
            this.txtBTotalYield = new System.Windows.Forms.TextBox();
            this.txtBTotalPartsPackaged = new System.Windows.Forms.TextBox();
            this.txtBYieldAssembly = new System.Windows.Forms.TextBox();
            this.txtBTotalPartsSuccessfullyAssembled = new System.Windows.Forms.TextBox();
            this.txtBYieldPaint = new System.Windows.Forms.TextBox();
            this.txtBTotalPartsSuccessfullyPainted = new System.Windows.Forms.TextBox();
            this.txtBYieldMold = new System.Windows.Forms.TextBox();
            this.txtBTotalPartSuccessfullyMolded = new System.Windows.Forms.TextBox();
            this.txtBTotalPartsMolded = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnClearList = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(714, 48);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Read";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lstQueueData
            // 
            this.lstQueueData.FormattingEnabled = true;
            this.lstQueueData.Location = new System.Drawing.Point(12, 53);
            this.lstQueueData.Name = "lstQueueData";
            this.lstQueueData.Size = new System.Drawing.Size(676, 342);
            this.lstQueueData.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(714, 77);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop Read";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Message Queue Server";
            // 
            // txtQueueServer
            // 
            this.txtQueueServer.Location = new System.Drawing.Point(151, 10);
            this.txtQueueServer.Name = "txtQueueServer";
            this.txtQueueServer.Size = new System.Drawing.Size(173, 20);
            this.txtQueueServer.TabIndex = 5;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(714, 214);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear List";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Remaining";
            // 
            // txtRemaining
            // 
            this.txtRemaining.Location = new System.Drawing.Point(436, 10);
            this.txtRemaining.Name = "txtRemaining";
            this.txtRemaining.Size = new System.Drawing.Size(100, 20);
            this.txtRemaining.TabIndex = 8;
            this.txtRemaining.Text = "0";
            this.txtRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkCount
            // 
            this.chkCount.AutoSize = true;
            this.chkCount.Location = new System.Drawing.Point(714, 252);
            this.chkCount.Name = "chkCount";
            this.chkCount.Size = new System.Drawing.Size(54, 17);
            this.chkCount.TabIndex = 9;
            this.chkCount.Text = "Count";
            this.chkCount.UseVisualStyleBackColor = true;
            // 
            // btnSingleRead
            // 
            this.btnSingleRead.Location = new System.Drawing.Point(714, 137);
            this.btnSingleRead.Name = "btnSingleRead";
            this.btnSingleRead.Size = new System.Drawing.Size(75, 23);
            this.btnSingleRead.TabIndex = 10;
            this.btnSingleRead.Text = "Single Read";
            this.btnSingleRead.UseVisualStyleBackColor = true;
            this.btnSingleRead.Click += new System.EventHandler(this.btnSingleRead_Click);
            // 
            // btnPurgeQ
            // 
            this.btnPurgeQ.Location = new System.Drawing.Point(714, 307);
            this.btnPurgeQ.Name = "btnPurgeQ";
            this.btnPurgeQ.Size = new System.Drawing.Size(75, 23);
            this.btnPurgeQ.TabIndex = 11;
            this.btnPurgeQ.Text = "Purge Q";
            this.btnPurgeQ.UseVisualStyleBackColor = true;
            this.btnPurgeQ.Click += new System.EventHandler(this.btnPurgeQ_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(715, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 22);
            this.button1.TabIndex = 13;
            this.button1.Text = "Write";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstWriteData
            // 
            this.lstWriteData.FormattingEnabled = true;
            this.lstWriteData.Location = new System.Drawing.Point(15, 419);
            this.lstWriteData.Name = "lstWriteData";
            this.lstWriteData.Size = new System.Drawing.Size(673, 381);
            this.lstWriteData.TabIndex = 14;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(883, 35);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 15;
            this.chart1.Text = "chart1";
            // 
            // lstBoxProduct
            // 
            this.lstBoxProduct.FormattingEnabled = true;
            this.lstBoxProduct.Location = new System.Drawing.Point(960, 371);
            this.lstBoxProduct.Name = "lstBoxProduct";
            this.lstBoxProduct.Size = new System.Drawing.Size(147, 121);
            this.lstBoxProduct.TabIndex = 16;
            this.lstBoxProduct.Click += new System.EventHandler(this.lstBoxProduct_Click);
            // 
            // txtBTotalYield
            // 
            this.txtBTotalYield.Location = new System.Drawing.Point(1083, 767);
            this.txtBTotalYield.Name = "txtBTotalYield";
            this.txtBTotalYield.Size = new System.Drawing.Size(100, 20);
            this.txtBTotalYield.TabIndex = 43;
            // 
            // txtBTotalPartsPackaged
            // 
            this.txtBTotalPartsPackaged.Location = new System.Drawing.Point(1083, 739);
            this.txtBTotalPartsPackaged.Name = "txtBTotalPartsPackaged";
            this.txtBTotalPartsPackaged.Size = new System.Drawing.Size(100, 20);
            this.txtBTotalPartsPackaged.TabIndex = 42;
            // 
            // txtBYieldAssembly
            // 
            this.txtBYieldAssembly.Location = new System.Drawing.Point(1083, 713);
            this.txtBYieldAssembly.Name = "txtBYieldAssembly";
            this.txtBYieldAssembly.Size = new System.Drawing.Size(100, 20);
            this.txtBYieldAssembly.TabIndex = 41;
            // 
            // txtBTotalPartsSuccessfullyAssembled
            // 
            this.txtBTotalPartsSuccessfullyAssembled.Location = new System.Drawing.Point(1083, 683);
            this.txtBTotalPartsSuccessfullyAssembled.Name = "txtBTotalPartsSuccessfullyAssembled";
            this.txtBTotalPartsSuccessfullyAssembled.Size = new System.Drawing.Size(100, 20);
            this.txtBTotalPartsSuccessfullyAssembled.TabIndex = 40;
            // 
            // txtBYieldPaint
            // 
            this.txtBYieldPaint.Location = new System.Drawing.Point(1083, 656);
            this.txtBYieldPaint.Name = "txtBYieldPaint";
            this.txtBYieldPaint.Size = new System.Drawing.Size(100, 20);
            this.txtBYieldPaint.TabIndex = 39;
            // 
            // txtBTotalPartsSuccessfullyPainted
            // 
            this.txtBTotalPartsSuccessfullyPainted.Location = new System.Drawing.Point(1083, 625);
            this.txtBTotalPartsSuccessfullyPainted.Name = "txtBTotalPartsSuccessfullyPainted";
            this.txtBTotalPartsSuccessfullyPainted.Size = new System.Drawing.Size(100, 20);
            this.txtBTotalPartsSuccessfullyPainted.TabIndex = 38;
            // 
            // txtBYieldMold
            // 
            this.txtBYieldMold.Location = new System.Drawing.Point(1083, 593);
            this.txtBYieldMold.Name = "txtBYieldMold";
            this.txtBYieldMold.Size = new System.Drawing.Size(100, 20);
            this.txtBYieldMold.TabIndex = 37;
            // 
            // txtBTotalPartSuccessfullyMolded
            // 
            this.txtBTotalPartSuccessfullyMolded.Location = new System.Drawing.Point(1083, 561);
            this.txtBTotalPartSuccessfullyMolded.Name = "txtBTotalPartSuccessfullyMolded";
            this.txtBTotalPartSuccessfullyMolded.Size = new System.Drawing.Size(100, 20);
            this.txtBTotalPartSuccessfullyMolded.TabIndex = 36;
            // 
            // txtBTotalPartsMolded
            // 
            this.txtBTotalPartsMolded.Location = new System.Drawing.Point(1083, 529);
            this.txtBTotalPartsMolded.Name = "txtBTotalPartsMolded";
            this.txtBTotalPartsMolded.Size = new System.Drawing.Size(100, 20);
            this.txtBTotalPartsMolded.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(889, 767);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Total yield";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(889, 738);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Total parts packaged";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(889, 713);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Yield assembly";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(889, 686);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Total parts successfully assembled";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(889, 656);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Yield paint";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(889, 625);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Total parts successfully painted";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(889, 593);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Yield Mold";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(889, 561);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Total  part successfully molded";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(889, 532);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Total parts molded";
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(715, 488);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(75, 23);
            this.btnClearList.TabIndex = 45;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 822);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.txtBTotalYield);
            this.Controls.Add(this.txtBTotalPartsPackaged);
            this.Controls.Add(this.txtBYieldAssembly);
            this.Controls.Add(this.txtBTotalPartsSuccessfullyAssembled);
            this.Controls.Add(this.txtBYieldPaint);
            this.Controls.Add(this.txtBTotalPartsSuccessfullyPainted);
            this.Controls.Add(this.txtBYieldMold);
            this.Controls.Add(this.txtBTotalPartSuccessfullyMolded);
            this.Controls.Add(this.txtBTotalPartsMolded);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lstBoxProduct);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lstWriteData);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPurgeQ);
            this.Controls.Add(this.btnSingleRead);
            this.Controls.Add(this.chkCount);
            this.Controls.Add(this.txtRemaining);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtQueueServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lstQueueData);
            this.Controls.Add(this.btnStart);
            this.Name = "frmMain";
            this.Text = "Sample Queue Reader";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lstQueueData;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQueueServer;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemaining;
        private System.Windows.Forms.CheckBox chkCount;
        private System.Windows.Forms.Button btnSingleRead;
        private System.Windows.Forms.Button btnPurgeQ;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstWriteData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListBox lstBoxProduct;
        private System.Windows.Forms.TextBox txtBTotalYield;
        private System.Windows.Forms.TextBox txtBTotalPartsPackaged;
        private System.Windows.Forms.TextBox txtBYieldAssembly;
        private System.Windows.Forms.TextBox txtBTotalPartsSuccessfullyAssembled;
        private System.Windows.Forms.TextBox txtBYieldPaint;
        private System.Windows.Forms.TextBox txtBTotalPartsSuccessfullyPainted;
        private System.Windows.Forms.TextBox txtBYieldMold;
        private System.Windows.Forms.TextBox txtBTotalPartSuccessfullyMolded;
        private System.Windows.Forms.TextBox txtBTotalPartsMolded;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Timer timer1;
    }
}

