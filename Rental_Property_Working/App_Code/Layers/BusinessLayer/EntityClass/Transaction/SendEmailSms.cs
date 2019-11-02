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
/// Summary description for SendEmailSms
/// </summary>
namespace Build.EntityClass
{
    public class SendEmailSms
    {
        #region[constants]
        public static string _Action = "@Action";
        public static string _SendESId = "@SendESId";
        public static string _SendESDate = "@SendESDate";
        public static string _Stage = "@Stage";
        public static string _ProjectID = "@ProjectID";
        public static string _TowerName = "@TowerName";
        //Details
        public static string _DemandDtlId = "@DemandDtlId";
        public static string _CustomerID = "@CustomerID";
        public static string _Flag = "@Flag";
        public static string _SendESdtlId = "@SendESdtlId";

        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _StrCondition = "@StrCond";

        #endregion

        #region [Defination]
        private Int32 m_Action;

        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_SendESId;

        public Int32 SendESId
        {
            get { return m_SendESId; }
            set { m_SendESId = value; }
        }

        private DateTime m_SendESDate;

        public DateTime SendESDate
        {
            get { return m_SendESDate; }
            set { m_SendESDate = value; }
        }

        private string m_Stage;

        public string Stage
        {
            get { return m_Stage; }
            set { m_Stage = value; }
        }

        private Int32 m_ProjectID;

        public Int32 ProjectID
        {
            get { return m_ProjectID; }
            set { m_ProjectID = value; }
        }
        private String m_TowerName;

        public String TowerName
        {
            get { return m_TowerName; }
            set { m_TowerName = value; }
        }

        private Int32 m_DemandDtlId;

        public Int32 DemandDtlId
        {
            get { return m_DemandDtlId; }
            set { m_DemandDtlId = value; }
        }

        private Int32 m_CustomerID;

        public Int32 CustomerID
        {
            get { return m_CustomerID; }
            set { m_CustomerID = value; }
        }

        private bool m_Flag;

        public bool Flag
        {
            get { return m_Flag; }
            set { m_Flag = value; }
        }

        private Int32 m_SendESdtlId;

        public Int32 SendESdtlId
        {
            get { return m_SendESdtlId; }
            set { m_SendESdtlId = value; }
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
        private String m_StrCond;

        public String StrCond
        {
            get { return m_StrCond; }
            set { m_StrCond = value; }
        }

        #endregion

        #region [Stored Proc]
        public static string SP_SendEmailSms = "SP_SendEmailSms";
        public static string SP_SendEmailSms1 = "SP_SendEmailSms1";
        #endregion
        public SendEmailSms()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}