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

    public class ProjectSaleRate
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _PSId = "@PSId";
        public static string _PCId = "@PCId";
        public static string _ProjectType = "@ProjectType";
       // public static string _TowerId = "@TowerId";
        //Dtails
        public static string _SPCSRId = "@SPCSRId";
        public static string _ApplicableDate = "@ApplicableDate";
        public static string _RateperSqft="@RateperSqft";
        public static string _DevelopmentCharges = "@DevelopmentCharges";

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
        private Int32 m_PSId;
        public Int32 PSId
        {
            get { return m_PSId; }
            set { m_PSId = value; }
        }
        private Int32 m_PCId;

        public Int32 PCId
        {
            get { return m_PCId; }
            set { m_PCId = value; }
        }
        private string m_ProjectType;

        public string ProjectType
        {
            get { return m_ProjectType; }
            set { m_ProjectType = value; }
        }
        //public Int32 ProjectTypeId
        //{
        //    get { return m_ProjectTypeId; }
        //    set { m_ProjectTypeId = value; }
        //}
        //private Int32 m_TowerId;
        //public Int32 TowerId
        //{
        //    get { return m_TowerId; }
        //    set { m_TowerId = value; }
        //}
        private Int32 m_SPCSRId;

        public Int32 SPCSRId
        {
            get { return m_SPCSRId; }
            set { m_SPCSRId = value; }
        }
        private decimal m_RateperSqft;

        public decimal RateperSqft
        {
            get { return m_RateperSqft; }
            set { m_RateperSqft = value; }
        }
        private decimal m_DevelopmentCharges;

        public decimal DevelopmentCharges
        {
            get { return m_DevelopmentCharges; }
            set { m_DevelopmentCharges = value; }
        }
        private DateTime m_ApplicableDate;

        public DateTime ApplicableDate
        {
            get { return m_ApplicableDate; }
            set { m_ApplicableDate = value; }
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
        public static string SP_ProjectSaleRate = "SP_ProjectSaleRate";
        #endregion
        public ProjectSaleRate()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
