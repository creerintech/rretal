using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MasterPages_MasterPage_RN : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            lblLoggedInUserNm.Text = string.Empty;
            lblLoggedInUserNm.Text = lblLoggedInUserNm.Text + " " + Session["UserName"].ToString();
        }
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Remove("UserName");
        Session.Remove("UserID");
        Session.Remove("Password");
        Session.Remove("EmpID");
        Session.Remove("Admin");
        Session.Remove("UserRole");
        Session.Remove("DataSet");
        Response.Redirect("~/Default.aspx");
    }
}
