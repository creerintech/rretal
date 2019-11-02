using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Build.EntityClass
{
    public class EmailConfiguration
    {

        #region Column Constant
        public static string _Action = "@Action";
        public static string _EmailConfigId = "@EmailConfigurationId";
        public static string _ProjectId = "@ProjectId";
        public static string _EmailId = "@EmailId";
        public static string _Password = "@Password";
        public static string _ServerName = "@ServerName";

        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";

        #endregion

        #region Definitions
        private Int32 m_EmailConfigId;
        public Int32 EmailConfigId
        {
            get { return m_EmailConfigId; }
            set { m_EmailConfigId = value; }
        }

        private Int32 m_ProjectId;
        public Int32 ProjectId
        {
            get { return m_ProjectId; }
            set { m_ProjectId = value; }
        }

        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private String m_Password;

        public String Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }

        private String m_EmailId;

        public String EmailId
        {
            get { return m_EmailId; }
            set { m_EmailId = value; }
        }

        private string m_ServerName;

        public string ServerName
        {
            get { return m_ServerName; }
            set { m_ServerName = value; }
        }

        private Int32 m_UserId;

        public Int32 UserId
        {
            get { return m_UserId; }
            set { m_UserId = value; }
        }

        private DateTime m_LoginDate;

        public DateTime LoginDate
        {
            get { return m_LoginDate; }
            set { m_LoginDate = value; }
        }

        private bool m_IsDeleted;

        public bool IsDeleted
        {
            get { return m_IsDeleted; }
            set { m_IsDeleted = value; }
        }

        private string m_StrCondition;

        public string StrCondition
        {
            get { return m_StrCondition; }
            set { m_StrCondition = value; }
        }
        #endregion

        # region Stored Procedure
        public static string SP_EmailConfiguration = "SP_EmailConfiguration";
         // public static string SP_BankMaster_Part1 = "SP_BankMaster_Part1";
        #endregion

        public EmailConfiguration()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}