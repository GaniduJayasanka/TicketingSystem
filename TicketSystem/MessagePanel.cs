﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketSystem
{
    public partial class MessagePanel : Form
    {
        public MessagePanel(string message, string title)
        {
            InitializeComponent();
            lblMessage.Text = message;
            Text = title;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
            
        }
    }
}
