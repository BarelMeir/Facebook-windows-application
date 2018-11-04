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

namespace A19_Ex01_FacebookApp
{
    public partial class MainForm : Form
    {
        private LoginForm m_LoginForm = new LoginForm();
        private User m_LoggedInUser;

        public MainForm()
        {
            m_LoginForm.ShowDialog();
            m_LoggedInUser = m_LoginForm.LoggedInUser;
            InitializeComponent();
            fetchUserInfo();
        }

        private void InitializeComponent()
        {
            this.labelMyProfile = new System.Windows.Forms.Label();
            this.pictureBoxProfilePicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMyProfile
            // 
            this.labelMyProfile.AutoSize = true;
            this.labelMyProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMyProfile.Location = new System.Drawing.Point(44, 26);
            this.labelMyProfile.Name = "labelMyProfile";
            this.labelMyProfile.Size = new System.Drawing.Size(230, 54);
            this.labelMyProfile.TabIndex = 0;
            this.labelMyProfile.Text = "My Profile";
            // 
            // pictureBoxProfilePicture
            // 
            this.pictureBoxProfilePicture.Location = new System.Drawing.Point(53, 107);
            this.pictureBoxProfilePicture.Name = "pictureBoxProfilePicture";
            this.pictureBoxProfilePicture.Size = new System.Drawing.Size(209, 183);
            this.pictureBoxProfilePicture.TabIndex = 1;
            this.pictureBoxProfilePicture.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2032, 1233);
            this.Controls.Add(this.pictureBoxProfilePicture);
            this.Controls.Add(this.labelMyProfile);
            this.Name = "Signed in as " + m_LoggedInUser.Name;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void fetchUserInfo()
        {
            pictureBoxProfilePicture.LoadAsync(m_LoggedInUser.PictureNormalURL);
        }

    }
}
