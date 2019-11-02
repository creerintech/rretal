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
/// Summary description for TaskList
/// </summary>
namespace Build.EntityClass
{
    public class TaskList
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _TaskListId = "@TaskListId";
        //ProjectTypeID
        public static string _TaskDate = "@TaskDate";
        public static string _EmpId = "@EmpId";
        
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@strCond";

        public static string _TaskListDtlId = "@TaskListDtlId";
        public static string _Task = "@Task";
        public static string _Priority = "@Priority";
        public static string _Description = "@Description";
        public static string _RaisedBy = "@RaisedBy";
        public static string _Owner = "@Owner";
        public static string _AssignedTo = "@AssignedTo";
        public static string _ExpectedDate = "@ExpectedDate";
        public static string _CompletedDate = "@CompletedDate";
        public static string _Status = "@Status";
        public static string _Remark = "@Remark";
        public static string _AssigneeRemark = "@AssigneeRemark";

        
        

        #endregion

        #region Definitions

        private string m_AssigneeRemark;

        public string AssigneeRemark
        {
            get { return m_AssigneeRemark; }
            set { m_AssigneeRemark = value; }
        }

        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_TaskListId;

        public Int32 TaskListId
        {
            get { return m_TaskListId; }
            set { m_TaskListId = value; }
        }

        private DateTime m_TaskDate;

        public DateTime TaskDate
        {
            get { return m_TaskDate; }
            set { m_TaskDate = value; }
        } 

        private string m_Task;

        public string Task
        {
            get { return m_Task; }
            set { m_Task = value; }
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

        private int m_TaskListDtlId;

        public int TaskListDtlId
        {
            get { return m_TaskListDtlId; }
            set { m_TaskListDtlId = value; }
        }

        private int m_Priority;

        public int Priority
        {
            get { return m_Priority; }
            set { m_Priority = value; }
        }

        private string m_Description;

        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }

        private int m_RaisedBy;

        public int RaisedBy
        {
            get { return m_RaisedBy; }
            set { m_RaisedBy = value; }
        }

        private int m_Owner;

        public int Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }

        private int m_AssignedTo;

        public int AssignedTo
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

        private int m_Status;

        public int Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        private string m_Remark;

        public string Remark
        {
            get { return m_Remark; }
            set { m_Remark = value; }
        } 
        

        #endregion

        # region Stored Procedure
        public static string SP_TaskListMaster = "SP_TaskListMaster";
        #endregion

        public TaskList()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
