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
/// Summary description for DetailsOfRevenue
/// </summary>
namespace Build.EntityClass
{
    public class DetailsOfRevenue
    {
        #region Column Constant
            public static string _Action = "@Action";
            public static string _EmpID = "@EmpID";
        #endregion

        #region Definitions
            private Int32 m_Action;
            public Int32 Action
            {
                get { return m_Action; }
                set { m_Action = value; }
            }
            private Int32 m_EmpID;

            public Int32 EmpID
            {
                get { return m_EmpID; }
                set { m_EmpID = value; }
            }
        #endregion

        # region Stored Procedure
            public static string SP_DetailsOfRevenue = "SP_DetailsOfRevenue";
        #endregion

        public DetailsOfRevenue()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}