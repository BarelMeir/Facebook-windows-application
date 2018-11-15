using A19_Ex01_FacebookAppLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace A19_Ex01_FacebookAppUI
{
    internal class DataWrapper
    {
        private List<User> m_FetchedData; // TODO make a general list
        private FacebookLogicHandler m_LogicHandler;

        internal DataWrapper(FacebookLogicHandler io_FacebookLogicHandler)
        {
            this.m_LogicHandler = io_FacebookLogicHandler;
        }

        internal List<User> FetchedData
        {
            get { return m_FetchedData; } 
        }

        internal void FetchFriends()
        {
            m_FetchedData = m_LogicHandler.GetFriends();
        }
    }
}
