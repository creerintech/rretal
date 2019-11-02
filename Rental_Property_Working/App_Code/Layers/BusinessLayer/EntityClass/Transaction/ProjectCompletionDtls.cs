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
    public class ProjectCompletionDtls
    {
        #region[constants]
        public static string _Action = "@Action";
        public static string _ProjectCompletionId = "@ProjectCompletionId";        
        public static string _PCId = "@PCId";
        public static string _EmpID = "@EmpID";
        public static string _Building = "@Building";
        public static string _PSdtlId = "@PSdtlId";
        public static string _PCDetailId = "@PCDetailId";
        public static string _CompletionDate = "@CompletionDate";

        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@strCond";
        #endregion

        #region[Defination]

        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }


        private Int32 m_ProjectCompletionId;
        public Int32 ProjectCompletionId
        {
            get { return m_ProjectCompletionId; }
            set { m_ProjectCompletionId = value; }
        }

        private DateTime m_CompletionDate;
        public DateTime CompletionDate
        {
            get { return m_CompletionDate; }
            set { m_CompletionDate = value; }
        }
        private Int32 m_EmpID;

        public Int32 EmpID
        {
            get { return m_EmpID; }
            set { m_EmpID = value; }
        }
        private Int32 m_PCId;
        public Int32 PCId
        {
            get { return m_PCId; }
            set { m_PCId = value; }
        }

        private string m_Building;
        public string Building
        {
            get { return m_Building; }
            set { m_Building = value; }
        }

        private Int32 m_PCDetailId;
        public Int32 PCDetailId
        {
            get { return m_PCDetailId; }
            set { m_PCDetailId = value; }
        }

        private Int32 m_PSdtlId;

        public Int32 PSdtlId
        {
            get { return m_PSdtlId; }
            set { m_PSdtlId = value; }
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

        public ProjectCompletionDtls()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
