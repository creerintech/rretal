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
    public class FlatLayout
    {
        #region Variable
        public static string _Action = "@Action";
        public static string _PCId = "@PCId";
        public static string _Building = "@Building";
        public static string _PCDetailId = "@PCDetailId";
        public static string _ImagePath = "@ImagePath";
        public static string _LayoutTypeId = "@LayoutTypeId";
        public static string _FlatLayoutId = "@FlatLayoutId";
        public static string _UnitNoDtlsId = "@UnitNoDtlsId";
        public static string _FloorId = "@FloorId";
        public static string _FloorName = "@FloorName";
        public static string _FloorDtlsId = "@FloorDtlsId";


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

        private Int32 m_PCDetailId;
        public Int32 PCDetailId
        {
            get { return m_PCDetailId; }
            set { m_PCDetailId = value; }
        }

        private string m_ImagePath;

        public string ImagePath
        {
            get { return m_ImagePath; }
            set { m_ImagePath = value; }
        }

        private Int32 m_LayoutTypeId;

        public Int32 LayoutTypeId
        {
            get { return m_LayoutTypeId; }
            set { m_LayoutTypeId = value; }
        }

        private Int32 m_FlatLayoutId;

        public Int32 FlatLayoutId
        {
            get { return m_FlatLayoutId; }
            set { m_FlatLayoutId = value; }
        }

        private Int32 m_UnitNoDtlsId;

        public Int32 UnitNoDtlsId
        {
            get { return m_UnitNoDtlsId; }
            set { m_UnitNoDtlsId = value; }
        }

        private Int32 m_FloorId;

        public Int32 FloorId
        {
            get { return m_FloorId; }
            set { m_FloorId = value; }
        }

        private string m_FloorName;

        public string FloorName
        {
            get { return m_FloorName; }
            set { m_FloorName = value; }
        }

        private Int32 m_FloorDtlsId;

        public Int32 FloorDtlsId
        {
            get { return m_FloorDtlsId; }
            set { m_FloorDtlsId = value; }
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


        #endregion

        #region[procedure]
        public static string SP_UploadFlatLayout = "SP_UploadFlatLayout";
        public static string SP_UploadFlatLayout_Part1 = "SP_UploadFlatLayout_Part1";   
        #endregion
        public FlatLayout()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
