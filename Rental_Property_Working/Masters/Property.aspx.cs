using Build.Utility;
using Build.EntityClass;
using Build.DB;
using Build.DataModel;
using Build.DALSQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_Property : System.Web.UI.Page
{

    #region Private Variable

    CommanFunction Obj_Comm = new CommanFunction();
    DataSet Ds = new DataSet();
    private string StrCondition = string.Empty;
    private string StrError = string.Empty;
    private bool Flag = true;

    PropertyMaster Entity_Property = new PropertyMaster();
    DMProperty obj_Property = new DMProperty();
    bool FlagEdit=false;
    #endregion

    #region  User Funtions

    private void MakeEmptyForm()
    {
        ViewState["EditId"] = null;
        txtProperty.Focus();
        HttpContext.Current.Cache["Dir"] = "";
        txtProperty.Text = string.Empty;
        txtPropertyAddress.Text = string.Empty;
        TxtSearch.Text = string.Empty;
       
        BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        BtnCancel.Visible = true;
        ReportGrid("");

        SetInitialRow();
        SetInitialRowExpenseDtls();
    }


    private void MakeControlEmpty()
    {
        ddlUnitType.SelectedValue = "0";
      
       txtUnitNo.Text = string.Empty;
        txtAreaSqf.Text = string.Empty;
        txtPropertytaxAmt.Text = string.Empty;
        txtSocietyMAmt.Text = string.Empty;
        ddlExpenseHead.SelectedValue = "0";
        txtExpAmount.Text = string.Empty;

        ViewState["GridIndex"] = null;
        ViewState["GridDetails"] = null;

        //ViewState["CurrentProexp"] = null;
        ViewState["GridIndexNew"] = null;
        ImgAddGrid.ImageUrl = "~/Images/Icon/Gridadd.png";
        ImgAddGrid.ToolTip = "Add Grid";


    }

    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add("#", typeof(Int32));
        dt.Columns.Add("FlatTypeId", typeof(Int32));
        dt.Columns.Add("FlatType", typeof(string));
        dt.Columns.Add("UnitNo", typeof(string));
        dt.Columns.Add("UnitArea", typeof(decimal));
        dt.Columns.Add("PropTaxAmt", typeof(decimal));
        dt.Columns.Add("SMAmt", typeof(decimal));
      
        dr = dt.NewRow();

        dr["#"] = 0;
        dr["FlatTypeId"] = 0;
        dr["FlatType"] = "";
        dr["UnitNo"] = "";
        dr["UnitArea"] = 0;
        dr["PropTaxAmt"] = 0;
        dr["SMAmt"] = 0;
        
        dt.Rows.Add(dr);

        ViewState["CurrentTable"] = dt;
        GridDetails.DataSource = dt;
        GridDetails.DataBind();
    }


    private void SetInitialRowExpenseDtls()
    {
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add("#", typeof(Int32));
        dt.Columns.Add("ExpenseHdId", typeof(Int32));
        dt.Columns.Add("Expense", typeof(string));
        dt.Columns.Add("Amount", typeof(decimal));
        

        dr = dt.NewRow();

        dr["#"] = 0;
        dr["ExpenseHdId"] = 0;
        dr["Expense"] = "";     
        dr["Amount"] = 0;
       

        dt.Rows.Add(dr);

        ViewState["CurrentProexp"] = dt;
        GrdProExpDtls.DataSource = dt;
        GrdProExpDtls.DataBind();
    }

    public void ReportGrid(string RepCondition)
    {
        string Substring = RepCondition.Split('-')[0];

        Ds = obj_Property.FillReportGrid(Substring, out StrError);
        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            HttpContext.Current.Cache["Dir"] = Ds.Tables[0];
            GrdReport.DataSource = Ds.Tables[0];
            GrdReport.DataBind();
        }
        else
        {
            GrdReport.DataSource = null;
            GrdReport.DataBind();
        }
        obj_Property = null;
        Ds = null;
    }

    private bool Check()
    {

        Ds = new DataSet();
        Flag = true;
        if (ViewState["EditID"] != null)
            Ds = obj_Property.ChkDuplicate(txtProperty.Text,Convert.ToInt32(ddlCompany.SelectedValue),long.Parse(ViewState["EditID"].ToString()), out StrError);
        else
            Ds = obj_Property.ChkDuplicate(txtProperty.Text, Convert.ToInt32(ddlCompany.SelectedValue), -1, out StrError);

        if (Ds.Tables.Count > 0)
        {
            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (long.Parse(Ds.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    Flag = false;
                    Obj_Comm.ShowPopUpMsg("Property  is Already Present..!", this.Page);
                    txtProperty.Text = string.Empty;
                }
            }
        }

      
        return Flag;
    }

    private void FillCombo()
    {
        try
        {
            Ds = obj_Property.BindCombo(out StrError);
            if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    ddlCompany.DataSource = Ds.Tables[0];
                    ddlCompany.DataTextField = "CompanyName";
                    ddlCompany.DataValueField = "CompanyId";
                    ddlCompany.DataBind();
                }

                if (Ds.Tables[1].Rows.Count > 0)
                {
                    ddlUnitType.DataSource = Ds.Tables[1];
                    ddlUnitType.DataTextField = "FlatType";
                    ddlUnitType.DataValueField = "FlatTypeId";
                    ddlUnitType.DataBind();
                }

                if (Ds.Tables[2].Rows.Count > 0)
                {
                    ddlExpenseHead.DataSource = Ds.Tables[2];
                    ddlExpenseHead.DataTextField = "Expense";
                    ddlExpenseHead.DataValueField = "ExpenseHdId";
                    ddlExpenseHead.DataBind();
                }

                if (Ds.Tables[3].Rows.Count > 0)
                {
                    ddlProprtyType.DataSource = Ds.Tables[3];
                    ddlProprtyType.DataTextField = "PropertyTypeDesc";
                    ddlProprtyType.DataValueField = "PropertyTypeId";
                    ddlProprtyType.DataBind();
                }

                if (Ds.Tables[4].Rows.Count > 0)
                {
                    ddlCity.DataSource = Ds.Tables[4];
                    ddlCity.DataTextField = "City";
                    ddlCity.DataValueField = "CityId";
                    ddlCity.DataBind();
                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }

    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet DST = new DataSet();

            if (!string.IsNullOrEmpty(Request.QueryString["PropertyId"]))
            {
                FillCombo();

                int ProMaintId = Convert.ToInt32(Request.QueryString["PropertyId"]);
                {
                    DST = obj_Property.GetRocordtoEdit(ProMaintId, out StrError);
                    if (DST.Tables.Count > 0 && DST.Tables[0].Rows.Count > 0)
                    {
                        txtProperty.Text = DST.Tables[0].Rows[0]["Property"].ToString();
                        txtPropertyAddress.Text = DST.Tables[0].Rows[0]["PropertyAddress"].ToString();
                        ddlCompany.SelectedValue = DST.Tables[0].Rows[0]["CompanyId"].ToString();
                        ddlProprtyType.SelectedValue = DST.Tables[0].Rows[0]["PropertyTypeId"].ToString();

                        ddlProprtyType_SelectedIndexChanged(Convert.ToInt32(ddlProprtyType.SelectedValue), EventArgs.Empty);
                        ddlPropertySubType.SelectedValue = DST.Tables[0].Rows[0]["PropertySubTypeId"].ToString();

                        ddlCity.SelectedValue = DST.Tables[0].Rows[0]["CityId"].ToString();
                        ddlCity_SelectedIndexChanged(Convert.ToInt32(ddlCity.SelectedValue), EventArgs.Empty);

                        ddlLocation.SelectedValue = DST.Tables[0].Rows[0]["LocationId"].ToString();
                        if (DST.Tables.Count > 0 && DST.Tables[1].Rows.Count > 0)
                        {
                            GridDetails.DataSource = DST.Tables[1];
                            GridDetails.DataBind();
                            ViewState["CurrentTable"] = DST.Tables[1];
                        }
                        else
                        {
                            SetInitialRow();
                        }

                        if (DST.Tables.Count > 0 && DST.Tables[2].Rows.Count > 0)
                        {
                            GrdProExpDtls.DataSource = DST.Tables[2];
                            GrdProExpDtls.DataBind();
                            ViewState["CurrentProexp"] = DST.Tables[2];
                        }
                        else
                        {
                            SetInitialRowExpenseDtls();
                        }

                        if (!FlagEdit)
                            BtnUpdate.Visible = true;
                        BtnSave.Visible = false;

                    }
                    else
                    {
                        // Make
                    }
                }
            }
            else
            {
                FillCombo();
                MakeEmptyForm();
            }
            //
            //MakeEmptyForm();
        }
    }

    //protected void TxtSearch_TextChanged(object sender, EventArgs e)
    //{
    //    if (string.IsNullOrEmpty((HttpContext.Current.Cache["Dir"]).ToString()))
    //    {
    //        DataTable DtNew = null;
    //    }
    //    else
    //    {
    //        DataTable DtNew = (DataTable)HttpContext.Current.Cache["Dir"];
    //        StrCondition = TxtSearch.Text.Trim();
    //        var query = from r in DtNew.AsEnumerable()
    //                    where (r.Field<string>("Property")).Contains(StrCondition)
    //                    select r;
    //        if (query != null && query.Count() > 0)
    //        {
    //            DataTable DTNEW = query.CopyToDataTable();

    //            GrdReport.DataSource = DTNEW;
    //            GrdReport.DataBind();
    //        }
    //        else
    //        {
    //            GrdReport.DataSource = null;
    //            GrdReport.DataBind();
    //        }
    //    }
    //}

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int UpdateRow = 0, idetrow = 0, idetrowDtls=0;
            try
            {
                if (Check() == true)
                {

                    DataTable dtInsert = new DataTable();
                    dtInsert = (DataTable)ViewState["CurrentTable"];
                    DataTable dtInsertNew = new DataTable();
                    dtInsertNew = (DataTable)ViewState["CurrentProexp"];

                    Entity_Property.PropertyId = Convert.ToInt32(ViewState["EditID"]);
                    Entity_Property.Property = txtProperty.Text;
                    Entity_Property.PropertyAddress = txtPropertyAddress.Text;
                    Entity_Property.CompanyId = Convert.ToInt32(ddlCompany.SelectedValue);
                    Entity_Property.PropertyTypeId = Convert.ToInt32(ddlProprtyType.SelectedValue);
                    Entity_Property.PropertySubTypeId = Convert.ToInt32(ddlPropertySubType.SelectedValue);
                    Entity_Property.CityId = Convert.ToInt32(ddlCity.SelectedValue);
                    Entity_Property.LocationId = Convert.ToInt32(ddlLocation.SelectedValue);  
   
                    Entity_Property.UserId = 1;
                    Entity_Property.LoginDate = DateTime.Now;


                    UpdateRow = obj_Property.UpdatePropertyMaster(ref Entity_Property, out StrError);

                    if (UpdateRow > 0)
                    {
                        if (ViewState["CurrentTable"] != null)
                        {
                            for (int i = 0; i < dtInsert.Rows.Count; i++)
                            {
                                Entity_Property.PropertyId = Convert.ToInt32(ViewState["EditID"]);
                                Entity_Property.FlatTypeId = Convert.ToInt32(dtInsert.Rows[i]["FlatTypeId"].ToString());
                                Entity_Property.UnitNo = dtInsert.Rows[i]["UnitNo"].ToString();
                                Entity_Property.UnitArea = Convert.ToDecimal(dtInsert.Rows[i]["UnitArea"].ToString());
                                Entity_Property.SocietyMaintenaceAmt = Convert.ToDecimal(dtInsert.Rows[i]["SMAmt"].ToString());
                                Entity_Property.PropertyTaxAmt = Convert.ToDecimal(dtInsert.Rows[i]["PropTaxAmt"].ToString());

                                idetrow = obj_Property.InsertPMDetail(ref Entity_Property, out StrError);
                            }
                        }


                        if (ViewState["CurrentProexp"] != null)
                        {
                            #region
                            for (int i = 0; i < dtInsertNew.Rows.Count; i++)
                            {
                                Entity_Property.PropertyId = Convert.ToInt32(ViewState["EditID"]);
                                Entity_Property.ExpenseHdId = Convert.ToInt32(dtInsertNew.Rows[i]["ExpenseHdId"].ToString());
                                Entity_Property.Amount = Convert.ToDecimal(dtInsertNew.Rows[i]["Amount"].ToString());

                                idetrowDtls = obj_Property.InsertPMExpDetail(ref Entity_Property, out StrError);
                            }
                            #endregion
                        }
                    }
                    if (UpdateRow > 0 && idetrow > 0)
                    {
                        Obj_Comm.ShowPopUpMsg("Record Updated Successfully", this.Page);
                        MakeEmptyForm();
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }       
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int InsertRow = 0, idetrow = 0, idetrowDtls=0;
        try
        {
            if (Check() == true)
            {
                DataTable dtInsert = new DataTable();
                dtInsert = (DataTable)ViewState["CurrentTable"];
                 DataTable dtInsertNew = new DataTable();
                 dtInsertNew = (DataTable)ViewState["CurrentProexp"];
                 
                Entity_Property.Property = txtProperty.Text;
                Entity_Property.PropertyAddress = txtPropertyAddress.Text;
                Entity_Property.CompanyId = Convert.ToInt32(ddlCompany.SelectedValue);
                Entity_Property.PropertyTypeId = Convert.ToInt32(ddlProprtyType.SelectedValue);
                Entity_Property.PropertySubTypeId = Convert.ToInt32(ddlPropertySubType.SelectedValue);
                Entity_Property.CityId = Convert.ToInt32(ddlCity.SelectedValue);
                Entity_Property.LocationId= Convert.ToInt32(ddlLocation.SelectedValue);  
   
                Entity_Property.UserId = 1;
                Entity_Property.LoginDate = DateTime.Now;

                InsertRow = obj_Property.InsertPropertyMaster(ref Entity_Property, out StrError);

                if (InsertRow > 0)
                {
                    if (ViewState["CurrentTable"] != null)
                    {
                        #region
                        for (int i = 0; i < dtInsert.Rows.Count; i++)
                        {

                            Entity_Property.PropertyId = InsertRow;
                            Entity_Property.FlatTypeId = Convert.ToInt32(dtInsert.Rows[i]["FlatTypeId"].ToString());
                            Entity_Property.UnitNo = dtInsert.Rows[i]["UnitNo"].ToString();
                            Entity_Property.UnitArea = Convert.ToDecimal(dtInsert.Rows[i]["UnitArea"].ToString());
                            Entity_Property.SocietyMaintenaceAmt = Convert.ToDecimal(dtInsert.Rows[i]["SMAmt"].ToString());
                            Entity_Property.PropertyTaxAmt= Convert.ToDecimal(dtInsert.Rows[i]["PropTaxAmt"].ToString());

                            idetrow = obj_Property.InsertPMDetail(ref Entity_Property, out StrError);
                        }
                        #endregion
                    }



                    if (ViewState["CurrentProexp"] != null)
                    {
                        #region
                        for (int i = 0; i < dtInsertNew.Rows.Count; i++)
                        {
                            Entity_Property.PropertyId = InsertRow;
                            Entity_Property.ExpenseHdId = Convert.ToInt32(dtInsertNew.Rows[i]["ExpenseHdId"].ToString());
                            Entity_Property.Amount = Convert.ToDecimal(dtInsertNew.Rows[i]["Amount"].ToString());

                            idetrowDtls = obj_Property.InsertPMExpDetail(ref Entity_Property, out StrError);
                        }
                        #endregion
                    }
                }

                if (InsertRow > 0 && idetrow > 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Saved Successfully..!", this.Page);

                }
                MakeEmptyForm();

            }

        }

        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        int DeleteId = 0;
        try
        {
            if (ViewState["EditID"] != null)
            {
                DeleteId = Convert.ToInt32(ViewState["EditID"]);
            }
            if (DeleteId != 0)
            {
                Entity_Property.PropertyId = DeleteId;
                Entity_Property.UserId = Convert.ToInt32(Session["UserID"]);
                Entity_Property.LoginDate = DateTime.Now;

                int iDelete = obj_Property.DeletePropertyMaster(ref Entity_Property, out StrError);
                if (iDelete != 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }
            }
            Entity_Property = null;
            Obj_Comm = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
        MakeControlEmpty();
    }

    protected void GrdReport_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                            Ds = obj_Property.GetRocordtoEdit(Convert.ToInt32(e.CommandArgument), out StrError);
                            if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                            {
                                txtProperty.Text = Ds.Tables[0].Rows[0]["Property"].ToString();
                                txtPropertyAddress.Text = Ds.Tables[0].Rows[0]["PropertyAddress"].ToString();
                                ddlCompany.SelectedValue =Ds.Tables[0].Rows[0]["CompanyId"].ToString();
                                ddlProprtyType.SelectedValue = Ds.Tables[0].Rows[0]["PropertyTypeId"].ToString();
                              
                                 ddlProprtyType_SelectedIndexChanged(Convert.ToInt32(ddlProprtyType.SelectedValue), EventArgs.Empty);
                                ddlPropertySubType.SelectedValue = Ds.Tables[0].Rows[0]["PropertySubTypeId"].ToString();

                                ddlCity.SelectedValue = Ds.Tables[0].Rows[0]["CityId"].ToString();
                                ddlCity_SelectedIndexChanged(Convert.ToInt32(ddlCity.SelectedValue), EventArgs.Empty);
                                
                                ddlLocation.SelectedValue = Ds.Tables[0].Rows[0]["LocationId"].ToString();

                                if (Ds.Tables.Count > 0 && Ds.Tables[1].Rows.Count > 0)
                                {
                                    GridDetails.DataSource = Ds.Tables[1];
                                    GridDetails.DataBind();
                                    ViewState["CurrentTable"] = Ds.Tables[1];
                                }
                                else
                                {
                                    SetInitialRow();
                                }

                                if (Ds.Tables.Count > 0 && Ds.Tables[2].Rows.Count > 0)
                                {
                                    GrdProExpDtls.DataSource = Ds.Tables[2];
                                    GrdProExpDtls.DataBind();
                                    ViewState["CurrentProexp"] = Ds.Tables[2];
                                }
                                else
                                {
                                    SetInitialRowExpenseDtls();
                                }
                            }
                            else
                            {
                                MakeEmptyForm();
                            }


                            BtnUpdate.Visible = true;
                            BtnSave.Visible = false;
                            BtnDelete.Visible = true;
                        }

                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void ImgAddGrid_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow dtTableRow = null;
                bool DupFlag = false;
                int k = 0;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    if (dtCurrentTable.Rows.Count == 1 && string.IsNullOrEmpty(dtCurrentTable.Rows[0]["FlatType"].ToString()))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }
                    if (ViewState["GridIndex"] != null)
                    {
                        k = Convert.ToInt32(ViewState["GridIndex"]);
                        dtCurrentTable.Rows[k]["#"] = Convert.ToInt32(ddlUnitType.SelectedValue);
                        dtCurrentTable.Rows[k]["FlatType"] = ddlUnitType.SelectedItem;
                        dtCurrentTable.Rows[k]["FlatTypeId"] = Convert.ToInt32(ddlUnitType.SelectedValue);

                        dtCurrentTable.Rows[k]["UnitNo"] = txtUnitNo.Text;
                        dtCurrentTable.Rows[k]["UnitArea"] = txtAreaSqf.Text;

                        if (!string.IsNullOrEmpty(txtPropertytaxAmt.Text))
                        {
                            dtCurrentTable.Rows[k]["PropTaxAmt"] = (!string.IsNullOrEmpty(txtPropertytaxAmt.Text)) ? Convert.ToDecimal(txtPropertytaxAmt.Text) : 0;
                        }
                        else
                        {
                            dtCurrentTable.Rows[k]["PropTaxAmt"] = (!string.IsNullOrEmpty(txtPropertytaxAmt.Text)) ? Convert.ToDecimal(txtPropertytaxAmt.Text) : 0;
                        }

                        if (!string.IsNullOrEmpty(txtSocietyMAmt.Text))
                        {
                            dtCurrentTable.Rows[k]["SMAmt"] = (!string.IsNullOrEmpty(txtSocietyMAmt.Text)) ? Convert.ToDecimal(txtSocietyMAmt.Text) : 0;
                        }
                        else
                        {
                            dtCurrentTable.Rows[k]["SMAmt"] = (!string.IsNullOrEmpty(txtSocietyMAmt.Text)) ? Convert.ToDecimal(txtSocietyMAmt.Text) : 0;
                        }
                        ViewState["CurrentTable"] = dtCurrentTable;
                        GridDetails.DataSource = dtCurrentTable;
                        GridDetails.DataBind();
                       MakeControlEmpty();

                    }

                    else
                    {

                        dtTableRow = dtCurrentTable.NewRow();
                        int rowindex = Convert.ToInt32(ViewState["GridIndex"]);
                        dtTableRow["FlatType"] = ddlUnitType.SelectedItem;
                        dtTableRow["FlatTypeId"] = Convert.ToInt32(ddlUnitType.SelectedValue);
                        dtTableRow["#"] = Convert.ToInt32(ddlUnitType.SelectedValue);
                        dtTableRow["UnitNo"] = txtUnitNo.Text;
                        dtTableRow["UnitArea"] = txtAreaSqf.Text;
                        if (!string.IsNullOrEmpty(txtPropertytaxAmt.Text))
                        {
                            dtTableRow["PropTaxAmt"] = (!string.IsNullOrEmpty(txtPropertytaxAmt.Text)) ? Convert.ToDecimal(txtPropertytaxAmt.Text) : 0;
                        }
                        else
                        {
                            dtTableRow["PropTaxAmt"] = (!string.IsNullOrEmpty(txtPropertytaxAmt.Text)) ? Convert.ToDecimal(txtPropertytaxAmt.Text) : 0;
                        }

                        if (!string.IsNullOrEmpty(txtSocietyMAmt.Text))
                        {
                            dtTableRow["SMAmt"] = (!string.IsNullOrEmpty(txtSocietyMAmt.Text)) ? Convert.ToDecimal(txtSocietyMAmt.Text) : 0;
                        }
                        else
                        {
                            dtTableRow["SMAmt"] = (!string.IsNullOrEmpty(txtSocietyMAmt.Text)) ? Convert.ToDecimal(txtSocietyMAmt.Text) : 0;
                        }
                        dtCurrentTable.Rows.Add(dtTableRow);
                      
                        ViewState["CurrentTable"] = dtCurrentTable;
                        GridDetails.DataSource = dtCurrentTable;
                        GridDetails.DataBind();
                        MakeControlEmpty();
                    }

                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void ImgProExpDtlsAdd_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ViewState["CurrentProexp"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentProexp"];
                DataRow dtTableRow = null;
            
                int k = 0;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    if (dtCurrentTable.Rows.Count == 1 && string.IsNullOrEmpty(dtCurrentTable.Rows[0]["Expense"].ToString()))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }
                    if (ViewState["GridIndexNew"] != null)
                    {
                        k = Convert.ToInt32(ViewState["GridIndexNew"]);
                        dtCurrentTable.Rows[k]["#"] = Convert.ToInt32(ddlExpenseHead.SelectedValue);
                        dtCurrentTable.Rows[k]["Expense"] = ddlExpenseHead.SelectedItem;
                        dtCurrentTable.Rows[k]["ExpenseHdId"] = Convert.ToInt32(ddlExpenseHead.SelectedValue);
                        dtCurrentTable.Rows[k]["Amount"] = (!string.IsNullOrEmpty(txtExpAmount.Text)) ? Convert.ToDecimal(txtExpAmount.Text) : 0; 

                        ViewState["CurrentProexp"] = dtCurrentTable;
                        GrdProExpDtls.DataSource = dtCurrentTable;
                        GrdProExpDtls.DataBind();
                        MakeControlEmpty();

                    }

                    else
                    {

                        dtTableRow = dtCurrentTable.NewRow();
                        int rowindex = Convert.ToInt32(ViewState["GridIndexNew"]);
                        dtTableRow["Expense"] = ddlExpenseHead.SelectedItem;
                        dtTableRow["ExpenseHdId"] = Convert.ToInt32(ddlExpenseHead.SelectedValue);
                        dtTableRow["#"] = Convert.ToInt32(ddlExpenseHead.SelectedValue);
                        dtTableRow["Amount"] = (!string.IsNullOrEmpty(txtExpAmount.Text)) ? Convert.ToDecimal(txtExpAmount.Text) : 0; 
                      

                        dtCurrentTable.Rows.Add(dtTableRow);

                        ViewState["CurrentProexp"] = dtCurrentTable;
                        GrdProExpDtls.DataSource = dtCurrentTable;
                        GrdProExpDtls.DataBind();
                        MakeControlEmpty();
                    }

                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void GridDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int Index;
            if (e.CommandName == "SelectGrid")
            {                
                ImgAddGrid.ToolTip = "Update";

                Index = Convert.ToInt32(e.CommandArgument);

                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        ViewState["GridIndex"] = Index;
                        ddlUnitType.SelectedValue = Convert.ToInt32(dtCurrentTable.Rows[Index]["FlatTypeId"]).ToString();
                        txtAreaSqf.Text = dtCurrentTable.Rows[Index]["UnitArea"].ToString();
                        txtUnitNo.Text = dtCurrentTable.Rows[Index]["UnitNo"].ToString();
                        txtPropertytaxAmt.Text = dtCurrentTable.Rows[Index]["PropTaxAmt"].ToString();
                        txtSocietyMAmt.Text = dtCurrentTable.Rows[Index]["SMAmt"].ToString();
                                      
                    }
                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void GridDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
                    GridDetails.DataSource = dt;
                    ViewState["CurrentTable"] = dt;
                    GridDetails.DataBind();
                }
                else
                {
                    SetInitialRow();
                }
                MakeControlEmpty();
            }           
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void GrdProExpDtls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int Index;
            if (e.CommandName == "SelectGrid")
            {
                ImgAddGrid.ToolTip = "Update";

                Index = Convert.ToInt32(e.CommandArgument);

                if (ViewState["CurrentProexp"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentProexp"];

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        ViewState["GridIndexNew"] = Index;
                        ddlExpenseHead.SelectedValue = Convert.ToInt32(dtCurrentTable.Rows[Index]["ExpenseHdId"]).ToString();
                        txtExpAmount.Text = dtCurrentTable.Rows[Index]["Amount"].ToString();                      
                    }
                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void GrdProExpDtls_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (ViewState["CurrentProexp"] != null)
            {
                int id = e.RowIndex;
                DataTable dt = (DataTable)ViewState["CurrentProexp"];

                dt.Rows.RemoveAt(id);
                if (dt.Rows.Count > 0)
                {
                    GrdProExpDtls.DataSource = dt;
                    ViewState["CurrentProexp"] = dt;
                    GrdProExpDtls.DataBind();
                }
                else
                {
                    SetInitialRowExpenseDtls();
                }
                MakeControlEmpty();
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    #region [Web Services]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        DMProperty Obj_CM = new DMProperty();
        String[] SearchList = Obj_CM.GetSuggestRecord(prefixText);
        return SearchList;
    }
    #endregion

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        StrCondition = TxtSearch.Text.Trim();
        ReportGrid(StrCondition);
    }

    protected void ddlProprtyType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DataSet Ds = new DataSet();
            Ds = obj_Property.GetDataOnProperty(Convert.ToInt32(ddlProprtyType.SelectedValue), out StrError);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                ddlPropertySubType.DataSource = Ds.Tables[0];
                ddlPropertySubType.DataTextField = "PropertySubTypeDesc";
                ddlPropertySubType.DataValueField = "PropertySubTypeId";
                ddlPropertySubType.DataBind();
            }

            ddlPropertySubType.Focus();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DataSet Ds = new DataSet();
            Ds = obj_Property.GetDataOnCity(Convert.ToInt32(ddlCity.SelectedValue), out StrError);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                ddlLocation.DataSource = Ds.Tables[0];
                ddlLocation.DataTextField = "LocationName";
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataBind();
            }

            ddlLocation.Focus();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}
