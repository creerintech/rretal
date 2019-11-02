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
/// Summary description for DocumentList
/// </summary>
namespace Build.EntityClass
{
    public class DocumentList
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _DocId = "@DocId";
        public static string _ProjectId = "@ProjectId";
        public static string _DocName = "@DocName";
      
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

        private Int32 m_DocId;

        public Int32 DocId
        {
            get { return m_DocId; }
            set { m_DocId = value; }
        }

        private string m_DocName;

        public string DocName
        {
            get { return m_DocName; }
            set { m_DocName = value; }
        }
        //ProjectTypeID
        private Int32 m_ProjectId;
        public Int32 ProjectId
        {
            get { return m_ProjectId; }
            set { m_ProjectId = value; }
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
        public static string SP_DocumentListMaster = "SP_DocumentListMaster";
        #endregion


        public DocumentList()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
