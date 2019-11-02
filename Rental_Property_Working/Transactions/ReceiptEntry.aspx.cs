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
using System.Data.SqlClient;
using Build.Utility;
using Build.EntityClass;
using Build.DB;
using Build.DataModel;
using Build.DALSQLHelper;
using System.Threading;
using System.Text;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class Transactions_ReceiptEntry : System.Web.UI.Page
{

    #region[Private Variables]
    DMReceiptMaster Obj_Receipt = new DMReceiptMaster();
    ReceiptMaster Entity_Receipt = new ReceiptMaster();
    CommanFunction Obj_Comm = new CommanFunction();
    DMReport obj_PO = new DMReport();
    DataSet DS = new DataSet();
    ReportDocument CRpt = new ReportDocument();
    string ReceiptNum = string.Empty;
    private string StrError = string.Empty;
    private string StrCondition = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false, FlagPrint = false;

    #endregion

    public void ReceiptNo()
    {
        try
        {
            DataSet DsCode = new DataSet();
            DsCode = Obj_Receipt.GetReceiptNo(out StrError);
            if (DsCode.Tables[0].Rows.Count > 0)
            {
                ReceiptNum = DsCode.Tables[0].Rows[0]["ReceiptNo"].ToString();
            }
            txtVoucherNo.Text = ReceiptNum;
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    private void FillCombo()
    {
        try
        {
            DS = Obj_Receipt.BindCombo(out StrError);
            if (DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    ddlPROPERTYTo.DataSource = DS.Tables[0];
                    ddlPROPERTYTo.DataTextField = "Property";
                    ddlPROPERTYTo.DataValueField = "PropertyId";
                    ddlPROPERTYTo.DataBind();
                }

                if (DS.Tables[1].Rows.Count > 0)
                {
                    ddlReceivedFrom.DataSource = DS.Tables[1];
                    ddlReceivedFrom.DataTextField = "PartyName";
                    ddlReceivedFrom.DataValueField = "PartyId";
                    ddlReceivedFrom.DataBind();
                }               
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }

    }

    private void MakeEmptyForm()
    {
        ViewState["EditId"] = null;
        ViewState["GridIndex"] = null;


        ddlReceivedFrom.SelectedValue = "0";
        ddlPROPERTYTo.SelectedValue = "0";
        txtUnitNO.Text = string.Empty;
        txtMonthDate.Text = DateTime.Now.ToString("MMM-yyyy");
        txtAmount.Text = "0";
        txtVoucherNo.Enabled = false;
        txtVoucherNo.Text = string.Empty;
        txtDate.Text = DateTime.Now.ToString("dd MMM yyyy");
        txtPaidAmount.Enabled = false;
        txtRemAmt.Enabled = false;
        txtNarration.Text = string.Empty;
        TxtSearch.Text = string.Empty;
        txtAmtinWord.Text = string.Empty;
        txtAmount.Text = string.Empty;

        BtnUpdate.Visible = false;
        BtnCancel.Visible = true;
        FillCombo();
        ReceiptNo();
       // SetInitialRow();

        //7-4-2013
        //SetInitialRowStages();
      

        txtDiffAmt.Text = "";


        ReportGrid(StrCondition);
        BtnSave.Visible = true;

        //#region[UserRights]
        //if (FlagAdd)
        //{
        //    BtnSave.Visible = false;
        //}
        //if (FlagEdit)
        //{
        //    BtnUpdate.Visible = false;
        //}
        //if (FlagDel)
        //{
        //    foreach (GridViewRow GRow in GrdReport.Rows)
        //    {
        //        GRow.FindControl("ImgBtnDelete").Visible = false;
        //    }
        //}
        //if (FlagPrint)
        //{
        //    foreach (GridViewRow GRow in GrdReport.Rows)
        //    {
        //        GRow.FindControl("Image1").Visible = false;
        //    }
        //}
        //#endregion
    }

    //private void FillComboMonthYear()
    //{
    //    try
    //    {
    //        string Input = string.Empty;
    //        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
    //        DataTable DTMonthAll = new DataTable();
    //        DTMonthAll.Columns.Add("BillingMonth");
    //        DTMonthAll.Columns.Add("ID");
    //        int cnt = 0;

    //        DataTable dtCutDate = (DataTable)ViewState["CutOffDate"];

    //        for (int i = 0; i < dtCutDate.Rows.Count; i++)
    //        {
    //            ddlMonth.Items.Add(new ListItem(info.GetMonthName(DateTime.Parse(dtCutDate.Rows[i][0].ToString()).Month) + " - " + DateTime.Parse(dtCutDate.Rows[i][0].ToString()).Year.ToString(), i.ToString()));
    //            DataRow dr;
    //            dr = DTMonthAll.NewRow();
    //            dr[0] = info.GetMonthName(DateTime.Parse(dtCutDate.Rows[i][0].ToString()).Month) + " - " + DateTime.Parse(dtCutDate.Rows[i][0].ToString()).Year.ToString();
    //            dr[1] = DateTime.Parse(dtCutDate.Rows[i][0].ToString()).Month;

    //            DTMonthAll.Rows.Add(dr);
    //        }

    //        cnt = 0;

    //        DataTable DD = DTMonthAll;
    //        ////DD.Rows.Add("--Select Month Year--", "0");
    //        //DataSet DS = Obj_Con.FillMonth(Convert.ToInt32(ddlProject.SelectedValue.ToString()), Convert.ToInt32(ddlContractor.SelectedValue.ToString()), out StrError);
    //        //if (DS.Tables.Count > 0)
    //        //{
    //        //    if (DS.Tables[0].Rows.Count > 0)
    //        //    {
    //        //        DataTable DTComplete = DS.Tables[0];
    //        //        for (int i = 0; i < DTComplete.Rows.Count; i++)
    //        //        {
    //        //            for (int j = 0; j < DD.Rows.Count; j++)
    //        //            {
    //        //                if (DTComplete.Rows[i]["BillingMthYr"].ToString() == DD.Rows[j]["BillingMonth"].ToString())
    //        //                {
    //        //                    DD.Rows.Remove(DD.Rows[j]);
    //        //                }
    //        //            }
    //        //        }
    //        //        ddlMonth.DataSource = DD;
    //        //        ddlMonth.DataTextField = "BillingMonth";
    //        //        ddlMonth.DataValueField = "ID";
    //        //        ddlMonth.DataBind();
    //        //        //ddlMonth.DataSource = ;
    //        //        //ddlMonth.DataBind();
    //        //    }
    //        //}
    //        DD.Rows.Add(" --Select Month Year--", 0);
    //        DD.DefaultView.Sort = "BillingMonth";
    //        ddlMonth.DataSource = DD.DefaultView.ToTable();
    //        ddlMonth.DataTextField = "BillingMonth";
    //        ddlMonth.DataValueField = "ID";

    //        ddlMonth.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        //throw new Exception(ex.Message);
    //        Obj_Comm.ErrorLog("DepartmentActivityRegister.aspx", "FillCombo", ex.Message, ex.StackTrace, ex.Source, 1);
    //        Obj_Comm.ShowPopUpMsg("Please try after Some Time..!", this.Page);
    //    }
    //}

    private void GETDATAFORMAIL(int From, int ClientCompanyID)
    {
        try
        {
           
            //DataSet DS = new DataSet();
            //string To = string.Empty;
            //string CC = string.Empty;
            //string Body = string.Empty;
            //int CompanyIndex = 1;                     
         
            //DS = null;        
            //string description = Server.HtmlDecode("HELLO,<br /><br />PLEASE FIND ATTACHED A RENTAL RECEIPT.<br />REGARDS,<br />", Environment.NewLine);
            //TxtBody.Text = description;
            //LBLID.Text = Convert.ToString(ViewState["MailID"]);
          //  GETPDF(Convert.ToInt32(ViewState["MailID"]));

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    //public string GETPDF(int reqid)
    //{
    //    //DMReport obj_PO = new DMReport();
    //    //string StrError = string.Empty;
    //    //string PDFMaster = string.Empty;
    //    //ReportDocument CRpt = new ReportDocument();
    //    //DataSet dslogin = new DataSet();
    //    //dslogin = obj_PO.GetReceiptForPrint(reqid, out StrError);

    //    //if (dslogin.Tables.Count <= 0)
    //    //{
    //    //    return string.Empty;
    //    //}
      
    //    //dslogin.Tables[0].TableName = "ReceiptMaster";
      
    //    ////-------------------------------------------------------------------------------------------
    //    //CRpt.Load(Server.MapPath("~/PrintReport/CryRptReceiptWithoutDetails.rpt");
    //    //CRpt.SetDataSource(dslogin);
    //    //string DATE = DateTime.Now.ToString("dd-MMM-yyyy ss");
    //    //PDFMaster = Server.MapPath(@"~/TempFiles/" + "Rent - " + DATE + ".pdf");
    //    //CRpt.ExportToDisk(ExportFormatType.PortableDocFormat, PDFMaster);
    //    //CHKATTACHBROUCHER.Checked = true;
    //    //CHKATTACHBROUCHER.Text = "Rent Details";
    //    //CHKATTACHBROUCHER.ToolTip = PDFMaster;
    //    //iframepdf.Attributes.Add("src", "../TempFiles/" + "Rent - " + (DATE) + ".pdf");
    //    return PDFMaster;
    //}

    private void ReportGrid(string RepCondition)
    {
        try
        {          
            DS = Obj_Receipt.GetReceiptList(RepCondition, out StrError);
            if (DS.Tables.Count > 0)
            {
               
                GrdReport.DataSource = DS;
                GrdReport.DataBind();
               
                Session["dtEmail"] = DS;
            }

            DS = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MakeEmptyForm();
        }        
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        DateTime dt1;

        String dtpFromDate = string.Empty;

        String Str1 = txtMonthDate.Text.Split('-')[0];
        String Str2 = txtMonthDate.Text.Split('-')[1];

        //string str = Convert.ToString(ddlPROPERTYTo.SelectedItem);
        //string[] s = str.Split('-');

        int monthIndex;
        string desiredMonth = txtMonthDate.Text.Split('-')[0];
        string[] MonthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        monthIndex = Array.IndexOf(MonthNames, desiredMonth) + 1;


        //  dtpFromDate = Convert.ToDateTime(txtMonthDate.Text).ToString("01-MMM-yyyy");
        dtpFromDate = Convert.ToDateTime(txtMonthDate.Text).ToString("01-MM-yyyy");

        int InsertRow = 0, InsertRowDtls = 0, UpdateProRent = 0, UpdateProMonth = 0, UpdateRemAmt=0;
        Entity_Receipt.ReceiptNo = txtVoucherNo.Text.ToUpper();


        Entity_Receipt.ReceiptDate = (!string.IsNullOrEmpty(txtDate.Text)) ? Convert.ToDateTime(txtDate.Text.Trim()) : Convert.ToDateTime("01-Jan-1753");

        Entity_Receipt.PartyId = Convert.ToInt32(ddlReceivedFrom.SelectedValue);
        Entity_Receipt.PropertyId = Convert.ToInt32(ddlPROPERTYTo.SelectedValue);

        string str = Convert.ToString(ddlPROPERTYTo.SelectedItem);
        string[] s = str.Split('-');

        Entity_Receipt.VoucherAmt = Convert.ToDecimal(txtAmount.Text);

        Entity_Receipt.PaidAmount = Convert.ToDecimal(txtPaidAmount.Text);

        Entity_Receipt.RemainingAmt = Convert.ToDecimal(txtRemAmt.Text);

       // Entity_Receipt.ForTheMonth = (!string.IsNullOrEmpty(txtMonthDate.Text)) ? Convert.ToDateTime(txtMonthDate.Text.Trim()) : Convert.ToDateTime("01-Jan-1753");

        Entity_Receipt.ForTheMonth = Convert.ToDateTime(dtpFromDate);
        Entity_Receipt.UnitNo = s[1];

        Entity_Receipt.Narration = txtNarration.Text.ToUpper();
      
        Entity_Receipt.UserId = Convert.ToInt32(Session["UserID"]);
        Entity_Receipt.LoginDate = DateTime.Now;


        Entity_Receipt.FortheMonthYear = txtMonthDate.Text.ToString();

       InsertRow = Obj_Receipt.InsertReceiptNew(ref Entity_Receipt, out StrError);

        if (InsertRow > 0)
        {
            if (Convert.ToDecimal(txtRemAmt.Text) == 0)
            {

                Entity_Receipt.ReceiptVoucherId = InsertRow;
                UpdateProRent = Obj_Receipt.UpdatePropertRentDtls(ref Entity_Receipt, out StrError);

                UpdateProMonth = Obj_Receipt.UpdatePropertMonthmapping(ref Entity_Receipt, out StrError);
            }
            else
            {
                UpdateRemAmt = Obj_Receipt.UpdateAmtPropertMonthmapping(ref Entity_Receipt, out StrError);
            }

        }

        if (InsertRow > 0)
        {
            Obj_Comm.ShowPopUpMsg("Record Saved Successfully", this.Page);
            
            MakeEmptyForm();
          
            Entity_Receipt = null;
            Obj_Receipt = null;
          
        }


    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int iUpdated = 0, idetrow = 0,UpdateProRent = 0, UpdateProMonth = 0, UpdateRemAmt=0;;
        DataSet DSC = new DataSet();
        try
        {
            Entity_Receipt.ReceiptVoucherId = Convert.ToInt32(ViewState["EditID"]);
            Entity_Receipt.ReceiptNo = txtVoucherNo.Text.ToUpper();
            Entity_Receipt.ReceiptDate = (!string.IsNullOrEmpty(txtDate.Text)) ? Convert.ToDateTime(txtDate.Text.Trim()) : Convert.ToDateTime("01-Jan-1753");

            Entity_Receipt.PartyId = Convert.ToInt32(ddlReceivedFrom.SelectedValue);
            Entity_Receipt.PropertyId = Convert.ToInt32(ddlPROPERTYTo.SelectedValue);
            Entity_Receipt.VoucherAmt = Convert.ToDecimal(txtAmount.Text);
            Entity_Receipt.PaidAmount = Convert.ToDecimal(txtPaidAmount.Text);

            Entity_Receipt.RemainingAmt = Convert.ToDecimal(txtRemAmt.Text);
            Entity_Receipt.ForTheMonth = (!string.IsNullOrEmpty(txtMonthDate.Text)) ? Convert.ToDateTime(txtMonthDate.Text.Trim()) : Convert.ToDateTime("01-Jan-1753");
            Entity_Receipt.UnitNo = txtUnitNO.Text.ToUpper();

            Entity_Receipt.Narration = txtNarration.Text.ToUpper();

            Entity_Receipt.UserId = Convert.ToInt32(Session["UserID"]);
            Entity_Receipt.LoginDate = DateTime.Now;

            iUpdated = Obj_Receipt.UpdatetReceiptVoucher(ref Entity_Receipt, out StrError);

            if (iUpdated > 0)
            {
                if (Convert.ToDecimal(txtRemAmt.Text) == 0)
                {

                    Entity_Receipt.ReceiptVoucherId = Convert.ToInt32(ViewState["EditID"]);
                    UpdateProRent = Obj_Receipt.UpdatePropertRentDtls(ref Entity_Receipt, out StrError);

                    UpdateProMonth = Obj_Receipt.UpdatePropertMonthmapping(ref Entity_Receipt, out StrError);
                }
                else
                {
                    UpdateRemAmt = Obj_Receipt.UpdateAmtPropertMonthmapping(ref Entity_Receipt, out StrError);
                }

            }

            if (iUpdated > 0)
            {
                Obj_Comm.ShowPopUpMsg("Record Update Successfully..!", this.Page);
            }
            MakeEmptyForm();
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg("Please try after Some Time..!", this.Page);
        }
    }

    #region[WebService]

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        DMReceiptMaster Obj_Con = new DMReceiptMaster();
        String[] SearchList = Obj_Con.GetSuggestRecord(prefixText);
        return SearchList;
    }

    #endregion

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        try
        {
            StrCondition = TxtSearch.Text;
            ReportGrid(StrCondition);
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }
   
    protected void GrdReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            switch (e.CommandName)
            {
                case ("Select"):
                    {
                        if (Convert.ToInt32(e.CommandArgument) != 0)
                        {
                            ViewState["EditID"] = Convert.ToInt32(e.CommandArgument);

                            DS = Obj_Receipt.GetReceiptToEdit(Convert.ToInt32(e.CommandArgument), out StrError);

                            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                            {

                                txtVoucherNo.Text = DS.Tables[0].Rows[0]["ReceiptNo"].ToString();
                                txtDate.Text = DS.Tables[0].Rows[0]["ReceiptDate"].ToString();
                                txtNarration.Text = DS.Tables[0].Rows[0]["Narration"].ToString();

                                ddlPROPERTYTo.SelectedValue = DS.Tables[0].Rows[0]["PropertyId"].ToString();
                                ddlReceivedFrom.SelectedValue = DS.Tables[0].Rows[0]["PartyId"].ToString();

                                txtUnitNO.Text = DS.Tables[0].Rows[0]["UnitNo"].ToString();
                                txtMonthDate.Text = DS.Tables[0].Rows[0]["ForTheMonth"].ToString();
                                txtAmount.Text = DS.Tables[0].Rows[0]["VoucherAmt"].ToString();
                                txtPaidAmount.Text = DS.Tables[0].Rows[0]["PaidAmount"].ToString();

                                txtRemAmt.Text = DS.Tables[0].Rows[0]["RemainingAmt"].ToString();
                                txtRemAmountCal.Text = DS.Tables[0].Rows[0]["RemainingAmt"].ToString();

                                if (!FlagEdit)
                                    BtnUpdate.Visible = true;
                                BtnSave.Visible = false;
                            }
                            else
                            {
                                MakeEmptyForm();
                            }
                        }

                        break;
                    }

                //case ("MailPO"):
                //    {
                //        //TRLOADING.Visible = false;
                //        //ViewState["MailID"] = Convert.ToInt32(e.CommandArgument);
                //        //GETDATAFORMAIL(1, 1);
                //        //MDPopUpYesNoMail.Show();
                //        //BtnPopMail.Focus();
                //    }
                //    break;

                #region Email
                case ("Email"):
                    {
                        if (Convert.ToInt32(e.CommandArgument) != 0)
                        {
                            ViewState["EditID"] = Convert.ToInt32(e.CommandArgument);
                            GridViewRow gv = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);




                            //ID = Convert.ToInt32(Request.QueryString["ID"]);
                            DS = obj_PO.GetReceiptForPrint(Convert.ToInt32(ViewState["EditID"]), out StrError);

                            if (DS.Tables.Count > 0)
                            {
                                if (DS.Tables[0].Rows.Count > 0)
                                {
                                    DataColumn column = new DataColumn("AmountInWords");
                                    column.DataType = typeof(string);
                                    DS.Tables[0].Columns.Add("AmountInWords");
                                    for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                    {
                                        DS.Tables[0].Rows[i]["AmountInWords"] = WordAmount.convertcurrency(Convert.ToDecimal(DS.Tables[0].Rows[i]["VoucherAmt"]));
                                    }

                                    //DS.Tables[1].Columns.Add("LogoImg1", System.Type.GetType("System.Byte[]"));
                                    ////DS.Tables[1].Columns.Add("LogoImg2", System.Type.GetType("System.Byte[]"));
                                    ////DS.Tables[1].Columns.Add("LogoImg3", System.Type.GetType("System.Byte[]"));
                                    //if (DS.Tables[1].Rows.Count - 1 >= 0)
                                    //{
                                    //    if (System.IO.File.Exists(Server.MapPath(DS.Tables[1].Rows[0]["LogoImg"].ToString())))
                                    //    {
                                    //        FileStream fs;
                                    //        BinaryReader br;
                                    //        fs = new FileStream(Server.MapPath(DS.Tables[1].Rows[0]["LogoImg"].ToString()), FileMode.Open);
                                    //        br = new BinaryReader(fs);
                                    //        byte[] imgbyteLogo = new byte[fs.Length + 1];
                                    //        imgbyteLogo = br.ReadBytes(Convert.ToInt32((fs.Length)));
                                    //        DS.Tables[1].Rows[0]["LogoImg1"] = imgbyteLogo;
                                    //        br.Close();
                                    //        fs.Close();
                                    //    }
                                    //}

                                    //for (int i = 0; i < DS.Tables[1].Rows.Count; i++)
                                    //{
                                    //    DS.Tables[1].Rows[i]["LogoImg1"] = DS.Tables[1].Rows[0]["LogoImg1"];
                                    //    //DS.Tables[1].Rows[i]["LogoImg2"] = DS.Tables[1].Rows[0]["LogoImg2"];
                                    //    //DS.Tables[1].Rows[i]["LogoImg3"] = DS.Tables[1].Rows[0]["LogoImg3"];
                                    //    DS.Tables[1].Rows[i]["CompanyAddress"] = DS.Tables[1].Rows[0]["CompanyAddress"];

                                    //}

                                    DS.Tables[0].TableName = "ReceiptMaster";
                                    //DS.Tables[1].TableName = "ReceiptCompany";
                                    //DS.Tables[2].TableName = "ChargeDetails";
                                    ////DS.Tables[3].TableName = "TaxDetails";
                                    ////DS.Tables[4].TableName = "AgreementValueDetails";
                                    CRpt.Load(Server.MapPath("~/PrintReport/CryRptReceiptWithoutDetails.rpt"));
                                    //CRpt.Load(Server.MapPath("~/PrintReport/CryRptGaganReceiptEmail.rpt"));
                                    CRpt.SetDataSource(DS);
                                    ////CRpt.SetParameterValue(0, int.Parse(DS.Tables[0].Rows[0]["PrintCnt"].ToString()));
                                    ////CRpt.SetParameterValue(1, DS.Tables[1].Rows[0]["Company"].ToString());
                                    //////CRPrint.ReportSource = CRpt;
                                    //////CRPrint.DataBind();
                                    //////CRPrint.DisplayToolbar = true;



                                    //------- Add New Code For Print-----
                                    //if (Print_Flag != 0)
                                    //{
                                    //    //CRpt.PrintOptions.PrinterName = "Send To OneNote 2007";
                                    //    //  CRpt.PrintToPrinter(1, false, 0, 0);
                                    //}

                                    #region Email
                                    DataSet grdDataset = (DataSet)Session["dtEmail"];
                                    DataTable GrdReport1 = grdDataset.Tables[0];
                                    string PDFmail = string.Empty;
                                    //string Email = Request.QueryString["Email"];
                                    string Email = DS.Tables[0].Rows[0]["Email"].ToString();
                                    string PCName = DS.Tables[0].Rows[0]["Property"].ToString(); //Request.QueryString["PCName"];
                                    Int64 TotalFiles = System.IO.Directory.GetFiles(Server.MapPath("~/ReceiptEmail/")).Count();
                                    PDFmail = Server.MapPath(@"~/ReceiptEmail/" + "Email - " + (DateTime.Now).ToString("dd-MMM-yyyy") + TotalFiles.ToString() + ".pdf");
                                    CRpt.Load(Server.MapPath("~/PrintReport/CryRptReceiptWithoutDetails.rpt"));
                                    CRpt.SetDataSource(DS);
                                    //CRpt.SetParameterValue(0, int.Parse(DS.Tables[0].Rows[0]["PrintCnt"].ToString()));
                                    //CRpt.SetParameterValue(1, DS.Tables[1].Rows[0]["Company"].ToString());
                                    CRpt.ExportToDisk(ExportFormatType.PortableDocFormat, PDFmail);
                                    string MsgFormat;




                                    System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
                                    System.Net.Mail.MailMessage msg1 = new System.Net.Mail.MailMessage();
                                    System.Net.Mail.MailMessage msg11 = new System.Net.Mail.MailMessage();
                                    string emailAddrofCust = DS.Tables[0].Rows[0]["Email"].ToString();
                                    //string emailAddrofCust = "dongare.rohini123@gmail.com";
                                    // string emailAddrofCust = "darekarsanjay1991@gmail.com";
                                    //string emailAddrofCust = "hasnainrupani@yahoo.com";

                                    if (emailAddrofCust == "")
                                    {

                                        Obj_Comm.ShowPopUpMsg("Email address not present", this.Page);
                                        return;
                                    }
                                    else
                                    {

                                        #region EmailBody
                                        emailAddrofCust = emailAddrofCust.Replace(';', ',');
                                        //msg1.From = new System.Net.Mail.MailAddress("prinsedarekar1991@gmail.com");
                                        msg1.From = new System.Net.Mail.MailAddress("revosolutionpune@yahoo.com");
                                        msg1.To.Add(emailAddrofCust);
                                        msg1.CC.Add("revosolutionpune@yahoo.com");
                                        msg1.Subject = "Receipt Voucher";
                                        MsgFormat = "<font face='Arial'>" + "<b>" + "Dear Sir/Madam," + "<b>" + "<p>" + Environment.NewLine + "<b>" + "Greetings from Atur India ." + "<b>" + "<p>";
                                        MsgFormat = MsgFormat + "<p>This is with reference to your Rent with us in the Property known as " + PCName + ".";//+ DS1.Tables[0].Rows[0]["Project"].ToString() +                                 
                                        MsgFormat = MsgFormat + " A Receipt Voucher has been attached here with. ";
                                        MsgFormat = MsgFormat + "<p>" + Environment.NewLine + "Please download the attachment for your ready reference." + Environment.NewLine;
                                        MsgFormat = MsgFormat + "</p><br>Thanking you,</p><p>";
                                        MsgFormat = MsgFormat + "</p><br>Regards,</p><p>" + Environment.NewLine;
                                        //MsgFormat = MsgFormat + " " + DS1.Tables[0].Rows[0]["Company"].ToString() + "<br></font>";
                                        //"Sales Executive<br></font>";
                                        msg1.Body = MsgFormat;
                                        msg1.IsBodyHtml = true;
                                        System.Net.Mail.Attachment mtl = new System.Net.Mail.Attachment(PDFmail);
                                        msg1.Attachments.Add(mtl);
                                        /*** For Gmail ****/
                                        //smtpClient.Host = "smtp.gmail.com";  // We use gmail as our smtp client
                                        //smtpClient.Port = 587;
                                        /*****End***/

                                        /*** For Yahoo ****/
                                        smtpClient.Host = "smtp.mail.yahoo.com";  // We use gmail as our smtp client
                                        smtpClient.Port = 587;
                                        /*****End***/

                                        smtpClient.EnableSsl = true;
                                        smtpClient.UseDefaultCredentials = true;
                                        //smtpClient.Credentials = new System.Net.NetworkCredential("prinsedarekar1991@gmail.com", "sanjay1234567");
                                        smtpClient.Credentials = new System.Net.NetworkCredential("revosolutionpune@yahoo.com", "revosacred123");

                                        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                                        {
                                            return true;
                                        };
                                        #endregion
                                        smtpClient.Send(msg1);
                                        //cnt1 = cnt1 + 1;
                                        Obj_Comm.ShowPopUpMsg("Mail Successfully Send..!", this.Page);

                                    }


                                }

                                break;
                            }

                                    #endregion


                        }
                        break;
                    }
                #endregion
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "paisa_conver", "paisa_conver()", true);
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg("Please try after Some Time..!", this.Page);
        }
           

        
    }

    protected void GrdReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {                
            int DeleteId = Convert.ToInt32(((ImageButton)GrdReport.Rows[e.RowIndex].Cells[0].FindControl("ImgBtnDelete")).CommandArgument.ToString());
            if (DeleteId != 0)
            {

                Entity_Receipt.ReceiptVoucherId = DeleteId;
                Entity_Receipt.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_Receipt.LoginDate = DateTime.Now;
                int iDelete = Obj_Receipt.DeleteReceipt(ref Entity_Receipt, out StrError);
                if (iDelete != 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }

            }
            Entity_Receipt = null;
            Obj_Comm = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void GrdReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GrdReport.PageIndex = e.NewPageIndex;
            StrCondition = TxtSearch.Text.Trim();
            ReportGrid(StrCondition);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void ddlReceivedFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //DataSet Ds = new DataSet();
            //Ds = Obj_Receipt.GetPropertyOnParty(Convert.ToInt32(ddlReceivedFrom.SelectedValue), out StrError);
            //if (Ds.Tables.Count > 0)
            //{
            //    if (Ds.Tables[0].Rows.Count > 0)
            //    {
            //        ddlPROPERTYTo.DataSource = Ds.Tables[0];
            //        ddlPROPERTYTo.DataValueField = "PropertyId";
            //        ddlPROPERTYTo.DataTextField = "Property";
            //        ddlPROPERTYTo.DataBind();
            //    }                     
            //}
            //ddlPROPERTYTo.Focus();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void ddlPROPERTYTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
             String dtpFromDate = string.Empty;

            DataSet Ds = new DataSet();
            String Str1 = txtMonthDate.Text.Split('-')[0];
            String Str2 = txtMonthDate.Text.Split('-')[1];

            string str = Convert.ToString(ddlPROPERTYTo.SelectedItem);
            string[] s = str.Split('-');

            int monthIndex;
            string desiredMonth = txtMonthDate.Text.Split('-')[0];
            string[] MonthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            monthIndex = Array.IndexOf(MonthNames, desiredMonth) + 1;

           
          //  dtpFromDate = Convert.ToDateTime(txtMonthDate.Text).ToString("01-MMM-yyyy");
            dtpFromDate = Convert.ToDateTime(txtMonthDate.Text).ToString("MM-01-yyyy");
            Ds = Obj_Receipt.GetPartyandAmount(Convert.ToInt32(ddlPROPERTYTo.SelectedValue), dtpFromDate, s[1], out StrError);
            if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[0].Rows.Count > 0)
                {
                  //  txtAmount.Text = Ds.Tables[0].Rows[0]["Amount"].ToString();
                }
                else
                {
                    // txtAmount.Text = "0.00";
                }

                if (Ds.Tables[1].Rows.Count > 0)
                {
                    ddlReceivedFrom.DataSource = Ds.Tables[1];
                    ddlReceivedFrom.DataTextField = "PartyName";
                    ddlReceivedFrom.DataValueField = "PartyId";
                    ddlReceivedFrom.DataBind();
                }
            }
           
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void txtMonthDate_TextChanged(object sender, EventArgs e)
    {
        try
        {

            DataSet DSA = new DataSet();

            string MonthYear = txtMonthDate.Text.ToString();


            DSA = Obj_Receipt.GetAmountOnMonth(Convert.ToInt32(ddlPROPERTYTo.SelectedValue), Convert.ToInt32(ddlReceivedFrom.SelectedValue), MonthYear, out StrError);

            if (DSA.Tables[0].Rows.Count > 0)
            {
                txtPaidAmount.Text = DSA.Tables[0].Rows[0]["RentalAmount"].ToString();

                if (!string.IsNullOrEmpty(DSA.Tables[0].Rows[0]["RemaingAmount"].ToString()))
                {
                    txtRemAmt.Text = DSA.Tables[0].Rows[0]["RemaingAmount"].ToString();

                    txtRemAmountCal.Text = DSA.Tables[0].Rows[0]["RemaingAmount"].ToString();
                }
                else
                {
                    txtRemAmt.Text = DSA.Tables[0].Rows[0]["RemaingAmount"].ToString();

                    txtRemAmountCal.Text = DSA.Tables[0].Rows[0]["RentalAmount"].ToString();
                }


                
            }
            else
            {
                txtPaidAmount.Text = "0.00";
                txtRemAmt.Text = "0.00";
            }

        
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }


    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        try
        {

            //DataSet DSA = new DataSet();

            //decimal ActualAmt = Convert.ToDecimal(txtPaidAmount.Text);
            //decimal paidAmt = Convert.ToDecimal(txtAmount.Text);

          
            //if (paidAmt > 0)
            //{
            //    txtRemAmt.Text = (ActualAmt-paidAmt).ToString();
            //}
            //else
            //{
            //    txtRemAmt.Text = "0.00";
            //}


        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }
}