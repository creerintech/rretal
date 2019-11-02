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
using Build.EntityClass;
using Build.DB;
using Build.DataModel;
using Build.DALSQLHelper;

public partial class Masters_ExpenceHeadMaster : System.Web.UI.Page
{

    #region[Private Variables]

    DMExpenceHeadMaster Obj_EH = new DMExpenceHeadMaster();
    ExpencesHeadMaster Entity_EH = new ExpencesHeadMaster();
    CommanFunction Obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();
    DataSet Dsa = new DataSet();
    private bool Flag = true;
    public static decimal TotalQty = 0;
    private string StrError = string.Empty;
    private string StrCondition = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;
    #endregion

    public void SetInitialRowExpence()
    {
        try
        {
            DataTable dtTable = new DataTable();
            DataRow dr;
            dtTable.Columns.Add("#", typeof(int));
            dtTable.Columns.Add("Particular", typeof(String));
            dtTable.Columns.Add("Qty", typeof(decimal));
            dtTable.Columns.Add("Rate", typeof(decimal));
            dtTable.Columns.Add("Amount", typeof(decimal));
            dtTable.Columns.Add("Remark", typeof(String));
          
            dr = dtTable.NewRow();

            dr["#"] = 0;
            dr["Particular"] = string.Empty;
            dr["Qty"] = 0;
            dr["Rate"] =0;
            dr["Amount"] = 0;       ;
            dr["Remark"] = string.Empty;
                        
            dtTable.Rows.Add(dr);
            ViewState["CurrentTable"] = dtTable;
            GrdExpencesDetails.DataSource = dtTable;
            GrdExpencesDetails.DataBind();
        }
        catch (Exception ex) { throw new Exception(ex.Message); }

    }

    private void MakeEmptyForm()
    {
        txtFromDate.Focus();
        ddlProjectName.SelectedValue = "0";
        txtEHNo.Text = string.Empty;
        txtFromDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
        if (!FlagAdd)
            BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        BtnCancel.Visible = true;
        GetCode();
        SetInitialRowExpence();
        
        FillCombo();
       ReportGrid(StrCondition);
    }

    private void FillCombo()
    {
        Dsa = Obj_EH.FillCombo(out StrError);
        if (Dsa.Tables.Count > 0)
        {
            if (Dsa.Tables[0].Rows.Count > 0)
            {
                ddlProjectName.DataSource = Dsa.Tables[0];
                ddlProjectName.DataTextField = "Property";
                ddlProjectName.DataValueField = "PropertyId";
                ddlProjectName.DataBind();
            }

        }
    }

    private void GetCode()
    {
        DS = Obj_EH.GetExpenceHeadNo(out StrError);

        if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
        {
            txtEHNo.Text = DS.Tables[0].Rows[0]["ExpenceNo"].ToString();
        }
    }

