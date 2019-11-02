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
/// Summary description for Country
/// </summary>
/// 
namespace Build.EntityClass
{
    public class Legend
    {
        #region[constants]
        public static string _Action = "@Action";
        public static string _LegendId = "@LegendId";
        public static string _ProjectId = "@ProjectId";
        public static string _Title = "@Title";
        public static string _Details = "@Details";
      
        //DET TABLE
        public static string _LegendDetID = "@LegendDetID";
        public static string _LegendSubT = "@LegendSubT";

        public static string _UserId="@UserId";
        public static string _LoginDate="@LoginDate";
        public static string _IsDeleted="@IsDeleted";
        public static string  _StrCondition="@StrCond";
        #endregion

        #region[Defination]

        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_LegendId;
        public Int32 LegendId
        {
            get { return m_LegendId; }
            set { m_LegendId = value; }
        }

        private Int32 m_ProjectId;
        public Int32 ProjectId
        {
            get { return m_ProjectId; }
            set { m_ProjectId = value; }
        }

        private String m_Title;
        public String Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        private String m_Details;
        public String Details
        {
            get { return m_Details; }
            set { m_Details = value; }
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

        //LegendDetID
        private Int32 m_LegendDetID;
        public Int32 LegendDetID
        {
            get { return m_LegendDetID; }
            set { m_LegendDetID = value; }
        }
        //LegendSubT

        private string m_LegendSubT;
        public string LegendSubT
        {
            get { return m_LegendSubT; }
            set { m_LegendSubT = value; }
        }

        private string m_StrCondition;

        public string StrCondition
        {
            get { return m_StrCondition; }
            set { m_StrCondition = value; }
        }                         
        #endregion

        #region[procedure]
        public static string SP_LegendMaster = "SP_LegendMaster";
        #endregion
        public Legend()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}