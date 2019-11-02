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
using Build.Utility;
using Build.DataModel;
using Build.DB;
using Build.EntityClass;
using System.Threading;
using System.IO;
using System.Management;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;


public partial class Login : System.Web.UI.Page
{
    #region Private Variable

    DataSet dsLogin = new DataSet();
    CommanFunction obj_Msg = new CommanFunction();
    DMUserLogin obj_Login = new DMUserLogin();
    UserLogin Entity_Login = new UserLogin();
    private string StrError = string.Empty;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
       // DateTime dt1 = DateTime.ParseExact("05-06-2014", "MM-dd-yyyy", CultureInfo.InvariantCulture);

       // if (dt1 <= DateTime.Today)//MM-dd-yyyy
       //// if (DateTime.Compare(DateTime.Now, Convert.ToDateTime("24-12-2013")) >= 0)//MM-dd-yyyy
       // {
       //     Session["ERROR"] = "Your Demo Version Has Expired..";
       //     Response.Redirect("~/ErrorPages/UserAccessDenied.aspx");
       // }   
        if (!Page.IsPostBack)
        { 
            Page.Header.DataBind();
            MakeEmptyForm();

            //LBLSERIALNO.Text = CheckSerial().Replace("-", "");
           
        }
    }

    public void MakeEmptyForm()
    {   
        //Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.Cache.SetNoStore();

        TxtUserName.Text = TxtPass.Text = string.Empty;
        TxtUserName.Focus();
    }
   
    protected void Timer1_Tick(object sender, EventArgs e)
    {
    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            Entity_Login.UserName = TxtUserName.Text.Trim();
            Entity_Login.Password = TxtPass.Text.Trim();

            dsLogin = obj_Login.GetLoginInfo(ref Entity_Login, out StrError);
            if (dsLogin.Tables.Count > 0 && dsLogin.Tables[0].Rows.Count > 0)
            {

                Session.Add("UserName", dsLogin.Tables[0].Rows[0]["UserName"].ToString());
                Session.Add("UserID", dsLogin.Tables[0].Rows[0]["UserID"].ToString());
                Session.Add("Password", dsLogin.Tables[0].Rows[0]["Password"].ToString());
                Session.Add("EmpID", dsLogin.Tables[0].Rows[0]["EmpID"].ToString());
                Session.Add("Admin", dsLogin.Tables[0].Rows[0]["Admin"].ToString());
                if (Convert.ToBoolean(dsLogin.Tables[0].Rows[0]["IsAdmin"].ToString()) == true)
                {
                    Session.Add("UserRole", "Administrator");
                }
                else
                {
                    Session.Add("UserRole", "User");
                }
                if (dsLogin.Tables[1].Rows.Count > 0)
                {
                    Session.Add("DataSet", dsLogin);
                }
                //Response.Redirect("~/Masters/HomeNew.aspx");
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

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
    }
   

    public static string  CheckSerial()
    {
        string res = ExecuteCommandSync("vol");
        const string search = "Number is";
        int startI = res.IndexOf(search, StringComparison.InvariantCultureIgnoreCase);
        string currentDiskID = "";
        if (startI > 0)
        {
            currentDiskID = res.Substring(startI + search.Length).Trim();

        }
        return currentDiskID;
    }

    public static string ExecuteCommandSync(object command)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo =
                new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                string result = proc.StandardOutput.ReadToEnd();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

       
}
