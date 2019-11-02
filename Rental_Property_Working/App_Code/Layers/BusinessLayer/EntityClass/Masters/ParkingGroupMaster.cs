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
    public class ParkingGroupMaster
    {
        #region Variable
        public static string _Action = "@Action";
        public static string _ParkingGroupId = "@ParkingGroupId";
        public static string _PCId = "@PCId";
        public static string _EmpID = "@EmpID";
        public static string _Building = "@Building";
        public static string _ParkingGroupName = "@ParkingGroupName";
        public static string _ParkingAmount = "@ParkingAmount";
        public static string _ParkingTypeId = "@ParkingTypeId";
        public static string _ParkingSubTypeId = "@ParkingSubTypeId";
        public static string _AciveGroup = "@AciveGroup";
        public static string _NoOfParking = "@NoOfParking";

        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";
        #endregion

        #region[Defination]

        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_ParkingGroupId;
        public Int32 ParkingGroupId
        {
            get { return m_ParkingGroupId; }
            set { m_ParkingGroupId = value; }
        }

        private Int32 m_EmpID;

        public Int32 EmpID
        {
            get { return m_EmpID; }
            set { m_EmpID = value; }
        }

        private bool m_AciveGroup;

        public bool AciveGroup
        {
            get { return m_AciveGroup; }
            set { m_AciveGroup = value; }
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

        private Int32 m_ParkingTypeId;
        public Int32 ParkingTypeId
        {
            get { return m_ParkingTypeId; }
            set { m_ParkingTypeId = value; }
        }

        private Int32 m_ParkingSubTypeId;
        public Int32 ParkingSubTypeId
        {
            get { return m_ParkingSubTypeId; }
            set { m_ParkingSubTypeId = value; }
        }

        private string m_ParkingGroupName;

        public string ParkingGroupName
        {
            get { return m_ParkingGroupName; }
            set { m_ParkingGroupName = value; }
        }

        private decimal m_ParkingAmount;

        public decimal ParkingAmount
        {
            get { return m_ParkingAmount; }
            set { m_ParkingAmount = value; }
        }

        private Int32 m_NoOfParking;
        public Int32 NoOfParking
        {
            get { return m_NoOfParking; }
            set { m_NoOfParking = value; }
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
        public static string SP_ParkingGroupMaster_I = "SP_ParkingGroupMaster_I";
        public static string SP_ParkingGroupMaster_II = "SP_ParkingGroupMaster_II";
        
        #endregion

        public ParkingGroupMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
