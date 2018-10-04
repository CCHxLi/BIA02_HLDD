//
// QueueReader
// 
// Description:     point of read a message queue with data for visualization
//
// Author:  Hanxiang Li, Darihan Darihan
// Last Update: 3 Oct 2018



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Messaging;
using System.Data.SqlClient;
using System.Globalization;


namespace QueueReader
{
    public partial class Form1 : Form
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
        public Form1()
        {
            InitializeComponent();
        }
    }
}
