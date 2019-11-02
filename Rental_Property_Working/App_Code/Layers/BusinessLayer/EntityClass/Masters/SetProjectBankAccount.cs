using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for SetProjectBankAccount
/// </summary>

namespace Build.EntityClass
{
    public class SetProjectBankAccount
    {
        #region Column Constant
        public static string _Action = "@Action";

        public static string _ProjectID = "@ProjectID";
        public static string _ProjectAccountID = "@ProjectAccountID";

        public static string _ProjectAccountDetID = "@ProjectAccountDetID";
        public static string _BankID = "@BankID";
        

        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";

        #endregion


        #region[Defination]

        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_ProjectAccountID;
        public Int32 ProjectAccountID
        {
            get { return m_ProjectAccountID; }
            set { m_ProjectAccountID = value; }
        }

        private Int32 m_ProjectID;
        public Int32 ProjectID
        {
            get { return m_ProjectID; }
            set { m_ProjectID = value; }
        }

        private Int32 m_ProjectAccountDetID;
        public Int32 ProjectAccountDetID
        {
            get { return m_ProjectAccountDetID; }
            set { m_ProjectAccountDetID = value; }
        }

        private Int32 m_BankID;
        public Int32 BankID
        {
            get { return m_BankID; }
            set { m_BankID = value; }
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

        #region
        public static string SP_SetProjectBankAccount = "SP_SetProjectBankAccount";
        #endregion


        public SetProjectBankAccount()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}