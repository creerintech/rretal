using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Threading;
using Build.Utility;
using Build.DataModel;
using Build.DB;
using Build.EntityClass;



public partial class _Default : System.Web.UI.Page
{
    #region Private Variable

        DataSet dsLogin = new DataSet();
        CommanFunction obj_Msg = new CommanFunction();
        DMUserLogin obj_Login = new DMUserLogin();
        UserLogin Entity_Login = new UserLogin();
        private string StrError = string.Empty;

    #endregion

    #region User Functions

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUser.Focus();
    }
    
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            Entity_Login.UserName = txtUser.Text.Trim();
            Entity_Login.Password = txtPass.Text.Trim();

            dsLogin = obj_Login.GetLoginInfo(ref Entity_Login, out StrError);
            if (dsLogin.Tables.Count > 0 && dsLogin.Tables[0].Rows.Count > 0)
            {

                Session.Add("UserName", dsLogin.Tables[0].Rows[0]["UserName"].ToString());
                Session.Add("UserID", dsLogin.Tables[0].Rows[0]["UserID"].ToString());
                Session.Add("Password", dsLogin.Tables[0].Rows[0]["Password"].ToString());

                if (Convert.ToBoolean(dsLogin.Tables[0].Rows[0]["IsAdmin"].ToString()) == true)
                {
                    Session.Add("UserRole", "Administrator");
                }
                else
                {
                    Session.Add("UserRole", "User");
                }
                //Session.Add("DataSet", dsLogin); After Setting User Right if Req.
                Response.Redirect("~/Masters/Home.aspx");

            }
            else
            {
                obj_Msg.ShowPopUpMsg("Invalid Login....!!", this.Page);
                // UserLogin.Authenticate=false ;
            }

        }
        catch (ThreadAbortException)
        {
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }
}
