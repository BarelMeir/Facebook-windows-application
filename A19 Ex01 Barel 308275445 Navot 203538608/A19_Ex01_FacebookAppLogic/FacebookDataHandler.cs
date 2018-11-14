using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace A19_Ex01_FacebookAppLogic
{
    internal class FacebookDataHandler
    {
        private User m_LoggedInUser;

        internal User LoggedInUser { get { return m_LoggedInUser; } }

        internal void LoginAndInit()
        {
            /// Owner: design.patterns   
            /// 

            /// guys app id : 1450160541956417
            /// our app id: 183018702606942

            /// Use the FacebookService.Login method to display the login form to any user who wish to use this application.
            /// You can then save the result.AccessToken for future auto-connect to this user:
            LoginResult result = FacebookService.Login("1450160541956417", /// (desig patter's "Design Patterns Course App 2.4" app)
                "public_profile",
                "user_birthday",
                "user_friends",
                "user_events",
                //"user_groups" (This permission is only available for apps using Graph API version v2.3 or older.)
                "user_hometown",
                "user_likes",
                "user_location",
                "user_photos",
                "user_posts",

                //"user_status" (This permission is only available for apps using Graph API version v2.3 or older.)
                "user_tagged_places",
                "user_videos",

                // "read_mailbox", (This permission is only available for apps using Graph API version v2.3 or older.)
                "read_page_mailboxes",
                // "read_stream", (This permission is only available for apps using Graph API version v2.3 or older.)
                // "manage_notifications", (This permission is only available for apps using Graph API version v2.3 or older.)
                "manage_pages",
                "publish_pages"

                );
            // These are NOT the complete list of permissions. Other permissions for example:
            // "user_birthday", "user_education_history", "user_hometown", "user_likes","user_location","user_relationships","user_relationship_details","user_religion_politics", "user_videos", "user_website", "user_work_history", "email","read_insights","rsvp_event","manage_pages"
            // The documentation regarding facebook login and permissions can be found here: 
            // https://developers.facebook.com/docs/facebook-login/permissions#reference


            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_LoggedInUser = result.LoggedInUser;
            }
            else
            {
                throw new Exception(result.ErrorMessage);
            }
        }

        internal List<Event> FetchEvents()
        {
            try
            {
                List<Event> eventsList = new List<Event>();

                if (m_LoggedInUser.Events.Count == 0)
                {
                    throw new Exception("There are no events to show.");
                }
                else
                {
                    foreach (Event fbEvent in m_LoggedInUser.Events)
                    {
                        eventsList.Add(fbEvent);
                    }
                }

                return eventsList;
            }
            catch
            {
                throw new Exception("Could not load Events.");
            }
        }

        internal List<Post> FetchWallPosts()
        {
            try
            {
                List<Post> postsList = new List<Post>();

                if (m_LoggedInUser.WallPosts.Count == 0)
                {
                    throw new Exception("There are no wall posts to show.");
                }
                else
                {
                    foreach (Post fbPost in m_LoggedInUser.Posts)
                    {
                        postsList.Add(fbPost);
                    }
                }

                return postsList;
            }
            catch
            {
                throw new Exception("Could not load Wall.");
            }
        }

        internal void SetNewPost(string io_PostMessage)
        {
            try
            {
                m_LoggedInUser.PostStatus(io_PostMessage);
            }
            catch(Exception e)
            {
                throw e;
                //throw new Exception("Could not create the post.");
            }
        }
        /// -----------------------------------------------------------------------------
        internal List<User> FetchFriends()
        {
            try
            {
                List<User> userFriends = new List<User>();
                if (m_LoggedInUser.Friends.Count == 0)
                {
                    throw new Exception("There are no friends to show.");
                }
                else
                {
                    foreach (User friend in m_LoggedInUser.Friends)
                    {
                        userFriends.Add(friend);
                        friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
                    }
                }

                return userFriends;
            }
            catch
            {
                throw new Exception("Could not load friends.");
            }
        }

        internal User FetchUserInfo()
        {
            try
            {
                return m_LoggedInUser;
            }
            catch
            {
                throw new Exception("Could not load user");
            }
        }

        internal string FetchProfileName()
        {
            try
            {
                string userName = m_LoggedInUser.Name;
                return userName;
            }
            catch
            {
                throw new Exception("Could not load name");
            }
        }

        internal string FetchBirthday()
        {
            try
            {
                string userBirthday = m_LoggedInUser.Birthday;
                return userBirthday;
            }
            catch
            {
                throw new Exception("Could not load birthday");
            }
        }

        internal string FetchLocation()
        {
            try
            {
                string userLocation = m_LoggedInUser.Location.Description;
                return userLocation;
            }
            catch
            {
                throw new Exception("Could not load location");
            }
        }

        internal string FetchEmail()
        {
            try
            {
                string userEmail = m_LoggedInUser.Email;
                return userEmail;
            }
            catch
            {
                throw new Exception("Could not load email");
            }
        }

        internal string FetchProfilePicture()
        {
            try
            {
                return m_LoggedInUser.PictureNormalURL;
            }
            catch
            {
                throw new Exception("Could not load profile picture");
            }
        }

        internal List<Album> FetchAlbums()
        {
            try
            {
                List<Album> userAlbums = new List<Album>();

                if (m_LoggedInUser.Albums.Count == 0)
                {
                    throw new Exception("There are no albums to show.");
                }
                else
                {
                    foreach (Album album in m_LoggedInUser.Albums)
                    {
                        userAlbums.Add(album);
                    }
                }
               
                return userAlbums;
            }
            catch
            {
                throw new Exception("Could not load albums");
            }
        }

        // -------------------------------------------------------------------------
        internal List<Page> FetchPages()
        {
            try
            {
                List<Page> userPages = new List<Page>();

                if (m_LoggedInUser.LikedPages.Count == 0)
                {
                    throw new Exception("There are no pages to show.");
                }
                else
                {
                    foreach (Page page in m_LoggedInUser.LikedPages)
                    {
                        userPages.Add(page);
                    }
                }

                return userPages;
            }
            catch
            {
                throw new Exception("Could not load user liked pages");
            }

        }

        internal List<Post> FetchWallWeekSummery()
        {
            try
            {
                List<Post> postsList = new List<Post>();
                DateTime currentDate = DateTime.Now.Date;
                TimeSpan timeSpan;

                if (m_LoggedInUser.WallPosts.Count == 0)
                {
                    throw new Exception("There are no posts to show.");
                }
                else
                {
                    foreach (Post currentPost in m_LoggedInUser.WallPosts)
                    {
                        timeSpan = currentDate.Subtract((DateTime)currentPost.CreatedTime);
                        if (timeSpan.Days < 7)
                        {
                            postsList.Add(currentPost);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                return postsList;
            }
            catch
            {
                throw new Exception("Could not load Wall.");
            }
        }
    }
}
