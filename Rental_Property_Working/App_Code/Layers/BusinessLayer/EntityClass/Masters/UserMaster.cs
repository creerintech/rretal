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
/// Summary description for UserMaster
namespace Build.EntityClass
{
    [Serializable()]

    public class UserMaster
    {
        #region[Constants]
            public const string _Action="@Action";
            public const string _UserID="@UserID";
            public const string _UserName="@UserName";
            public const string _EmployeeName="@EmployeeName";
            public const string _EmpID="@EmpID";
            public const string _LocationId="@LocationId";
            public const string _EmailId="@EmailId";
            public const string _Password="@Password";
            public const string _UserType="@UserType";
            public const string _Group="@Group";
            public const string _FormCaption="@FormCaption";
            public const string _ViewAuth="@ViewAuth";
            public const string _AddAuth="@AddAuth";
            public const string _DelAuth="@DelAuth";
            public const string _EditAuth="@EditAuth";
            public const string _PrintAuth="@PrintAuth";
            public const string _LUserID="@LUserID";
            public const string _CreatedBy="@CreatedBy";
            public const string _LoginDate="@LoginDate";
            public const string _RepCondition="@RepCondition";
            public const string _IsAdmin = "@IsAdmin";
            public const string _IsDeleted = "@IsDeleted";
            public const string _Cheked = "@Checked";


            public const string _UpdatedBy = "@UpdatedBy";
            public const string _UpdatedDate = "@UpdatedDate";
            public const string _DeletedBy = "@DeletedBy";
            public const string _DeletedDate = "@DeletedDate";
            public const string _FkUserId = "@Fk_UserId";
            public const string _UserId = "@UserId";
            public const string _FormName = "@FormName";
            public const string _PCId = "@PCId";
            public const string _LoginName = "@LoginName";
        #endregion

        #region[Store Procedures]
            public const string SP_USERMASTER = "SP_USERMASTER";   
        #endregion

        #region[Definations]


            private DateTime m_DeletedDate;

            public DateTime DeletedDate
            {
                get { return m_DeletedDate; }
                set { m_DeletedDate = value; }
            }

            private Int32 m_DeletedBy;

            public Int32 DeletedBy
            {
                get { return m_DeletedBy; }
                set { m_DeletedBy = value; }
            }

            private Int32 m_UpdatedBy;

            public Int32 UpdatedBy
            {
                get { return m_UpdatedBy; }
                set { m_UpdatedBy = value; }
            }

            private DateTime m_UpdatedDate;

            public DateTime UpdatedDate
            {
                get { return m_UpdatedDate; }
                set { m_UpdatedDate = value; }
            }

            private string m_LoginName;

            public string LoginName
            {
                get { return m_LoginName; }
                set { m_LoginName = value; }
            }

            private Int32 m_UserID;

            public Int32 UserID
            {
                get { return m_UserID; }
                set { m_UserID = value; }
            }
           
            private Int32 m_PCId;

            public Int32 PCId
            {
                get { return m_PCId; }
                set { m_PCId = value; }
            }

            private string m_FormName;

            public string FormName
            {
                get { return m_FormName; }
                set { m_FormName = value; }
            }

            private Int32 m_FkUserId;

            public Int32 FkUserId
            {
                get { return m_FkUserId; }
                set { m_FkUserId = value; }
            }

            private bool m_IsAdmin;

            public bool IsAdmin
            {
                get { return m_IsAdmin; }
                set { m_IsAdmin = value; }
            }

            private bool m_IsDeleted;

            public bool IsDeleted
            {
                get { return m_IsDeleted; }
                set { m_IsDeleted = value; }
            }



        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

       
        private string m_UserName;
        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }
        private string m_EmployeeName;
        public string EmployeeName
        {
            get { return m_EmployeeName; }
            set { m_EmployeeName = value; }
        }
        private Int32 m_EmpID;
        public Int32 EmpID
        {
            get { return m_EmpID; }
            set { m_EmpID = value; }
        }
        private Int32 m_LocationId;
        public Int32 LocationId
        {
            get { return m_LocationId; }
            set { m_LocationId = value; }
        }
        private string m_EmailId;
        public string EmailId
        {
            get { return m_EmailId; }
            set { m_EmailId = value; }
        }
        private string m_Password;
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }
        private string m_UserType;
        public string UserType
        {
            get { return m_UserType; }
            set { m_UserType = value; }
        }
        private char m_Group;
        public char Group
        {
            get { return m_Group; }
            set { m_Group = value; }
        }
        private string m_FormCaption;
        public string FormCaption
        {
            get { return m_FormCaption; }
            set { m_FormCaption = value; }
        }
        private bool m_ViewAuth;
        public bool ViewAuth
        {
            get { return m_ViewAuth; }
            set { m_ViewAuth = value; }
        }
        private bool m_AddAuth;
        public bool AddAuth
        {
            get { return m_AddAuth; }
            set { m_AddAuth = value; }
        }
        private bool m_DelAuth;
        public bool DelAuth
        {
            get { return m_DelAuth; }
            set { m_DelAuth = value; }
        }
        private bool m_EditAuth;
        public bool EditAuth
        {
            get { return m_EditAuth; }
            set { m_EditAuth = value; }
        }
        private bool m_PrintAuth;
        public bool PrintAuth
        {
            get { return m_PrintAuth; }
            set { m_PrintAuth = value; }
        }
        private Int32 m_LUserID;
        public Int32 LUserID
        {
            get { return m_LUserID; }
            set { m_LUserID = value; }
        }
        private Int32 m_CreatedBy;
        public Int32 CreatedBy
        {
            get { return m_CreatedBy; }
            set { m_CreatedBy = value; }
        }
        private DateTime m_LoginDate;
        public DateTime LoginDate
        {
            get { return m_LoginDate; }
            set { m_LoginDate = value; }
        }
        private string m_RepCondition;
        public string RepCondition
        {
            get { return m_RepCondition; }
            set { m_RepCondition = value; }
        }

        private bool m_Cheked;

        public bool Cheked
        {
            get { return m_Cheked; }
            set { m_Cheked = value; }
        }
        #endregion
        public UserMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
