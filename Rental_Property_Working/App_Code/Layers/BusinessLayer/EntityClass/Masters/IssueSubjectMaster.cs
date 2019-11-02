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
    public class IssueSubjectMaster
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _IssueSubjectId = "@IssueSubjectId";
        public static string _IssueSubject = "@IssueSubject";
        public static string _Answer = "@Answer";

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

        private Int32 m_IssueSubjectId;

        public Int32 IssueSubjectId
        {
            get { return m_IssueSubjectId; }
            set { m_IssueSubjectId = value; }
        }

        private string m_IssueSubject;

        public string IssueSubject
        {
            get { return m_IssueSubject; }
            set { m_IssueSubject = value; }
        }

        private string m_Answer;

        public string Answer
        {
            get { return m_Answer; }
            set { m_Answer = value; }
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
        public static string SP_IssueSubjectMaster = "SP_IssueSubjectMaster";
        #endregion

        public IssueSubjectMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
