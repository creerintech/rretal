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


    public class ProjectStage
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _ProjectStageId="@ProjectStageId";
        public static string _PCId = "@PCId";
        public static string _ProjectStageDtlsId = "@ProjectStageDtlsId";
        public static string _PaymentSchedule = "@PaymentSchedule";
        public static string _ProjectStageType = "@ProjectStageType";

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
        private Int32 m_ProjectStageId;
        public Int32 ProjectStageId
        {
            get { return m_ProjectStageId; }
            set { m_ProjectStageId = value; }
        }

        private Int32 m_ProjectStageType;

        public Int32 ProjectStageType
        {
            get { return m_ProjectStageType; }
            set { m_ProjectStageType = value; }
        }
        

        private Int32 m_PCId;

        public Int32 PCId
        {
            get { return m_PCId; }
            set { m_PCId = value; }
        }
        private Int32 m_ProjectStageDtlsId;

        public Int32 ProjectStageDtlsId
        {
            get { return m_ProjectStageDtlsId; }
            set { m_ProjectStageDtlsId = value; }
        }
        private string m_PaymentSchedule;

        public string PaymentSchedule
        {
            get { return m_PaymentSchedule; }
            set { m_PaymentSchedule = value; }
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
        public static string SP_ProjectStage = "SP_ProjectStage";
        #endregion
        public ProjectStage()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
