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
/// Summary description for ReceiptPaymentListing
/// </summary>
namespace Build.EntityClass
{
    public class ReceiptPaymentListing
    {
        #region Column Constant
            public static string _Action = "@Action";
        #endregion

        #region Definitions
            private Int32 m_Action;
            public Int32 Action
            {
                get { return m_Action; }
                set { m_Action = value; }
            }
        #endregion

        # region Stored Procedure
            public static string SP_ReceiptPaymentListing = "SP_ReceiptPaymentListing";
        #endregion

        public ReceiptPaymentListing()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}