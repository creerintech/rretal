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

    public class BankMaster
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _BankId = "@BankId";
        public static string _BankName = "@BankName";

        public static string _Branch = "@Branch";
        public static string _Address = "@Address";
        public static string _TelNo = "@TelNo";
        public static string _Agentname = "@Agentname";
        public static string _IFSCCode = "@IFSCCode";
        public static string _MICRCode = "@MICRCode";
        public static string _MobNo = "@MobNo";
        public static string _PrevEmpWith = "@PrevEmpWith";
        public static string _Remarks = "@Remarks";
        public static string _EmailId = "@EmailId";
        public static string _SeniorAgent = "@SeniorAgent";
        public static string _SeniorContactNo = "@SeniorContactNo";

        public static string _LedgerId = "@LedgerId";
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";

        //----Details----
        public static string _BankFileUploadId = "@BankFileUploadId";
        public static string _DocumentPath = "@DocumentPath ";
        #endregion

        #region Definitions
        private string m_DocumentPath;
        public string DocumentPath
        {
            get { return m_DocumentPath; }
            set { m_DocumentPath = value; }
        }

        private Int32 m_BankFileUploadId;
        public Int32 BankFileUploadId
        {
            get { return m_BankFileUploadId; }
            set { m_BankFileUploadId = value; }
        }

        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_BankId;

        public Int32 BankId
        {
            get { return m_BankId; }
            set { m_BankId = value; }
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
        private string m_Address;

        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }
        private string m_TelNo;

        public string TelNo
        {
            get { return m_TelNo; }
            set { m_TelNo = value; }
        }
        private string m_Agentname;

        public string Agentname
        {
            get { return m_Agentname; }
            set { m_Agentname = value; }
        }

        private string m_MobNo;

        public string MobNo
        {
            get { return m_MobNo; }
            set { m_MobNo = value; }
        }

        private string m_EmailId;

        public string EmailId
        {
            get { return m_EmailId; }
            set { m_EmailId = value; }
        }

        private string m_SeniorAgent;

        public string SeniorAgent
        {
            get { return m_SeniorAgent; }
            set { m_SeniorAgent = value; }
        }

        private string m_SeniorContactNo;

        public string SeniorContactNo
        {
            get { return m_SeniorContactNo; }
            set { m_SeniorContactNo = value; }
        }

        private bool m_IsSenior;

        public bool IsSenior
        {
            get { return m_IsSenior; }
            set { m_IsSenior = value; }
        }

        private string m_PrevEmpWith;

        public string PrevEmpWith
        {
            get { return m_PrevEmpWith; }
            set { m_PrevEmpWith = value; }
        }
        private string m_Remarks;

        public string Remarks
        {
            get { return m_Remarks; }
            set { m_Remarks = value; }
        }
        private string m_IFSCCode;

        public string IFSCCode
        {
            get { return m_IFSCCode; }
            set { m_IFSCCode = value; }
        }

        private string m_MICRCode;

        public string MICRCode
        {
            get { return m_MICRCode; }
            set { m_MICRCode = value; }
        }

        private Int32 m_LedgerId;

        public Int32 LedgerId
        {
            get { return m_LedgerId; }
            set { m_LedgerId = value; }
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
        public static string SP_BankMaster = "SP_BankMaster";
        public static string SP_BankMaster_Part1 = "SP_BankMaster_Part1";
        public static string Bank_MasterValidation = "Bank_MasterValidation";
        #endregion

        public BankMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
