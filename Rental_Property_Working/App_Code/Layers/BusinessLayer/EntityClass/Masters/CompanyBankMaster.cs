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
    public class CompanyBankMaster
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _CompanyBankId = "@CompanyBankId";
        public static string _PCId = "@PCId";
        public static string _CompanyBankDtlsId = "@CompanyBankDtlsId";
        public static string _ProjectCompanyId = "@ProjectCompanyId";
        public static string _BankTypeId = "@BankTypeId";
        public static string _BankName = "@BankName";
        public static string _Branch = "@Branch";
        public static string _AccountNo = "@AccountNo";
        public static string _RTGSNo = "@RTGSNo";
        public static string _ChequeDrawnAccName = "@ChequeDrawnAccName";
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";
        #endregion

        #region Definitions
        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_CompanyBankId;

        public Int32 CompanyBankId
        {
            get { return m_CompanyBankId; }
            set { m_CompanyBankId = value; }
        }
        private Int32 m_PCId;

        public Int32 PCId
        {
            get { return m_PCId; }
            set { m_PCId = value; }
        }

        private Int32 m_CompanyBankDtlsId;

        public Int32 CompanyBankDtlsId
        {
            get { return m_CompanyBankDtlsId; }
            set { m_CompanyBankDtlsId = value; }
        }

        private Int32 m_ProjectCompanyId;

        public Int32 ProjectCompanyId
        {
            get { return m_ProjectCompanyId; }
            set { m_ProjectCompanyId = value; }
        }

        private Int32 m_BankTypeId;

        public Int32 BankTypeId
        {
            get { return m_BankTypeId; }
            set { m_BankTypeId = value; }
        }
        private string m_BankName;

        public string BankName
        {
            get { return m_BankName; }
            set { m_BankName = value; }
        }
        private string m_Branch;

        public string Branch
        {
            get { return m_Branch; }
            set { m_Branch = value; }
        }

        private string m_AccountNo;

        public string AccountNo
        {
            get { return m_AccountNo; }
            set { m_AccountNo = value; }
        }
        private string m_RTGSNo;

        public string RTGSNo
        {
            get { return m_RTGSNo; }
            set { m_RTGSNo = value; }
        }
        private string m_ChequeDrawnAccName;

        public string ChequeDrawnAccName
        {
            get { return m_ChequeDrawnAccName; }
            set { m_ChequeDrawnAccName = value; }
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
        public static string SP_CompanyBankMaster = "SP_CompanyBankMaster";
        #endregion
        public CompanyBankMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
