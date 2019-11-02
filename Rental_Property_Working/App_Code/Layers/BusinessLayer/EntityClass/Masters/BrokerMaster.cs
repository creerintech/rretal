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
/// Summary description for BrokerMaster
/// </summary>

namespace Build.EntityClass
{
    public class BrokerMaster
    {
        #region Column Constant
        public static string _Action = "@Action";

        public static string _BrokerName = "@BrokerName";
        public static string _BrokerId = "@BrokerId";
        public static string _BrokerType = "@BrokerType";
        public static string _PANCardNo = "@PANCardNo";
        public static string _ServiceTaxNo = "@ServiceTaxNo";

        public static string _AddressB = "@AddressB";
        public static string _MobileNo = "@MobileNo";
        public static string _Phone = "@Phone";
        public static string _EmailB = "@EmailB";
        public static string _CompanyName = "@CompanyName";
        public static string _FaxNo = "@FaxNo";
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

        private Int32 m_BrokerId;
        public Int32 BrokerId
        {
            get { return m_BrokerId; }
            set { m_BrokerId = value; }
        }

        private int m_BrokerType;

        public int BrokerType
        {
            get { return m_BrokerType; }
            set { m_BrokerType = value; }
        }

        private string m_PANCardNo;
        public string PANCardNo
        {
            get { return m_PANCardNo; }
            set { m_PANCardNo = value; }
        }

        private string m_ServiceTaxNo;
        public string ServiceTaxNo
        {
            get { return m_ServiceTaxNo; }
            set { m_ServiceTaxNo = value; }
        }

        private string m_BrokerName;
        public string BrokerName
        {
            get { return m_BrokerName; }
            set { m_BrokerName = value; }
        }

        private string m_AddressB;
        public string AddressB
        {
            get { return m_AddressB; }
            set { m_AddressB = value; }
        }

        private string m_Phone;
        public string Phone
        {
            get { return m_Phone; }
            set { m_Phone = value; }
        }

        private string m_EmailB;
        public string EmailB
        {
            get { return m_EmailB; }
            set { m_EmailB = value; }
        }

        private string m_MobileNo;
        public string MobileNo
        {
            get { return m_MobileNo; }
            set { m_MobileNo = value; }
        }

        private string m_CompanyName;

        public string CompanyName
        {
            get { return m_CompanyName; }
            set { m_CompanyName = value; }
        }

        private string m_FaxNo;

        public string FaxNo
        {
            get { return m_FaxNo; }
            set { m_FaxNo = value; }
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
        public static string SP_BrokerMaster = "SP_BrokerMaster";
        #endregion


        public BrokerMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}