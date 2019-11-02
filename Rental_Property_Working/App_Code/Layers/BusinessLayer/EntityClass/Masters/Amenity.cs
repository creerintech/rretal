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
    public class Amenity
    {
        #region[constants]
        public static string _Action = "@Action";
        public static string _AmenityId = "@AmenityId";
        public static string _ProjectId = "@ProjectId";
        public static string _Title = "@Title";
        public static string _Details = "@Details";
      
        //DET TABLE
        public static string _AmenityDetID = "@AmenityDetID";
        public static string _AmenitySubT = "@AmenitySubT";


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

        private Int32 m_AmenityId;
        public Int32 AmenityId
        {
            get { return m_AmenityId; }
            set { m_AmenityId = value; }
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

        //AmenityDetID
        private Int32 m_AmenityDetID;
        public Int32 AmenityDetID
        {
            get { return m_AmenityDetID; }
            set { m_AmenityDetID = value; }
        }
        //AmenitySubT

        private string m_AmenitySubT;
        public string AmenitySubT
        {
            get { return m_AmenitySubT; }
            set { m_AmenitySubT = value; }
        }

        private string m_StrCondition;

        public string StrCondition
        {
            get { return m_StrCondition; }
            set { m_StrCondition = value; }
        }                         
        #endregion

        #region[procedure]
        public static string SP_AminityMaster = "SP_AminityMaster";
        #endregion
        public Amenity()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}