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


namespace Build.EntityClass
{
    public class ProjectBankMaster
    {
        #region Column Constant

        public static string _Action = "@Action";
        public static string _ProjectBankId = "@ProjectBankId";
        public static string _PCId = "@PCId";
        public static string _BankName = "@BankName";
        public static string _BranchName = "@BranchName";
        public static string _AccountNumber = "@AccountNumber";
        public static string _Fevour = "@Fevour";
        public static string _strCond = "@strCond";
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _UsedCount = "@UsedCount";
        public static string _ProjectId = "@ProjectId";
        
        #endregion

        #region Definitions

        private Int32 m_Action;

        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_ProjectBankId;

        public Int32 ProjectBankId
        {
            get { return m_ProjectBankId; }
            set { m_ProjectBankId = value; }
        }

        private Int32 m_PCId;

        public Int32 PCId
        {
            get { return m_PCId; }
            set { m_PCId = value; }
        }

        private string m_BankName;

        public string BankName
        {
            get { return m_BankName; }
            set { m_BankName = value; }
        }
        private string m_BranchName;

        public string BranchName
        {
            get { return m_BranchName; }
            set { m_BranchName = value; }
        }
        private string m_AccountNumber;

        public string AccountNumber
        {
            get { return m_AccountNumber; }
            set { m_AccountNumber = value; }
        }
        private string m_Fevour;

        public string Fevour
        {
            get { return m_Fevour; }
            set { m_Fevour = value; }
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

        private Int32 m_UsedCount;

        public Int32 UsedCount
        {
            get { return m_UsedCount; }
            set { m_UsedCount = value; }
        }

        private Int32 m_ProjectId;

        public Int32 ProjectId
        {
            get { return m_ProjectId; }
            set { m_ProjectId = value; }
        }

        #endregion

        #region Stored Procedure

        public static string SP_ProjectBankMaster = "SP_ProjectBankMaster";

        #endregion


        public ProjectBankMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
