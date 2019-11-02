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

    public class PropertySubTypeMaster
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _PropertyTypeId = "@PropertyTypeId";

        public static string _PropertySubTypeDesc = "@PropertySubTypeDesc";
        public static string _PropertySubTypeId = "@PropertySubTypeId";

        public static string _LoginId = "@LoginId";
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

        private Int32 m_PropertyTypeId;

        public Int32 PropertyTypeId
        {
            get { return m_PropertyTypeId; }
            set { m_PropertyTypeId = value; }
        }


        private Int32 m_PropertySubTypeId;

        public Int32 PropertySubTypeId
        {
            get { return m_PropertySubTypeId; }
            set { m_PropertySubTypeId = value; }
        }

        private string m_PropertySubTypeDesc;

        public string PropertySubTypeDesc
        {
            get { return m_PropertySubTypeDesc; }
            set { m_PropertySubTypeDesc = value; }
        }

        private Int32 m_LoginId;

        public Int32 LoginId
        {
            get { return m_LoginId; }
            set { m_LoginId = value; }
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
        public static string SP_PropertySubTypeMaster = "SP_PropertySubTypeMaster";
        #endregion

        public PropertySubTypeMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

}
