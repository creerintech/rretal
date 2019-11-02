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
/// Summary description for CustomerGrievance
/// </summary>
namespace Build.EntityClass
{
    public class CustomerGrievance
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _GrievanceId = "@GrievanceId";
        public static string _GrievanceDate = "@GrievanceDate";
        public static string _EmpId = "@EmpId";
        public static string _GrievanceDtlsId = "@GrievanceDtlsId";
        public static string _CustId = "@CustId";
        public static string _PCId = "@PCId";
        public static string _FlatNo = "@FlatNo";
        public static string _ContactDtls = "@ContactDtls";
        public static string _Issue = "@Issue";
        public static string _RelatedTo = "@RelatedTo";
        public static string _AssignedTo = "@AssignedTo";
        public static string _ExpectedDate = "@ExpectedDate";
        public static string _CompletedDate = "@CompletedDate";
        public static string _Status = "@Status";
        public static string _Solution = "@Solution";
        public static string _Comments = "@Comments";

        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@strCond";
        #endregion

        #region Definitions
        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_GrievanceId;

        public Int32 GrievanceId
        {
            get { return m_GrievanceId; }
            set { m_GrievanceId = value; }
        }

        private DateTime m_GrievanceDate;

        public DateTime GrievanceDate
        {
            get { return m_GrievanceDate; }
            set { m_GrievanceDate = value; }
        }

        private Int32 m_CustId;

        public Int32 CustId
        {
            get { return m_CustId; }
            set { m_CustId = value; }
        }


        private Int32 m_PCId;

        public Int32 PCId
        {
            get { return m_PCId; }
            set { m_PCId = value; }
        }

        private string m_FlatNo;

        public string FlatNo
        {
            get { return m_FlatNo; }
            set { m_FlatNo = value; }
        }

        private string m_ContactDtls;

        public string ContactDtls
        {
            get { return m_ContactDtls; }
            set { m_ContactDtls = value; }
        }

        private string m_Issue;

        public string Issue
        {
            get { return m_Issue; }
            set { m_Issue = value; }
        }
        private Int32 m_RelatedTo;

        public Int32 RelatedTo
        {
            get { return m_RelatedTo; }
            set { m_RelatedTo = value; }
        }
        private Int32 m_AssignedTo;

        public Int32 AssignedTo
        {
            get { return m_AssignedTo; }
            set { m_AssignedTo = value; }
        }

        private DateTime m_ExpectedDate;

        public DateTime ExpectedDate
        {
            get { return m_ExpectedDate; }
            set { m_ExpectedDate = value; }
        }

        private DateTime m_CompletedDate;

        public DateTime CompletedDate
        {
            get { return m_CompletedDate; }
            set { m_CompletedDate = value; }
        }

        private Int32 m_Status;

        public Int32 Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }
        private string m_Solution;
        public string Solution
        {
            get { return m_Solution; }
            set { m_Solution = value; }
        }

        private string m_Comments;

        public string Comments
        {
            get { return m_Comments; }
            set { m_Comments = value; }
        }
       
        private Int32 m_EmpId;

        public Int32 EmpId
        {
            get { return m_EmpId; }
            set { m_EmpId = value; }
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

        public static string SP_GrievanceMaster = "SP_GrievanceMaster";
        public CustomerGrievance()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
