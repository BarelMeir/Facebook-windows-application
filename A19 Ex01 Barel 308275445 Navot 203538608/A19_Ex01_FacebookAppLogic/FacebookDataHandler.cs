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

        internal List<string> FetchEvents()
        {
            try
            {
                List<string> eventsList = new List<string>();

                if (m_LoggedInUser.Events.Count == 0)
                {
                    eventsList.Add("There are no events to show.");
                }
                else
                {
                    foreach (Event fbEvent in m_LoggedInUser.Events)
                    {
                        string currentEvent = string.Empty;
                        currentEvent = string.Format("{0} at {1}", fbEvent.Name, fbEvent.StartTime);
                        eventsList.Add(currentEvent);
                    }
                }

                return eventsList;
            }
            catch
            {
                throw new Exception("Could not load Events.");
            }
        }


    }
}
