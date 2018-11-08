using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using A19_Ex01_FacebookAppLogic;

namespace A19_Ex01_FacebookAppUI
{
    public partial class LoginForm : Form
    {
        private FacebookLogicHandler m_LogicHandler;

        public LoginForm()
        {
            m_LogicHandler = FacebookLogicHandler.GetLogicHandler();
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            m_LogicHandler.Login();
            this.Close();
        }
    }
}
