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
using System.Threading;

namespace A19_Ex01_FacebookAppUI
{
    public partial class FacebookUIForm : Form
    {
        private LoginForm m_LoginForm = new LoginForm();
        private FacebookLogicHandler m_LogicHandler;
        private eDataState m_CurrentDataState = eDataState.General;
        private eDataState m_LastDataState = eDataState.General;
        private ListBox.ObjectCollection m_CurrentStateListBoxItems;
        private List<object> m_LogicDataForListBox;
        private Thread m_thread;
        private DataWrapper m_DataWrapper;

        public FacebookUIForm()
        {
            m_LoginForm.ShowDialog();
            m_LogicHandler = FacebookLogicHandler.GetLogicHandler();
            InitializeComponent();
            fetchUserInfo();
            m_CurrentStateListBoxItems = new ListBox.ObjectCollection(listBoxData);
            m_LogicDataForListBox = new List<object>();
            m_DataWrapper = new DataWrapper(m_LogicHandler);
            m_thread = new Thread(new ThreadStart(m_DataWrapper.FetchFriends));
        }

        private void InitializeComponent()
        {
            this.labelMyProfile = new System.Windows.Forms.Label();
            this.pictureBoxProfilePicture = new System.Windows.Forms.PictureBox();
            this.listBoxData = new System.Windows.Forms.ListBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelBirthday = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.labelDataHeader = new System.Windows.Forms.Label();
            this.buttonFriendsData = new System.Windows.Forms.Button();
            this.buttonEventsData = new System.Windows.Forms.Button();
            this.buttonWallData = new System.Windows.Forms.Button();
            this.buttonNewPost = new System.Windows.Forms.Button();
            this.buttonAlbumsData = new System.Windows.Forms.Button();
            this.buttonTrendsData = new System.Windows.Forms.Button();
            this.buttonWeekSummeryData = new System.Windows.Forms.Button();
            this.textBoxNewPost = new System.Windows.Forms.TextBox();
            this.buttonBackListBox = new System.Windows.Forms.Button();
            this.pictureBoxSelectedItemPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedItemPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMyProfile
            // 
            this.labelMyProfile.AutoSize = true;
            this.labelMyProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMyProfile.Location = new System.Drawing.Point(11, 78);
            this.labelMyProfile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMyProfile.Name = "labelMyProfile";
            this.labelMyProfile.Size = new System.Drawing.Size(190, 44);
            this.labelMyProfile.TabIndex = 0;
            this.labelMyProfile.Text = "My Profile";
            // 
            // pictureBoxProfilePicture
            // 
            this.pictureBoxProfilePicture.Location = new System.Drawing.Point(18, 143);
            this.pictureBoxProfilePicture.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxProfilePicture.Name = "pictureBoxProfilePicture";
            this.pictureBoxProfilePicture.Size = new System.Drawing.Size(183, 187);
            this.pictureBoxProfilePicture.TabIndex = 1;
            this.pictureBoxProfilePicture.TabStop = false;
            // 
            // listBoxData
            // 
            this.listBoxData.FormattingEnabled = true;
            this.listBoxData.ItemHeight = 25;
            this.listBoxData.Location = new System.Drawing.Point(668, 128);
            this.listBoxData.Name = "listBoxData";
            this.listBoxData.Size = new System.Drawing.Size(844, 854);
            this.listBoxData.TabIndex = 2;
            this.listBoxData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxData_MouseDoubleClick);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(216, 143);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 37);
            this.labelName.TabIndex = 3;
            // 
            // labelBirthday
            // 
            this.labelBirthday.AutoSize = true;
            this.labelBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBirthday.Location = new System.Drawing.Point(216, 193);
            this.labelBirthday.Name = "labelBirthday";
            this.labelBirthday.Size = new System.Drawing.Size(0, 37);
            this.labelBirthday.TabIndex = 4;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(216, 243);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(0, 37);
            this.labelEmail.TabIndex = 5;
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocation.Location = new System.Drawing.Point(219, 293);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(0, 37);
            this.labelLocation.TabIndex = 6;
            // 
            // labelDataHeader
            // 
            this.labelDataHeader.AutoSize = true;
            this.labelDataHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataHeader.Location = new System.Drawing.Point(660, 78);
            this.labelDataHeader.Name = "labelDataHeader";
            this.labelDataHeader.Size = new System.Drawing.Size(94, 44);
            this.labelDataHeader.TabIndex = 7;
            this.labelDataHeader.Text = "data";
            // 
            // buttonFriendsData
            // 
            this.buttonFriendsData.Location = new System.Drawing.Point(19, 634);
            this.buttonFriendsData.Name = "buttonFriendsData";
            this.buttonFriendsData.Size = new System.Drawing.Size(150, 79);
            this.buttonFriendsData.TabIndex = 8;
            this.buttonFriendsData.Text = "Friends";
            this.buttonFriendsData.UseVisualStyleBackColor = true;
            this.buttonFriendsData.Click += new System.EventHandler(this.buttonFriendsData_Click);
            // 
            // buttonEventsData
            // 
            this.buttonEventsData.Location = new System.Drawing.Point(19, 732);
            this.buttonEventsData.Name = "buttonEventsData";
            this.buttonEventsData.Size = new System.Drawing.Size(150, 79);
            this.buttonEventsData.TabIndex = 9;
            this.buttonEventsData.Text = "Events";
            this.buttonEventsData.UseVisualStyleBackColor = true;
            this.buttonEventsData.Click += new System.EventHandler(this.buttonEventsData_Click);
            // 
            // buttonWallData
            // 
            this.buttonWallData.Location = new System.Drawing.Point(19, 832);
            this.buttonWallData.Name = "buttonWallData";
            this.buttonWallData.Size = new System.Drawing.Size(150, 79);
            this.buttonWallData.TabIndex = 10;
            this.buttonWallData.Text = "Wall Posts";
            this.buttonWallData.UseVisualStyleBackColor = true;
            this.buttonWallData.Click += new System.EventHandler(this.buttonWallData_Click);
            // 
            // buttonNewPost
            // 
            this.buttonNewPost.Location = new System.Drawing.Point(491, 531);
            this.buttonNewPost.Name = "buttonNewPost";
            this.buttonNewPost.Size = new System.Drawing.Size(148, 37);
            this.buttonNewPost.TabIndex = 11;
            this.buttonNewPost.Text = "Post";
            this.buttonNewPost.UseVisualStyleBackColor = true;
            this.buttonNewPost.Click += new System.EventHandler(this.buttonNewPost_Click);
            // 
            // buttonAlbumsData
            // 
            this.buttonAlbumsData.Location = new System.Drawing.Point(197, 732);
            this.buttonAlbumsData.Name = "buttonAlbumsData";
            this.buttonAlbumsData.Size = new System.Drawing.Size(150, 79);
            this.buttonAlbumsData.TabIndex = 12;
            this.buttonAlbumsData.Text = "Albums";
            this.buttonAlbumsData.UseVisualStyleBackColor = true;
            this.buttonAlbumsData.Click += new System.EventHandler(this.buttonAlbumsData_Click);
            // 
            // buttonTrendsData
            // 
            this.buttonTrendsData.Location = new System.Drawing.Point(197, 832);
            this.buttonTrendsData.Name = "buttonTrendsData";
            this.buttonTrendsData.Size = new System.Drawing.Size(150, 79);
            this.buttonTrendsData.TabIndex = 13;
            this.buttonTrendsData.Text = "Trends";
            this.buttonTrendsData.UseVisualStyleBackColor = true;
            this.buttonTrendsData.Click += new System.EventHandler(this.buttonTrendsData_Click);
            // 
            // buttonWeekSummeryData
            // 
            this.buttonWeekSummeryData.Location = new System.Drawing.Point(197, 634);
            this.buttonWeekSummeryData.Name = "buttonWeekSummeryData";
            this.buttonWeekSummeryData.Size = new System.Drawing.Size(150, 79);
            this.buttonWeekSummeryData.TabIndex = 14;
            this.buttonWeekSummeryData.Text = "Week Summery";
            this.buttonWeekSummeryData.UseVisualStyleBackColor = true;
            this.buttonWeekSummeryData.Click += new System.EventHandler(this.buttonWeekSummeryData_Click);
            // 
            // textBoxNewPost
            // 
            this.textBoxNewPost.Location = new System.Drawing.Point(19, 402);
            this.textBoxNewPost.Multiline = true;
            this.textBoxNewPost.Name = "textBoxNewPost";
            this.textBoxNewPost.Size = new System.Drawing.Size(620, 123);
            this.textBoxNewPost.TabIndex = 15;
            this.textBoxNewPost.Enter += new System.EventHandler(this.textBoxNewPost_Enter);
            this.textBoxNewPost.Leave += new System.EventHandler(this.textBoxNewPost_Leave);
            // 
            // buttonBackListBox
            // 
            this.buttonBackListBox.Location = new System.Drawing.Point(1350, 78);
            this.buttonBackListBox.Name = "buttonBackListBox";
            this.buttonBackListBox.Size = new System.Drawing.Size(161, 43);
            this.buttonBackListBox.TabIndex = 16;
            this.buttonBackListBox.Text = "back";
            this.buttonBackListBox.UseVisualStyleBackColor = true;
            this.buttonBackListBox.Visible = false;
            this.buttonBackListBox.Click += new System.EventHandler(this.buttonBackListBox_Click);
            // 
            // pictureBoxSelectedItemPictureBox
            // 
            this.pictureBoxSelectedItemPictureBox.Location = new System.Drawing.Point(1326, 143);
            this.pictureBoxSelectedItemPictureBox.Name = "pictureBoxSelectedItemPictureBox";
            this.pictureBoxSelectedItemPictureBox.Size = new System.Drawing.Size(174, 187);
            this.pictureBoxSelectedItemPictureBox.TabIndex = 17;
            this.pictureBoxSelectedItemPictureBox.TabStop = false;
            this.pictureBoxSelectedItemPictureBox.Visible = false;
            // 
            // FacebookUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 994);
            this.Controls.Add(this.pictureBoxSelectedItemPictureBox);
            this.Controls.Add(this.buttonBackListBox);
            this.Controls.Add(this.textBoxNewPost);
            this.Controls.Add(this.buttonWeekSummeryData);
            this.Controls.Add(this.buttonTrendsData);
            this.Controls.Add(this.buttonAlbumsData);
            this.Controls.Add(this.buttonNewPost);
            this.Controls.Add(this.buttonWallData);
            this.Controls.Add(this.buttonEventsData);
            this.Controls.Add(this.buttonFriendsData);
            this.Controls.Add(this.labelDataHeader);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelBirthday);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.listBoxData);
            this.Controls.Add(this.pictureBoxProfilePicture);
            this.Controls.Add(this.labelMyProfile);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FacebookUIForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedItemPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void fetchUserInfo()
        {
            try
            {
                this.pictureBoxProfilePicture.LoadAsync(m_LogicHandler.GetProfilePicture());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            try
            {
                this.labelName.Text = m_LogicHandler.GetProfileName();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            try
            {
                this.labelEmail.Text = m_LogicHandler.GetEmail();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            try
            {
                this.labelBirthday.Text = m_LogicHandler.GetBirthday();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            try
            {
                this.labelLocation.Text = m_LogicHandler.GetLocation();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            try
            {
                textBoxNewPost_Leave(this, null);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void changeState(eDataState i_State, string i_Lable)
        {
            m_CurrentDataState = i_State;
            labelDataHeader.Text = i_Lable;
            listBoxData.Items.Clear();
            m_LogicDataForListBox.Clear();
            m_CurrentStateListBoxItems.Clear();

            switch (m_CurrentDataState)
            {
                case eDataState.Albums:
                    changeDataAlbums();
                    break;
                case eDataState.Events:
                    changeDataEvents();
                    break;
                case eDataState.Friends:
                    //changeDataFriends();
                    m_thread.Start();
                    ThreadchangeDataFriends();
                    break;
                case eDataState.SetNewPost:
                    // Add Code
                    break;
                case eDataState.Trends:
                    changeDataTrends();
                    break;
                case eDataState.WallPosts:
                    changeDataWallPosts();
                    break;
                case eDataState.WeekSummery:
                    changeDataWeekSummery();
                    break;
            }
        }

        private void buttonFriendsData_Click(object sender, EventArgs e)
        {
            try
            {
                changeState(eDataState.Friends, "Friends");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void changeDataFriends()
        {
            try
            {
                foreach (User friend in m_LogicHandler.GetFriends())
                {
                    if (friend != null)
                    {
                        // for a clean Tostring of the object
                        listBoxData.Items.Add(string.Format("{0}, {1}", friend.Name, friend.Gender));
                        // to save the actual object (to expand selected)
                        m_LogicDataForListBox.Add(friend);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void ThreadchangeDataFriends()
        {
            try
            {
                listBoxData.Items.Add("Loading Friends...");
                m_thread.Join();
                foreach (User friend in m_DataWrapper.FetchedData)
                {
                    if (friend != null)
                    {
                        // for a clean Tostring of the object
                        listBoxData.Items.Add(string.Format("{0}, {1}", friend.Name, friend.Gender));
                        // to save the actual object (to expand selected)
                        m_LogicDataForListBox.Add(friend);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }




        private void buttonWallData_Click(object sender, EventArgs e)
        {
            try
            {
                changeState(eDataState.WallPosts, "My Wall");
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void changeDataWallPosts()
        {
            try
            {
                foreach (Post post in m_LogicHandler.GetWallPosts())
                {
                    if (post.Message != null)
                    {
                        // for a clean Tostring of the object
                        listBoxData.Items.Add(post.Message);
                        // to save the actual object (to expand selected)
                        m_LogicDataForListBox.Add(post);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonTrendsData_Click(object sender, EventArgs e)
        {
            // TODO: ADD CODE
        }

        private void changeDataTrends()
        {
            // TODO: ADD CODE
        }

        private void buttonEventsData_Click(object sender, EventArgs e)
        {
            try
            {
                changeState(eDataState.Events, "Events");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void changeDataEvents()
        {
            try
            {
                foreach (Event @event in m_LogicHandler.GetEvents())
                {
                    if (@event.Name != null)
                    {
                        // for a clean Tostring of the object
                        listBoxData.Items.Add(string.Format("{0} at: {1}", @event.Name, @event.StartTime));
                        // to save the actual object (to expand selected)
                        m_LogicDataForListBox.Add(@event);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonAlbumsData_Click(object sender, EventArgs e)
        {
            try
            {
                changeState(eDataState.Albums, "Albums");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void changeDataAlbums()
        {
            try
            {
                foreach (Album album in m_LogicHandler.GetAlbums())
                {
                    if (album.Name != null)
                    {
                        // for a clean Tostring of the object
                        listBoxData.Items.Add(string.Format("{0}, created at: {1}", album.Name, album.CreatedTime));
                        // to save the actual object (to expand selected)
                        m_LogicDataForListBox.Add(album);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonWeekSummeryData_Click(object sender, EventArgs e)
        {
            // TODO: ADD CODE
        }

        private void changeDataWeekSummery()
        {
            // TODO: ADD CODE
        }

        private void textBoxNewPost_Enter(object sender, EventArgs e)
        {
            this.textBoxNewPost.Text = string.Empty;
            this.textBoxNewPost.ForeColor = Color.Black;
        }

        private void textBoxNewPost_Leave(object sender, EventArgs e)
        {
            this.textBoxNewPost.ForeColor = Color.Gray;
            this.textBoxNewPost.Text = string.Format("What's on your mind, {0}?", m_LogicHandler.GetProfileName());
        }

        private void listBoxData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                extandSelectedItem();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void extandSelectedItem()
        {
            try
            {
                object selectedItemAtListBox = listBoxData.SelectedItem;
                object selectedItemLogical = m_LogicDataForListBox[listBoxData.Items.IndexOf(selectedItemAtListBox)];

                if (selectedItemLogical != null && m_CurrentDataState != eDataState.General)
                {
                    m_LastDataState = m_CurrentDataState;
                    saveCurrentStateData();
                    this.buttonBackListBox.Visible = true;
                    this.listBoxData.Items.Clear();
                    switch (m_CurrentDataState)
                    {
                        case eDataState.Friends:
                            selectedFriend(selectedItemLogical as User);
                            break;
                        case eDataState.Albums:
                            selectedAlbum(selectedItemLogical as Album);
                            break;
                        case eDataState.Events:
                            selectedEvent(selectedItemLogical as Event);
                            break;
                        case eDataState.WeekSummery:
                            //code
                            break;
                        case eDataState.WallPosts:
                            //code
                            break;
                        case eDataState.Trends:
                            //code
                            break;
                        case eDataState.SetNewPost:
                            //code
                            break;
                        default:
                            //code
                            break;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void saveCurrentStateData()
        {
            if(m_CurrentStateListBoxItems != null && m_CurrentStateListBoxItems.Count != 0)
            {
                m_CurrentStateListBoxItems.Clear();
            }

            foreach (object item in listBoxData.Items)
            {
                m_CurrentStateListBoxItems.Add(item);
            }
        }

        private void loadLastStateData()
        {
            listBoxData.Items.Clear();

            foreach (object item in m_CurrentStateListBoxItems)
            {
                this.listBoxData.Items.Add(item);
            }
        }

        private void selectedFriend(User i_Friend)
        {
            try
            {
                m_CurrentDataState = eDataState.General;
                if(i_Friend.Name != null)
                {
                    listBoxData.Items.Add(string.Format("Name: {0}", i_Friend.Name));
                }

                if (i_Friend.Email != null)
                {
                    listBoxData.Items.Add(string.Format("Email: {0}", i_Friend.Email));
                }

                if(i_Friend.Gender != null)
                {
                    listBoxData.Items.Add(string.Format("Gender: {0}", i_Friend.Gender));
                }

                if (i_Friend.About != null)
                {
                    listBoxData.Items.Add("About:");
                    listBoxData.Items.Add(string.Format("\t {0}", i_Friend.About));
                }

                if (i_Friend.Birthday != null)
                {
                    listBoxData.Items.Add(string.Format("Birthday: {0}", i_Friend.Birthday));
                }

                if (i_Friend.Checkins != null)
                {
                    listBoxData.Items.Add("Checkins:");
                    foreach(Checkin checkin in i_Friend.Checkins)
                    {
                       if (checkin != null)
                        {
                            listBoxData.Items.Add(string.Format("\t {0}", checkin.Message));
                        }
                    }
                }

                if (i_Friend.Events != null)
                {
                    listBoxData.Items.Add("Events:");
                    foreach (Event events in i_Friend.Events)
                    {
                        if (events != null)
                        {
                            listBoxData.Items.Add(string.Format("\t {0}", events.Name));
                        }
                    }
                }

                if (i_Friend.Languages != null)
                {
                    listBoxData.Items.Add("Languages:");
                    foreach (object language in i_Friend.Languages)
                    {
                        if (language != null)
                        {
                            listBoxData.Items.Add(string.Format("\t {0}", language));
                        }
                    }
                }

                if (i_Friend.Educations != null)
                {
                    listBoxData.Items.Add("Educations:");
                    foreach (object education in i_Friend.Educations)
                    {
                        if (education != null)
                        {
                            listBoxData.Items.Add(string.Format("\t {0}", education));
                        }
                    }
                }

                if (i_Friend.Hometown != null)
                {
                    listBoxData.Items.Add(string.Format("Home Town: {0}", i_Friend.Hometown));
                }

                if (i_Friend.PictureNormalURL != null)
                {
                    pictureBoxSelectedItemPictureBox.LoadAsync(i_Friend.PictureNormalURL);
                    pictureBoxSelectedItemPictureBox.Visible = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void selectedAlbum(Album i_Album)
        {
            try
            {
                m_CurrentDataState = eDataState.General;
                if (i_Album.Name != null)
                {
                    listBoxData.Items.Add(string.Format("Name: {0}", i_Album.Name));
                }

                if (i_Album.Count != null)
                {
                    listBoxData.Items.Add(string.Format("Number of photos: {0}", i_Album.Count));
                }

                if (i_Album.CreatedTime != null)
                {
                    listBoxData.Items.Add(string.Format("Created at: {0}", i_Album.CreatedTime));
                }

                if (i_Album.UpdateTime != null)
                {
                    listBoxData.Items.Add(string.Format("Updated at: {0}", i_Album.UpdateTime));
                }

                if (i_Album.Description != null)
                {
                    listBoxData.Items.Add("Description:");
                    listBoxData.Items.Add(string.Format("\t {0}", i_Album.Description));
                }

                if (i_Album.Location != null)
                {
                    listBoxData.Items.Add(string.Format("Location: {0}", i_Album.Location));
                }

                if (i_Album.LikedBy != null)
                {
                    listBoxData.Items.Add("Liked by:");
                    foreach (User liker in i_Album.LikedBy)
                    {
                        if (liker != null)
                        {
                            listBoxData.Items.Add(string.Format("\t {0}", liker.Name));
                        }
                    }
                }

                if (i_Album.Comments != null)
                {
                    listBoxData.Items.Add("Comments:");
                    foreach (Comment comment in i_Album.Comments)
                    {
                        if (comment != null)
                        {
                            listBoxData.Items.Add(string.Format("\t {0}", comment.Message));
                        }
                    }
                }

                if (i_Album.CoverPhotoID != null)
                {
                    pictureBoxSelectedItemPictureBox.LoadAsync(i_Album.CoverPhotoID);
                    pictureBoxSelectedItemPictureBox.Visible = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void selectedEvent(Event i_Event)
        {
            try
            {
                m_CurrentDataState = eDataState.General;
                if (i_Event.Name != null)
                {
                    listBoxData.Items.Add(string.Format("Name: {0}", i_Event.Name));
                }

                if (i_Event.Description != null)
                {
                    listBoxData.Items.Add(string.Format("Description: {0}", i_Event.Description));
                }

                if (i_Event.StartTime != null)
                {
                    listBoxData.Items.Add(string.Format("Time: {0}", i_Event.StartTime));
                }

                if (i_Event.AttendingUsers != null)
                {
                    listBoxData.Items.Add("Attending:");
                    foreach (User user in i_Event.AttendingUsers)
                    {
                        if (user != null)
                        {
                            listBoxData.Items.Add(string.Format("\t {0}", user.Name));
                        }
                    }
                }

                if (i_Event.Location != null)
                {
                    listBoxData.Items.Add(string.Format("Location: {0}", i_Event.Location));
                }

                if (i_Event.PictureNormalURL != null)
                {
                    pictureBoxSelectedItemPictureBox.LoadAsync(i_Event.PictureNormalURL);
                    pictureBoxSelectedItemPictureBox.Visible = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonBackListBox_Click(object sender, EventArgs e)
        {
            loadLastStateData();
            m_CurrentDataState = m_LastDataState;
            this.pictureBoxSelectedItemPictureBox.Visible = false;
            this.pictureBoxSelectedItemPictureBox.Image = null;
            this.buttonBackListBox.Visible = false;
        }

        private void buttonNewPost_Click(object sender, EventArgs e)
        {
            // Add Code
        }
    }
}