    public void ReportGrid(string RepCondition)
    {
        string StrError = "";
        try
        {
            DS = Obj_EH.GetProject(RepCondition, out StrError);

            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                ViewState["CurrentProject"] = DS.Tables[0];
                GrdReport.DataSource = DS.Tables[0];
                GrdReport.DataBind();
                HttpContext.Current.Cache["Dir"] = DS.Tables[0];
            }
            else
            {
                GrdReport.DataSource = null;
                GrdReport.DataBind();
            }
            Obj_EH = null;
            DS = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            MakeEmptyForm();
        }
    }


    protected void ImgAddRrow_Click(object sender, ImageClickEventArgs e)
    {
        int rowIndex = 0;
        if (Convert.ToInt32(ddlProjectName.SelectedValue) > 0)
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataTable DTTEMP = dtCurrentTable.Clone();
                DataRow dtTableRow = null;
                #region

                if (GrdExpencesDetails.Rows[0].Cells[1].Text.Equals("&nbsp;") || string.IsNullOrEmpty(GrdExpencesDetails.Rows[0].Cells[1].Text))
                {
                    dtCurrentTable.Rows.RemoveAt(0);
                }

                for (int i = 0; i < GrdExpencesDetails.Rows.Count; i++)
                {
                    TextBox txtParticular = (TextBox)GrdExpencesDetails.Rows[i].Cells[2].FindControl("txtParticular");
                    TextBox txtQty = (TextBox)GrdExpencesDetails.Rows[i].Cells[3].FindControl("txtQty");
                    TextBox txtRate = (TextBox)GrdExpencesDetails.Rows[i].Cells[4].FindControl("txtRate");
                    TextBox txtAmount = (TextBox)GrdExpencesDetails.Rows[i].Cells[5].FindControl("txtAmount");
                    TextBox txtRemark = (TextBox)GrdExpencesDetails.Rows[i].Cells[6].FindControl("txtRemark");

                    dtTableRow = DTTEMP.NewRow();
                    dtTableRow["Particular"] = txtParticular.Text;
                    dtTableRow["Qty"] = txtQty.Text;
                    dtTableRow["Rate"] = txtRate.Text;
                    dtTableRow["Amount"] = txtAmount.Text;
                    dtTableRow["Remark"] = txtRemark.Text;
                    rowIndex++;
                    DTTEMP.Rows.Add(dtTableRow);

                }
                if (DTTEMP.Rows.Count > 0)
                {
                    dtCurrentTable = DTTEMP;
                }
                dtTableRow = null;
                #endregion

                if (dtCurrentTable.Rows.Count > 0)
                {
                    dtTableRow = dtCurrentTable.NewRow();

                    dtTableRow["#"] = 0;
                    dtTableRow["Particular"] = "";
                    dtTableRow["Qty"] = 0;
                    dtTableRow["Rate"] = 0;
                    dtTableRow["Amount"] = 0;                    
                    dtTableRow["Remark"] = "";
                    dtCurrentTable.Rows.Add(dtTableRow);

                    ViewState["CurrentTable"] = dtCurrentTable;
                    GrdExpencesDetails.DataSource = dtCurrentTable;
                    GrdExpencesDetails.DataBind();

                   // Makecontrolempty();
                }
            }
        }
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

                            DS = Obj_EH.GetExpenceHeadToEdit(Convert.ToInt32(e.CommandArgument), out StrError);

                            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                            {
                                txtEHNo.Text = DS.Tables[0].Rows[0]["ExpenceNo"].ToString();
                                txtFromDate.Text = DS.Tables[0].Rows[0]["ExpenceDate"].ToString();
                                ddlProjectName.SelectedValue = DS.Tables[0].Rows[0]["PropertyId"].ToString();

                                if (DS.Tables.Count > 0 && DS.Tables[1].Rows.Count > 0)
                                {
                                    GrdExpencesDetails.DataSource = DS.Tables[1];
                                    GrdExpencesDetails.DataBind();
                                    ViewState["CurrentTable"] = DS.Tables[1];
                                }
                                else
                                {
                                    SetInitialRowExpence();
                                }
                                if (!FlagEdit)
                                BtnUpdate.Visible = true;
                                BtnSave.Visible = false;
                            }
                            else
                            {
                                // Makefromempty();
                            }
                        }

                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg("Please try after Some Time..!", this.Page);
        }
    }

    protected void GrdReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet usecount = new DataSet();
        try
        {
            int DeleteId = Convert.ToInt32(((ImageButton)GrdReport.Rows[e.RowIndex].Cells[0].FindControl("ImgBtnDelete")).CommandArgument.ToString());

            if (DeleteId != 0)
            {
                Entity_EH.ExpenceId = DeleteId;
                Entity_EH.UserId = Convert.ToInt32(Session["UserID"]);
                Entity_EH.LoginDate = DateTime.Now;

                int iDelete = Obj_EH.DeleteExpenceHead(ref Entity_EH, out StrError);
                if (iDelete != 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int irow = 0, idetrow = 0;
        try
        {
            DataSet DSC = new DataSet();

            DataTable dtInsert = new DataTable();
            dtInsert = (DataTable)ViewState["CurrentTable"];

            Entity_EH.ExpenceNo = txtEHNo.Text;
            Entity_EH.ExpenceDate = Convert.ToDateTime(txtFromDate.Text);
            Entity_EH.PropertyId = Convert.ToInt32(ddlProjectName.SelectedValue);            
            Entity_EH.UserId = 1;//Convert.ToInt32(Session["UserId"]);
            Entity_EH.LoginDate = DateTime.Now;

            irow = Obj_EH.InsertExpenceHead(ref Entity_EH, out StrError);

            if (irow > 0)
            {
                if (ViewState["CurrentTable"] != null)
                {
                    #region
                    for (int i = 0; i < dtInsert.Rows.Count; i++)
                    {

                        Entity_EH.ExpenceId = irow;

                        TextBox txtParticular = (TextBox)GrdExpencesDetails.Rows[i].Cells[2].FindControl("txtParticular");
                        Entity_EH.Perticulars = txtParticular.Text;

                        TextBox txtQty = (TextBox)GrdExpencesDetails.Rows[i].Cells[3].FindControl("txtQty");
                        Entity_EH.Qty = Convert.ToDecimal(txtQty.Text);

                        TextBox txtRate = (TextBox)GrdExpencesDetails.Rows[i].Cells[4].FindControl("txtRate");
                        Entity_EH.Rate = Convert.ToDecimal(txtRate.Text);

                        TextBox txtAmount = (TextBox)GrdExpencesDetails.Rows[i].Cells[5].FindControl("txtAmount");
                        Entity_EH.Amount = Convert.ToDecimal(txtAmount.Text);

                        TextBox txtRemark = (TextBox)GrdExpencesDetails.Rows[i].Cells[6].FindControl("txtRemark");
                        Entity_EH.Remark = txtRemark.Text;

                        idetrow = Obj_EH.InsertExpenceHeadDetail(ref Entity_EH, out StrError);

                    }
                    #endregion
                }

            }

            if (idetrow > 0 && irow > 0)
            {
                Obj_Comm.ShowPopUpMsg("Record Saved Successfully..!", this.Page);

            }
            MakeEmptyForm();
        }
        catch (Exception)
        {
            //Obj_Comm.ErrorLog("DepartmentActivityRegister.aspx", " BtnSave_Click", "Exception", "ex.so", "", 1);
        }
    }


    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int irow = 0, idetrow = 0;
        DataSet DSC = new DataSet();
        try
        {
            DataTable dtInsert = new DataTable();
            dtInsert = (DataTable)ViewState["CurrentTable"];
            Entity_EH.ExpenceId = Convert.ToInt32(ViewState["EditID"]);
            Entity_EH.ExpenceNo = txtEHNo.Text;
            Entity_EH.ExpenceDate = Convert.ToDateTime(txtFromDate.Text);
            Entity_EH.PropertyId = Convert.ToInt32(ddlProjectName.SelectedValue);
            Entity_EH.UserId = 1;
            Entity_EH.LoginDate = DateTime.Now;

            irow = Obj_EH.UpdatetExpenceHead(ref Entity_EH, out StrError);

            if (irow > 0)
            {
                if (ViewState["CurrentTable"] != null)
                {
                    for (int i = 0; i < dtInsert.Rows.Count; i++)
                    {
                        Entity_EH.ExpenceId = Convert.ToInt32(ViewState["EditID"]);

                      
                        TextBox txtParticular = (TextBox)GrdExpencesDetails.Rows[i].Cells[2].FindControl("txtParticular");
                        Entity_EH.Perticulars = txtParticular.Text;

                        TextBox txtQty = (TextBox)GrdExpencesDetails.Rows[i].Cells[3].FindControl("txtQty");
                        Entity_EH.Qty = Convert.ToDecimal(txtQty.Text);

                        TextBox txtRate = (TextBox)GrdExpencesDetails.Rows[i].Cells[4].FindControl("txtRate");
                        Entity_EH.Rate = Convert.ToDecimal(txtRate.Text);

                        TextBox txtAmount = (TextBox)GrdExpencesDetails.Rows[i].Cells[5].FindControl("txtAmount");
                        Entity_EH.Amount = Convert.ToDecimal(txtAmount.Text);

                        TextBox txtRemark = (TextBox)GrdExpencesDetails.Rows[i].Cells[6].FindControl("txtRemark");
                        Entity_EH.Remark = txtRemark.Text;

                        idetrow = Obj_EH.InsertExpenceHeadDetail(ref Entity_EH, out StrError);
                    }
                }
            }
            if (idetrow > 0 && irow > 0)
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

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
    }

    #region[WebService]

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        DMExpenceHeadMaster Obj_Con = new DMExpenceHeadMaster();
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

    protected void GrdExpencesDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            DataSet DST = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtAmount = ((TextBox)e.Row.FindControl("txtAmount"));

                TotalQty += Convert.ToDecimal(txtAmount.Text.ToString());
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Total";
                e.Row.Cells[5].Text = TotalQty.ToString("0.00");

                TotalQty = 0;
                e.Row.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {
        }
    }

    protected void GrdExpencesDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (ViewState["CurrentTable"] != null)
            {
                int id = e.RowIndex;
                DataTable dt = (DataTable)ViewState["CurrentTable"];

                dt.Rows.RemoveAt(id);

                if (dt.Rows.Count > 0)
                {
                    GrdExpencesDetails.DataSource = dt;
                    ViewState["CurrentTable"] = dt;
                    GrdExpencesDetails.DataBind();
                }
                else
                {
                    SetInitialRowExpence();
                }

            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}
