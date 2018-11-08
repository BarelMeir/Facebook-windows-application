using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A19_Ex01_FacebookAppLogic
{
    public class FacebookLogicHandler
    {
        private FacebookDataHandler m_DataHandler = new FacebookDataHandler();
        private static FacebookLogicHandler m_LogicHandler = null;
        private static readonly object sr_HandlerLock = new object(); // TODO: change name according to guyro

        private FacebookLogicHandler()
        {
        }

        public static FacebookLogicHandler GetLogicHandler()
        {
            // Thread safe Singelton 
            if (m_LogicHandler == null)
            {
                lock (sr_HandlerLock)
                {
                    if (m_LogicHandler == null)
                    {
                        m_LogicHandler = new FacebookLogicHandler();
                    }
                }
            }
            
            return m_LogicHandler;
        }
        


        public void Login()
        {
            try
            {
                m_DataHandler.LoginAndInit();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
    }
}
