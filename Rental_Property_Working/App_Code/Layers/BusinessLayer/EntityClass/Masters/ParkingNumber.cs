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
/// Summary description for ParkingNumber
/// </summary>
namespace Build.EntityClass
{
    public class ParkingNumber
    {
        #region[constants]
        public static string _Action = "@Action";
        public static string _ParkingNumberId = "@ParkingNumberId";
        public static string _PCId = "@PCId";
        public static string _Tower = "@Tower";
        public static string _ParkingNo = "@ParkingNo";
        public static string _PNdetailId = "@PNdetailId";
        public static string _TotalParking = "@TotalParking";
        public static string _ParkingTypeId = "@ParkingTypeId";

        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";
        #endregion

        #region [Defination]

        private Int32 m_ParkingNumberId;

        public Int32 ParkingNumberId
        {
            get { return m_ParkingNumberId; }
            set { m_ParkingNumberId = value; }
        }
        private Int32 m_PCId;

        public Int32 PCId
        {
            get { return m_PCId; }
            set { m_PCId = value; }
        }
        private string m_Tower;

        public string Tower
        {
            get { return m_Tower; }
            set { m_Tower = value; }
        }
        private string m_ParkingNo;

        public string ParkingNo
        {
            get { return m_ParkingNo; }
            set { m_ParkingNo = value; }
        }
        private Int32 m_PNdetailId;

        public Int32 PNdetailId
        {
            get { return m_PNdetailId; }
            set { m_PNdetailId = value; }
        }
        private Int32 m_TotalParking;

        public Int32 TotalParking
        {
            get { return m_TotalParking; }
            set { m_TotalParking = value; }
        }
        private Int32 m_ParkingTypeId;

        public Int32 ParkingTypeId
        {
            get { return m_ParkingTypeId; }
            set { m_ParkingTypeId = value; }
        }
    


        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
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

        #region[procedure]
        public static string SP_ParkingNumber = "SP_ParkingNumber";
        #endregion
        public ParkingNumber()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
