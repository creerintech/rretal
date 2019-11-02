using  System;
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
using System.Threading;
using System.IO;
using System.Collections.Generic;
using Build.Utility;
using Build.EntityClass;
using Build.DB;
using Build.DataModel;
using Build.DALSQLHelper;

#region Pdf
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;
#endregion

#region Crystal Report
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using System.Globalization;
#endregion


public partial class Masters_ProjectConfigurator1 : System.Web.UI.Page
{
    #region[Private Variables]
    DMProjectConfigurator Obj_PC = new DMProjectConfigurator();
    ProjectConfigurator Entity_PC = new ProjectConfigurator();
    CommanFunction Obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();
    DataSet DS1 = new DataSet();
    private bool Flag = false;
    private static int FloorNoCount = 0;
    private static bool FlagBooked = false;
    private string StrError = string.Empty;
    private string StrCondition = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false, FlagPrint = false;
    #endregion

    #region[UserDefinedFunction]

    //User Right Function===========
    public void CheckUserRight()
    {
        try
        {
            FlagAdd = FlagDel = FlagEdit = FlagPrint = false;
            #region [USER RIGHT]
            //Checking Session Varialbels========
            if (Session["UserName"] != null && Session["UserRole"] != null)
            {
                //Checking User Role========
                //if (!Session["UserRole"].Equals("Administrator"))
                ////Checking Right of users=======
                //{
                System.Data.DataSet dsChkUserRight = new System.Data.DataSet();
                System.Data.DataSet dsChkUserRight1 = new System.Data.DataSet();
                dsChkUserRight1 = (DataSet)Session["DataSet"];

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='Project Configurator Master'");
                if (dtRow.Length > 0)
                {
                    DataTable dt = dtRow.CopyToDataTable();
                    dsChkUserRight.Tables.Add(dt);// = dt.Copy();
                }
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["ViewAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["AddAuth"].ToString()) == false &&
                    Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false &&
                    Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["PrintAuth"].ToString()) == false)
                {
                    Response.Redirect("~/Masters/NotAuthUser.aspx");
                }
                //Checking View Right ========                    
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["ViewAuth"].ToString()) == false)
                {
                    GrdReport.Visible = false;
                }
                //Checking Add Right ========                    
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["AddAuth"].ToString()) == false)
                {
                    BtnSave.Visible = false;
                    FlagAdd = true;

                }
                //Edit /Delete Column Visible ========
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false &&
                    Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["PrintAuth"].ToString()) == false)
                {
                    foreach (GridViewRow GRow in GrdReport.Rows)
                    {
                        GRow.FindControl("ImgBtnDelete").Visible = false;
                        // GRow.FindControl("ImgBtnEdit").Visible = true;
                        GRow.FindControl("ImgBtnPrint").Visible = false;
                    }
                    BtnUpdate.Visible = false;
                    FlagDel = true;
                    FlagEdit = true;
                    FlagPrint = true;
                }
                else
                {
                    //Checking Delete Right ========
                    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false)
                    {
                        foreach (GridViewRow GRow in GrdReport.Rows)
                        {
                            GRow.FindControl("ImgBtnDelete").Visible = false;                           
                        }
                        FlagDel = true;
                    }

                    //Checking Edit Right ========
                    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                    {
                        //foreach (GridViewRow GRow in GrdReport.Rows)
                        //{
                        //GRow.FindControl("ImageGridEdit").Visible = false;

                        //FlagEdit = true;
                        //}
                        BtnUpdate.Visible = false;

                    }


                    //Checking Print Right ========
                    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["PrintAuth"].ToString()) == false)
                    {
                        foreach (GridViewRow GRow in GrdReport.Rows)
                        {
                            GRow.FindControl("ImgBtnPrint").Visible = false;                        
                        }
                        FlagPrint = true;
                    }
                }
                dsChkUserRight.Dispose();
                //}
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            #endregion
        }
        catch (ThreadAbortException ex)
        {
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    //User Right Function===========

    private void MakeEmptyForm()
    {
        //string satr = DateTime.Now.DayOfWeek.ToString();
        //string Name = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
        txtSaleableFSI.Text = "0";
        txtLoading.Text = "";
        txtTotalLand.Text = "0";

        trAddGrid.Visible = false;
        DivDetailGrid.Visible = false;
        txtStampDuty.Text = string.Empty;
        txtRegistration.Text = string.Empty;
        txtVat.Text = string.Empty;
        txtCollection.Text = string.Empty;
        txtServiceTax.Text = string.Empty;
        txtCancelCharge.Text = string.Empty;
        txtTerraceAreaPer.Text = "100";
        txtGardenAreaPer.Text = "100";
            
        ddlClone.Items.Clear();
        txtSubTotal.Enabled = false;
        txtTotalAll.Enabled = false;
        txtProjectName.Focus();
        BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        BtnCancel.Visible = true;
        ImgDone.Visible = false;
        txtNoofTower.Text = "0";
        txtTotalAll.Text = "0";
        txtProjectName.Text = string.Empty;
        TxtSearch.Text = string.Empty;
        txtSqft.Enabled = false;
        RBEvenOdd.Checked = true;
        ddlProjectType.SelectedValue = "0";
        ddlProjectSubtype.SelectedValue = "0";
        txtAddress.Text = string.Empty;
        txtPCNo.Enabled = false;
        txtSubTotal.Text = "0";

        GetPCNo();
        Fillcombo();
        ReportGrid(StrCondition);
        SetInitialCompanyRow();
        SetInitialRowImages();
        SetInitialRowLayout();
        SetInitialRowMap();
        SetInitialRowLogo();
        SetInitialRowPlan();
        SetInitialRowAmenity();
        SetInitialRowSpec();
        SetInitialRowMain();
        SetInitialRowVideo();

        #region[UserRights]
        if (FlagAdd)
        {
            BtnSave.Visible = false;
        }
        if (FlagEdit)
        {
            //foreach (GridViewRow GRow in GrdReport.Rows)
            //{
            //    GRow.FindControl("ImgBtnEdit").Visible = false;
            //}
            BtnUpdate.Visible = false;
        }
        if (FlagDel)
        {
            foreach (GridViewRow GRow in GrdReport.Rows)
            {
                GRow.FindControl("ImgBtnDelete").Visible = false;
            }
        }
        if (FlagPrint)
        {
            foreach (GridViewRow GRow in GrdReport.Rows)
            {
                GRow.FindControl("ImgBtnPrint").Visible = false;
            }
        }
        #endregion
    }

    private void MakeControlEmpty()
    {
        txtCompanyName.Text = string.Empty;
        txtCompanyAddress.Text = string.Empty;
        lblLogopath.Text = string.Empty;

        ViewState["GridIndex"] = null;
        ImgAddCompany.ImageUrl = "~/Images/Icon/Gridadd.png";
        ImgAddCompany.ToolTip = "Add Grid";
        ImgCompanyLogo.ImageUrl = "";

    }

    private void MakeTowerControlEmpty()
    {
        txtFloor.Text = "0";
        txtUnit.Text ="0";
        txtSqft.Text = "0";
        txtSqftEven.Text = "0";
        txtSqftOdd.Text = "0";
        txtTowerName.Text = string.Empty;
        txtSubTotal.Text = "0";
        GridDetails.DataSource = null;
        GridDetails.DataBind();
    }
    private void Fillcombo()
    {
        try
        {

            DataSet DsCombo = new DataSet();
            DsCombo = Obj_PC.FillCombo(out StrError);
            if (DsCombo.Tables.Count > 0)
            {
                //===========Grade
                if (DsCombo.Tables[0].Rows.Count > 0)
                {
                    ddlProjectType.DataSource = DsCombo.Tables[0];
                    ddlProjectType.DataTextField = "ProjectType";
                    ddlProjectType.DataValueField = "ProjectTypeId";
                    ddlProjectType.DataBind();
                }
                if (DsCombo.Tables[1].Rows.Count > 0)
                {
                    ddlProjectSubtype.DataSource = DsCombo.Tables[1];
                    ddlProjectSubtype.DataTextField = "ProjectSubType";
                    ddlProjectSubtype.DataValueField = "ProjectSubTypeId";
                    ddlProjectSubtype.DataBind();
                }
                if (DsCombo.Tables[2].Rows.Count > 0)
                {
                    ViewState["ddlFlatType"] = DsCombo.Tables[2];
                }
            }
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private bool Check()
    {
        int Count = 1;
        Label lblComp=(Label)GridCompany.Rows[0].FindControl("lblCompany");
        Label lblTowerName1 = (Label)GridMainDetail.Rows[0].FindControl("lblTowerName1");
        int Number =!string.IsNullOrEmpty(txtNoofTower.Text)? Convert.ToInt32(txtNoofTower.Text):0;
        DataTable dtMainGrid = (DataTable)ViewState["MainDetail"];
        for (int j = dtMainGrid.Rows.Count - 2; j > 0; j--)
        {
            string currName = dtMainGrid.Rows[j]["TowerName"].ToString();
            string PrevName = dtMainGrid.Rows[j + 1]["TowerName"].ToString();
            if (!PrevName.Equals(currName))
            {
                Count++;
            }
        }
        if (Count != Convert.ToInt32(txtNoofTower.Text))
        {
            Obj_Comm.ShowPopUpMsg("Please Insert Towers", this.Page);
        }

        if (!lblComp.Text.Equals("&nbsp;") && !lblComp.Text.Equals("") && Number > 0 && !lblTowerName1.Text.Equals("&nbsp;") && !lblTowerName1.Text.Equals("") && Count == Convert.ToInt32(txtNoofTower.Text))
        {
            Flag=true;
        }
        return Flag;
    }
    private bool CountTower()
    {
        int Count = 1;
        Label lblComp = (Label)GridCompany.Rows[0].FindControl("lblCompany");
        Label lblTowerName1 = (Label)GridMainDetail.Rows[0].FindControl("lblTowerName1");
        int Number = !string.IsNullOrEmpty(txtNoofTower.Text) ? Convert.ToInt32(txtNoofTower.Text) : 0;
        DataTable dtMainGrid = (DataTable)ViewState["MainDetail"];
        for (int j = dtMainGrid.Rows.Count - 2; j > 0; j--)
        {
            string currName = dtMainGrid.Rows[j]["TowerName"].ToString();
            string PrevName = dtMainGrid.Rows[j + 1]["TowerName"].ToString();
            if (!PrevName.Equals(currName))
            {
                Count++;
            }
        }
       
        if (!string.IsNullOrEmpty(txtTowerName.Text) && !txtTowerName.Text.Equals("&nbsp;") && ddlClone.Items.Count > 0 && Count<Convert.ToInt32(txtNoofTower.Text))
        {
            Flag = true;
        }
        return Flag;
    }
    private void ReportGrid(string RepCondition)
    {
        try
        { 
            DS = new DataSet();
            DS = Obj_PC.GetProjectConfig(RepCondition, out StrError);
            if (DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    GrdReport.DataSource = DS.Tables[0];
                    GrdReport.DataBind();
                }
                else
                {
                    GrdReport.DataSource = null;
                    GrdReport.DataBind();
                }
                if (DS.Tables[2].Rows.Count > 0)
                {
                    GridAmenities.DataSource = DS.Tables[2];
                    ViewState["GridAmenity"] = DS.Tables[2];
                    GridAmenities.DataBind();
                }
                else
                {
                    GridAmenities.DataSource = null;
                    GridAmenities.DataBind();
                }
                if (DS.Tables[1].Rows.Count > 0)
                {
                    ViewState["GridSpecific"] = DS.Tables[1];
                    GridSpecific.DataSource = DS.Tables[1];
                    GridSpecific.DataBind();
                }
                else
                {

                    GridSpecific.DataSource = null;
                    GridSpecific.DataBind();
                }
                if (DS.Tables[3].Rows.Count > 0)
                {
                    GridDocumentList.DataSource = DS.Tables[3];
                    ViewState["DocumentList"] = DS.Tables[3];
                    GridDocumentList.DataBind();
                }
                else
                {
                    GridDocumentList.DataSource = null;
                    GridDocumentList.DataBind();
                }
            }
            Obj_PC = null;
            DS = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    //private void SetInitialRow(int Floor, int unit)
    //{
    //    try
    //    {
    //        DataTable dt = new DataTable();
    //        DataRow dr;
    //        string SqftAll = txtSqft.Text;
    //        string SqftEven = txtSqftEven.Text;
    //        string SqftOdd = txtSqftOdd.Text;

    //        string Name = txtTowerName.Text;
    //        dt.Columns.Add("#", typeof(int));
    //        TemplateField cr1 = new TemplateField();
    //        cr1.HeaderTemplate = new MyGridview(DataControlRowType.Header, "Tower Name", "", 0);
    //        cr1.ItemTemplate = new MyGridview(DataControlRowType.DataRow, "", Name, 0);
    //        // Add the field column to the Columns collection of the GridView control.
    //        this.GridDetails.Columns.Add(cr1);
    //        for (int j = 0; j < unit; j++)
    //        {
    //            if (RBEvenOdd.Checked == true)
    //            {
    //                if (j % 2 == 0)
    //                {
    //                    TemplateField cr = new TemplateField();
    //                    cr.HeaderTemplate = new MyGridview(DataControlRowType.Header, "Unit" + (j + 1), SqftOdd, 1);
    //                    cr.ItemTemplate = new MyGridview(DataControlRowType.DataRow, "" + j, SqftOdd, 1);
    //                    // Add the field column to the Columns collection of the GridView control.

    //                    this.GridDetails.Columns.Add(cr);
    //                }
    //                else
    //                {
    //                    TemplateField cr = new TemplateField();
    //                    cr.HeaderTemplate = new MyGridview(DataControlRowType.Header, "Unit" + (j + 1), SqftEven, 1);
    //                    cr.ItemTemplate = new MyGridview(DataControlRowType.DataRow, "" + j, SqftEven, 1);
    //                    // Add the field column to the Columns collection of the GridView control.
    //                    this.GridDetails.Columns.Add(cr);
    //                }
    //            }
    //            else
    //            {
    //                TemplateField cr = new TemplateField();
    //                cr.HeaderTemplate = new MyGridview(DataControlRowType.Header, "Unit" + (j + 1), SqftAll, 1);
    //                cr.ItemTemplate = new MyGridview(DataControlRowType.DataRow, "", SqftAll, 1);
    //                // Add the field column to the Columns collection of the GridView control.
    //                this.GridDetails.Columns.Add(cr);
    //            }

    //        }


    //        for (int i = 0; i < Floor; i++)
    //        {
    //            dr = dt.NewRow();

    //            dr["#"] = 0;

    //            dt.Rows.Add(dr);

    //        }

    //        //ViewState["CurrentTable"] = dt;
    //        GridDetails.DataSource = dt;
    //        GridDetails.DataBind();
    //        DataTable Dtnew = new DataTable();
    //        //for (int s = 0; s < GridDetails.Rows.Count; s++)
    //        //{
    //        //    string value = ((TextBox)GridDetails.Rows[s].FindControl("txtUnit0")).Text;
    //        //    string value1 = ((TextBox)GridDetails.Rows[s].FindControl("txtUnit1")).Text;

    //        //}
    //        //for (int s = 0; s < GridDetails.Rows.Count; s++)
    //        //{
    //        //    //Dtnew.Columns.Add("#", typeof(int));
    //        //    DataRow datarw;
    //        //    GridViewRow row = GridDetails.Rows[s];
    //        //    datarw = dt.NewRow();
    //        //    for (int i = 0; i < row.Cells.Count; i++)
    //        //    {
    //        //        datarw[i] = ((TextBox)row.FindControl("txtUnit0")).Text;
    //        //    }

    //        //    Dtnew.Rows.Add(datarw);
    //        //}

    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //}

    private void SetInitialRow(int Floor,int unit)
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add(new DataColumn("LayoutPath", typeof(string)));
            dt.Columns.Add(new DataColumn("TowerName", typeof(string)));
            dt.Columns.Add(new DataColumn("FlatNo", typeof(string)));
           
            dt.Columns.Add(new DataColumn("Sqft", typeof(decimal)));
            dt.Columns.Add(new DataColumn("TerraceArea", typeof(decimal)));
            dt.Columns.Add(new DataColumn("GardenArea", typeof(decimal)));
            dt.Columns.Add(new DataColumn("CarpetArea", typeof(decimal)));


            dt.Columns.Add(new DataColumn("SqftSaleBuiltUp", typeof(decimal)));
            dt.Columns.Add(new DataColumn("TerraceAreaSaleBuiltUp", typeof(decimal)));
            dt.Columns.Add(new DataColumn("GardenAreaSaleBuiltUp", typeof(decimal)));
            dt.Columns.Add(new DataColumn("SaleableArea", typeof(decimal)));


            dt.Columns.Add(new DataColumn("AgreementCarpetFlat", typeof(decimal)));
            dt.Columns.Add(new DataColumn("AgreementCarpetTerrace", typeof(decimal)));

            dt.Columns.Add(new DataColumn("AgreementBuiltUpFlat", typeof(decimal)));
            dt.Columns.Add(new DataColumn("AgreementBuiltUpTerrace", typeof(decimal)));
            
            dt.Columns.Add(new DataColumn("FlatTypeId", typeof(int)));
            dt.Columns.Add(new DataColumn("Floor", typeof(int)));
            dt.Columns.Add(new DataColumn("Unit", typeof(int)));
            dt.Columns.Add(new DataColumn("FloorNo", typeof(int)));
            dt.Columns.Add(new DataColumn("FacingTypeId", typeof(int)));
            dt.Columns.Add(new DataColumn("TerracePer", typeof(decimal)));
            dt.Columns.Add(new DataColumn("GardenPer", typeof(decimal)));

            int j=1,k = 1;
            for (int i = 0; i < (Floor*unit); i++)
            {
                dr = dt.NewRow();
                if (k <= unit)
                {
                   
                }
                else
                {
                    k = 1;
                    j++;
                }
                if (RBEvenOdd.Checked == true)
                {
                    if (i % 2 == 0)
                    {
                        dr["Sqft"] = txtSqftOdd.Text;
                        dr["TerraceArea"] = txtSqftOdd.Text;
                        dr["GardenArea"] = txtSqftOdd.Text;
                        dr["SaleableArea"] = txtSqftOdd.Text;
                        dr["CarpetArea"] = txtSqftOdd.Text;
                        
                        dr["FlatTypeId"] = 0;
                        dr["Floor"] = !string.IsNullOrEmpty(txtFloor.Text) ? Convert.ToInt32(txtFloor.Text) : 0;
                        dr["Unit"] = !string.IsNullOrEmpty(txtUnit.Text) ? Convert.ToInt32(txtUnit.Text) : 0;

                        dr["TerracePer"] = !string.IsNullOrEmpty(txtTerraceAreaPer.Text) ? Convert.ToInt32(txtTerraceAreaPer.Text) : 0;
                        dr["GardenPer"] = !string.IsNullOrEmpty(txtGardenAreaPer.Text) ? Convert.ToInt32(txtGardenAreaPer.Text) : 0;

                        if (k < 10)
                            dr["FlatNo"] = txtTowerName.Text + j + "0" + k;
                            //dr["FlatNo"] = j + "0" + k; //Done By Sushma On 25 Apr 2014
                        else
                            dr["FlatNo"] = txtTowerName.Text + j + k;
                            //dr["FlatNo"] = j + k;  //Done By Sushma On 25 Apr 2014
                        dr["TowerName"] = txtTowerName.Text;
                        k++;
                    }
                    else
                    {
                        dr["Sqft"] = txtSqftEven.Text;
                        dr["TerraceArea"] = txtSqftEven.Text;
                        dr["GardenArea"] = txtSqftEven.Text;
                        dr["SaleableArea"] = txtSqftEven.Text;
                        dr["CarpetArea"] = txtSqftEven.Text;

                        dr["FlatTypeId"] = 0;
                        dr["Floor"] = !string.IsNullOrEmpty(txtFloor.Text) ? Convert.ToInt32(txtFloor.Text) : 0;
                        dr["Unit"] = !string.IsNullOrEmpty(txtUnit.Text) ? Convert.ToInt32(txtUnit.Text) : 0;

                        dr["TerracePer"] = !string.IsNullOrEmpty(txtTerraceAreaPer.Text) ? Convert.ToInt32(txtTerraceAreaPer.Text) : 0;
                        dr["GardenPer"] = !string.IsNullOrEmpty(txtGardenAreaPer.Text) ? Convert.ToInt32(txtGardenAreaPer.Text) : 0;

                        if (k < 10)
                            dr["FlatNo"] = txtTowerName.Text + j + "0" + k;
                            //dr["FlatNo"] = j + "0" + k; //Done By Sushma On 25 Apr 2014
                        else
                            dr["FlatNo"] = txtTowerName.Text + j + k;
                            //dr["FlatNo"] = j + k; //Done By Sushma On 25 Apr 2014
                            dr["TowerName"] = txtTowerName.Text;
                        k++;
                    }
                }
                else
                {
                    dr["Sqft"] = txtSqft.Text;
                    dr["TerraceArea"] = txtSqft.Text;
                    dr["GardenArea"] = txtSqft.Text;
                    dr["CarpetArea"] = txtSqft.Text;

                    dr["SaleableArea"] = txtSqft.Text;

                    dr["FlatTypeId"] = 0;
                    dr["Floor"] = !string.IsNullOrEmpty(txtFloor.Text) ? Convert.ToInt32(txtFloor.Text) : 0;
                    dr["Unit"] = !string.IsNullOrEmpty(txtUnit.Text) ? Convert.ToInt32(txtUnit.Text) : 0;
                    dr["TerracePer"] = !string.IsNullOrEmpty(txtTerraceAreaPer.Text) ? Convert.ToInt32(txtTerraceAreaPer.Text) : 0;
                    dr["GardenPer"] = !string.IsNullOrEmpty(txtGardenAreaPer.Text) ? Convert.ToInt32(txtGardenAreaPer.Text) : 0;

                    if (k < 10)
                        dr["FlatNo"] = txtTowerName.Text + j + "0" + k;
                        //dr["FlatNo"] = j + "0" + k; //Done By Sushma On 25 Apr 2014
                    else
                        dr["FlatNo"] = txtTowerName.Text + j + k;
                    //dr["FlatNo"] =  j + k; //Done By Sushma On 25 Apr 2014
                    dr["TowerName"] = txtTowerName.Text;
                    k++;
                }

                dr["SqftSaleBuiltUp"] = 0;
                dr["TerraceAreaSaleBuiltUp"] = 0;
                dr["GardenAreaSaleBuiltUp"] = 0;


                dr["AgreementCarpetFlat"] = 0;
                dr["AgreementCarpetTerrace"] = 0;

                dr["AgreementBuiltUpFlat"] = 0;
                dr["AgreementBuiltUpTerrace"] = 0;

                dr["FloorNo"] = 0;
                dr["FacingTypeId"] = 0;
                dr["LayoutPath"] = "";
                dt.Rows.Add(dr);
            }
            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
            GridDetails.DataSource = dt;
            GridDetails.DataBind();

            #region [Generate Floor]

            int FloorCount = 1;
            int Count = 0;
            for (int i = 0; i < GridDetails.Rows.Count; i++)
            {
                if (Count >= unit)
                {
                    FloorCount++;
                    Count = 1;
                }
                else
                {
                    Count++;
                }
                GridDetails.Rows[i].Cells[19].Text = FloorCount.ToString();

            }
            #endregion

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {

        }
    }

    private void SetInitialRowFloorwise(int Floor, int unit)
    {
        try
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            if (ViewState["CurrentTableFloor"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableFloor"];

                DataRow dtTableRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 0; i < (unit); i++)
                    {
                        dtTableRow = dtCurrentTable.NewRow();
                        dtTableRow["Sqft"] = !string.IsNullOrEmpty(txtSqft.Text) ? txtSqft.Text : "";
                        dtTableRow["TerraceArea"] = !string.IsNullOrEmpty(txtSqft.Text) ? txtSqft.Text : "";
                        dtTableRow["GardenArea"] = !string.IsNullOrEmpty(txtSqft.Text) ? txtSqft.Text : "";
                        dtTableRow["CarpetArea"] = !string.IsNullOrEmpty(txtSqft.Text) ? txtSqft.Text : "";

                        dtTableRow["SqftSaleBuiltUp"] = !string.IsNullOrEmpty(txtSqft.Text) ? txtSqft.Text : "";
                        dtTableRow["TerraceAreaSaleBuiltUp"] = !string.IsNullOrEmpty(txtSqft.Text) ? txtSqft.Text : "";
                        dtTableRow["GardenAreaSaleBuiltUp"] = !string.IsNullOrEmpty(txtSqft.Text) ? txtSqft.Text : "";
                        dtTableRow["SaleableArea"] = !string.IsNullOrEmpty(txtSqft.Text) ? txtSqft.Text : "";

                        dtTableRow["AgreementCarpetFlat"] = !string.IsNullOrEmpty(txtSqft.Text) ? txtSqft.Text : "";
                        dtTableRow["AgreementCarpetTerrace"] = !string.IsNullOrEmpty(txtSqft.Text) ? txtSqft.Text : "";

                        dtTableRow["AgreementBuiltUpFlat"] = !string.IsNullOrEmpty(txtSqft.Text) ? txtSqft.Text : "";
                        dtTableRow["AgreementBuiltUpTerrace"] = !string.IsNullOrEmpty(txtSqft.Text) ? txtSqft.Text : "";
                        
                        dtTableRow["FlatTypeId"] = 0;
                        dtTableRow["Floor"] = !string.IsNullOrEmpty((Floor + 1).ToString()) ? (Floor + 1).ToString() : "";
                        dtTableRow["Unit"] = !string.IsNullOrEmpty(txtUnit.Text) ? txtUnit.Text : "";

                        dtTableRow["FlatNo"] = txtTowerName.Text + (Floor+1).ToString()+"0"+(i+1);
                        dtTableRow["TowerName"] = !string.IsNullOrEmpty(txtTowerName.Text) ? txtTowerName.Text : "";
                        dtTableRow["FloorNo"] = Floor + 1;
                        dtTableRow["FacingTypeId"] = 0;
                        dtTableRow["LayoutPath"] = "";
                        dtTableRow["TerracePer"] = !string.IsNullOrEmpty(txtTerraceAreaPer.Text) ? Convert.ToInt32(txtTerraceAreaPer.Text) : 0;
                        dtTableRow["GardenPer"] = !string.IsNullOrEmpty(txtGardenAreaPer.Text) ? Convert.ToInt32(txtGardenAreaPer.Text) : 0;

                        dtCurrentTable.Rows.Add(dtTableRow);
                    }
                    ViewState["CurrentTable"] = dtCurrentTable;
                    ViewState["CurrentTableFloor"] = dtCurrentTable;
                    
                    GridDetails.DataSource = dtCurrentTable;
                    GridDetails.DataBind();
                    DivDetailGrid.Visible = true;
                    trAddGrid.Visible = true;
                }
            }
            else
            {
               
                dt.Columns.Add(new DataColumn("LayoutPath", typeof(string)));
                dt.Columns.Add(new DataColumn("TowerName", typeof(string)));
                dt.Columns.Add(new DataColumn("FlatNo", typeof(string)));

                dt.Columns.Add(new DataColumn("Sqft", typeof(decimal)));
                dt.Columns.Add(new DataColumn("TerraceArea", typeof(decimal)));
                dt.Columns.Add(new DataColumn("GardenArea", typeof(decimal)));
                dt.Columns.Add(new DataColumn("CarpetArea", typeof(decimal)));

                dt.Columns.Add(new DataColumn("SqftSaleBuiltUp", typeof(decimal)));
                dt.Columns.Add(new DataColumn("TerraceAreaSaleBuiltUp", typeof(decimal)));
                dt.Columns.Add(new DataColumn("GardenAreaSaleBuiltUp", typeof(decimal)));
                dt.Columns.Add(new DataColumn("SaleableArea", typeof(decimal)));


                dt.Columns.Add(new DataColumn("AgreementCarpetFlat", typeof(decimal)));
                dt.Columns.Add(new DataColumn("AgreementCarpetTerrace", typeof(decimal)));

                dt.Columns.Add(new DataColumn("AgreementBuiltUpFlat", typeof(decimal)));
                dt.Columns.Add(new DataColumn("AgreementBuiltUpTerrace", typeof(decimal)));


                dt.Columns.Add(new DataColumn("FlatTypeId", typeof(int)));
                dt.Columns.Add(new DataColumn("Floor", typeof(int)));
                dt.Columns.Add(new DataColumn("Unit", typeof(int)));
                dt.Columns.Add(new DataColumn("FloorNo", typeof(int)));
                dt.Columns.Add(new DataColumn("FacingTypeId", typeof(int)));
                dt.Columns.Add(new DataColumn("TerracePer", typeof(decimal)));
                dt.Columns.Add(new DataColumn("GardenPer", typeof(decimal)));

                int j = 1, k = 1;
                for (int i = 0; i < (unit); i++)
                {
                    dr = dt.NewRow();
                    if (k <= unit)
                    {

                    }
                    else
                    {
                        k = 1;
                        j++;
                    }

                    dr["Sqft"] = txtSqft.Text;
                    dr["TerraceArea"] = 0;
                    dr["GardenArea"] = 0;
                    dr["CarpetArea"] = 0;

                    dr["SqftSaleBuiltUp"] = 0;
                    dr["TerraceAreaSaleBuiltUp"] = 0;
                    dr["GardenAreaSaleBuiltUp"] = 0;
                    dr["SaleableArea"] = 0;

                    dr["AgreementCarpetFlat"] = 0;
                    dr["AgreementCarpetTerrace"] = 0;

                    dr["AgreementBuiltUpFlat"] = 0;
                    dr["AgreementBuiltUpTerrace"] = 0;

                    dr["FlatTypeId"] = 0;
                    dr["Floor"] = !string.IsNullOrEmpty((Floor+1).ToString()) ? Convert.ToInt32(Floor+1) : 0;
                    dr["Unit"] = !string.IsNullOrEmpty(txtUnit.Text) ? Convert.ToInt32(txtUnit.Text) : 0;

                    if (k < 10)
                        dr["FlatNo"] = txtTowerName.Text + j + "0" + k;
                    else
                        dr["FlatNo"] = txtTowerName.Text + j + k;
                    dr["TowerName"] = txtTowerName.Text;
                    k++;

                    dr["FloorNo"] = Floor+1;
                    dr["FacingTypeId"] = 0;
                    dr["LayoutPath"] = "";
                    dr["TerracePer"] = !string.IsNullOrEmpty(txtTerraceAreaPer.Text) ? Convert.ToInt32(txtTerraceAreaPer.Text) : 0;
                    dr["GardenPer"] = !string.IsNullOrEmpty(txtGardenAreaPer.Text) ? Convert.ToInt32(txtGardenAreaPer.Text) : 0;

                    dt.Rows.Add(dr);
                }
                //Store the DataTable in ViewState
                ViewState["CurrentTableFloor"] = dt;
                ViewState["CurrentTable"] = dt;
                GridDetails.DataSource = dt;
                GridDetails.DataBind();
                DivDetailGrid.Visible = true;
                trAddGrid.Visible = true;

                //#region [Generate Floor]

                //int FloorCount = 1;
                //int Count = 0;
                //for (int i = 0; i < GridDetails.Rows.Count; i++)
                //{
                //    if (Count >= unit)
                //    {
                //        FloorCount++;
                //        Count = 1;
                //    }
                //    else
                //    {
                //        Count++;
                //    }
                //    GridDetails.Rows[i].Cells[12].Text = FloorCount.ToString();

                //}
                //#endregion

                dt = null;
                dr = null;
            }
           

        }
        catch (Exception ex)
        {

        }
    }

    private void SetInitialCompanyRow()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add(new DataColumn("#", typeof(int)));
            dt.Columns.Add(new DataColumn("Company", typeof(string)));
            dt.Columns.Add(new DataColumn("CompanyAddress", typeof(string)));
            dt.Columns.Add(new DataColumn("LogoImg", typeof(string)));

          
            dr = dt.NewRow();

            dr["#"] = 0;
            dr["Company"] = "";
            dr["CompanyAddress"] = "";
            dr["LogoImg"] = "";
     
                dt.Rows.Add(dr);
            
            //Store the DataTable in ViewState
            ViewState["CompanyTable"] = dt;
            GridCompany.DataSource = dt;
            GridCompany.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {

        }
    }

    private void SetInitialDocumentList()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add(new DataColumn("DocId", typeof(int)));
            dt.Columns.Add(new DataColumn("DocName", typeof(string)));
            

            dr = dt.NewRow();

            dr["DocId"] = 0;
            dr["DocName"] = "";
          
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["DocumentList"] = dt;
            GridDocumentList.DataSource = dt;
            GridDocumentList.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {

        }
    }

    private void SetInitialRowMain()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add(new DataColumn("UsedCount", typeof(string)));
            dt.Columns.Add(new DataColumn("PCDetailId", typeof(string)));

            dt.Columns.Add(new DataColumn("TowerName", typeof(string)));
            dt.Columns.Add(new DataColumn("FlatNo", typeof(string)));
            dt.Columns.Add(new DataColumn("Sqft", typeof(decimal)));
            dt.Columns.Add(new DataColumn("TerraceArea", typeof(decimal)));
            dt.Columns.Add(new DataColumn("GardenArea", typeof(decimal)));
            dt.Columns.Add(new DataColumn("CarpetArea", typeof(decimal)));

            dt.Columns.Add(new DataColumn("SqftSaleBuiltUp", typeof(decimal)));
            dt.Columns.Add(new DataColumn("TerraceAreaSaleBuiltUp", typeof(decimal)));
            dt.Columns.Add(new DataColumn("GardenAreaSaleBuiltUp", typeof(decimal)));
            dt.Columns.Add(new DataColumn("SaleableArea", typeof(decimal)));


            dt.Columns.Add(new DataColumn("AgreementCarpetFlat", typeof(decimal)));
            dt.Columns.Add(new DataColumn("AgreementCarpetTerrace", typeof(decimal)));

            dt.Columns.Add(new DataColumn("AgreementBuiltUpFlat", typeof(decimal)));
            dt.Columns.Add(new DataColumn("AgreementBuiltUpTerrace", typeof(decimal)));

            dt.Columns.Add(new DataColumn("FlatTypeId", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Floor", typeof(int)));
            dt.Columns.Add(new DataColumn("Unit", typeof(int)));
            dt.Columns.Add(new DataColumn("FloorNo", typeof(int)));
            dt.Columns.Add(new DataColumn("FacingTypeId", typeof(int)));
            dt.Columns.Add(new DataColumn("LayoutPath", typeof(string)));
            dt.Columns.Add(new DataColumn("TerracePer", typeof(string)));
            dt.Columns.Add(new DataColumn("GardenPer", typeof(string)));
            
                dr = dt.NewRow();

                    dr["UsedCount"] = 0;
                    dr["PCDetailId"] = 0;
                    dr["Sqft"] = 0;
                    dr["TerraceArea"] = 0;
                    dr["GardenArea"] = 0;
                    dr["SaleableArea"] = 0;
                    dr["CarpetArea"] = 0;
                    dr["FlatNo"] ="" ;
                    dr["TowerName"] ="";
                    dr["FlatTypeId"] = 0;
                    dr["Floor"] = 0;
                    dr["Unit"] = 0;
                    dr["FloorNo"] = 0;
                    dr["FacingTypeId"] = 0;
                    dr["LayoutPath"] = "";
                    dr["TerracePer"] = 0;
                    dr["GardenPer"] = 0;
                    dr["SqftSaleBuiltUp"] = 0;
                    dr["TerraceAreaSaleBuiltUp"] = 0;
                    dr["GardenAreaSaleBuiltUp"] = 0;


                    dr["AgreementCarpetFlat"] = 0;
                    dr["AgreementCarpetTerrace"] = 0;

                    dr["AgreementBuiltUpFlat"] = 0;
                    dr["AgreementBuiltUpTerrace"] = 0;

                dt.Rows.Add(dr);
            
            //Store the DataTable in ViewState
            ViewState["MainDetail"] = dt;
            GridMainDetail.DataSource = dt;
            GridMainDetail.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {

        }
    }

    private void SetInitialRowImages()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add(new DataColumn("ImageName", typeof(string)));
            dr = dt.NewRow();

            dr["ImageName"] = "";
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTableImages"] = dt;
            grdupload.DataSource = dt;
            grdupload.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void SetInitialRowLayout()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add(new DataColumn("LayoutImg", typeof(string)));
            dr = dt.NewRow();

            dr["LayoutImg"] = "";
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTableLayout"] = dt;
            GridLayout.DataSource = dt;
            GridLayout.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void SetInitialRowMap()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add(new DataColumn("MapImg", typeof(string)));
            dr = dt.NewRow();

            dr["MapImg"] = "";
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTableMap"] = dt;
            GridMap.DataSource = dt;
            GridMap.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void SetInitialRowLogo()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add(new DataColumn("LogoImg", typeof(string)));
            dr = dt.NewRow();

            dr["LogoImg"] = "";
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTableLogo"] = dt;
            GridLogo.DataSource = dt;
            GridLogo.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void SetInitialRowPlan()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add(new DataColumn("PlanImg", typeof(string)));
            dr = dt.NewRow();

            dr["PlanImg"] = "";
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTablePlan"] = dt;
            GridPlan.DataSource = dt;
            GridPlan.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void SetInitialRowAmenity()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add(new DataColumn("AmenityImage", typeof(string)));
            dr = dt.NewRow();

            dr["AmenityImage"] = "";
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTableAmenity"] = dt;
            GridAmenityImg.DataSource = dt;
            GridAmenityImg.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void SetInitialRowSpec()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add(new DataColumn("SpecImage", typeof(string)));
            dr = dt.NewRow();

            dr["SpecImage"] = "";
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTableSpec"] = dt;
            GridSpecImg.DataSource = dt;
            GridSpecImg.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void SetInitialRowVideo()
    {
        try
        {
            DataTable dt1 = new DataTable();

            DataRow dr = null;
            dt1.Columns.Add(new DataColumn("VideoName", typeof(string)));
            dr = dt1.NewRow();

            dr["VideoName"] = "";
            dt1.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTableVideo"] = dt1;
            GridVideo.DataSource = dt1;
            GridVideo.DataBind();

            dt1 = null;
            dr = null;
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }
    
    private void AddtoGridPhotos(string filename)
    {
        try
        {
            if (ViewState["CurrentTableImages"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableImages"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    // CheckBox chkIma=(CheckBox)grdupload.Rows[i].Cells[1].FindControl[|]
                    drCurrentRow = dtCurrentTable.NewRow();

                    if (dtCurrentTable.Rows.Count == 1 && dtCurrentTable.Rows[0]["ImageName"].ToString().Equals(""))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }

                    drCurrentRow["ImageName"] ="~/Images/" + filename;
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    //Store the current data to ViewState
                    ViewState["CurrentTableImages"] = dtCurrentTable;

                    //Rebind the Grid with the current data
                    grdupload.DataSource = dtCurrentTable;
                    grdupload.DataBind();

                    ////Checking User Right Function============
                    //CheckUserRight();
                    ////Checking User Right Function============
                }
            }

            else
            {
                Response.Write("ViewState is null");

            }
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void AddtoGridLayout(string filename)
    {
        try
        {
            if (ViewState["CurrentTableLayout"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableLayout"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    // CheckBox chkIma=(CheckBox)grdupload.Rows[i].Cells[1].FindControl[|]
                    drCurrentRow = dtCurrentTable.NewRow();

                    if (dtCurrentTable.Rows.Count == 1 && dtCurrentTable.Rows[0]["LayoutImg"].ToString().Equals(""))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }

                    drCurrentRow["LayoutImg"] = "~/Images/" + filename;
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    //Store the current data to ViewState
                    ViewState["CurrentTableLayout"] = dtCurrentTable;

                    //Rebind the Grid with the current data
                    GridLayout.DataSource = dtCurrentTable;
                    GridLayout.DataBind();

                    ////Checking User Right Function============
                    //CheckUserRight();
                    ////Checking User Right Function============
                }
            }

            else
            {
                Response.Write("ViewState is null");

            }
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void AddtoGridMap(string filename)
    {
        try
        {
            if (ViewState["CurrentTableMap"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableMap"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    // CheckBox chkIma=(CheckBox)grdupload.Rows[i].Cells[1].FindControl[|]
                    drCurrentRow = dtCurrentTable.NewRow();

                    if (dtCurrentTable.Rows.Count == 1 && dtCurrentTable.Rows[0]["MapImg"].ToString().Equals(""))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }

                    drCurrentRow["MapImg"] = "~/Images/" + filename;
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    //Store the current data to ViewState
                    ViewState["CurrentTableMap"] = dtCurrentTable;

                    //Rebind the Grid with the current data
                    GridMap.DataSource = dtCurrentTable;
                    GridMap.DataBind();

                    ////Checking User Right Function============
                    //CheckUserRight();
                    ////Checking User Right Function============
                }
            }

            else
            {
                Response.Write("ViewState is null");

            }
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void AddtoGridLogo(string filename)
    {
        try
        {
            if (ViewState["CurrentTableLogo"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableLogo"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    // CheckBox chkIma=(CheckBox)grdupload.Rows[i].Cells[1].FindControl[|]
                    drCurrentRow = dtCurrentTable.NewRow();

                    if (dtCurrentTable.Rows.Count == 1 && dtCurrentTable.Rows[0]["LogoImg"].ToString().Equals(""))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }

                    drCurrentRow["LogoImg"] = "~/Images/" + filename;
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    //Store the current data to ViewState
                    ViewState["CurrentTableLogo"] = dtCurrentTable;

                    //Rebind the Grid with the current data
                    GridLogo.DataSource = dtCurrentTable;
                    GridLogo.DataBind();

                    ////Checking User Right Function============
                    //CheckUserRight();
                    ////Checking User Right Function============
                }
            }

            else
            {
                Response.Write("ViewState is null");

            }
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void AddtoGridAmenity(string filename)
    {
        try
        {
            if (ViewState["CurrentTableAmenity"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableAmenity"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    // CheckBox chkIma=(CheckBox)grdupload.Rows[i].Cells[1].FindControl[|]
                    drCurrentRow = dtCurrentTable.NewRow();

                    if (dtCurrentTable.Rows.Count == 1 && dtCurrentTable.Rows[0]["AmenityImage"].ToString().Equals(""))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }

                    drCurrentRow["AmenityImage"] = "~/Images/" + filename;
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    //Store the current data to ViewState
                    ViewState["CurrentTableAmenity"] = dtCurrentTable;

                    //Rebind the Grid with the current data
                    GridAmenityImg.DataSource = dtCurrentTable;
                    GridAmenityImg.DataBind();

                    ////Checking User Right Function============
                    //CheckUserRight();
                    ////Checking User Right Function============
                }
            }

            else
            {
                Response.Write("ViewState is null");

            }
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void AddtoGridSpec(string filename)
    {
        try
        {
            if (ViewState["CurrentTableSpec"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableSpec"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    // CheckBox chkIma=(CheckBox)grdupload.Rows[i].Cells[1].FindControl[|]
                    drCurrentRow = dtCurrentTable.NewRow();

                    if (dtCurrentTable.Rows.Count == 1 && dtCurrentTable.Rows[0]["SpecImage"].ToString().Equals(""))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }

                    drCurrentRow["SpecImage"] = "~/Images/" + filename;
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    //Store the current data to ViewState
                    ViewState["CurrentTableSpec"] = dtCurrentTable;

                    //Rebind the Grid with the current data
                    GridSpecImg.DataSource = dtCurrentTable;
                    GridSpecImg.DataBind();

                    ////Checking User Right Function============
                    //CheckUserRight();
                    ////Checking User Right Function============
                }
            }

            else
            {
                Response.Write("ViewState is null");

            }
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void AddtoGridPlan(string filename)
    {
        try
        {
            if (ViewState["CurrentTablePlan"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTablePlan"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    // CheckBox chkIma=(CheckBox)grdupload.Rows[i].Cells[1].FindControl[|]
                    drCurrentRow = dtCurrentTable.NewRow();

                    if (dtCurrentTable.Rows.Count == 1 && dtCurrentTable.Rows[0]["PlanImg"].ToString().Equals(""))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }

                    drCurrentRow["PlanImg"] = "~/Images/" + filename;
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    //Store the current data to ViewState
                    ViewState["CurrentTablePlan"] = dtCurrentTable;

                    //Rebind the Grid with the current data
                    GridPlan.DataSource = dtCurrentTable;
                    GridPlan.DataBind();

                    ////Checking User Right Function============
                    //CheckUserRight();
                    ////Checking User Right Function============
                }
            }

            else
            {
                Response.Write("ViewState is null");

            }
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void AddtoGridVideo(string filename)
    {
        try
        {
            if (ViewState["CurrentTableVideo"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableVideo"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    // CheckBox chkIma=(CheckBox)grdupload.Rows[i].Cells[1].FindControl[|]
                    drCurrentRow = dtCurrentTable.NewRow();

                    if (dtCurrentTable.Rows.Count == 1 && dtCurrentTable.Rows[0]["VideoName"].ToString().Equals(""))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }

                    drCurrentRow["VideoName"] ="~/index_videolb/video/" + filename;
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    //Store the current data to ViewState
                    ViewState["CurrentTableVideo"] = dtCurrentTable;

                    //Rebind the Grid with the current data
                    GridVideo.DataSource = dtCurrentTable;
                    GridVideo.DataBind();

                    ////Checking User Right Function============
                    //CheckUserRight();
                    ////Checking User Right Function============
                }
            }

            else
            {
                Response.Write("ViewState is null");

            }
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    public void GetPCNo()
    {
        try
        {
            DS = Obj_PC.GetPCNO(out StrError);
            if (DS.Tables[0].Rows.Count > 0)
            {
                txtPCNo.Text = DS.Tables[0].Rows[0]["PCNo"].ToString();
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    public void GeneratePDF(string Imagepath, string BackImg, string fileName, string HeaderName, string[] Title, string[] Details, string[] TitleSpec, string[] DetailsSpec, Page oPage)
    {
        var document = new Document(PageSize.A4, 50, 50, 25, 25);
        document.SetMargins(3, 3, 3, 3);
        try
        {
            //Imagepath =Convert.ToString(GridLayout.Rows[0].Cells[1]);
            //BackImg = Convert.ToString(GridLogo.Rows[0].Cells[1]);
            // oPage.Response.Clear();
            PdfWriter.GetInstance(document, oPage.Response.OutputStream);
            // generates the grid first
            StringBuilder strB = new StringBuilder();
            StringBuilder strB1 = new StringBuilder();
            string str = string.Empty;
          //  str = " <table width='100%' ><tr><td align='center'><b>" + HeaderName + "</b></td></tr></table><br><br>";
            strB.Append(str);
            document.Open();
            using (StringWriter sWriter = new StringWriter(strB))
            {
                using (HtmlTextWriter htWriter = new HtmlTextWriter(sWriter))
                {
                    //GridReport.RenderControl(htWriter);
                    //GridSpec.RenderControl(htWriter);
                }

            }

            // now read the Grid html one by one and add into the document object
            using (TextReader sReader = new StringReader(strB.ToString()))
            {
                iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(BackImg);
                iTextSharp.text.Image backimg = iTextSharp.text.Image.GetInstance(Imagepath);

                Paragraph paragraph = new Paragraph(@"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse blandit blandit 
                turpis. Nam in lectus ut dolor consectetuer bibendum. Morbi neque ipsum, laoreet id; dignissim et, viverra id, mauris. Nulla 
                mauris elit, consectetuer sit amet, accumsan eget, congue ac, libero. Vivamus suscipit. Nunc dignissim consectetuer lectus. Fusce 
                elit nisi; commodo non, facilisis quis, hendrerit eu, dolor? Suspendisse eleifend nisi ut magna. Phasellus id lectus! Vivamus 
                laoreet enim et dolor. Integer arcu mauris, ultricies vel, porta quis, venenatis at, libero. Donec nibh est, adipiscing et, ul");
                paragraph.Alignment = Element.ALIGN_CENTER;
                gif.ScaleToFit(120f,120f);
                gif.Alignment = Element.ALIGN_CENTER;
                //gif.Alignment = iTextSharp.text.Image.UNDERLYING;
                gif.IndentationLeft = 9f;
                gif.SpacingAfter = 9f;
                gif.BorderWidthTop = 36f;

                backimg.ScaleToFit(3000f, 1000f);
                backimg.Alignment = iTextSharp.text.Image.UNDERLYING;
                backimg.SetAbsolutePosition(0,0);

                PdfPTable table = new PdfPTable(3);

                var FontColour = new BaseColor(75, 125, 31);
                var FontColour1 = new BaseColor(125, 75, 31);
                var MyFont = FontFactory.GetFont("Times New Roman", 11, FontColour);
                var MyFont1 = FontFactory.GetFont("Times New Roman", 11, FontColour1);

                PdfPCell cell = new PdfPCell(new Paragraph(HeaderName, MyFont1));
                PdfPCell cell1 = new PdfPCell(new Phrase(""));
                PdfPCell cell2 = new PdfPCell(new Phrase(""));
                PdfPCell cellimg = new PdfPCell(gif);
                cell.Border = Rectangle.NO_BORDER;
                
                cell1.Border = Rectangle.NO_BORDER;
                cell2.Border = Rectangle.NO_BORDER;
                cellimg.Border = Rectangle.NO_BORDER;

                cell.Colspan = 3;
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                table.AddCell(cell);
                table.AddCell(cell1);
                table.AddCell(cellimg);
                table.AddCell(cell2);
             //   table.DefaultCell.Border =;
                document.Add(table);
                document.Add(new Phrase(Environment.NewLine));
                document.Add(new Phrase(Environment.NewLine));
               // document.Add(gif);
                document.Add(paragraph);
                document.Add(backimg);

                document.NewPage();

                document.Add(new Paragraph("Amenities :"));

                for (int i = 0; i < Title.Length; i++)
                {
                    Chunk chk = new Chunk(Title[i], MyFont);
                    chk.SetUnderline(0.5f, -1.5f);
                    Paragraph paraTitle = new Paragraph();
                    paraTitle.Add(chk);
                    paraTitle.Alignment = Element.ALIGN_LEFT;
                    document.Add(paraTitle);
                    Paragraph paraDetail = new Paragraph(Details[i], MyFont1);
                    paraDetail.Alignment = Element.ALIGN_LEFT;
                    document.Add(paraDetail);
                }
                document.Add(new Paragraph("Specification :"));

                for (int i = 0; i < TitleSpec.Length; i++)
                {
                    Chunk chk = new Chunk(TitleSpec[i], MyFont);
                    chk.SetUnderline(0.5f, -1.5f);
                    Paragraph paraTitle = new Paragraph();
                    paraTitle.Add(chk);
                    paraTitle.Alignment = Element.ALIGN_LEFT;
                    document.Add(paraTitle);
                    Paragraph paraDetail = new Paragraph(DetailsSpec[i], MyFont1);
                    paraDetail.Alignment = Element.ALIGN_LEFT;
                    document.Add(paraDetail);
                }   
                List<IElement> list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                foreach (IElement elm in list)
                {
                    document.Add(elm);

                }
            }

            //oPage.Response.ContentType = "application/pdf";
            //oPage.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            //oPage.Response.Flush();
            //oPage.Response.End();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            document.Close();
        }
    }

    public void BindddlClone()
    {
        for (int i = 0; i < GridMainDetail.Rows.Count - 1; i++)//For Refreshing ddlClone
        {
            Label TowerName = (Label)GridMainDetail.Rows[i].Cells[1].FindControl("lblTowerName1");
            Label PrevTowerName = (Label)GridMainDetail.Rows[i + 1].Cells[1].FindControl("lblTowerName1");
            if (i == 0)
            {
                ddlClone.Items.Clear();
                ddlClone.Items.Add(new System.Web.UI.WebControls.ListItem(TowerName.Text, TowerName.Text));
            }
            else
            {
                if (!TowerName.Text.Equals(PrevTowerName.Text))
                {
                    ddlClone.Items.Add(new System.Web.UI.WebControls.ListItem(PrevTowerName.Text, PrevTowerName.Text));
                }
            }
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AccordionPane1.HeaderContainer.Width = 950;
            AccordionPane2.HeaderContainer.Width = 950;

            CheckUserRight();
            MakeEmptyForm();
            MakeControlEmpty();
            MakeTowerControlEmpty();
           
           
        }
        else
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "getvalue", " getvalue();", true);
        }
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "CalSubTotalNew1", "CalSubTotalNew();", true);
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int InsertRow, InsertRowDtls, InsertSpecific, InsertAmenity, InsertProjectImg, InsertCompany = 0;
        try
        {
            if (Check())
            {
                Entity_PC.PCNo = txtProjectName.Text.Trim();
                Entity_PC.PCName = txtProjectName.Text.Trim();
                Entity_PC.ProjectTypeId = Convert.ToInt32(ddlProjectType.SelectedValue);
                Entity_PC.ProjectSubTypeId = Convert.ToInt32(ddlProjectSubtype.SelectedValue);
                Entity_PC.Address = txtAddress.Text.Trim();
                Entity_PC.NOofTowers = Convert.ToInt32(txtNoofTower.Text);
                //Entity_PC.TowerName = txtTowerName.Text.Trim();
                //Entity_PC.Floors = !string.IsNullOrEmpty(txtFloor.Text) ? Convert.ToInt32(txtFloor.Text) : 0;
                //Entity_PC.Units = !string.IsNullOrEmpty(txtUnit.Text) ? Convert.ToInt32(txtUnit.Text) : 0;
                if (RBAll.Checked == true)
                    Entity_PC.IsAll = true;
                else
                    Entity_PC.IsAll = false;
                Entity_PC.SqftAll = !string.IsNullOrEmpty(txtSqft.Text) ? Convert.ToDecimal(txtSqft.Text) : 0;
                Entity_PC.SqftEven = !string.IsNullOrEmpty(txtSqftEven.Text) ? Convert.ToDecimal(txtSqftEven.Text) : 0;
                Entity_PC.SqftOdd = !string.IsNullOrEmpty(txtSqftOdd.Text) ? Convert.ToDecimal(txtSqftOdd.Text) : 0;
                //Entity_PC.LayoutPath = Convert.ToString(ViewState["ImageLayout"]);
                //Entity_PC.MapPath = Convert.ToString(ViewState["ImageMap"]);
                //Entity_PC.VideoPath = Convert.ToString(ViewState["UploadedPath1"]);

                Entity_PC.StampAC = txtStampDuty.Text.Trim();
                Entity_PC.RegistrationAC = txtRegistration.Text.Trim();
                Entity_PC.VatAC = txtVat.Text.Trim();
                Entity_PC.CollectionAC = txtCollection.Text.Trim();
                Entity_PC.ServiceTaxAC = txtServiceTax.Text.Trim();
                Entity_PC.CancelCharge = !string.IsNullOrEmpty(txtCancelCharge.Text) ? Convert.ToDecimal(txtCancelCharge.Text) : 0;
                Entity_PC.TerraceAreaPer = !string.IsNullOrEmpty(txtTerraceAreaPer.Text) ? Convert.ToDecimal(txtTerraceAreaPer.Text) : 0;
                Entity_PC.GardenAreaPer = !string.IsNullOrEmpty(txtGardenAreaPer.Text) ? Convert.ToDecimal(txtGardenAreaPer.Text) : 0;

                Entity_PC.Loading =  txtLoading.Text.Trim();
                Entity_PC.LandArea = !string.IsNullOrEmpty(txtTotalLand.Text) ? Convert.ToDecimal(txtTotalLand.Text) : 0;
                Entity_PC.SaleableFSI = !string.IsNullOrEmpty(txtSaleableFSI.Text) ? Convert.ToDecimal(txtSaleableFSI.Text) : 0;

                Entity_PC.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_PC.LoginDate = DateTime.Now;

                InsertRow = Obj_PC.InsertProjectConfi(ref Entity_PC, out StrError);
                Entity_PC.PCId = InsertRow;
                if (InsertRow > 0)
                {
                    //Insert Into PCAmenity
                    for (int i = 0; i < GridAmenities.Rows.Count; i++)
                    {
                        CheckBox GrdSelectAll = (CheckBox)GridAmenities.Rows[i].Cells[3].FindControl("chkDetails");
                        TextBox txtTitle1 = (TextBox)GridAmenities.Rows[i].Cells[2].FindControl("GrtxtTermCondition_Head");
                        if (txtTitle1.Text != "")
                        {
                            //Label TermId = (Label)GridAmenities.Rows[i].Cells[0].FindControl("LblEntryId");
                            //int a = Convert.ToInt32(TermId.Text);
                            //Entity_PC.AmenityId = a;
                            if (GrdSelectAll.Checked == true)
                            {
                                Entity_PC.AmenityId = 1;
                            }
                            else
                            {
                                Entity_PC.AmenityId = 2;
                            }
                           
                            TextBox txtTitle = (TextBox)GridAmenities.Rows[i].Cells[2].FindControl("GrtxtTermCondition_Head");
                            Entity_PC.Title = txtTitle.Text;
                            TextBox txtdesc = (TextBox)GridAmenities.Rows[i].Cells[4].FindControl("GrtxtDesc");
                            Entity_PC.Details = txtdesc.Text;
                            InsertAmenity = Obj_PC.InsertAmenityDetail(ref Entity_PC, out StrError);

                        }
                    }

                    //Insert Into PCSpecification
                    for (int i = 0; i < GridSpecific.Rows.Count; i++)
                    {
                        CheckBox GrdSelectAll = (CheckBox)GridSpecific.Rows[i].Cells[3].FindControl("chkDetails");
                        TextBox txtTitle1 = (TextBox)GridSpecific.Rows[i].Cells[2].FindControl("GrtxtTermCondition_Head");
                        if (txtTitle1.Text != "")
                        {
                            //Label TermId = (Label)GridSpecific.Rows[i].Cells[0].FindControl("LblEntryId");
                            //int a = Convert.ToInt32(TermId.Text);
                            //Entity_PC.SpecificationId = a;
                            if (GrdSelectAll.Checked == true)
                            {
                                Entity_PC.SpecificationId = 1;
                            }
                            else
                            {
                                Entity_PC.SpecificationId = 2;
                            }
                            TextBox txtTitle = (TextBox)GridSpecific.Rows[i].Cells[2].FindControl("GrtxtTermCondition_Head");
                            Entity_PC.Title = txtTitle.Text;
                            TextBox txtdesc = (TextBox)GridSpecific.Rows[i].Cells[4].FindControl("GrtxtDesc");
                            Entity_PC.Details = txtdesc.Text;
                            InsertSpecific = Obj_PC.InsertSpecificDetail(ref Entity_PC, out StrError);

                        }
                    }
                    for (int j = 0; j < grdupload.Rows.Count; j++)
                    {
                        CheckBox chkupload = (CheckBox)grdupload.Rows[j].Cells[0].FindControl("chkUpload");
                          
                        if (chkupload.Checked == true)
                        {
                            if (!grdupload.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(grdupload.Rows[j].Cells[1].Text))
                            {
                            Entity_PC.ImagePath = grdupload.Rows[j].Cells[1].Text;
                            InsertProjectImg = Obj_PC.InsertProjectImage(ref Entity_PC, out StrError);
                            }
                        }
                    }
                    for (int j = 0; j < GridLayout.Rows.Count; j++)
                    {
                        CheckBox chkupload = (CheckBox)GridLayout.Rows[j].Cells[0].FindControl("chkLayout");
                        if (chkupload.Checked == true)
                        {
                            if (!GridLayout.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(GridLayout.Rows[j].Cells[1].Text))
                            {
                                Entity_PC.LayoutPath = GridLayout.Rows[j].Cells[1].Text;
                                InsertProjectImg = Obj_PC.InsertProjectLayout(ref Entity_PC, out StrError);
                            }
                        }
                    }
                    for (int j = 0; j < GridMap.Rows.Count; j++)
                    {
                        CheckBox chkupload = (CheckBox)GridMap.Rows[j].Cells[0].FindControl("chkMap");
                        if (chkupload.Checked == true)
                        {
                            if (!GridMap.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(GridMap.Rows[j].Cells[1].Text))
                            {
                                Entity_PC.MapPath = GridMap.Rows[j].Cells[1].Text;
                                InsertProjectImg = Obj_PC.InsertProjectMap(ref Entity_PC, out StrError);
                            }
                        }
                    }
                    for (int j = 0; j < GridLogo.Rows.Count; j++)
                    {
                        CheckBox chkupload = (CheckBox)GridLogo.Rows[j].Cells[0].FindControl("chkLogo");
                        if (chkupload.Checked == true)
                        {
                            if (!GridLogo.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(GridLogo.Rows[j].Cells[1].Text))
                            {
                                Entity_PC.LogoPath = GridLogo.Rows[j].Cells[1].Text;
                                InsertProjectImg = Obj_PC.InsertProjectLogo(ref Entity_PC, out StrError);
                            }
                        }
                    }
                    for (int j = 0; j < GridPlan.Rows.Count; j++)
                    {
                        CheckBox chkupload = (CheckBox)GridPlan.Rows[j].Cells[0].FindControl("chkPlan");
                        if (chkupload.Checked == true)
                        {
                            if (!GridPlan.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(GridPlan.Rows[j].Cells[1].Text))
                            {
                                Entity_PC.PlanPath = GridPlan.Rows[j].Cells[1].Text;
                                InsertProjectImg = Obj_PC.InsertProjectPlan(ref Entity_PC, out StrError);
                            }
                        }
                    }
                    for (int j = 0; j < GridVideo.Rows.Count; j++)
                    {
                        CheckBox chkupload = (CheckBox)GridVideo.Rows[j].Cells[0].FindControl("chkVideo");
                        if (chkupload.Checked == true)
                        {
                            if (!GridVideo.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(GridVideo.Rows[j].Cells[1].Text))
                            {
                                Entity_PC.VideoPath = GridVideo.Rows[j].Cells[1].Text;
                                InsertProjectImg = Obj_PC.InsertProjectVideo(ref Entity_PC, out StrError);
                            }
                        }
                    }
                    for (int j = 0; j < GridAmenityImg.Rows.Count; j++)
                    {
                        CheckBox chkupload = (CheckBox)GridAmenityImg.Rows[j].Cells[0].FindControl("chkAmenity");
                        if (chkupload.Checked == true)
                        {
                            if (!GridAmenityImg.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(GridAmenityImg.Rows[j].Cells[1].Text))
                            {
                                Entity_PC.AmenityPath = GridAmenityImg.Rows[j].Cells[1].Text;
                                InsertProjectImg = Obj_PC.InsertAmenityImage(ref Entity_PC, out StrError);
                            }
                        }
                    }
                    for (int j = 0; j < GridSpecImg.Rows.Count; j++)
                    {
                        CheckBox chkupload = (CheckBox)GridSpecImg.Rows[j].Cells[0].FindControl("chkSpec");
                        if (chkupload.Checked == true)
                        {
                            if (!GridSpecImg.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(GridSpecImg.Rows[j].Cells[1].Text))
                            {
                                Entity_PC.SpecPath = GridSpecImg.Rows[j].Cells[1].Text;
                                InsertProjectImg = Obj_PC.InsertSpecImage(ref Entity_PC, out StrError);
                            }
                        }
                    }
                    if (ViewState["MainDetail"] != null)
                    {
                        DataTable dtInsert = new DataTable();
                        dtInsert = (DataTable)ViewState["MainDetail"];
                        for (int i = 0; i < dtInsert.Rows.Count; i++)
                        {
                            Entity_PC.TowerName = dtInsert.Rows[i]["TowerName"].ToString();
                            Entity_PC.FlatNo = dtInsert.Rows[i]["FlatNo"].ToString();
                            Entity_PC.Sqft = Convert.ToDecimal(dtInsert.Rows[i]["SqFt"].ToString());
                            Entity_PC.FlatTypeId = Convert.ToInt32(dtInsert.Rows[i]["FlatTypeId"].ToString());
                            Entity_PC.Floors = Convert.ToInt32(dtInsert.Rows[i]["Floor"].ToString());
                            Entity_PC.Units = Convert.ToInt32(dtInsert.Rows[i]["Unit"].ToString());
                            Entity_PC.TerraceArea = Convert.ToDecimal(dtInsert.Rows[i]["TerraceArea"].ToString());
                            Entity_PC.GardenArea = Convert.ToDecimal(dtInsert.Rows[i]["GardenArea"].ToString());
                            Entity_PC.CarpetArea = Convert.ToDecimal(dtInsert.Rows[i]["CarpetArea"].ToString());

                            Entity_PC.SqftSaleBuiltUp = Convert.ToDecimal(dtInsert.Rows[i]["SqftSaleBuiltUp"].ToString());
                            Entity_PC.TerraceAreaSaleBuiltUp = Convert.ToDecimal(dtInsert.Rows[i]["TerraceAreaSaleBuiltUp"].ToString());
                            Entity_PC.GardenAreaSaleBuiltUp = Convert.ToDecimal(dtInsert.Rows[i]["GardenAreaSaleBuiltUp"].ToString());
                            Entity_PC.SaleableArea = Convert.ToDecimal(dtInsert.Rows[i]["SaleableArea"].ToString());

                            Entity_PC.FlatAgreementCarpet = Convert.ToDecimal(dtInsert.Rows[i]["AgreementCarpetFlat"].ToString());
                            Entity_PC.TerraceAgreementCarpet = Convert.ToDecimal(dtInsert.Rows[i]["AgreementCarpetTerrace"].ToString());

                            Entity_PC.FlatAgreementBuiltUp = Convert.ToDecimal(dtInsert.Rows[i]["AgreementBuiltUpFlat"].ToString());
                            Entity_PC.TerraceAgreementBuiltUp = Convert.ToDecimal(dtInsert.Rows[i]["AgreementBuiltUpTerrace"].ToString());

                            Entity_PC.FloorNo = Convert.ToInt32(dtInsert.Rows[i]["FloorNo"].ToString());
                            Entity_PC.FacingTypeId = Convert.ToInt32(dtInsert.Rows[i]["FacingTypeId"].ToString());
                            Entity_PC.FlatLayoutPath = dtInsert.Rows[i]["LayoutPath"].ToString();
                            Entity_PC.TerraceAreaPer = Convert.ToDecimal(dtInsert.Rows[i]["TerracePer"].ToString());
                            Entity_PC.GardenAreaPer = Convert.ToDecimal(dtInsert.Rows[i]["GardenPer"].ToString());

                            InsertRowDtls = Obj_PC.InsertPCDetail(ref Entity_PC, out StrError);
                        }

                    }
                    if (ViewState["CompanyTable"] != null)
                    {
                        DataTable dtInsert = new DataTable();
                        dtInsert = (DataTable)ViewState["CompanyTable"];
                        for (int i = 0; i < dtInsert.Rows.Count; i++)
                        {
                            Entity_PC.Company = dtInsert.Rows[i]["Company"].ToString();
                            Entity_PC.CompanyAddress = dtInsert.Rows[i]["CompanyAddress"].ToString();
                            Entity_PC.LogoImg = dtInsert.Rows[i]["LogoImg"].ToString();

                            InsertRowDtls = Obj_PC.InsertCompany(ref Entity_PC, out StrError);
                        }

                    }
                    for (int j = 0; j < GridDocumentList.Rows.Count; j++)
                    {
                        Entity_PC.DocId = Convert.ToInt32(((Label)GridDocumentList.Rows[j].FindControl("LblEntryId")).Text);
                        Label lblDocPath = (Label)GridDocumentList.Rows[j].FindControl("lblImgPath");
                        if (!lblDocPath.Text.Equals("&nbsp;") && !string.IsNullOrEmpty(lblDocPath.Text))
                        {
                            Entity_PC.IsChecked = true;
                            Entity_PC.DocPath = lblDocPath.Text;
                        }
                        else
                        {
                            Entity_PC.DocPath = "";
                            Entity_PC.IsChecked = false;
                        }
                        InsertProjectImg = Obj_PC.InsertDocumentDetail(ref Entity_PC, out StrError);
                    }
                    Obj_Comm.ShowPopUpMsg("Record Saved Successfully", this.Page);
                    MakeEmptyForm();
                    Entity_PC = null;
                    Obj_Comm = null;
                }
            }
            else
                Obj_Comm.ShowPopUpMsg("Please Select Details", this.Page);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int UpdateRow = 0, InsertRowDtls = 0, InsertSpecific, InsertAmenity = 0, InsertProjectImg=0;
         int hiddenField = Convert.ToInt32(hiddenbox.Value);
         if (hiddenField == 0)
         {
             try
             {
                 if (Check())
                 {
                     if (ViewState["EditID"] != null)
                     {
                         Entity_PC.PCId = Convert.ToInt32(ViewState["EditID"]);
                     }
                     Entity_PC.PCNo = txtPCNo.Text.Trim();
                     Entity_PC.PCName = txtProjectName.Text.Trim();
                     Entity_PC.ProjectTypeId = Convert.ToInt32(ddlProjectType.SelectedValue);
                     Entity_PC.ProjectSubTypeId = Convert.ToInt32(ddlProjectSubtype.SelectedValue);
                     Entity_PC.Address = txtAddress.Text.Trim();
                     Entity_PC.NOofTowers = Convert.ToInt32(txtNoofTower.Text);
                     Entity_PC.TowerName = txtTowerName.Text.Trim();
                     //Entity_PC.Floors = !string.IsNullOrEmpty(txtFloor.Text) ? Convert.ToInt32(txtFloor.Text) : 0;
                     //Entity_PC.Units =!string.IsNullOrEmpty(txtUnit.Text) ?  Convert.ToInt32(txtUnit.Text):0;
                     if (RBAll.Checked == true)
                         Entity_PC.IsAll = true;
                     else
                         Entity_PC.IsAll = false;
                     Entity_PC.SqftAll = !string.IsNullOrEmpty(txtSqft.Text) ? Convert.ToDecimal(txtSqft.Text) : 0;
                     Entity_PC.SqftEven = !string.IsNullOrEmpty(txtSqftEven.Text) ? Convert.ToDecimal(txtSqftEven.Text) : 0;
                     Entity_PC.SqftOdd = !string.IsNullOrEmpty(txtSqftOdd.Text) ? Convert.ToDecimal(txtSqftOdd.Text) : 0;
                     Entity_PC.LayoutPath = Convert.ToString(ViewState["ImageLayout"]);
                     Entity_PC.MapPath = Convert.ToString(ViewState["ImageMap"]);
                     Entity_PC.VideoPath = Convert.ToString(ViewState["UploadedPath1"]);

                     Entity_PC.StampAC = txtStampDuty.Text.Trim();
                     Entity_PC.RegistrationAC = txtRegistration.Text.Trim();
                     Entity_PC.VatAC = txtVat.Text.Trim();
                     Entity_PC.CollectionAC = txtCollection.Text.Trim();
                     Entity_PC.ServiceTaxAC = txtServiceTax.Text.Trim();
                     Entity_PC.CancelCharge = !string.IsNullOrEmpty(txtCancelCharge.Text) ? Convert.ToDecimal(txtCancelCharge.Text) : 0;
                     Entity_PC.TerraceAreaPer = !string.IsNullOrEmpty(txtTerraceAreaPer.Text) ? Convert.ToDecimal(txtTerraceAreaPer.Text) : 0;
                     Entity_PC.GardenAreaPer = !string.IsNullOrEmpty(txtGardenAreaPer.Text) ? Convert.ToDecimal(txtGardenAreaPer.Text) : 0;
                     Entity_PC.FlagBooked = Convert.ToBoolean(FlagBooked);

                     Entity_PC.Loading = txtLoading.Text.Trim();
                     Entity_PC.LandArea = !string.IsNullOrEmpty(txtTotalLand.Text) ? Convert.ToDecimal(txtTotalLand.Text) : 0;
                     Entity_PC.SaleableFSI = !string.IsNullOrEmpty(txtSaleableFSI.Text) ? Convert.ToDecimal(txtSaleableFSI.Text) : 0;

                     Entity_PC.UserId = Convert.ToInt32(Session["UserId"]);
                     Entity_PC.LoginDate = DateTime.Now;

                     UpdateRow = Obj_PC.UpdateProjectConfi(ref Entity_PC, out StrError);

                     if (UpdateRow > 0)
                     {
                         //Insert Into PCAmenity
                         for (int i = 0; i < GridAmenities.Rows.Count; i++)
                         {
                             CheckBox GrdSelectAll = (CheckBox)GridAmenities.Rows[i].Cells[3].FindControl("chkDetails");
                             TextBox txtTitle1 = (TextBox)GridAmenities.Rows[i].Cells[2].FindControl("GrtxtTermCondition_Head");
                             if (txtTitle1.Text != "")
                             {
                                 //Label TermId = (Label)GridAmenities.Rows[i].Cells[0].FindControl("LblEntryId");
                                 //int a = Convert.ToInt32(TermId.Text);
                                // Entity_PC.AmenityId = a;
                                 if (GrdSelectAll.Checked == true)
                                 {
                                     Entity_PC.AmenityId = 1;
                                 }
                                 else
                                 {
                                     Entity_PC.AmenityId = 2;
                                 }

                        

                                 TextBox txtTitle = (TextBox)GridAmenities.Rows[i].Cells[2].FindControl("GrtxtTermCondition_Head");
                                 Entity_PC.Title = txtTitle.Text;
                                 TextBox txtdesc = (TextBox)GridAmenities.Rows[i].Cells[4].FindControl("GrtxtDesc");
                                 Entity_PC.Details = txtdesc.Text;
                                 InsertAmenity = Obj_PC.InsertAmenityDetail(ref Entity_PC, out StrError);

                             }
                         }

                         //Insert Into PCAmenity
                         for (int i = 0; i < GridSpecific.Rows.Count; i++)
                         {
                             CheckBox GrdSelectAll = (CheckBox)GridSpecific.Rows[i].Cells[3].FindControl("chkDetails");
                             TextBox txtTitle1 = (TextBox)GridSpecific.Rows[i].Cells[2].FindControl("GrtxtTermCondition_Head");
                             if ( txtTitle1.Text != "")
                             {
                                 if (GrdSelectAll.Checked == true)
                                 {
                                     Entity_PC.SpecificationId = 1;
                                 }
                                 else
                                 {
                                     Entity_PC.SpecificationId = 2;
                                 }
                                 //Label TermId = (Label)GridSpecific.Rows[i].Cells[0].FindControl("LblEntryId");
                                 //Entity_PC.SpecificationId = Convert.ToInt32(TermId.Text);

                                 TextBox txtTitle = (TextBox)GridSpecific.Rows[i].Cells[2].FindControl("GrtxtTermCondition_Head");
                                 Entity_PC.Title = txtTitle.Text;
                                 TextBox txtdesc = (TextBox)GridSpecific.Rows[i].Cells[4].FindControl("GrtxtDesc");
                                 Entity_PC.Details = txtdesc.Text;
                                 InsertSpecific = Obj_PC.InsertSpecificDetail(ref Entity_PC, out StrError);
                             }
                         }
                         for (int j = 0; j < grdupload.Rows.Count; j++)
                         {
                             CheckBox chkupload = (CheckBox)grdupload.Rows[j].Cells[0].FindControl("chkUpload");
                             if (chkupload.Checked == true)
                             {
                                 if (!grdupload.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(grdupload.Rows[j].Cells[1].Text))
                                 {
                                     Entity_PC.ImagePath = grdupload.Rows[j].Cells[1].Text;
                                     InsertProjectImg = Obj_PC.InsertProjectImage(ref Entity_PC, out StrError);
                                 }
                             }
                         }
                         for (int j = 0; j < GridLayout.Rows.Count; j++)
                         {
                             CheckBox chkupload = (CheckBox)GridLayout.Rows[j].Cells[0].FindControl("chkLayout");
                             if (chkupload.Checked == true)
                             {
                                 if (!GridLayout.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(GridLayout.Rows[j].Cells[1].Text))
                                 {
                                     Entity_PC.LayoutPath = GridLayout.Rows[j].Cells[1].Text;
                                     InsertProjectImg = Obj_PC.InsertProjectLayout(ref Entity_PC, out StrError);
                                 }
                             }
                         }
                         for (int j = 0; j < GridMap.Rows.Count; j++)
                         {
                             CheckBox chkupload = (CheckBox)GridMap.Rows[j].Cells[0].FindControl("chkMap");
                             if (chkupload.Checked == true)
                             {
                                 if (!GridMap.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(GridMap.Rows[j].Cells[1].Text))
                                 {
                                     Entity_PC.MapPath = GridMap.Rows[j].Cells[1].Text;
                                     InsertProjectImg = Obj_PC.InsertProjectMap(ref Entity_PC, out StrError);
                                 }
                             }
                         }
                         for (int j = 0; j < GridLogo.Rows.Count; j++)
                         {
                             CheckBox chkupload = (CheckBox)GridLogo.Rows[j].Cells[0].FindControl("chkLogo");
                             if (chkupload.Checked == true)
                             {
                                 if (!GridLogo.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(GridLogo.Rows[j].Cells[1].Text))
                                 {
                                     Entity_PC.LogoPath = GridLogo.Rows[j].Cells[1].Text;
                                     InsertProjectImg = Obj_PC.InsertProjectLogo(ref Entity_PC, out StrError);
                                 }
                             }
                         }
                         for (int j = 0; j < GridPlan.Rows.Count; j++)
                         {
                             CheckBox chkupload = (CheckBox)GridPlan.Rows[j].Cells[0].FindControl("chkPlan");
                             if (chkupload.Checked == true)
                             {
                                 if (!GridPlan.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(GridPlan.Rows[j].Cells[1].Text))
                                 {
                                     Entity_PC.PlanPath = GridPlan.Rows[j].Cells[1].Text;
                                     InsertProjectImg = Obj_PC.InsertProjectPlan(ref Entity_PC, out StrError);
                                 }
                             }
                         }
                         for (int j = 0; j < GridVideo.Rows.Count; j++)
                         {
                             CheckBox chkupload = (CheckBox)GridVideo.Rows[j].Cells[0].FindControl("chkVideo");
                             if (chkupload.Checked == true)
                             {
                                 if (!GridVideo.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(GridVideo.Rows[j].Cells[1].Text))
                                 {
                                     Entity_PC.VideoPath = GridVideo.Rows[j].Cells[1].Text;
                                     InsertProjectImg = Obj_PC.InsertProjectVideo(ref Entity_PC, out StrError);
                                 }
                             }
                         }
                         for (int j = 0; j < GridAmenityImg.Rows.Count; j++)
                         {
                             CheckBox chkupload = (CheckBox)GridAmenityImg.Rows[j].Cells[0].FindControl("chkAmenity");
                             if (chkupload.Checked == true)
                             {
                                 if (!GridAmenityImg.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(GridAmenityImg.Rows[j].Cells[1].Text))
                                 {
                                     Entity_PC.AmenityPath = GridAmenityImg.Rows[j].Cells[1].Text;
                                     InsertProjectImg = Obj_PC.InsertAmenityImage(ref Entity_PC, out StrError);
                                 }
                             }
                         }
                         for (int j = 0; j < GridSpecImg.Rows.Count; j++)
                         {
                             CheckBox chkupload = (CheckBox)GridSpecImg.Rows[j].Cells[0].FindControl("chkSpec");
                             if (chkupload.Checked == true)
                             {
                                 if (!GridSpecImg.Rows[j].Cells[1].Text.Equals("&nbsp;") && !string.IsNullOrEmpty(GridSpecImg.Rows[j].Cells[1].Text))
                                 {
                                     Entity_PC.SpecPath = GridSpecImg.Rows[j].Cells[1].Text;
                                     InsertProjectImg = Obj_PC.InsertSpecImage(ref Entity_PC, out StrError);
                                 }
                             }
                         }
                         if (ViewState["MainDetail"] != null && !FlagBooked)
                         {
                             DataTable dtInsert = new DataTable();
                             dtInsert = (DataTable)ViewState["MainDetail"];
                             for (int i = 0; i < dtInsert.Rows.Count; i++)
                             {
                                 Entity_PC.TowerName = dtInsert.Rows[i]["TowerName"].ToString();
                                 Entity_PC.FlatNo = dtInsert.Rows[i]["FlatNo"].ToString();
                                 Entity_PC.Sqft = Convert.ToDecimal(dtInsert.Rows[i]["SqFt"].ToString());
                                 Entity_PC.FlatTypeId = Convert.ToInt32(dtInsert.Rows[i]["FlatTypeId"].ToString());
                                 Entity_PC.Floors = Convert.ToInt32(dtInsert.Rows[i]["Floor"].ToString());
                                 Entity_PC.Units = Convert.ToInt32(dtInsert.Rows[i]["Unit"].ToString());
                                 Entity_PC.TerraceArea = Convert.ToDecimal(dtInsert.Rows[i]["TerraceArea"].ToString());
                                 Entity_PC.GardenArea = Convert.ToDecimal(dtInsert.Rows[i]["GardenArea"].ToString());
                                 Entity_PC.CarpetArea = Convert.ToDecimal(dtInsert.Rows[i]["CarpetArea"].ToString());

                                 Entity_PC.SqftSaleBuiltUp = Convert.ToDecimal(dtInsert.Rows[i]["SqftSaleBuiltUp"].ToString());
                                 Entity_PC.TerraceAreaSaleBuiltUp = Convert.ToDecimal(dtInsert.Rows[i]["TerraceAreaSaleBuiltUp"].ToString());
                                 Entity_PC.GardenAreaSaleBuiltUp = Convert.ToDecimal(dtInsert.Rows[i]["GardenAreaSaleBuiltUp"].ToString());
                                 Entity_PC.SaleableArea = Convert.ToDecimal(dtInsert.Rows[i]["SaleableArea"].ToString());

                                 Entity_PC.FlatAgreementCarpet = Convert.ToDecimal(dtInsert.Rows[i]["AgreementCarpetFlat"].ToString());
                                 Entity_PC.TerraceAgreementCarpet = Convert.ToDecimal(dtInsert.Rows[i]["AgreementCarpetTerrace"].ToString());

                                 Entity_PC.FlatAgreementBuiltUp = Convert.ToDecimal(dtInsert.Rows[i]["AgreementBuiltUpFlat"].ToString());
                                 Entity_PC.TerraceAgreementBuiltUp = Convert.ToDecimal(dtInsert.Rows[i]["AgreementBuiltUpTerrace"].ToString());

                                 Entity_PC.FloorNo = Convert.ToInt32(dtInsert.Rows[i]["FloorNo"].ToString());
                                 Entity_PC.FacingTypeId = Convert.ToInt32(dtInsert.Rows[i]["FacingTypeId"].ToString());
                                 Entity_PC.FlatLayoutPath = dtInsert.Rows[i]["LayoutPath"].ToString();
                                 Entity_PC.TerraceAreaPer = Convert.ToDecimal(dtInsert.Rows[i]["TerracePer"].ToString());
                                 Entity_PC.GardenAreaPer = Convert.ToDecimal(dtInsert.Rows[i]["GardenPer"].ToString());

                                 InsertRowDtls = Obj_PC.InsertPCDetail(ref Entity_PC, out StrError);
                             }

                         }
                         if (ViewState["CompanyTable"] != null)
                         {
                             DataTable dtInsert = new DataTable();
                             dtInsert = (DataTable)ViewState["CompanyTable"];
                             for (int i = 0; i < dtInsert.Rows.Count; i++)
                             {
                                 Entity_PC.Company = dtInsert.Rows[i]["Company"].ToString();
                                 Entity_PC.CompanyAddress = dtInsert.Rows[i]["CompanyAddress"].ToString();
                                 Entity_PC.LogoImg = dtInsert.Rows[i]["LogoImg"].ToString();

                                 InsertRowDtls = Obj_PC.InsertCompany(ref Entity_PC, out StrError);
                             }
                         }
                         for (int j = 0; j < GridDocumentList.Rows.Count; j++)
                         {
                             Entity_PC.DocId = Convert.ToInt32(((Label)GridDocumentList.Rows[j].FindControl("LblEntryId")).Text);
                             Label lblDocPath = (Label)GridDocumentList.Rows[j].FindControl("lblImgPath");
                             if (!lblDocPath.Text.Equals("&nbsp;") && !string.IsNullOrEmpty(lblDocPath.Text))
                             {
                                 Entity_PC.IsChecked = true;
                                 Entity_PC.DocPath = lblDocPath.Text;
                                 
                             }
                             else
                             {
                                 Entity_PC.DocPath = "";
                                 Entity_PC.IsChecked = false;
                             }
                             InsertProjectImg = Obj_PC.InsertDocumentDetail(ref Entity_PC, out StrError);
                         }
                         Obj_Comm.ShowPopUpMsg("Record Updated Successfully", this.Page);
                         MakeEmptyForm();
                         Entity_PC = null;
                         Obj_Comm = null;
                     }
                     
                 }
                 else
                 {
                     Obj_Comm.ShowPopUpMsg("Please Insert Details", this.Page);
                 }
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }
    }

    protected void GrdReport_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //try
        //{
        //    switch (e.CommandName)
        //    {
        //        case ("Select"):
        //            {
        //                if (Convert.ToInt32(e.CommandArgument) != 0)
        //                {
        //                    ViewState["EditID"] = Convert.ToInt32(e.CommandArgument);
        //                    DS = Obj_ProjectType.GetProjectTypeForEdit(Convert.ToInt32(e.CommandArgument), out StrError);
        //                    if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
        //                    {
        //                        txtProjectType.Text = DS.Tables[0].Rows[0]["ProjectType"].ToString();
        //                    }
        //                    else
        //                    {
        //                        MakeEmptyForm();
        //                    }
        //                    DS = null;
        //                    Obj_ProjectType = null;
        //                    BtnUpdate.Visible = true;
        //                    BtnSave.Visible = false;
        //                    BtnDelete.Visible = true;
        //                    txtProjectType.Focus();
        //                }

        //                break;
        //            }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    throw new Exception(ex.Message);
        //}
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        //int i = Convert.ToInt32(hiddenbox.Value);
        //if (i == 0)
        //{
        //    try
        //    {
        //        int DeleteId = 0;
        //        if (ViewState["EditID"] != null)
        //        {
        //            DeleteId = Convert.ToInt32(ViewState["EditID"]);
        //        }
        //        if (DeleteId != 0)
        //        {
        //            Entity_ProjectType.ProjectTypeId = DeleteId;
        //            Entity_ProjectType.UserId = Convert.ToInt32(Session["UserId"]);
        //            Entity_ProjectType.LoginDate = DateTime.Now;
        //            int iDelete = Obj_ProjectType.DeleteProjectType(ref Entity_ProjectType, out StrError);
        //            if (iDelete != 0)
        //            {
        //                Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
        //                MakeEmptyForm();
        //            }

        //        }
        //        Entity_ProjectType = null;
        //        Obj_Comm = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
        MakeControlEmpty();
        MakeTowerControlEmpty();
    }

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        StrCondition = TxtSearch.Text.Trim();
        ReportGrid(StrCondition);
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        DMProjectConfigurator Obj_PC = new DMProjectConfigurator();
        string[] SearchList = Obj_PC.GetSuggestRecord(prefixText);
        return SearchList;
    }

    protected void GridDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dtType = (DataTable)ViewState["ddlFlatType"];

                ((DropDownList)e.Row.FindControl("ddlFlatType")).DataSource = dtType;
                ((DropDownList)e.Row.FindControl("ddlFlatType")).DataTextField = "FlatType";
                ((DropDownList)e.Row.FindControl("ddlFlatType")).DataValueField = "FlatTypeId";
                ((DropDownList)e.Row.FindControl("ddlFlatType")).DataBind();
                ((DropDownList)e.Row.FindControl("ddlFlatType")).SelectedValue = ((Label)e.Row.FindControl("lblFlatTypeId")).Text;
                ((DropDownList)e.Row.FindControl("ddlFacingType")).SelectedValue = ((Label)e.Row.FindControl("lblFacingTypeId")).Text;
                
                ((TextBox)e.Row.FindControl("txtSqm")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtSqft")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtTerraceSqmSaleCarpet")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtTerraceAreaSaleCarpet")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtGardenSqmSaleCarpet")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtGardenAreaSaleCarpet")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtCarpetSqmSaleCarpet")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtCarpetAreaSaleCarpet")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");

                ((TextBox)e.Row.FindControl("txtSqmSaleBuiltUp")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtSqftSaleBuiltUp")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtTerraceSqmSaleBuiltUp")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtTerraceAreaSaleBuiltUp")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtGardenSqmSaleBuiltUp")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtGardenAreaSaleBuiltUp")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtSaleableSqmSaleBuiltUp")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtSaleableAreaSaleBuiltUp")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");

                ((TextBox)e.Row.FindControl("txtSqmAgreementCarpet")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtFlatAgreementCarpet")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtTerraceSqmAgreementCarpet")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtTerraceAgreementCarpet")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");

                ((TextBox)e.Row.FindControl("txtFlatSqmAgreementBuiltUp")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtFlatAgreementBuiltUp")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtTerraceSqmAgreementBuiltUp")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtTerraceAgreementBuiltUp")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");


                Label LayoutPath=(Label)e.Row.FindControl("lblImgPath");
                if (!string.IsNullOrEmpty(LayoutPath.Text) && !LayoutPath.Text.Equals("&nbsp;"))
                {
                    e.Row.BackColor = System.Drawing.Color.LawnGreen;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.White;
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
        int Count = 1;
        DivDetailGrid.Visible = true;
        trAddGrid.Visible = true;
        if (RBType.SelectedValue == "0")
        {
            ViewState["CurrentTable"] = null;
            DataTable dtMainGrid = (DataTable)ViewState["MainDetail"];
            if (dtMainGrid.Rows.Count > 0 && !dtMainGrid.Rows[0]["TowerName"].ToString().Equals("") && !dtMainGrid.Rows[0]["TowerName"].ToString().Equals("&nbsp;"))
            {
                for (int j = dtMainGrid.Rows.Count - 2; j > 0; j--)
                {
                    string currName = dtMainGrid.Rows[j]["TowerName"].ToString();
                    string PrevName = dtMainGrid.Rows[j + 1]["TowerName"].ToString();
                    if (!PrevName.Equals(currName))
                    {
                        Count++;
                    }
                }
                if (Count < Convert.ToInt32(txtNoofTower.Text))
                {
                    SetInitialRow(Convert.ToInt32(txtFloor.Text), Convert.ToInt32(txtUnit.Text));
                }
                else
                {
                    Obj_Comm.ShowPopUpMsg("Already You Have Entered " + txtNoofTower.Text + " Towers", this.Page);
                }
            }
            else
            {
                
                if (Count <= Convert.ToInt32(txtNoofTower.Text))
                {
                    SetInitialRow(Convert.ToInt32(txtFloor.Text), Convert.ToInt32(txtUnit.Text));
                }
                else
                {
                    Obj_Comm.ShowPopUpMsg("Please Enter No. of Towers", this.Page);
                }
            }
            Label2.Text = "Tower Detail Grid :- You have Entered Configuration for All Floor";
        }
        else
        {
            ViewState["CurrentTable"] = null;
            if (Count <= Convert.ToInt32(txtNoofTower.Text))
            {
                if (Convert.ToInt32(txtFloor.Text) > FloorNoCount)
                {

                    SetInitialRowFloorwise(FloorNoCount, Convert.ToInt32(txtUnit.Text));
                    FloorNoCount++;
                    if (Convert.ToInt32(txtFloor.Text) == FloorNoCount)
                    {
                        Label2.Text = "Tower Detail Grid :- You have Entered Configuration for All Floor";
                    }
                    else
                    {
                        Label2.Text = "Tower Detail Grid :- You have Entered Configuration for Floor-" + (FloorNoCount).ToString();
                    }
                }
                else
                {
                    Label2.Text = "Tower Detail Grid :- You have Entered Configuration for All Floor";
                    Obj_Comm.ShowPopUpMsg("You Have Entered All Floor", this.Page);
                }
            }
            else
            {
                Obj_Comm.ShowPopUpMsg("Please Enter No. of Towers", this.Page);
            }

        }
    }

    protected void lnkUpload_Click(object sender, EventArgs e)
    {
        try
        {
            //To Delete All Files In Direcotry===========
            string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("~/Images/Temp/"));
            foreach (string filePath in filePaths)
                System.IO.File.Delete(filePath);
            //To Delete All Files In Direcotry===========
            Random random = new Random();

            if (FuUpload.HasFile)
            {
                //--Total No of Files--
                Int64 TotalFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Images")).Count();

                string filename = System.IO.Path.GetFileName(FuUpload.FileName);
                filename = TotalFiles + "-" + filename;
                FuUpload.SaveAs(Server.MapPath("~/Images/Temp/") + filename);
                FuUpload.SaveAs(Server.MapPath("~/Images/") + filename);

                //==========USed For Resize Image to Gal Size===================
                //System.Drawing.Image GalImage = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                //GalImage.Save(Server.MapPath("~/Images/") + filename);
                //GalImage = null;
                //==========USed For Resize Image to Gal Size===================   

                //==========USed For Resize Image to Thumb===================
                //System.Drawing.Image Thumb = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                //Thumb.Save(Server.MapPath("~/Images/Thumb/") + filename);
                //Thumb = null;
                //==========USed For Resize Image to Thumb===================

               // ViewState["UploadedPath"] = "~/Images/" + filename;
                //Add To image
                AddtoGridLayout(filename);
                //imgThumb.ImageUrl = @"~/Images/" + filename;
                //ViewState["ImageLayout"] = imgThumb.ImageUrl;
                //imgThumb.DataBind();
                //SetInitialRow(Convert.ToInt32(txtFloor.Text), Convert.ToInt32(txtUnit.Text));
            }

        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg("Upload status: The file could not be uploaded. The following error occured: " + ex.Message, this.Page);
        }
    }

    protected void Lnk_Map_Click(object sender, EventArgs e)
    {
        try
        {
            //To Delete All Files In Direcotry===========
            string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("~/Images/Temp/"));
            foreach (string filePath in filePaths)
                System.IO.File.Delete(filePath);
            //To Delete All Files In Direcotry===========
            Random random = new Random();

            if (FileUploadMap.HasFile)
            {
              
                //--Total No of Files--
                Int64 TotalFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Images")).Count();
               // string str = System.IO.Path.GetDirectoryName(FileUploadMap.PostedFile.FileName);
                string filename = System.IO.Path.GetFileName(FileUploadMap.FileName);
                filename = TotalFiles + "-" + filename;
                FileUploadMap.SaveAs(Server.MapPath("~/Images/Temp/") + filename);
               // FileUploadMap.SaveAs(Server.MapPath("~/Images/original/") + filename);

                //==========USed For Resize Image to Gal Size===================
                System.Drawing.Image GalImage = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                GalImage.Save(Server.MapPath("~/Images/") + filename);
                GalImage = null;
                //==========USed For Resize Image to Gal Size===================   

                //==========USed For Resize Image to Thumb===================
                System.Drawing.Image Thumb = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                Thumb.Save(Server.MapPath("~/Images/Thumb/") + filename);
                Thumb = null;
                //==========USed For Resize Image to Thumb===================

               // ViewState["UploadedPath"] = "~/Images/" + filename;
                //Add To image
                AddtoGridMap(filename);
                //ImgMap.ImageUrl = @"~/Images/" + filename;
                //ViewState["ImageMap"] = ImgMap.ImageUrl;
                //ImgMap.DataBind();
               // SetInitialRow(Convert.ToInt32(txtFloor.Text), Convert.ToInt32(txtUnit.Text));
            }

        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg("Upload status: The file could not be uploaded. The following error occured: " + ex.Message, this.Page);
        }
    }

    protected void LnkImages_Click(object sender, EventArgs e)
    {
        try
        {
            //To Delete All Files In Direcotry===========
            string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("~/Images/Temp/"));
            foreach (string filePath in filePaths)
                System.IO.File.Delete(filePath);
            //To Delete All Files In Direcotry===========
            Random random = new Random();

            if (FileUploadImages.HasFile)
            {
                //--Total No of Files--
                Int64 TotalFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Images")).Count();

                string filename = System.IO.Path.GetFileName(FileUploadImages.FileName);
                filename = TotalFiles + "-" + filename;
                FileUploadImages.SaveAs(Server.MapPath("~/Images/Temp/") + filename);
                //FileUploadImages.SaveAs(Server.MapPath("~/Images/original/") + filename);

                //==========USed For Resize Image to Gal Size===================
                System.Drawing.Image GalImage = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                GalImage.Save(Server.MapPath("~/Images/") + filename);
                GalImage = null;
                //==========USed For Resize Image to Gal Size===================   

                //==========USed For Resize Image to Thumb===================
                System.Drawing.Image Thumb = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                Thumb.Save(Server.MapPath("~/Images/Thumb/") + filename);
                Thumb = null;
                //==========USed For Resize Image to Thumb===================

               // ViewState["UploadedPath"] = "~/Images/" + filename;
                //Add To image
                AddtoGridPhotos(filename);
             //   SetInitialRow(Convert.ToInt32(txtFloor.Text), Convert.ToInt32(txtUnit.Text));
            }

        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg("Upload status: The file could not be uploaded. The following error occured: " + ex.Message, this.Page);
        }
    }

    protected void lnkVideo_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUploadVideo.HasFile)
            {
                //--Total No of Files--
                Int64 TotalFiles = System.IO.Directory.GetFiles(Server.MapPath("~/index_videolb/video")).Count();

                string filename = System.IO.Path.GetFileName(FileUploadVideo.FileName);
                filename = TotalFiles + "-" + filename;
                FileUploadVideo.SaveAs(Server.MapPath("~/index_videolb/video/") + filename);

                ViewState["UploadedPath1"] = "~/index_videolb/video/" + filename;

               //  Flag = 1;// To Update the Model Image
                //VideoControl.Attributes["s"] = @"~/Images/" + filename;
                //ViewState["ImageCustPhotos"] = ImgMap.ImageUrl;
                //ImgMap.DataBind();
                //Add To Grid               
                AddtoGridVideo(filename);
            }
         //   SetInitialRow(Convert.ToInt32(txtFloor.Text), Convert.ToInt32(txtUnit.Text));
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg("Upload status: The file could not be uploaded. The following error occured: " + ex.Message, this.Page);
        }
    }

    protected void lnkLogo_Click(object sender, EventArgs e)
    {
        try
        {
            //To Delete All Files In Direcotry===========
            string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("~/Images/Temp/"));
            foreach (string filePath in filePaths)
                System.IO.File.Delete(filePath);
            //To Delete All Files In Direcotry===========
            Random random = new Random();

            if (LogoUpload.HasFile)
            {
                //--Total No of Files--
                Int64 TotalFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Images")).Count();

                string filename = System.IO.Path.GetFileName(LogoUpload.FileName);
                filename = TotalFiles + "-" + filename;
                LogoUpload.SaveAs(Server.MapPath("~/Images/Temp/") + filename);
                //LogoUpload.SaveAs(Server.MapPath("~/Images/original/") + filename);

                //==========USed For Resize Image to Gal Size===================
                System.Drawing.Image GalImage = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                GalImage.Save(Server.MapPath("~/Images/") + filename);
                GalImage = null;
                //==========USed For Resize Image to Gal Size===================   

                //==========USed For Resize Image to Thumb===================
                System.Drawing.Image Thumb = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                Thumb.Save(Server.MapPath("~/Images/Thumb/") + filename);
                Thumb = null;
                //==========USed For Resize Image to Thumb===================

                //ViewState["UploadedPath"] = "~/Images/" + filename;
                //Add To image
                AddtoGridLogo(filename);
                //ImgMap.ImageUrl = @"~/Images/" + filename;
                //ViewState["ImageMap"] = ImgMap.ImageUrl;
                //ImgMap.DataBind();
                // SetInitialRow(Convert.ToInt32(txtFloor.Text), Convert.ToInt32(txtUnit.Text));
            }

        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg("Upload status: The file could not be uploaded. The following error occured: " + ex.Message, this.Page);
        }
    }

    protected void lnkPlan_Click(object sender, EventArgs e)
    {
        try
        {
            //To Delete All Files In Direcotry===========
            string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("~/Images/Temp/"));
            foreach (string filePath in filePaths)
                System.IO.File.Delete(filePath);
            //To Delete All Files In Direcotry===========
            Random random = new Random();

            if (PlanUpload.HasFile)
            {
                //--Total No of Files--
                Int64 TotalFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Images")).Count();

                string filename = System.IO.Path.GetFileName(PlanUpload.FileName);
                filename = TotalFiles + "-" + filename;
                PlanUpload.SaveAs(Server.MapPath("~/Images/Temp/") + filename);
                //PlanUpload.SaveAs(Server.MapPath("~/Images/original/") + filename);

                //==========USed For Resize Image to Gal Size===================
                System.Drawing.Image GalImage = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                GalImage.Save(Server.MapPath("~/Images/") + filename);
                GalImage = null;
                //==========USed For Resize Image to Gal Size===================   

                //==========USed For Resize Image to Thumb===================
                System.Drawing.Image Thumb = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                Thumb.Save(Server.MapPath("~/Images/Thumb/") + filename);
                Thumb = null;
                //==========USed For Resize Image to Thumb===================

                //ViewState["UploadedPath"] = "~/Images/" + filename;
                //Add To image
                AddtoGridPlan(filename);
                //ImgMap.ImageUrl = @"~/Images/" + filename;
                //ViewState["ImageMap"] = ImgMap.ImageUrl;
                //ImgMap.DataBind();
                // SetInitialRow(Convert.ToInt32(txtFloor.Text), Convert.ToInt32(txtUnit.Text));
            }

        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg("Upload status: The file could not be uploaded. The following error occured: " + ex.Message, this.Page);
        }
    }

    protected void lnkCompany_Click(object sender, EventArgs e)
    {
        try
        {
            //To Delete All Files In Direcotry===========
            string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("~/Images/Temp/"));
            foreach (string filePath in filePaths)
                System.IO.File.Delete(filePath);
            //To Delete All Files In Direcotry===========
            Random random = new Random();

            if (CompanyLogoUpload.HasFile)
            {
                //--Total No of Files--
                Int64 TotalFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Images")).Count();

                string filename = System.IO.Path.GetFileName(CompanyLogoUpload.FileName);
                filename = TotalFiles + "-" + filename;
                CompanyLogoUpload.SaveAs(Server.MapPath("~/Images/Temp/") + filename);
               // CompanyLogoUpload.SaveAs(Server.MapPath("~/Images/original/") + filename);

                //==========USed For Resize Image to Gal Size===================
                System.Drawing.Image GalImage = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                GalImage.Save(Server.MapPath("~/Images/") + filename);
                GalImage = null;
                //==========USed For Resize Image to Gal Size===================   

                //==========USed For Resize Image to Thumb===================
                System.Drawing.Image Thumb = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                Thumb.Save(Server.MapPath("~/Images/Thumb/") + filename);
                Thumb = null;
                //==========USed For Resize Image to Thumb===================
                lblLogopath.Text = "~/Images/" + filename;
                ImgDone.Visible = true;
                ImgCompanyLogo.ImageUrl = @"~/Images/" + filename;
                ImgCompanyLogo.DataBind();
                //ViewState["UploadedPath"] = "~/Images/" + filename;
                //Add To image
                //ImgMap.ImageUrl = @"~/Images/" + filename;
                //ViewState["ImageMap"] = ImgMap.ImageUrl;
                //ImgMap.DataBind();
                // SetInitialRow(Convert.ToInt32(txtFloor.Text), Convert.ToInt32(txtUnit.Text));
            }

        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg("Upload status: The file could not be uploaded. The following error occured: " + ex.Message, this.Page);
        }
    }

    protected void GrdReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Decimal TotalSqft = 0;
        try
        {
            switch (e.CommandName)
            {
                case ("Select"):
                    {
                        if (Convert.ToInt32(e.CommandArgument) != 0)
                        {
                            int EnquiryID = Convert.ToInt32(e.CommandArgument);

                            ViewState["EditID"] = EnquiryID;
                            DS = Obj_PC.GetPCForEdit(EnquiryID, out StrError,1);
                            DS1 = Obj_PC.GetPCForEdit(EnquiryID, out StrError,0);

                                if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                                {
                                    txtPCNo.Text = Convert.ToString(DS.Tables[0].Rows[0]["PCNo"]);
                                    txtProjectName.Text = Convert.ToString(DS.Tables[0].Rows[0]["PCName"]);
                                    ddlProjectType.SelectedValue = Convert.ToString(DS.Tables[0].Rows[0]["ProjectTypeId"]);
                                    ddlProjectSubtype.SelectedValue = Convert.ToString(DS.Tables[0].Rows[0]["ProjectSubTypeId"]);
                                    txtAddress.Text = Convert.ToString(DS.Tables[0].Rows[0]["Address"]);
                                    txtNoofTower.Text = Convert.ToString(DS.Tables[0].Rows[0]["NOofTowers"]);

                                    txtStampDuty.Text = Convert.ToString(DS.Tables[0].Rows[0]["StampAC"]);
                                    txtRegistration.Text = Convert.ToString(DS.Tables[0].Rows[0]["RegistrationAC"]);
                                    txtVat.Text = Convert.ToString(DS.Tables[0].Rows[0]["VatAC"]);
                                    txtCollection.Text = Convert.ToString(DS.Tables[0].Rows[0]["CollectionAC"]);
                                    txtServiceTax.Text = Convert.ToString(DS.Tables[0].Rows[0]["ServiceTaxAC"]);
                                    txtCancelCharge.Text = Convert.ToString(DS.Tables[0].Rows[0]["CancelCharge"]);
                                    txtTerraceAreaPer.Text = Convert.ToString(DS.Tables[0].Rows[0]["TerraceAreaPer"]);
                                    txtGardenAreaPer.Text = Convert.ToString(DS.Tables[0].Rows[0]["GardenAreaPer"]);

                                    txtLoading.Text = Convert.ToString(DS.Tables[0].Rows[0]["Loading"]);
                                    txtTotalLand.Text = Convert.ToString(DS.Tables[0].Rows[0]["LandArea"]);
                                    txtSaleableFSI.Text = Convert.ToString(DS.Tables[0].Rows[0]["SaleableFSI"]);
  
                                    bool Isall = Convert.ToBoolean(DS.Tables[1].Rows[0]["IsAll"]);
                                    if (Isall)
                                        RBAll.Checked = true;
                                    else
                                        RBEvenOdd.Checked = true;



                                    if (DS.Tables[1].Rows.Count > 0)
                                    {
                                        ViewState["MainDetail"] = DS.Tables[1];
                                        GridMainDetail.DataSource = DS.Tables[1];
                                        GridMainDetail.DataBind();
                                        for (int i = 0; i < DS.Tables[1].Rows.Count; i++)
                                        {
                                            TotalSqft += Convert.ToDecimal(DS.Tables[1].Rows[i]["SaleableArea"]);
                                        }
                                        txtTotalAll.Text = TotalSqft.ToString();
                                        BindddlClone();
                                    }
                                    else
                                    {

                                        GridMainDetail.DataSource = null;
                                        GridMainDetail.DataBind();
                                    }
                                    if (DS.Tables[2].Rows.Count > 0)
                                    {
                                        GridAmenities.DataSource = DS.Tables[2];
                                        GridAmenities.DataBind();
                                    }
                                    else
                                    {
                                        DataTable dtAmenity = (DataTable)ViewState["GridAmenity"];
                                        GridAmenities.DataSource = dtAmenity;
                                        GridAmenities.DataBind();
                                    }
                                    if (DS.Tables[3].Rows.Count > 0)
                                    {
                                        GridSpecific.DataSource = DS.Tables[3];
                                        GridSpecific.DataBind();
                                    }
                                    else
                                    {
                                        DataTable dtSpec = (DataTable)ViewState["GridSpecific"];
                                        GridSpecific.DataSource = dtSpec;
                                        GridSpecific.DataBind();
                                    }
                                    if (DS.Tables[4].Rows.Count > 0)
                                    {
                                        ViewState["CompanyTable"] = DS.Tables[4];
                                        GridCompany.DataSource = DS.Tables[4];
                                        GridCompany.DataBind();
                                    }
                                    else
                                    {
                                        SetInitialCompanyRow();
                                    }
                                    if (DS1.Tables[0].Rows.Count > 0)
                                    {
                                        ViewState["CurrentTableImages"] = DS1.Tables[0];
                                        grdupload.DataSource = DS1.Tables[0];
                                        grdupload.DataBind();
                                    }
                                    else
                                    {
                                        SetInitialRowImages();
                                    }
                                    if (DS1.Tables[1].Rows.Count > 0)
                                    {
                                        GridVideo.DataSource = DS1.Tables[1];
                                        GridVideo.DataBind();
                                    }
                                    else
                                    {
                                        SetInitialRowVideo();
                                    }
                                    if (DS1.Tables[2].Rows.Count > 0)
                                    {
                                        ViewState["CurrentTablePlan"] = DS1.Tables[2];
                                        GridPlan.DataSource = DS1.Tables[2];
                                        GridPlan.DataBind();
                                    }
                                    else
                                    {
                                        SetInitialRowPlan();
                                    }
                                    if (DS1.Tables[3].Rows.Count > 0)
                                    {
                                        ViewState["CurrentTableLogo"] = DS1.Tables[3];
                                        GridLogo.DataSource = DS1.Tables[3];
                                        GridLogo.DataBind();
                                    }
                                    else
                                    {
                                        SetInitialRowLogo();
                                    }
                                    if (DS1.Tables[4].Rows.Count > 0)
                                    {
                                        ViewState["CurrentTableLayout"] = DS1.Tables[4];
                                        GridLayout.DataSource = DS1.Tables[4];
                                        GridLayout.DataBind();
                                    }
                                    else
                                    {
                                        SetInitialRowLayout();
                                    }
                                    if (DS1.Tables[5].Rows.Count > 0)
                                    {
                                        ViewState["CurrentTableMap"] = DS1.Tables[5];
                                        GridMap.DataSource = DS1.Tables[5];
                                        GridMap.DataBind();
                                    }
                                    else
                                    {
                                        SetInitialRowMap();
                                    }
                                    if (DS1.Tables[6].Rows.Count > 0)
                                    {
                                        GridAmenityImg.DataSource = DS1.Tables[6];
                                        ViewState["CurrentTableAmenity"] = DS1.Tables[6];
                                        GridAmenityImg.DataBind();
                                    }
                                    else
                                    {
                                        SetInitialRowAmenity();
                                    }
                                    if (DS1.Tables[7].Rows.Count > 0)
                                    {
                                        ViewState["CurrentTableSpec"] = DS1.Tables[7];
                                        GridSpecImg.DataSource = DS1.Tables[7];
                                        GridSpecImg.DataBind();
                                    }
                                    else
                                    {
                                        SetInitialRowSpec();
                                    }
                                     if (DS1.Tables[8].Rows.Count > 0)
                                    {

                                        ViewState["DocumentList"] = DS1.Tables[8];
                                        GridDocumentList.DataSource = DS1.Tables[8];
                                        GridDocumentList.DataBind();
                                        for (int i = 0; i < GridDocumentList.Rows.Count; i++)
                                        {
                                            if (Convert.ToBoolean(DS1.Tables[8].Rows[i]["IsChecked"]))
                                            {
                                                GridDocumentList.Rows[i].BackColor = System.Drawing.Color.LightSteelBlue;
                                            }
                                            else
                                            {
                                                GridDocumentList.Rows[i].BackColor = System.Drawing.Color.White;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        SetInitialRowSpec();
                                    }
                                   
                                }
                                else
                                {
                                    MakeEmptyForm();
                                }

                                if (DS.Tables[5].Rows.Count > 0)
                                {
                                    if (Convert.ToInt32(DS.Tables[5].Rows[0]["Booked"]) > 0)
                                    {
                                        FlagBooked = true;
                                        //Obj_Comm.ShowPopUpMsg("Can't change Flat Details because booking has been made aginst this Project..", this.Page);
                                        Obj_Comm.ShowPopUpMsg("You can change Individual Flat Detail and Other Details!", this.Page);
                                    }
                                    else
                                    {
                                        FlagBooked = false;
                                    }
                                }

                                if (!FlagEdit)
                                    BtnUpdate.Visible = true;
                                if (!FlagDel)
                                {
                                    foreach (GridViewRow GRow in GrdReport.Rows)
                                    {
                                        GRow.FindControl("ImgBtnDelete").Visible = true;
                                    }
                                }
                                if (!FlagPrint)
                                {
                                    foreach (GridViewRow GRow in GrdReport.Rows)
                                    {
                                        GRow.FindControl("ImgBtnPrint").Visible = true;
                                    }
                                }
                            BtnSave.Visible = false;
                            DS = null;
                            Obj_PC = null;
                            
                            
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "CalSaleableFSI", "CalSaleableFSI();", true);//Done By Sushma 24 Apr 2014
                        break;
      
                    }
                #region case_PDF
                case ("Pdf"):
                    {
                        if (Convert.ToInt32(e.CommandArgument) != 0)
                        {
                            int PCID = Convert.ToInt32(e.CommandArgument);
                            DS = Obj_PC.GetPCForEdit(PCID, out StrError, 1);
                            DS1 = Obj_PC.GetPCForEdit(PCID, out StrError, 0);
                            if (DS1.Tables.Count > 0 && DS.Tables.Count > 0)
                            {

                                if (DS.Tables[0].Rows.Count>0)
                                {
                                    DS.Tables[0].TableName = "ProjectDetails";
                                    
                                }
                                if (DS1.Tables[3].Rows.Count > 0)
                                {

                                    DS1.Tables[3].TableName = "LogoImage";

                                    // Print Picture in Crystal Report Dynamically.

                                    DS1.Tables[3].Columns.Add("ImageLogo", System.Type.GetType("System.Byte[]"));

                                    for (int k = 0; k < DS1.Tables[3].Rows.Count; k++)
                                    {
                                        string Image = Server.MapPath(DS1.Tables[3].Rows[k]["LogoImg"].ToString());

                                        if (System.IO.File.Exists(Image))
                                        {
                                            FileStream fs;
                                            BinaryReader br;

                                            fs = new FileStream(Image, FileMode.Open);

                                            br = new BinaryReader(fs);
                                            byte[] imgbyte = new byte[fs.Length + 1];
                                            imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)));

                                            DS1.Tables[3].Rows[k]["ImageLogo"] = imgbyte;

                                            br.Close();
                                            fs.Close();
                                        }
                                    }
                                }
                                // Print Picture in Crystal Report Dynamically.
                                ReportDocument CRpt1 = new ReportDocument();
                                CRpt1.Load(Server.MapPath("~/Reports/CryRptPdfImage.rpt"));
                                CRpt1.SetDataSource(DS);
                            }
                            else
                            {
                                Obj_Comm.ShowPopUpMsg("No Data Found..!", this.Page);
                                //GridReportList.DataSource = dsLogin.Tables[0];
                                //GridReportList.DataBind();

                                //dsLogin.Clear();

                            }
                        }

                        break;
                    }
                #endregion
            }
        }
        catch(ThreadAbortException Thex)
        {
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void  ImgAddMainDetail_Click(object sender, ImageClickEventArgs e)
    {
      
        DataTable dtAddGrid = new DataTable();
        DataTable dtGrid = (DataTable)ViewState["CurrentTable"];
     
        FloorNoCount = 0;
        Label2.Text = "Tower Detail Grid :-";

        if(dtGrid!=null && GridDetails.Rows.Count>0)
        {
            if (dtGrid.Rows.Count == 1 && string.IsNullOrEmpty(dtGrid.Rows[0]["TowerName"].ToString()))
            {
                dtGrid.Rows.RemoveAt(0);
            }
            if (GridMainDetail.Rows.Count == 1 && string.IsNullOrEmpty(GridMainDetail.Rows[0].Cells[0].Text))//FOr 1st Entry in Main Grid
            {
                dtAddGrid = dtGrid.Copy();
                dtAddGrid.Clear();
                for (int i = 0; i < GridDetails.Rows.Count; i++)
                {
                    DataRow dr = dtAddGrid.NewRow();
                    Label TowerName = (Label)GridDetails.Rows[i].Cells[1].FindControl("lblTowerName");
                    Label FlatNo = (Label)GridDetails.Rows[i].Cells[2].FindControl("lblFlatNo");

                    TextBox Sqft = (TextBox)GridDetails.Rows[i].Cells[3].FindControl("txtSqft");
                    TextBox TerraceArea = (TextBox)GridDetails.Rows[i].Cells[4].FindControl("txtTerraceAreaSaleCarpet");
                    TextBox GardenArea = (TextBox)GridDetails.Rows[i].Cells[5].FindControl("txtGardenAreaSaleCarpet");
                    TextBox CarpetArea = (TextBox)GridDetails.Rows[i].Cells[6].FindControl("txtCarpetAreaSaleCarpet");


                    TextBox txtSqftSaleBuiltUp = (TextBox)GridDetails.Rows[i].Cells[7].FindControl("txtSqftSaleBuiltUp");
                    TextBox txtTerraceAreaSaleBuiltUp = (TextBox)GridDetails.Rows[i].Cells[8].FindControl("txtTerraceAreaSaleBuiltUp");
                    TextBox txtGardenAreaSaleBuiltUp = (TextBox)GridDetails.Rows[i].Cells[9].FindControl("txtGardenAreaSaleBuiltUp");
                    TextBox txtSaleableAreaSaleBuiltUp = (TextBox)GridDetails.Rows[i].Cells[10].FindControl("txtSaleableAreaSaleBuiltUp");


                    TextBox txtFlatAgreementCarpet = (TextBox)GridDetails.Rows[i].Cells[11].FindControl("txtFlatAgreementCarpet");
                    TextBox txtTerraceAgreementCarpet = (TextBox)GridDetails.Rows[i].Cells[12].FindControl("txtTerraceAgreementCarpet");

                    TextBox txtFlatAgreementBuiltUp = (TextBox)GridDetails.Rows[i].Cells[13].FindControl("txtFlatAgreementBuiltUp");
                    TextBox txtTerraceAgreementBuiltUp = (TextBox)GridDetails.Rows[i].Cells[14].FindControl("txtTerraceAgreementBuiltUp");

                    TextBox txtTerracePer = (TextBox)GridDetails.Rows[i].Cells[20].FindControl("txtTerracePer");
                    TextBox txtGardenPer = (TextBox)GridDetails.Rows[i].Cells[21].FindControl("txtGardenPer");
                    
                    DropDownList ddlType = (DropDownList)GridDetails.Rows[i].Cells[15].FindControl("ddlFlatType");
                    Label Floor = (Label)GridDetails.Rows[i].Cells[16].FindControl("lblFloor");
                    Label Unit = (Label)GridDetails.Rows[i].Cells[17].FindControl("lblUnit");
                    DropDownList ddlFacingType = (DropDownList)GridDetails.Rows[i].Cells[18].FindControl("ddlFacingType");
                    Label LayoutPath = (Label)GridDetails.Rows[i].Cells[0].FindControl("lblImgPath");

                    dr["Sqft"] = !string.IsNullOrEmpty(Sqft.Text) ? Convert.ToDecimal(Sqft.Text) : 0;
                   
                    dr["TerraceArea"] = !string.IsNullOrEmpty(TerraceArea.Text) ? Convert.ToDecimal(TerraceArea.Text) : 0;
                    dr["GardenArea"] = !string.IsNullOrEmpty(GardenArea.Text) ? Convert.ToDecimal(GardenArea.Text) : 0;
                    dr["CarpetArea"] = !string.IsNullOrEmpty(CarpetArea.Text) ? Convert.ToDecimal(CarpetArea.Text) : 0;

     dr["SqftSaleBuiltUp"] = !string.IsNullOrEmpty(txtSqftSaleBuiltUp.Text) ? Convert.ToDecimal(txtSqftSaleBuiltUp.Text) : 0;
    dr["TerraceAreaSaleBuiltUp"] = !string.IsNullOrEmpty(txtTerraceAreaSaleBuiltUp.Text) ? Convert.ToDecimal(txtTerraceAreaSaleBuiltUp.Text) : 0;
dr["GardenAreaSaleBuiltUp"] = !string.IsNullOrEmpty(txtGardenAreaSaleBuiltUp.Text) ? Convert.ToDecimal(txtGardenAreaSaleBuiltUp.Text) : 0;
dr["SaleableArea"] = !string.IsNullOrEmpty(txtSaleableAreaSaleBuiltUp.Text) ? Convert.ToDecimal(txtSaleableAreaSaleBuiltUp.Text) : 0;

dr["AgreementCarpetFlat"] = !string.IsNullOrEmpty(txtFlatAgreementCarpet.Text) ? Convert.ToDecimal(txtFlatAgreementCarpet.Text) : 0;
dr["AgreementCarpetTerrace"] = !string.IsNullOrEmpty(txtTerraceAgreementCarpet.Text) ? Convert.ToDecimal(txtTerraceAgreementCarpet.Text) : 0;

dr["AgreementBuiltUpFlat"] = !string.IsNullOrEmpty(txtFlatAgreementBuiltUp.Text) ? Convert.ToDecimal(txtFlatAgreementBuiltUp.Text) : 0;
dr["AgreementBuiltUpTerrace"] = !string.IsNullOrEmpty(txtTerraceAgreementBuiltUp.Text) ? Convert.ToDecimal(txtTerraceAgreementBuiltUp.Text) : 0;

                    dr["FlatNo"] = Convert.ToString(FlatNo.Text);
                    dr["TowerName"] = Convert.ToString(TowerName.Text);
                    dr["FlatTypeId"] = ddlType.SelectedValue;
                    dr["Floor"] = Convert.ToInt32(Floor.Text);
                    dr["Unit"] = Convert.ToInt32(Unit.Text);
                    dr["FloorNo"] = Convert.ToInt32(GridDetails.Rows[i].Cells[19].Text);
                    dr["FacingTypeId"] = Convert.ToInt32(ddlFacingType.SelectedValue);
                    dr["LayoutPath"] = Convert.ToString(LayoutPath.Text);
                    dr["TerracePer"] = Convert.ToString(txtTerracePer.Text);
                    dr["GardenPer"] = Convert.ToString(txtGardenPer.Text);

                    //dr["UsedCount"] = 0;
                    //dr["PCDetailId"] = 0;

                    dtAddGrid.Rows.Add(dr);
                }
                dtAddGrid.Columns.Add("UsedCount");
                dtAddGrid.Columns.Add("PCDetailId");
                foreach (DataRow drNew in dtAddGrid.Rows)
                {
                    drNew["UsedCount"] = 0;
                    drNew["PCDetailId"] = 0;
                }
                txtTotalAll.Text = txtSubTotal.Text;
                ViewState["MainDetail"] = dtAddGrid;
                GridMainDetail.DataSource = dtAddGrid;
                GridMainDetail.DataBind();
      
            }
            else   //FOr >2nd Entry Entry in Main Grid
            {
                
                DataTable dtGrid1 = (DataTable)ViewState["MainDetail"];
                dtAddGrid = dtGrid1.Copy();
                //int Count = 1;
                //for (int j = dtAddGrid.Rows.Count-2; j > 0; j--)
                //{
                //   string currName= dtAddGrid.Rows[j]["TowerName"].ToString();
                //   string PrevName = dtAddGrid.Rows[j+1]["TowerName"].ToString();
                //   if (!PrevName.Equals(currName))
                //   {
                //       Count++;
                //   }
                //}
                for (int i = 0; i < GridDetails.Rows.Count; i++)
                {
                    DataRow dr = dtAddGrid.NewRow();
                    Label TowerName = (Label)GridDetails.Rows[i].Cells[1].FindControl("lblTowerName");
                    Label FlatNo = (Label)GridDetails.Rows[i].Cells[2].FindControl("lblFlatNo");
                    TextBox Sqft = (TextBox)GridDetails.Rows[i].Cells[3].FindControl("txtSqft");

                    TextBox TerraceArea = (TextBox)GridDetails.Rows[i].Cells[4].FindControl("txtTerraceAreaSaleCarpet");
                    TextBox GardenArea = (TextBox)GridDetails.Rows[i].Cells[5].FindControl("txtGardenAreaSaleCarpet");
                    TextBox CarpetArea = (TextBox)GridDetails.Rows[i].Cells[6].FindControl("txtCarpetAreaSaleCarpet");


                    TextBox txtSqftSaleBuiltUp = (TextBox)GridDetails.Rows[i].Cells[7].FindControl("txtSqftSaleBuiltUp");
                    TextBox txtTerraceAreaSaleBuiltUp = (TextBox)GridDetails.Rows[i].Cells[8].FindControl("txtTerraceAreaSaleBuiltUp");
                    TextBox txtGardenAreaSaleBuiltUp = (TextBox)GridDetails.Rows[i].Cells[9].FindControl("txtGardenAreaSaleBuiltUp");
                    TextBox txtSaleableAreaSaleBuiltUp = (TextBox)GridDetails.Rows[i].Cells[10].FindControl("txtSaleableAreaSaleBuiltUp");


                    TextBox txtFlatAgreementCarpet = (TextBox)GridDetails.Rows[i].Cells[11].FindControl("txtFlatAgreementCarpet");
                    TextBox txtTerraceAgreementCarpet = (TextBox)GridDetails.Rows[i].Cells[12].FindControl("txtTerraceAgreementCarpet");

                    TextBox txtFlatAgreementBuiltUp = (TextBox)GridDetails.Rows[i].Cells[13].FindControl("txtFlatAgreementBuiltUp");
                    TextBox txtTerraceAgreementBuiltUp = (TextBox)GridDetails.Rows[i].Cells[14].FindControl("txtTerraceAgreementBuiltUp");

                    TextBox txtTerracePer = (TextBox)GridDetails.Rows[i].Cells[20].FindControl("txtTerracePer");
                    TextBox txtGardenPer = (TextBox)GridDetails.Rows[i].Cells[21].FindControl("txtGardenPer");

                    DropDownList ddlType = (DropDownList)GridDetails.Rows[i].Cells[15].FindControl("ddlFlatType");
                    Label Floor = (Label)GridDetails.Rows[i].Cells[16].FindControl("lblFloor");
                    Label Unit = (Label)GridDetails.Rows[i].Cells[17].FindControl("lblUnit");
                    DropDownList ddlFacingType = (DropDownList)GridDetails.Rows[i].Cells[18].FindControl("ddlFacingType");
                    Label LayoutPath = (Label)GridDetails.Rows[i].Cells[0].FindControl("lblImgPath");

                    //TextBox TerraceArea = (TextBox)GridDetails.Rows[i].Cells[4].FindControl("txtTerraceArea");
                    //TextBox GardenArea = (TextBox)GridDetails.Rows[i].Cells[5].FindControl("txtGardenArea");
                    //TextBox SaleableArea = (TextBox)GridDetails.Rows[i].Cells[7].FindControl("txtSaleableArea");
                    //TextBox CarpetArea = (TextBox)GridDetails.Rows[i].Cells[6].FindControl("txtCarpetArea");


                    //DropDownList ddlType = (DropDownList)GridDetails.Rows[i].Cells[8].FindControl("ddlFlatType");
                    //Label Floor = (Label)GridDetails.Rows[i].Cells[9].FindControl("lblFloor");
                    //Label Unit = (Label)GridDetails.Rows[i].Cells[10].FindControl("lblUnit");
                    //DropDownList ddlFacingType = (DropDownList)GridDetails.Rows[i].Cells[11].FindControl("ddlFacingType");
                    //Label LayoutPath = (Label)GridDetails.Rows[i].Cells[0].FindControl("lblImgPath");
                    //TextBox txtTerracePer = (TextBox)GridDetails.Rows[i].Cells[6].FindControl("txtTerracePer");
                    //TextBox txtGardenPer = (TextBox)GridDetails.Rows[i].Cells[6].FindControl("txtGardenPer");



                    dr["Sqft"] = !string.IsNullOrEmpty(Sqft.Text) ? Convert.ToDecimal(Sqft.Text) : 0;
                    dr["TerraceArea"] = !string.IsNullOrEmpty(TerraceArea.Text) ? Convert.ToDecimal(TerraceArea.Text) : 0;
                    dr["GardenArea"] = !string.IsNullOrEmpty(GardenArea.Text) ? Convert.ToDecimal(GardenArea.Text) : 0;
                    dr["SaleableArea"] = !string.IsNullOrEmpty(txtSaleableAreaSaleBuiltUp.Text) ? Convert.ToDecimal(txtSaleableAreaSaleBuiltUp.Text) : 0;
                    dr["CarpetArea"] = !string.IsNullOrEmpty(CarpetArea.Text) ? Convert.ToDecimal(CarpetArea.Text) : 0;


                    dr["SqftSaleBuiltUp"] = !string.IsNullOrEmpty(txtSqftSaleBuiltUp.Text) ? Convert.ToDecimal(txtSqftSaleBuiltUp.Text) : 0;
                    dr["TerraceAreaSaleBuiltUp"] = !string.IsNullOrEmpty(txtTerraceAreaSaleBuiltUp.Text) ? Convert.ToDecimal(txtTerraceAreaSaleBuiltUp.Text) : 0;
                    dr["GardenAreaSaleBuiltUp"] = !string.IsNullOrEmpty(txtGardenAreaSaleBuiltUp.Text) ? Convert.ToDecimal(txtGardenAreaSaleBuiltUp.Text) : 0;
                    dr["SaleableArea"] = !string.IsNullOrEmpty(txtSaleableAreaSaleBuiltUp.Text) ? Convert.ToDecimal(txtSaleableAreaSaleBuiltUp.Text) : 0;

                    dr["AgreementCarpetFlat"] = !string.IsNullOrEmpty(txtFlatAgreementCarpet.Text) ? Convert.ToDecimal(txtFlatAgreementCarpet.Text) : 0;
                    dr["AgreementCarpetTerrace"] = !string.IsNullOrEmpty(txtTerraceAgreementCarpet.Text) ? Convert.ToDecimal(txtTerraceAgreementCarpet.Text) : 0;

                    dr["AgreementBuiltUpFlat"] = !string.IsNullOrEmpty(txtFlatAgreementBuiltUp.Text) ? Convert.ToDecimal(txtFlatAgreementBuiltUp.Text) : 0;
                    dr["AgreementBuiltUpTerrace"] = !string.IsNullOrEmpty(txtTerraceAgreementBuiltUp.Text) ? Convert.ToDecimal(txtTerraceAgreementBuiltUp.Text) : 0;


                    dr["FlatNo"] = Convert.ToString(FlatNo.Text);
                    dr["TowerName"] = Convert.ToString(TowerName.Text);
                    dr["FlatTypeId"] = ddlType.SelectedValue;
                    dr["Floor"] = Convert.ToInt32(Floor.Text);
                    dr["Unit"] = Convert.ToInt32(Unit.Text);
                    dr["FloorNo"] = Convert.ToInt32(GridDetails.Rows[i].Cells[19].Text);
                    dr["FacingTypeId"] = Convert.ToInt32(ddlFacingType.SelectedValue);
                    dr["LayoutPath"] = Convert.ToString(LayoutPath.Text);
                    dr["TerracePer"] = Convert.ToString(txtTerracePer.Text);
                    dr["GardenPer"] = Convert.ToString(txtGardenPer.Text);
                    
                    dr["UsedCount"] = 0;
                    dr["PCDetailId"] = 0;

                    dtAddGrid.Rows.Add(dr);
                }
                txtTotalAll.Text = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtTotalAll.Text)).ToString();
                ViewState["MainDetail"] = dtAddGrid;
                GridMainDetail.DataSource = dtAddGrid;
                GridMainDetail.DataBind();
              
            }
            BindddlClone();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CalSubTotalMain", "CalSubTotalMain();", true);
            MakeTowerControlEmpty();

        }

    }

    protected void GrdSelectAllHeader_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox GrdSelectAllHeader = ((CheckBox)GridAmenities.HeaderRow.FindControl("GrdSelectAllHeader"));
        if (GrdSelectAllHeader.Checked == true)
        {
            for (int i = 0; i < GridAmenities.Rows.Count; i++)
            {
                ((CheckBox)GridAmenities.Rows[i].Cells[1].FindControl("GrdSelectAll")).Checked = true;

                // GridUserRight.Rows[i].BackColor = System.Drawing.Color.LightGray;
                GridAmenities.Rows[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#F2FFF8");

            }
        }
        else
        {
            for (int i = 0; i < GridAmenities.Rows.Count; i++)
            {
                ((CheckBox)GridAmenities.Rows[i].Cells[0].FindControl("GrdSelectAll")).Checked = false;

                GridAmenities.Rows[i].BackColor = System.Drawing.Color.White;
            }
        }

    }

    protected void GrdSelectAllHeader1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox GrdSelectAllHeader = ((CheckBox)GridSpecific.HeaderRow.FindControl("GrdSelectAllHeader1"));
        if (GrdSelectAllHeader.Checked == true)
        {
            for (int i = 0; i < GridSpecific.Rows.Count; i++)
            {
                ((CheckBox)GridSpecific.Rows[i].Cells[1].FindControl("GrdSelectAll")).Checked = true;

                // GridUserRight.Rows[i].BackColor = System.Drawing.Color.LightGray;
                GridSpecific.Rows[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#F2FFF8");

            }
        }
        else
        {
            for (int i = 0; i < GridSpecific.Rows.Count; i++)
            {
                ((CheckBox)GridSpecific.Rows[i].Cells[0].FindControl("GrdSelectAll")).Checked = false;

                GridSpecific.Rows[i].BackColor = System.Drawing.Color.White;
            }
        }

    }

    protected void GridMainDetail_DataBound(object sender, EventArgs e)
    {
        //=========For Merge the Row In to Single Section=================
        for (int rowIndex = GridMainDetail.Rows.Count - 2;rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = GridMainDetail.Rows[rowIndex];
            GridViewRow gvPreviousRow = GridMainDetail.Rows[rowIndex + 1];
            // for (int cellCount = 0; cellCount < gvRow.Cells.Count;cellCount++)
            //{
            Label txtRow = (Label)GridMainDetail.Rows[rowIndex].Cells[0].FindControl("lblselect");
            Label txtPreviousRow = (Label)GridMainDetail.Rows[rowIndex + 1].Cells[0].FindControl("lblselect");
            if (txtRow.Text == txtPreviousRow.Text)
            {
                if (gvPreviousRow.Cells[0].RowSpan < 2)
                {
                    gvRow.Cells[0].RowSpan = 2;
                }
                else
                {
                    gvRow.Cells[0].RowSpan =
                        gvPreviousRow.Cells[0].RowSpan + 1;
                }
                gvPreviousRow.Cells[0].CssClass = "Display_None";
            }
            //}
        }
        //=========For Merge the Row In to Single Section=================
    }

    protected void GridMainDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case ("Select"):
                    {
                        DataTable dt=(DataTable)ViewState["MainDetail"];
                        DataTable dtnew = dt.Copy();
                        DataTable dtMain = dt.Copy();

                        dtnew.Clear();
                        dtMain.Clear();

                        string Name=e.CommandArgument.ToString();
                        for (int i = 0; i < GridMainDetail.Rows.Count; i++)
                        {
                            Label TowerName = (Label)GridMainDetail.Rows[i].Cells[0].FindControl("lblTowerName1");
                            if (Name == TowerName.Text) //Set Dt for Selected Tower Name
                            {
                                DataRow dr = dtnew.NewRow();
                                Label FlatNo = (Label)GridMainDetail.Rows[i].Cells[3].FindControl("lblFlatNo1");
                                TextBox Sqft = (TextBox)GridMainDetail.Rows[i].Cells[4].FindControl("txtSqft1");
                                TextBox TerraceArea = (TextBox)GridMainDetail.Rows[i].Cells[5].FindControl("txtTerraceAreaSaleCarpet1");
                                TextBox GardenArea = (TextBox)GridMainDetail.Rows[i].Cells[6].FindControl("txtGardenAreaSaleCarpet1");
                                TextBox CarpetArea = (TextBox)GridMainDetail.Rows[i].Cells[7].FindControl("txtCarpetAreaSaleCarpet1");

                                TextBox txtSqftSaleBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[8].FindControl("txtSqftSaleBuiltUp1");
                TextBox txtTerraceAreaSaleBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[9].FindControl("txtTerraceAreaSaleBuiltUp1");
                          TextBox txtGardenAreaSaleBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[10].FindControl("txtGardenAreaSaleBuiltUp1");
                                TextBox SaleableArea = (TextBox)GridMainDetail.Rows[i].Cells[11].FindControl("txtSaleableAreaSaleBuiltUp1");

                    TextBox txtFlatAgreementCarpet = (TextBox)GridMainDetail.Rows[i].Cells[12].FindControl("txtFlatAgreementCarpet1");
                    TextBox txtTerraceAgreementCarpet = (TextBox)GridMainDetail.Rows[i].Cells[13].FindControl("txtTerraceAgreementCarpet1");

                    TextBox txtFlatAgreementBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[14].FindControl("txtFlatAgreementBuiltUp1");
                    TextBox txtTerraceAgreementBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[15].FindControl("txtTerraceAgreementBuiltUp1");


                    DropDownList ddlFlatType = (DropDownList)GridMainDetail.Rows[i].Cells[16].FindControl("ddlFlatType1");
                    Label Floor = (Label)GridMainDetail.Rows[i].Cells[17].FindControl("lblFloor1");
                    Label Unit = (Label)GridMainDetail.Rows[i].Cells[18].FindControl("lblUnit1");
                                DropDownList ddlFacingType = (DropDownList)GridMainDetail.Rows[i].Cells[19].FindControl("ddlFacingType1");

                                Label LayoutPath = (Label)GridMainDetail.Rows[i].Cells[21].FindControl("lblImgPath1");
                                TextBox txtTerracePer = (TextBox)GridMainDetail.Rows[i].Cells[22].FindControl("txtTerracePer1");
                                TextBox txtGardenPer = (TextBox)GridMainDetail.Rows[i].Cells[23].FindControl("txtGardenPer1");

                                txtTerraceAreaPer.Text = txtTerracePer.Text;
                                txtGardenAreaPer.Text = txtGardenPer.Text;

                                txtSubTotal.Text = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(SaleableArea.Text)).ToString();
                                txtTotalAll.Text = (Convert.ToDecimal(txtTotalAll.Text) - Convert.ToDecimal(SaleableArea.Text)).ToString();
                                dr["Sqft"] = !string.IsNullOrEmpty(Sqft.Text) ? Convert.ToDecimal(Sqft.Text) : 0;
                                dr["TerraceArea"] = !string.IsNullOrEmpty(TerraceArea.Text) ? Convert.ToDecimal(TerraceArea.Text) : 0;
                                dr["GardenArea"] = !string.IsNullOrEmpty(GardenArea.Text) ? Convert.ToDecimal(GardenArea.Text) : 0;
                                dr["CarpetArea"] = !string.IsNullOrEmpty(CarpetArea.Text) ? Convert.ToDecimal(CarpetArea.Text) : 0;

dr["SqftSaleBuiltUp"] = !string.IsNullOrEmpty(txtSqftSaleBuiltUp.Text) ? Convert.ToDecimal(txtSqftSaleBuiltUp.Text) : 0;
dr["TerraceAreaSaleBuiltUp"] = !string.IsNullOrEmpty(txtTerraceAreaSaleBuiltUp.Text) ? Convert.ToDecimal(txtTerraceAreaSaleBuiltUp.Text) : 0;
dr["GardenAreaSaleBuiltUp"] = !string.IsNullOrEmpty(txtGardenAreaSaleBuiltUp.Text) ? Convert.ToDecimal(txtGardenAreaSaleBuiltUp.Text) : 0;
dr["SaleableArea"] = !string.IsNullOrEmpty(SaleableArea.Text) ? Convert.ToDecimal(SaleableArea.Text) : 0;

dr["AgreementCarpetFlat"] = !string.IsNullOrEmpty(txtFlatAgreementCarpet.Text) ? Convert.ToDecimal(txtFlatAgreementCarpet.Text) : 0;
dr["AgreementCarpetTerrace"] = !string.IsNullOrEmpty(txtTerraceAgreementCarpet.Text) ? Convert.ToDecimal(txtTerraceAgreementCarpet.Text) : 0;

dr["AgreementBuiltUpFlat"] = !string.IsNullOrEmpty(txtFlatAgreementBuiltUp.Text) ? Convert.ToDecimal(txtFlatAgreementBuiltUp.Text) : 0;
dr["AgreementBuiltUpTerrace"] = !string.IsNullOrEmpty(txtTerraceAgreementBuiltUp.Text) ? Convert.ToDecimal(txtTerraceAgreementBuiltUp.Text) : 0;

                             


                                dr["FlatNo"] = Convert.ToString(FlatNo.Text);
                                dr["TowerName"] = Convert.ToString(TowerName.Text);
                                dr["FlatTypeId"] = ddlFlatType.SelectedValue;
                                dr["Floor"] = Floor.Text;
                                dr["Unit"] = Unit.Text;
                                dr["FloorNo"] =Convert.ToInt32(GridMainDetail.Rows[i].Cells[20].Text);
                                dr["FacingTypeId"] = Convert.ToInt32(ddlFacingType.SelectedValue);
                                dr["LayoutPath"] = Convert.ToString(LayoutPath.Text);
                                dr["TerracePer"] = Convert.ToString(txtTerracePer.Text);
                                dr["GardenPer"] = Convert.ToString(txtGardenPer.Text);

                                dtnew.Rows.Add(dr);
                            }
                            else  //Set Dt for Other Than Selected Tower Name
                            {
                                DataRow dr = dtMain.NewRow();
                                Label FlatNo = (Label)GridMainDetail.Rows[i].Cells[3].FindControl("lblFlatNo1");
                                TextBox Sqft = (TextBox)GridMainDetail.Rows[i].Cells[4].FindControl("txtSqft1");
                                TextBox TerraceArea = (TextBox)GridMainDetail.Rows[i].Cells[5].FindControl("txtTerraceAreaSaleCarpet1");
                                TextBox GardenArea = (TextBox)GridMainDetail.Rows[i].Cells[6].FindControl("txtGardenAreaSaleCarpet1");
                                TextBox CarpetArea = (TextBox)GridMainDetail.Rows[i].Cells[7].FindControl("txtCarpetAreaSaleCarpet1");

                                TextBox txtSqftSaleBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[8].FindControl("txtSqftSaleBuiltUp1");
                        TextBox txtTerraceAreaSaleBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[9].FindControl("txtTerraceAreaSaleBuiltUp1");
                        TextBox txtGardenAreaSaleBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[10].FindControl("txtGardenAreaSaleBuiltUp1");
                        TextBox SaleableArea = (TextBox)GridMainDetail.Rows[i].Cells[11].FindControl("txtSaleableAreaSaleBuiltUp1");

                        TextBox txtFlatAgreementCarpet = (TextBox)GridMainDetail.Rows[i].Cells[12].FindControl("txtFlatAgreementCarpet1");
                        TextBox txtTerraceAgreementCarpet = (TextBox)GridMainDetail.Rows[i].Cells[13].FindControl("txtTerraceAgreementCarpet1");

                        TextBox txtFlatAgreementBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[14].FindControl("txtFlatAgreementBuiltUp1");
                        TextBox txtTerraceAgreementBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[15].FindControl("txtTerraceAgreementBuiltUp1");


                                DropDownList ddlFlatType = (DropDownList)GridMainDetail.Rows[i].Cells[16].FindControl("ddlFlatType1");
                                Label Floor = (Label)GridMainDetail.Rows[i].Cells[17].FindControl("lblFloor1");
                                Label Unit = (Label)GridMainDetail.Rows[i].Cells[18].FindControl("lblUnit1");
                                DropDownList ddlFacingType = (DropDownList)GridMainDetail.Rows[i].Cells[19].FindControl("ddlFacingType1");

                                Label LayoutPath = (Label)GridMainDetail.Rows[i].Cells[21].FindControl("lblImgPath1");
                                TextBox txtTerracePer = (TextBox)GridMainDetail.Rows[i].Cells[22].FindControl("txtTerracePer1");
                                TextBox txtGardenPer = (TextBox)GridMainDetail.Rows[i].Cells[23].FindControl("txtGardenPer1");
                            

                                dr["Sqft"] = !string.IsNullOrEmpty(Sqft.Text) ? Convert.ToDecimal(Sqft.Text) : 0;
                                dr["TerraceArea"] = !string.IsNullOrEmpty(TerraceArea.Text) ? Convert.ToDecimal(TerraceArea.Text) : 0;
                                dr["GardenArea"] = !string.IsNullOrEmpty(GardenArea.Text) ? Convert.ToDecimal(GardenArea.Text) : 0;
                                dr["CarpetArea"] = !string.IsNullOrEmpty(CarpetArea.Text) ? Convert.ToDecimal(CarpetArea.Text) : 0;
dr["SqftSaleBuiltUp"] = !string.IsNullOrEmpty(txtSqftSaleBuiltUp.Text) ? Convert.ToDecimal(txtSqftSaleBuiltUp.Text) : 0;
dr["TerraceAreaSaleBuiltUp"] = !string.IsNullOrEmpty(txtTerraceAreaSaleBuiltUp.Text) ? Convert.ToDecimal(txtTerraceAreaSaleBuiltUp.Text) : 0;
dr["GardenAreaSaleBuiltUp"] = !string.IsNullOrEmpty(txtGardenAreaSaleBuiltUp.Text) ? Convert.ToDecimal(txtGardenAreaSaleBuiltUp.Text) : 0;
dr["SaleableArea"] = !string.IsNullOrEmpty(SaleableArea.Text) ? Convert.ToDecimal(SaleableArea.Text) : 0;

dr["AgreementCarpetFlat"] = !string.IsNullOrEmpty(txtFlatAgreementCarpet.Text) ? Convert.ToDecimal(txtFlatAgreementCarpet.Text) : 0;
dr["AgreementCarpetTerrace"] = !string.IsNullOrEmpty(txtTerraceAgreementCarpet.Text) ? Convert.ToDecimal(txtTerraceAgreementCarpet.Text) : 0;

dr["AgreementBuiltUpFlat"] = !string.IsNullOrEmpty(txtFlatAgreementBuiltUp.Text) ? Convert.ToDecimal(txtFlatAgreementBuiltUp.Text) : 0;
dr["AgreementBuiltUpTerrace"] = !string.IsNullOrEmpty(txtTerraceAgreementBuiltUp.Text) ? Convert.ToDecimal(txtTerraceAgreementBuiltUp.Text) : 0;

                             
                                dr["FlatNo"] = Convert.ToString(FlatNo.Text);
                                dr["TowerName"] = Convert.ToString(TowerName.Text);
                                dr["FlatTypeId"] = ddlFlatType.SelectedValue;
                                dr["Floor"] = Floor.Text;
                                dr["Unit"] = Unit.Text;
                                dr["FloorNo"] = Convert.ToInt32(GridMainDetail.Rows[i].Cells[20].Text);
                                dr["FacingTypeId"] = Convert.ToInt32(ddlFacingType.SelectedValue);
                                dr["LayoutPath"] = Convert.ToString(LayoutPath.Text);
                                dr["TerracePer"] = Convert.ToString(txtTerracePer.Text);
                                dr["GardenPer"] = Convert.ToString(txtGardenPer.Text);

                                dtMain.Rows.Add(dr);
                            }
                        }
                      
                        ViewState["CurrentTable"] = dtnew;
                        GridDetails.DataSource=dtnew;
                        GridDetails.DataBind();
                        DivDetailGrid.Visible = true;
                        trAddGrid.Visible = true;

                        ViewState["MainDetail"] = dtMain;
                        GridMainDetail.DataSource = dtMain;
                        GridMainDetail.DataBind();

                        BindddlClone();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "CalSubTotalNew", " CalSubTotalNew();", true);                    
                        break;
                    }
                case ("Delete"):
                    {
                        int index = Convert.ToInt32(e.CommandArgument);
                        DataTable dt = (DataTable)ViewState["MainDetail"];



                        if (ViewState["EditID"] != null)
                        {
                            int UsedCount = Convert.ToInt32(this.GridMainDetail.DataKeys[index - 1]["UsedCount"]);
                            Entity_PC.PCDetailId = Convert.ToInt32(this.GridMainDetail.DataKeys[index - 1]["PCDetailId"]);
                            
                            Entity_PC.PCId = Convert.ToInt32(ViewState["EditID"]);
                            int iDelete = 0;
                            if (UsedCount==0)
                            {

                                iDelete = Obj_PC.DeleteFlats(ref Entity_PC, out StrError);
                            }

                            if (iDelete != 0)
                            {
                                Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                            }
                            else
                            {
                                Obj_Comm.ShowPopUpMsg("Record is Present in other transaction..!", this.Page);
                                return;
                            }

                        }


                        if (dt.Rows.Count > 0)
                        {
                            dt.Rows[index - 1].Delete();
                            dt.AcceptChanges();
                            ViewState["MainDetail"] = dt;
                            GridMainDetail.DataSource = dt;
                            GridMainDetail.DataBind();
                        }
                        else
                        {
                            GridMainDetail.DataSource = null;
                            GridMainDetail.DataBind();
                        }
                        break;

                    }
                case ("ChangeRow"):
                    {
                        int index = Convert.ToInt32(e.CommandArgument);
                        DataTable dt = (DataTable)ViewState["MainDetail"];



                        if (ViewState["EditID"] != null)
                        {
                           
                            Entity_PC.PCDetailId = Convert.ToInt32(this.GridMainDetail.DataKeys[index - 1]["PCDetailId"]);
                            Entity_PC.PCId = Convert.ToInt32(ViewState["EditID"]);

                            Entity_PC.Sqft = Convert.ToDecimal(((TextBox)GridMainDetail.Rows[index - 1].FindControl("txtSqft1")).Text);
                            Entity_PC.TerraceArea= Convert.ToDecimal(((TextBox)GridMainDetail.Rows[index - 1].FindControl("txtTerraceAreaSaleCarpet1")).Text);
                            Entity_PC.CarpetArea = Convert.ToDecimal(((TextBox)GridMainDetail.Rows[index - 1].FindControl("txtCarpetAreaSaleCarpet1")).Text);

                            Entity_PC.SqftSaleBuiltUp = Convert.ToDecimal(((TextBox)GridMainDetail.Rows[index - 1].FindControl("txtSqftSaleBuiltUp1")).Text);
                            Entity_PC.TerraceAreaSaleBuiltUp = Convert.ToDecimal(((TextBox)GridMainDetail.Rows[index - 1].FindControl("txtTerraceAreaSaleBuiltUp1")).Text);

                            Entity_PC.SaleableArea = Convert.ToDecimal(((TextBox)GridMainDetail.Rows[index - 1].FindControl("txtSaleableAreaSaleBuiltUp1")).Text);

                            Entity_PC.FlatAgreementCarpet = Convert.ToDecimal(((TextBox)GridMainDetail.Rows[index - 1].FindControl("txtFlatAgreementCarpet1")).Text);
                            Entity_PC.TerraceAgreementCarpet = Convert.ToDecimal(((TextBox)GridMainDetail.Rows[index - 1].FindControl("txtTerraceAgreementCarpet1")).Text);

                            Entity_PC.FlatAgreementBuiltUp = Convert.ToDecimal(((TextBox)GridMainDetail.Rows[index - 1].FindControl("txtFlatAgreementBuiltUp1")).Text);
                            Entity_PC.TerraceAgreementBuiltUp = Convert.ToDecimal(((TextBox)GridMainDetail.Rows[index - 1].FindControl("txtTerraceAgreementBuiltUp1")).Text);

                            
                             int iDelete = Obj_PC.UpdateFlats(ref Entity_PC, out StrError);

                             Obj_Comm.ShowPopUpMsg("Record Updated Successfully..!", this.Page);

                             
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

    protected void GrdReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            int DeleteId = Convert.ToInt32(((ImageButton)GrdReport.Rows[e.RowIndex].Cells[0].FindControl("ImgBtnDelete")).CommandArgument.ToString());
            DS = Obj_PC.GetPCForEdit(DeleteId, out StrError,0);
            if(DS.Tables.Count>0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    string[] path = new string[DS.Tables[0].Rows.Count];
                    for(int i=0;i<DS.Tables[0].Rows.Count;i++)
                    {

                        path[i] = System.IO.Path.GetFileName(DS.Tables[0].Rows[i]["ImageName"].ToString());
                   
                    }
                    foreach (string filePath in path)
                    {
                        System.IO.File.Delete(Server.MapPath("~/Images/" + filePath));
                    }
                }
                if (DS.Tables[1].Rows.Count > 0)
                {
                    string[] path = new string[DS.Tables[1].Rows.Count];
                    for (int i = 0; i < DS.Tables[1].Rows.Count; i++)
                    {

                        path[i] = System.IO.Path.GetFileName(DS.Tables[1].Rows[i]["VideoName"].ToString());

                    }
                    foreach (string filePath in path)
                    {
                        System.IO.File.Delete(Server.MapPath("~/index_videolb/video/" + filePath));
                    }
                }
                if (DS.Tables[2].Rows.Count > 0)
                {
                    string[] path = new string[DS.Tables[2].Rows.Count];
                    for (int i = 0; i < DS.Tables[2].Rows.Count; i++)
                    {

                        path[i] = System.IO.Path.GetFileName(DS.Tables[2].Rows[i]["PlanImg"].ToString());

                    }
                    foreach (string filePath in path)
                    {
                        System.IO.File.Delete(Server.MapPath("~/Images/" + filePath));
                    }
                }
                if (DS.Tables[3].Rows.Count > 0)
                {
                    string[] path = new string[DS.Tables[3].Rows.Count];
                    for (int i = 0; i < DS.Tables[3].Rows.Count; i++)
                    {

                        path[i] = System.IO.Path.GetFileName(DS.Tables[3].Rows[i]["LogoImg"].ToString());

                    }
                    foreach (string filePath in path)
                    {
                        System.IO.File.Delete(Server.MapPath("~/Images/" + filePath));
                    }
                }
                if (DS.Tables[4].Rows.Count > 0)
                {
                    string[] path = new string[DS.Tables[4].Rows.Count];
                    for (int i = 0; i < DS.Tables[4].Rows.Count; i++)
                    {

                        path[i] = System.IO.Path.GetFileName(DS.Tables[4].Rows[i]["LayoutImg"].ToString());

                    }
                    foreach (string filePath in path)
                    {
                        System.IO.File.Delete(Server.MapPath("~/Images/" + filePath));
                    }
                }
                if (DS.Tables[5].Rows.Count > 0)
                {
                    string[] path = new string[DS.Tables[5].Rows.Count];
                    for (int i = 0; i < DS.Tables[5].Rows.Count; i++)
                    {

                        path[i] = System.IO.Path.GetFileName(DS.Tables[5].Rows[i]["MapImg"].ToString());

                    }
                    foreach (string filePath in path)
                    {
                        System.IO.File.Delete(Server.MapPath("~/Images/" + filePath));
                    }
                }
            }
            if (DeleteId != 0)
            {
                Entity_PC.PCId = DeleteId;
                Entity_PC.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_PC.LoginDate = DateTime.Now;
                int iDelete = Obj_PC.DeleteProjectConfi(ref Entity_PC, out StrError);
                if (iDelete != 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }

            }
            Entity_PC = null;
            Obj_Comm = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void ImgAddCompany_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ViewState["CompanyTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CompanyTable"];

                DataRow dtTableRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    if (dtCurrentTable.Rows.Count == 1 && string.IsNullOrEmpty(dtCurrentTable.Rows[0]["Company"].ToString()))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }
                    if (ViewState["GridIndex"] != null)
                    {
                        int rowindex = Convert.ToInt32(ViewState["GridIndex"]);

                        dtCurrentTable.Rows[rowindex]["Company"] = !string.IsNullOrEmpty(txtCompanyName.Text) ? txtCompanyName.Text : "";
                        dtCurrentTable.Rows[rowindex]["CompanyAddress"] = !string.IsNullOrEmpty(txtCompanyAddress.Text) ? txtCompanyAddress.Text : "";
                        dtCurrentTable.Rows[rowindex]["LogoImg"] = !string.IsNullOrEmpty(lblLogopath.Text) ? lblLogopath.Text : "";

                        ImgDone.Visible = false;
                        ViewState["CompanyTable"] = dtCurrentTable;
                        GridCompany.DataSource = dtCurrentTable;
                        GridCompany.DataBind();
                        MakeControlEmpty();

                    }
                    else
                    {

                        dtTableRow = dtCurrentTable.NewRow();
                        dtTableRow["#"] = 0;
                        dtTableRow["Company"] = !string.IsNullOrEmpty(txtCompanyName.Text) ? txtCompanyName.Text : "";
                        dtTableRow["CompanyAddress"] = !string.IsNullOrEmpty(txtCompanyAddress.Text) ? txtCompanyAddress.Text : "";
                        dtTableRow["LogoImg"] = !string.IsNullOrEmpty(lblLogopath.Text) ? lblLogopath.Text : "";

                        ImgDone.Visible = false;
                        dtCurrentTable.Rows.Add(dtTableRow);
                        ViewState["CompanyTable"] = dtCurrentTable;
                        GridCompany.DataSource = dtCurrentTable;
                        GridCompany.DataBind();
                        MakeControlEmpty();
                    }
                }
            }

        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void GridCompany_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int Index;
            if (e.CommandName == "SelectGrid")
            {
                ImgAddCompany.ImageUrl = "~/Images/Icon/GridUpdate.png";
                ImgAddCompany.DataBind();
                ImgAddCompany.ToolTip = "Update";

                Index = Convert.ToInt32(e.CommandArgument);

                ViewState["GridIndex"] = Index;
                Label lblCompany = (Label)GridCompany.Rows[Index].Cells[1].FindControl("lblCompany");
                Label lblCompanyAddress = (Label)GridCompany.Rows[Index].Cells[2].FindControl("lblCompanyAddress");
                Label lblLogoImg = (Label)GridCompany.Rows[Index].Cells[3].FindControl("lblLogoImg");
                ImgCompanyLogo.ImageUrl = @"" +lblLogoImg.Text;
                ImgCompanyLogo.DataBind();
                txtCompanyName.Text = lblCompany.Text;
                txtCompanyAddress.Text = lblCompanyAddress.Text;
                lblLogopath.Text =lblLogoImg.Text;
                

            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void GridMainDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void lnkAmenity_Click(object sender, EventArgs e)
    {
        try
        {
            //To Delete All Files In Direcotry===========
            string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("~/Images/Temp/"));
            foreach (string filePath in filePaths)
                System.IO.File.Delete(filePath);
            //To Delete All Files In Direcotry===========
            Random random = new Random();

            if (AmenityUpload.HasFile)
            {
                //--Total No of Files--
                Int64 TotalFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Images")).Count();

                string filename = System.IO.Path.GetFileName(AmenityUpload.FileName);
                filename = TotalFiles + "-" + filename;
                AmenityUpload.SaveAs(Server.MapPath("~/Images/Temp/") + filename);
                AmenityUpload.SaveAs(Server.MapPath("~/Images/original/") + filename);

                //==========USed For Resize Image to Gal Size===================
                System.Drawing.Image GalImage = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                GalImage.Save(Server.MapPath("~/Images/") + filename);
                GalImage = null;
                //==========USed For Resize Image to Gal Size===================   

                //==========USed For Resize Image to Thumb===================
                System.Drawing.Image Thumb = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                Thumb.Save(Server.MapPath("~/Images/Thumb/") + filename);
                Thumb = null;
                //==========USed For Resize Image to Thumb===================

                //ViewState["UploadedPath"] = "~/Images/" + filename;
                //Add To image
                AddtoGridAmenity(filename);
                //ImgMap.ImageUrl = @"~/Images/" + filename;
                //ViewState["ImageMap"] = ImgMap.ImageUrl;
                //ImgMap.DataBind();
                // SetInitialRow(Convert.ToInt32(txtFloor.Text), Convert.ToInt32(txtUnit.Text));
            }

        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg("Upload status: The file could not be uploaded. The following error occured: " + ex.Message, this.Page);
        }
    }

    protected void lnkSpecification_Click(object sender, EventArgs e)
    {
        try
        {
            //To Delete All Files In Direcotry===========
            string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("~/Images/Temp/"));
            foreach (string filePath in filePaths)
                System.IO.File.Delete(filePath);
            //To Delete All Files In Direcotry===========
            Random random = new Random();

            if (SpecUpload.HasFile)
            {
                //--Total No of Files--
                Int64 TotalFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Images")).Count();

                string filename = System.IO.Path.GetFileName(SpecUpload.FileName);
                filename = TotalFiles + "-" + filename;
                SpecUpload.SaveAs(Server.MapPath("~/Images/Temp/") + filename);
                SpecUpload.SaveAs(Server.MapPath("~/Images/original/") + filename);

                //==========USed For Resize Image to Gal Size===================
                System.Drawing.Image GalImage = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                GalImage.Save(Server.MapPath("~/Images/") + filename);
                GalImage = null;
                //==========USed For Resize Image to Gal Size===================   

                //==========USed For Resize Image to Thumb===================
                System.Drawing.Image Thumb = Obj_Comm.ResizeImage(System.Drawing.Image.FromFile(Server.MapPath("~/Images/Temp/") + filename), 200, 200);
                Thumb.Save(Server.MapPath("~/Images/Thumb/") + filename);
                Thumb = null;
                //==========USed For Resize Image to Thumb===================

                //ViewState["UploadedPath"] = "~/Images/" + filename;
                //Add To image
                AddtoGridSpec(filename);
                //ImgMap.ImageUrl = @"~/Images/" + filename;
                //ViewState["ImageMap"] = ImgMap.ImageUrl;
                //ImgMap.DataBind();
                // SetInitialRow(Convert.ToInt32(txtFloor.Text), Convert.ToInt32(txtUnit.Text));
            }

        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg("Upload status: The file could not be uploaded. The following error occured: " + ex.Message, this.Page);
        }
    }

    protected void GridMainDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dtType = (DataTable)ViewState["ddlFlatType"];

                ((DropDownList)e.Row.FindControl("ddlFlatType1")).DataSource = dtType;
                ((DropDownList)e.Row.FindControl("ddlFlatType1")).DataTextField = "FlatType";
                ((DropDownList)e.Row.FindControl("ddlFlatType1")).DataValueField = "FlatTypeId";
                ((DropDownList)e.Row.FindControl("ddlFlatType1")).DataBind();
                ((DropDownList)e.Row.FindControl("ddlFlatType1")).SelectedValue = ((Label)e.Row.FindControl("lblFlatTypeId1")).Text;
                ((DropDownList)e.Row.FindControl("ddlFacingType1")).SelectedValue = ((Label)e.Row.FindControl("lblFacingTypeId1")).Text;
                ((TextBox)e.Row.FindControl("txtSqm1")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtSqft1")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtTerraceSqmSaleCarpet1")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtTerraceAreaSaleCarpet1")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtGardenSqmSaleCarpet1")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtGardenAreaSaleCarpet1")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtCarpetSqmSaleCarpet1")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtCarpetAreaSaleCarpet1")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");


                ((TextBox)e.Row.FindControl("txtSqmSaleBuiltUp1")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtSqftSaleBuiltUp1")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtTerraceSqmSaleBuiltUp1")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtTerraceAreaSaleBuiltUp1")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtGardenSqmSaleBuiltUp1")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtGardenAreaSaleBuiltUp1")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtSaleableSqmSaleBuiltUp1")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtSaleableAreaSaleBuiltUp1")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");

                ((TextBox)e.Row.FindControl("txtSqmAgreementCarpet1")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtFlatAgreementCarpet1")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtTerraceSqmAgreementCarpet1")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtTerraceAgreementCarpet1")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");

                ((TextBox)e.Row.FindControl("txtFlatSqmAgreementBuiltUp1")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtFlatAgreementBuiltUp1")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");
                ((TextBox)e.Row.FindControl("txtTerraceSqmAgreementBuiltUp1")).Text = Convert.ToDecimal(Convert.ToDecimal(((TextBox)e.Row.FindControl("txtTerraceAgreementBuiltUp1")).Text) * Convert.ToDecimal(0.092903)).ToString("#0.00");

              
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    protected void ApplyToAll_Click(object sender, ImageClickEventArgs e)
    {
        if (GridDetails.Rows.Count > 0)
        {
            int k = Convert.ToInt32(((Label)GridDetails.Rows[0].FindControl("lblUnit")).Text);
            int j = 0, z = 0;
            int c = 1;
            decimal[] sqft = new decimal[50];
            decimal[] sqftEven = new decimal[50];
            decimal[] TerraceArea = new decimal[50];
            decimal[] TerraceAreaEven = new decimal[50];
            decimal[] GardenArea = new decimal[50];
            decimal[] GardenAreaEven = new decimal[50];
         
            decimal[] CarpetArea = new decimal[50];
            decimal[] CarpetAreaEven = new decimal[50];

            decimal[] SqftSaleBuiltUp = new decimal[50];
            decimal[] SqftSaleBuiltUpEven = new decimal[50];
            decimal[] TerraceAreaSaleBuiltUp = new decimal[50];
            decimal[] TerraceAreaSaleBuiltUpEven = new decimal[50];
            decimal[] GardenAreaSaleBuiltUp = new decimal[50];
            decimal[] GardenAreaSaleBuiltUpEven = new decimal[50];
            decimal[] SaleableArea = new decimal[50];
            decimal[] SaleableAreaEven = new decimal[50];

            decimal[] FlatAgreementCarpet = new decimal[50];
            decimal[] FlatAgreementCarpetEven = new decimal[50];
            decimal[] TerraceAgreementCarpet = new decimal[50];
            decimal[] TerraceAgreementCarpetEven = new decimal[50];

            decimal[] FlatAgreementBuiltUp = new decimal[50];
            decimal[] FlatAgreementBuiltUpEven = new decimal[50];
            decimal[] TerraceAgreementBuiltUp = new decimal[50];
            decimal[] TerraceAgreementBuiltUpEven = new decimal[50];

            int[] FlatType = new int[50];
            int[] FlatTypeEven = new int[50];
            int[] FacingType = new int[50];
            int[] FacingTypeEven = new int[50];


            for (int i = 0; i < k; i++)
            {
                sqft[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtSqft")).Text);
                FlatType[i] = Convert.ToInt32(((DropDownList)GridDetails.Rows[i].FindControl("ddlFlatType")).SelectedValue);
                FacingType[i] = Convert.ToInt32(((DropDownList)GridDetails.Rows[i].FindControl("ddlFacingType")).SelectedValue);
                TerraceArea[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAreaSaleCarpet")).Text);
                GardenArea[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtGardenAreaSaleCarpet")).Text);
                CarpetArea[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtCarpetAreaSaleCarpet")).Text);

                SqftSaleBuiltUp[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtSqftSaleBuiltUp")).Text);
                TerraceAreaSaleBuiltUp[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAreaSaleBuiltUp")).Text);
                GardenAreaSaleBuiltUp[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtGardenAreaSaleBuiltUp")).Text);
                SaleableArea[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtSaleableAreaSaleBuiltUp")).Text);

                FlatAgreementCarpet[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtFlatAgreementCarpet")).Text);
                TerraceAgreementCarpet[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAgreementCarpet")).Text);

                FlatAgreementBuiltUp[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtFlatAgreementBuiltUp")).Text);
                TerraceAgreementBuiltUp[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAgreementBuiltUp")).Text);

            }
            for (int i = k; i < k + k; i++)
            {
                sqftEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtSqft")).Text);
                FlatTypeEven[z] = Convert.ToInt32(((DropDownList)GridDetails.Rows[i].FindControl("ddlFlatType")).SelectedValue);
                FacingTypeEven[z] = Convert.ToInt32(((DropDownList)GridDetails.Rows[i].FindControl("ddlFacingType")).SelectedValue);
                TerraceAreaEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAreaSaleCarpet")).Text);
                GardenAreaEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtGardenAreaSaleCarpet")).Text);
                SaleableAreaEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtSaleableAreaSaleBuiltUp")).Text);
                CarpetAreaEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtCarpetAreaSaleCarpet")).Text);

                SqftSaleBuiltUpEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtSqftSaleBuiltUp")).Text);
                TerraceAreaSaleBuiltUpEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAreaSaleBuiltUp")).Text);
                GardenAreaSaleBuiltUpEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtGardenAreaSaleBuiltUp")).Text);
                SaleableAreaEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtSaleableAreaSaleBuiltUp")).Text);

                FlatAgreementCarpetEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtFlatAgreementCarpet")).Text);
                TerraceAgreementCarpetEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAgreementCarpet")).Text);

                FlatAgreementBuiltUpEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtFlatAgreementBuiltUp")).Text);
                TerraceAgreementBuiltUpEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAgreementBuiltUp")).Text);

                z++;
            }

            for (int i = 0; i < GridDetails.Rows.Count; i++)
            {

           

                ((TextBox)GridDetails.Rows[i].FindControl("txtSqm")).Text = Convert.ToDecimal(sqft[j] * Convert.ToDecimal(0.092903)).ToString("#0.0000");
                ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceSqmSaleCarpet")).Text = Convert.ToDecimal(TerraceArea[j] * Convert.ToDecimal(0.092903)).ToString("#0.0000");
                ((TextBox)GridDetails.Rows[i].FindControl("txtGardenSqmSaleCarpet")).Text = Convert.ToDecimal(GardenArea[j] * Convert.ToDecimal(0.092903)).ToString("#0.0000");
                ((TextBox)GridDetails.Rows[i].FindControl("txtCarpetSqmSaleCarpet")).Text = Convert.ToDecimal(CarpetArea[j] * Convert.ToDecimal(0.092903)).ToString("#0.0000");

                ((TextBox)GridDetails.Rows[i].FindControl("txtSqmSaleBuiltUp")).Text = Convert.ToDecimal(SqftSaleBuiltUp[j] * Convert.ToDecimal(0.092903)).ToString("#0.0000");
                ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceSqmSaleBuiltUp")).Text = Convert.ToDecimal(TerraceAreaSaleBuiltUp[j] * Convert.ToDecimal(0.092903)).ToString("#0.0000");
                ((TextBox)GridDetails.Rows[i].FindControl("txtGardenSqmSaleBuiltUp")).Text = Convert.ToDecimal(GardenAreaSaleBuiltUp[j] * Convert.ToDecimal(0.092903)).ToString("#0.0000");
                ((TextBox)GridDetails.Rows[i].FindControl("txtSaleableSqmSaleBuiltUp")).Text = Convert.ToDecimal(SaleableArea[j] * Convert.ToDecimal(0.092903)).ToString("#0.0000");

                ((TextBox)GridDetails.Rows[i].FindControl("txtSqmAgreementCarpet")).Text = Convert.ToDecimal(FlatAgreementCarpet[j] * Convert.ToDecimal(0.092903)).ToString("#0.0000");
                ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceSqmAgreementCarpet")).Text = Convert.ToDecimal(TerraceAgreementCarpet[j] * Convert.ToDecimal(0.092903)).ToString("#0.0000");

                ((TextBox)GridDetails.Rows[i].FindControl("txtFlatSqmAgreementBuiltUp")).Text = Convert.ToDecimal(FlatAgreementBuiltUp[j] * Convert.ToDecimal(0.092903)).ToString("#0.0000");
                ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceSqmAgreementBuiltUp")).Text = Convert.ToDecimal(TerraceAgreementBuiltUp[j] * Convert.ToDecimal(0.092903)).ToString("#0.0000");


                ((TextBox)GridDetails.Rows[i].FindControl("txtSqft")).Text = sqft[j].ToString();
                ((DropDownList)GridDetails.Rows[i].FindControl("ddlFlatType")).SelectedValue = FlatType[j].ToString();
                ((DropDownList)GridDetails.Rows[i].FindControl("ddlFacingType")).SelectedValue = FacingType[j].ToString();
                ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAreaSaleCarpet")).Text = TerraceArea[j].ToString();
                ((TextBox)GridDetails.Rows[i].FindControl("txtGardenAreaSaleCarpet")).Text = GardenArea[j].ToString();
                ((TextBox)GridDetails.Rows[i].FindControl("txtCarpetAreaSaleCarpet")).Text = CarpetArea[j].ToString();

                ((TextBox)GridDetails.Rows[i].FindControl("txtSqftSaleBuiltUp")).Text = SqftSaleBuiltUp[j].ToString();
                ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAreaSaleBuiltUp")).Text = TerraceAreaSaleBuiltUp[j].ToString();
                ((TextBox)GridDetails.Rows[i].FindControl("txtGardenAreaSaleBuiltUp")).Text = GardenAreaSaleBuiltUp[j].ToString();
                ((TextBox)GridDetails.Rows[i].FindControl("txtSaleableAreaSaleBuiltUp")).Text = SaleableArea[j].ToString();

                ((TextBox)GridDetails.Rows[i].FindControl("txtFlatAgreementCarpet")).Text = FlatAgreementCarpet[j].ToString();
                ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAgreementCarpet")).Text = TerraceAgreementCarpet[j].ToString();

                ((TextBox)GridDetails.Rows[i].FindControl("txtFlatAgreementBuiltUp")).Text = FlatAgreementBuiltUp[j].ToString();
                ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAgreementBuiltUp")).Text = TerraceAgreementBuiltUp[j].ToString();
             
                j++;
                if (j == k)
                {
                    j = 0;
                }

                //if (c % 2 == 0)
                //{
                //    if (j < k)
                //    {
                //        ((TextBox)GridDetails.Rows[i].FindControl("txtSqft")).Text = sqftEven[j].ToString();
                //        ((DropDownList)GridDetails.Rows[i].FindControl("ddlFlatType")).SelectedValue = FlatTypeEven[j].ToString();
                //        ((DropDownList)GridDetails.Rows[i].FindControl("ddlFacingType")).SelectedValue = FacingTypeEven[j].ToString();
                //        ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceArea")).Text = TerraceAreaEven[j].ToString();
                //        ((TextBox)GridDetails.Rows[i].FindControl("txtGardenArea")).Text = GardenAreaEven[j].ToString();
                //        ((TextBox)GridDetails.Rows[i].FindControl("txtSaleableArea")).Text = SaleableAreaEven[j].ToString();
                //        j++;
                //        if (j == k)
                //        {
                //            c++;
                //            j = 0;
                //        }
                //    }

                //}
                //else
                //{
                //    if (j < k)
                //    {
                //        ((TextBox)GridDetails.Rows[i].FindControl("txtSqft")).Text = sqft[j].ToString();
                //        ((DropDownList)GridDetails.Rows[i].FindControl("ddlFlatType")).SelectedValue = FlatType[j].ToString();
                //        ((DropDownList)GridDetails.Rows[i].FindControl("ddlFacingType")).SelectedValue = FacingType[j].ToString();
                //        ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceArea")).Text = TerraceArea[j].ToString();
                //        ((TextBox)GridDetails.Rows[i].FindControl("txtGardenArea")).Text = GardenArea[j].ToString();
                //        ((TextBox)GridDetails.Rows[i].FindControl("txtSaleableArea")).Text = SaleableArea[j].ToString();
                //        j++;
                //        if (j == k)
                //        {
                //            c++;
                //            j = 0;
                //        }

                //    }

                //}

            }
      
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CalSubTotalNew1", "CalSubTotalNew();", true);
        }
       
        }

    protected void ApplyToEvenOdd_Click(object sender, ImageClickEventArgs e)
    {
        if (GridDetails.Rows.Count > 0)
        {
            int k = Convert.ToInt32(((Label)GridDetails.Rows[0].FindControl("lblUnit")).Text);
            int j = 0, z = 0;
            int c = 1;
            decimal[] sqft = new decimal[50];
            decimal[] sqftEven = new decimal[50];
            decimal[] TerraceArea = new decimal[50];
            decimal[] TerraceAreaEven = new decimal[50];
            decimal[] GardenArea = new decimal[50];
            decimal[] GardenAreaEven = new decimal[50];

            decimal[] CarpetArea = new decimal[50];
            decimal[] CarpetAreaEven = new decimal[50];

            decimal[] SqftSaleBuiltUp = new decimal[50];
            decimal[] SqftSaleBuiltUpEven = new decimal[50];
            decimal[] TerraceAreaSaleBuiltUp = new decimal[50];
            decimal[] TerraceAreaSaleBuiltUpEven = new decimal[50];
            decimal[] GardenAreaSaleBuiltUp = new decimal[50];
            decimal[] GardenAreaSaleBuiltUpEven = new decimal[50];
            decimal[] SaleableArea = new decimal[50];
            decimal[] SaleableAreaEven = new decimal[50];

            decimal[] FlatAgreementCarpet = new decimal[50];
            decimal[] FlatAgreementCarpetEven = new decimal[50];
            decimal[] TerraceAgreementCarpet = new decimal[50];
            decimal[] TerraceAgreementCarpetEven = new decimal[50];

            decimal[] FlatAgreementBuiltUp = new decimal[50];
            decimal[] FlatAgreementBuiltUpEven = new decimal[50];
            decimal[] TerraceAgreementBuiltUp = new decimal[50];
            decimal[] TerraceAgreementBuiltUpEven = new decimal[50];

            int[] FlatType = new int[50];
            int[] FlatTypeEven = new int[50];
            int[] FacingType = new int[50];
            int[] FacingTypeEven = new int[50];


            for (int i = 0; i < k; i++)
            {
                sqft[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtSqft")).Text);
                FlatType[i] = Convert.ToInt32(((DropDownList)GridDetails.Rows[i].FindControl("ddlFlatType")).SelectedValue);
                FacingType[i] = Convert.ToInt32(((DropDownList)GridDetails.Rows[i].FindControl("ddlFacingType")).SelectedValue);
                TerraceArea[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAreaSaleCarpet")).Text);
                GardenArea[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtGardenAreaSaleCarpet")).Text);
                CarpetArea[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtCarpetAreaSaleCarpet")).Text);

                SqftSaleBuiltUp[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtSqftSaleBuiltUp")).Text);
                TerraceAreaSaleBuiltUp[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAreaSaleBuiltUp")).Text);
                GardenAreaSaleBuiltUp[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtGardenAreaSaleBuiltUp")).Text);
                SaleableArea[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtSaleableAreaSaleBuiltUp")).Text);

                FlatAgreementCarpet[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtFlatAgreementCarpet")).Text);
                TerraceAgreementCarpet[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAgreementCarpet")).Text);

                FlatAgreementBuiltUp[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtFlatAgreementBuiltUp")).Text);
                TerraceAgreementBuiltUp[i] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAgreementBuiltUp")).Text);

            }
            for (int i = k; i < k + k; i++)
            {
                sqftEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtSqft")).Text);
                FlatTypeEven[z] = Convert.ToInt32(((DropDownList)GridDetails.Rows[i].FindControl("ddlFlatType")).SelectedValue);
                FacingTypeEven[z] = Convert.ToInt32(((DropDownList)GridDetails.Rows[i].FindControl("ddlFacingType")).SelectedValue);
                TerraceAreaEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAreaSaleCarpet")).Text);
                GardenAreaEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtGardenAreaSaleCarpet")).Text);
                SaleableAreaEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtSaleableAreaSaleBuiltUp")).Text);
                CarpetAreaEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtCarpetAreaSaleCarpet")).Text);

                SqftSaleBuiltUpEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtSqftSaleBuiltUp")).Text);
                TerraceAreaSaleBuiltUpEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAreaSaleBuiltUp")).Text);
                GardenAreaSaleBuiltUpEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtGardenAreaSaleBuiltUp")).Text);
                SaleableAreaEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtSaleableAreaSaleBuiltUp")).Text);

                FlatAgreementCarpetEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtFlatAgreementCarpet")).Text);
                TerraceAgreementCarpetEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAgreementCarpet")).Text);

                FlatAgreementBuiltUpEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtFlatAgreementBuiltUp")).Text);
                TerraceAgreementBuiltUpEven[z] = Convert.ToDecimal(((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAgreementBuiltUp")).Text);

                z++;
            }

            for (int i = 0; i < GridDetails.Rows.Count; i++)
            {

                //((TextBox)GridDetails.Rows[i].FindControl("txtSqft")).Text = sqft[j].ToString();

                //((TextBox)GridDetails.Rows[i].FindControl("txtSqm")).Text =Convert.ToDecimal(sqft[j] * Convert.ToDecimal(0.092903)).ToString("#0.00");
                //((TextBox)GridDetails.Rows[i].FindControl("txtTerraceSqm")).Text = Convert.ToDecimal(TerraceArea[j] * Convert.ToDecimal(0.092903)).ToString("#0.00");
                //((TextBox)GridDetails.Rows[i].FindControl("txtGardenSqm")).Text = Convert.ToDecimal(GardenArea[j] * Convert.ToDecimal(0.092903)).ToString("#0.00");
                //((TextBox)GridDetails.Rows[i].FindControl("txtCarpetSqm")).Text = Convert.ToDecimal(CarpetArea[j] * Convert.ToDecimal(0.092903)).ToString("#0.00");
                //((TextBox)GridDetails.Rows[i].FindControl("txtSaleableSqm")).Text = Convert.ToDecimal(SaleableArea[j] * Convert.ToDecimal(0.092903)).ToString("#0.00");

                //((DropDownList)GridDetails.Rows[i].FindControl("ddlFlatType")).SelectedValue = FlatType[j].ToString();
                //((DropDownList)GridDetails.Rows[i].FindControl("ddlFacingType")).SelectedValue = FacingType[j].ToString();
                //((TextBox)GridDetails.Rows[i].FindControl("txtTerraceArea")).Text = TerraceArea[j].ToString();
                //((TextBox)GridDetails.Rows[i].FindControl("txtGardenArea")).Text = GardenArea[j].ToString();
                //((TextBox)GridDetails.Rows[i].FindControl("txtSaleableArea")).Text = SaleableArea[j].ToString();
                //((TextBox)GridDetails.Rows[i].FindControl("txtCarpetArea")).Text = CarpetArea[j].ToString();
                //j++;
                //if (j == k)
                //{
                //    j = 0;
                //}

                if (c % 2 == 0)
                {
                    if (j < k)
                    {


                        ((TextBox)GridDetails.Rows[i].FindControl("txtSqft")).Text = sqftEven[j].ToString();
                        ((DropDownList)GridDetails.Rows[i].FindControl("ddlFlatType")).SelectedValue = FlatTypeEven[j].ToString();
                        ((DropDownList)GridDetails.Rows[i].FindControl("ddlFacingType")).SelectedValue = FacingTypeEven[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAreaSaleCarpet")).Text = TerraceAreaEven[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtGardenAreaSaleCarpet")).Text = GardenAreaEven[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtCarpetAreaSaleCarpet")).Text = CarpetAreaEven[j].ToString();

                        ((TextBox)GridDetails.Rows[i].FindControl("txtSqftSaleBuiltUp")).Text = SqftSaleBuiltUpEven[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAreaSaleBuiltUp")).Text = TerraceAreaSaleBuiltUpEven[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtGardenAreaSaleBuiltUp")).Text = GardenAreaSaleBuiltUpEven[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtSaleableAreaSaleBuiltUp")).Text = SaleableAreaEven[j].ToString();

                        ((TextBox)GridDetails.Rows[i].FindControl("txtFlatAgreementCarpet")).Text = FlatAgreementCarpetEven[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAgreementCarpet")).Text = TerraceAgreementCarpetEven[j].ToString();

                        ((TextBox)GridDetails.Rows[i].FindControl("txtFlatAgreementBuiltUp")).Text = FlatAgreementBuiltUpEven[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAgreementBuiltUp")).Text = TerraceAgreementBuiltUpEven[j].ToString();
             

                        j++;
                        if (j == k)
                        {
                            c++;
                            j = 0;
                        }
                    }

                }
                else
                {
                    if (j < k)
                    {
                        ((TextBox)GridDetails.Rows[i].FindControl("txtSqft")).Text = sqft[j].ToString();
                        ((DropDownList)GridDetails.Rows[i].FindControl("ddlFlatType")).SelectedValue = FlatType[j].ToString();
                        ((DropDownList)GridDetails.Rows[i].FindControl("ddlFacingType")).SelectedValue = FacingType[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAreaSaleCarpet")).Text = TerraceArea[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtGardenAreaSaleCarpet")).Text = GardenArea[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtCarpetAreaSaleCarpet")).Text = CarpetArea[j].ToString();

                        ((TextBox)GridDetails.Rows[i].FindControl("txtSqftSaleBuiltUp")).Text = SqftSaleBuiltUp[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAreaSaleBuiltUp")).Text = TerraceAreaSaleBuiltUp[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtGardenAreaSaleBuiltUp")).Text = GardenAreaSaleBuiltUp[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtSaleableAreaSaleBuiltUp")).Text = SaleableArea[j].ToString();

                        ((TextBox)GridDetails.Rows[i].FindControl("txtFlatAgreementCarpet")).Text = FlatAgreementCarpet[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAgreementCarpet")).Text = TerraceAgreementCarpet[j].ToString();

                        ((TextBox)GridDetails.Rows[i].FindControl("txtFlatAgreementBuiltUp")).Text = FlatAgreementBuiltUp[j].ToString();
                        ((TextBox)GridDetails.Rows[i].FindControl("txtTerraceAgreementBuiltUp")).Text = TerraceAgreementBuiltUp[j].ToString();

                        j++;
                        if (j == k)
                        {
                            c++;
                            j = 0;
                        }

                    }

                }

            }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "CalSubTotal", " CalSubTotal();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CalSubTotalNew", " CalSubTotalNew();", true);
        }
    }

    protected void GridCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (ViewState["CompanyTable"] != null)
            {
                int id = e.RowIndex;
                DataTable dt = (DataTable)ViewState["CompanyTable"];
                dt.Rows.RemoveAt(id);
                if (dt.Rows.Count > 0)
                {
                    GridCompany.DataSource = dt;
                    GridCompany.DataBind();
                    ViewState["CompanyTable"] = dt;
                }
                else
                {
                    SetInitialCompanyRow();
                }
                
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    protected void GridAmenities_DataBound(object sender, EventArgs e)
    {
        //=========For Merge the Row In to Single Section=================
        for (int rowIndex = GridAmenities.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = GridAmenities.Rows[rowIndex];
            GridViewRow gvPreviousRow = GridAmenities.Rows[rowIndex + 1];
            TextBox txtRow = (TextBox)GridAmenities.Rows[rowIndex].Cells[2].FindControl("GrtxtTermCondition_Head");
            TextBox txtPreviousRow = (TextBox)GridAmenities.Rows[rowIndex + 1].Cells[2].FindControl("GrtxtTermCondition_Head");
            if (txtRow.Text == txtPreviousRow.Text)
            {
                if (gvPreviousRow.Cells[2].RowSpan < 2)
                {
                    gvRow.Cells[2].RowSpan = 2;
                }
                else
                {
                    gvRow.Cells[2].RowSpan =
                        gvPreviousRow.Cells[2].RowSpan + 1;
                }
                gvPreviousRow.Cells[2].Visible = false;
              
            }
            //}
        }
        //=========For Merge the Row In to Single Section=================
    }

    protected void ddlProjectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ProjectTypeID = Convert.ToInt32(ddlProjectType.SelectedValue);
        DataSet Ds = new DataSet();
        Ds = Obj_PC.GetFlatType(ProjectTypeID, out StrError);

        if (Ds.Tables.Count > 0)
        {
            if (Ds.Tables[0].Rows.Count > 0)
            {
                ViewState["ddlFlatType"] = Ds.Tables[0];
              
            }
            if (Ds.Tables[1].Rows.Count > 0)
            {
                ddlProjectSubtype.DataSource = Ds.Tables[1];
                ddlProjectSubtype.DataTextField = "ProjectSubType";
                ddlProjectSubtype.DataValueField = "ProjectSubTypeId";
                ddlProjectSubtype.DataBind();
            }
        }
    }

    protected void GridSpecific_DataBound(object sender, EventArgs e)
    {
        //=========For Merge the Row In to Single Section=================
        for (int rowIndex = GridSpecific.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = GridSpecific.Rows[rowIndex];
            GridViewRow gvPreviousRow = GridSpecific.Rows[rowIndex + 1];
            // for (int cellCount = 0; cellCount < gvRow.Cells.Count;cellCount++)
            //{
            TextBox txtRow = (TextBox)GridSpecific.Rows[rowIndex].Cells[2].FindControl("GrtxtTermCondition_Head");
            TextBox txtPreviousRow = (TextBox)GridSpecific.Rows[rowIndex + 1].Cells[2].FindControl("GrtxtTermCondition_Head");
            if (txtRow.Text == txtPreviousRow.Text)
            {
                if (gvPreviousRow.Cells[2].RowSpan < 2)
                {
                    gvRow.Cells[2].RowSpan = 2;
                }
                else
                {
                    gvRow.Cells[2].RowSpan =
                        gvPreviousRow.Cells[2].RowSpan + 1;
                }
                gvPreviousRow.Cells[2].Visible = false;
            }
            //}
        }
        //=========For Merge the Row In to Single Section=================
    }

    protected void btnClone_Click(object sender, EventArgs e)
    {
        try
        {
            if (CountTower())
            {
                DataTable dt = (DataTable)ViewState["MainDetail"];
                DataTable dtnew = dt.Copy();
                dtnew.Clear();
                string Name = ddlClone.SelectedItem.Text.Trim();
               
                    for (int i = 0; i < GridMainDetail.Rows.Count; i++)
                    {
                        Label TowerName = (Label)GridMainDetail.Rows[i].Cells[0].FindControl("lblTowerName1");
                        if (Name == TowerName.Text) //Set Dt for Selected Tower Name
                        {
                            DataRow dr = dtnew.NewRow();
                            Label FlatNo = (Label)GridMainDetail.Rows[i].Cells[2].FindControl("lblFlatNo1");
                            TextBox Sqft = (TextBox)GridMainDetail.Rows[i].Cells[3].FindControl("txtSqft1");
                            DropDownList ddlFlatType = (DropDownList)GridMainDetail.Rows[i].Cells[15].FindControl("ddlFlatType1");
                            Label Floor = (Label)GridMainDetail.Rows[i].Cells[16].FindControl("lblFloor1");
                            Label Unit = (Label)GridMainDetail.Rows[i].Cells[17].FindControl("lblUnit1");
                            TextBox TerraceArea = (TextBox)GridMainDetail.Rows[i].Cells[4].FindControl("txtTerraceAreaSaleCarpet1");
                            TextBox GardenArea = (TextBox)GridMainDetail.Rows[i].Cells[5].FindControl("txtGardenAreaSaleCarpet1");
                            TextBox TotalCarpetArea = (TextBox)GridMainDetail.Rows[i].Cells[6].FindControl("txtCarpetAreaSaleCarpet1");
                           
                        TextBox txtSqftSaleBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[7].FindControl("txtSqftSaleBuiltUp1");
                        TextBox txtTerraceAreaSaleBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[8].FindControl("txtTerraceAreaSaleBuiltUp1");
                        TextBox txtGardenAreaSaleBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[9].FindControl("txtGardenAreaSaleBuiltUp1");
                        TextBox SaleableArea = (TextBox)GridMainDetail.Rows[i].Cells[10].FindControl("txtSaleableAreaSaleBuiltUp1");

                        TextBox txtFlatAgreementCarpet = (TextBox)GridMainDetail.Rows[i].Cells[11].FindControl("txtFlatAgreementCarpet1");
                        TextBox txtTerraceAgreementCarpet = (TextBox)GridMainDetail.Rows[i].Cells[12].FindControl("txtTerraceAgreementCarpet1");

                        TextBox txtFlatAgreementBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[13].FindControl("txtFlatAgreementBuiltUp1");
                        TextBox txtTerraceAgreementBuiltUp = (TextBox)GridMainDetail.Rows[i].Cells[14].FindControl("txtTerraceAgreementBuiltUp1");
                            
                         DropDownList ddlFacingType = (DropDownList)GridMainDetail.Rows[i].Cells[18].FindControl("ddlFacingType1");

                         TextBox txtTerracePer = (TextBox)GridMainDetail.Rows[i].Cells[21].FindControl("txtTerracePer1");
                         TextBox txtGardenPer = (TextBox)GridMainDetail.Rows[i].Cells[22].FindControl("txtGardenPer1");

                            //txtSubTotal.Text = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(SaleableArea.Text)).ToString();
                            //For txtSubTotal
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "CalSubTotalNew", " CalSubTotalNew();", true);


                            dr["Sqft"] = !string.IsNullOrEmpty(Sqft.Text) ? Convert.ToDecimal(Sqft.Text) : 0;
                            string removeString = TowerName.Text.Trim();
                            int index = FlatNo.Text.IndexOf(removeString);
                            int length = removeString.Length;
                            String startOfString = FlatNo.Text.Substring(0, index);
                            String endOfString = FlatNo.Text.Substring(index + length);
                            String cleanPath = startOfString + endOfString;

            dr["FlatNo"] = Convert.ToString(txtTowerName.Text + cleanPath);
            dr["TowerName"] = Convert.ToString(txtTowerName.Text);
            dr["FlatTypeId"] = ddlFlatType.SelectedValue;
            dr["Floor"] = Floor.Text;
            dr["Unit"] = Unit.Text;
            dr["FacingTypeId"] = ddlFacingType.SelectedValue;
            dr["CarpetArea"] = !string.IsNullOrEmpty(TotalCarpetArea.Text) ? Convert.ToDecimal(TotalCarpetArea.Text) : 0;
            dr["TerraceArea"] = !string.IsNullOrEmpty(TerraceArea.Text) ? Convert.ToDecimal(TerraceArea.Text) : 0;
            dr["GardenArea"] = !string.IsNullOrEmpty(GardenArea.Text) ? Convert.ToDecimal(GardenArea.Text) : 0;

            dr["SqftSaleBuiltUp"] = !string.IsNullOrEmpty(txtSqftSaleBuiltUp.Text) ? Convert.ToDecimal(txtSqftSaleBuiltUp.Text) : 0;
            dr["TerraceAreaSaleBuiltUp"] = !string.IsNullOrEmpty(txtTerraceAreaSaleBuiltUp.Text) ? Convert.ToDecimal(txtTerraceAreaSaleBuiltUp.Text) : 0;
            dr["GardenAreaSaleBuiltUp"] = !string.IsNullOrEmpty(txtGardenAreaSaleBuiltUp.Text) ? Convert.ToDecimal(txtGardenAreaSaleBuiltUp.Text) : 0;
            dr["SaleableArea"] = !string.IsNullOrEmpty(SaleableArea.Text) ? Convert.ToDecimal(SaleableArea.Text) : 0;

            dr["AgreementCarpetFlat"] = !string.IsNullOrEmpty(txtFlatAgreementCarpet.Text) ? Convert.ToDecimal(txtFlatAgreementCarpet.Text) : 0;
            dr["AgreementCarpetTerrace"] = !string.IsNullOrEmpty(txtTerraceAgreementCarpet.Text) ? Convert.ToDecimal(txtTerraceAgreementCarpet.Text) : 0;

            dr["AgreementBuiltUpFlat"] = !string.IsNullOrEmpty(txtFlatAgreementBuiltUp.Text) ? Convert.ToDecimal(txtFlatAgreementBuiltUp.Text) : 0;
            dr["AgreementBuiltUpTerrace"] = !string.IsNullOrEmpty(txtTerraceAgreementBuiltUp.Text) ? Convert.ToDecimal(txtTerraceAgreementBuiltUp.Text) : 0;

           dr["FloorNo"] = !string.IsNullOrEmpty(GridMainDetail.Rows[i].Cells[20].Text)? Convert.ToInt32(GridMainDetail.Rows[i].Cells[20].Text):0;

           dr["TerracePer"] = !string.IsNullOrEmpty(txtTerracePer.Text) ? Convert.ToDecimal(txtTerracePer.Text) : 0;
           dr["GardenPer"] = !string.IsNullOrEmpty(txtGardenPer.Text) ? Convert.ToDecimal(txtGardenPer.Text) : 0;
                            
                            dtnew.Rows.Add(dr);
                        }
                    }
                    ViewState["CurrentTable"] = dtnew;
                    GridDetails.DataSource = dtnew;
                    GridDetails.DataBind();
                    DivDetailGrid.Visible = true;
                    trAddGrid.Visible = true;

            }
            else
            {
                Obj_Comm.ShowPopUpMsg("Please Check Details", this.Page);
            }
        }
        catch (Exception Ex) { throw new Exception(Ex.Message); }
    }

    protected void lnkUploadDoc_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkUploadDoc = (LinkButton)sender;
            GridViewRow dr = (GridViewRow)lnkUploadDoc.Parent.Parent;

         
            //To Delete All Files In Direcotry===========
            string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("~/Images/Temp/"));
            foreach (string filePath in filePaths)
            System.IO.File.Delete(filePath);
            //To Delete All Files In Direcotry===========
            Random random = new Random();
            FileUpload FileUpload = ((FileUpload)dr.FindControl("FuUpload1"));
            Label lblImgPath = ((Label)dr.FindControl("lblImgPath"));

            if (FileUpload.HasFile)
            {
                dr.BackColor = System.Drawing.Color.LightSteelBlue;
                //--Total No of Files--
                Int64 TotalFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Images")).Count();

                string filename = System.IO.Path.GetFileName(FileUpload.FileName);
                filename = TotalFiles + "-" + filename;
                FileUpload.SaveAs(Server.MapPath("~/Images/Temp/") + filename);
                FileUpload.SaveAs(Server.MapPath("~/Images/ProjectImage/") + filename);
                lblImgPath.Text = "~/Images/ProjectImage/" + filename;
                //Add To image
               // AddtoGridLayout(filename);
              
            }

        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg("Upload status: The file could not be uploaded. The following error occured: " + ex.Message, this.Page);
        }
    }

    protected void lnkCancelDoc_Click(object sender, EventArgs e)
    {
        LinkButton lnkCancelDoc = (LinkButton)sender;
        GridViewRow dr = (GridViewRow)lnkCancelDoc.Parent.Parent;
        dr.BackColor = System.Drawing.Color.White;
        Label lblImgPath = ((Label)dr.FindControl("lblImgPath"));
        lblImgPath.Text = "";
    }

    protected void lnkUploadLayout_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkUploadDoc = (LinkButton)sender;
            GridViewRow dr = (GridViewRow)lnkUploadDoc.Parent.Parent;

          
            //To Delete All Files In Direcotry===========
            string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("~/Images/Temp/"));
            foreach (string filePath in filePaths)
                System.IO.File.Delete(filePath);
            //To Delete All Files In Direcotry===========
            Random random = new Random();
            FileUpload FileUpload = ((FileUpload)dr.FindControl("FuUpload2"));
            Label lblImgPath = ((Label)dr.FindControl("lblImgPath"));

            if (FileUpload.HasFile)
            {
                //--Total No of Files--
                Int64 TotalFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Images")).Count();

                string filename = System.IO.Path.GetFileName(FileUpload.FileName);
                filename = TotalFiles + "-" + filename;
                FileUpload.SaveAs(Server.MapPath("~/Images/Temp/") + filename);
                FileUpload.SaveAs(Server.MapPath("~/Images/ProjectImage/") + filename);
                lblImgPath.Text = "~/Images/ProjectImage/" + filename;
                //Add To image
                // AddtoGridLayout(filename);
                dr.BackColor = System.Drawing.Color.LawnGreen;

            }

        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg("Upload status: The file could not be uploaded. The following error occured: " + ex.Message, this.Page);
        }
    }
    protected void GridDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridView HeaderGrid1 = (GridView)sender;

            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            GridViewRow HeaderGridRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.CssClass = "Header";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.ForeColor = System.Drawing.Color.White;
         
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Areas for Sales Team";
            HeaderCell.CssClass = "Header";
            HeaderCell.ColumnSpan = 6;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Areas for Agreement";
            HeaderCell.CssClass = "Header";
            HeaderCell.ColumnSpan = 4;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.CssClass = "Header";
            HeaderCell.ColumnSpan = 4;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow.Cells.Add(HeaderCell);

            TableCell HeaderCell1 = new TableCell();
            HeaderCell1.Text = "";
            HeaderCell1.CssClass = "Header";
            HeaderCell1.ColumnSpan = 3;
            HeaderCell1.ForeColor = System.Drawing.Color.White;

            HeaderGridRow1.Cells.Add(HeaderCell1);

            HeaderCell1 = new TableCell();
            HeaderCell1.Text = "Carpet";
            HeaderCell1.CssClass = "Header";
            HeaderCell1.ColumnSpan = 3;
            HeaderCell1.ForeColor = System.Drawing.Color.White;
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow1.Cells.Add(HeaderCell1);

            HeaderCell1 = new TableCell();
            HeaderCell1.Text = "BuiltUp";
            HeaderCell1.CssClass = "Header";
            HeaderCell1.ColumnSpan = 3;
            HeaderCell1.ForeColor = System.Drawing.Color.White;
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow1.Cells.Add(HeaderCell1);

            HeaderCell1 = new TableCell();
            HeaderCell1.Text = "Carpet";
            HeaderCell1.CssClass = "Header";
            HeaderCell1.ColumnSpan = 2;
            HeaderCell1.ForeColor = System.Drawing.Color.White;
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow1.Cells.Add(HeaderCell1);

            HeaderCell1 = new TableCell();
            HeaderCell1.Text = "BuiltUp";
            HeaderCell1.CssClass = "Header";
            HeaderCell1.ColumnSpan = 2;
            HeaderCell1.ForeColor = System.Drawing.Color.White;
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow1.Cells.Add(HeaderCell1);

            HeaderCell1 = new TableCell();
            HeaderCell1.Text = "";
            HeaderCell1.CssClass = "Header";
            HeaderCell1.ColumnSpan = 4;
            HeaderCell1.ForeColor = System.Drawing.Color.White;
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow1.Cells.Add(HeaderCell1);

            GridDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);
            GridDetails.Controls[0].Controls.AddAt(1, HeaderGridRow1);
        }
    }
    protected void GridMainDetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridView HeaderGrid1 = (GridView)sender;
            GridView HeaderGrid2 = (GridView)sender;

            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            GridViewRow HeaderGridRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            GridViewRow HeaderGridRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.CssClass = "Header";
            HeaderCell.ColumnSpan = 4;
            HeaderCell.ForeColor = System.Drawing.Color.White;

            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Areas for Sales Team";
            HeaderCell.CssClass = "Header";
            HeaderCell.ColumnSpan = 6;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Areas for Agreement";
            HeaderCell.CssClass = "Header";
            HeaderCell.ColumnSpan = 4;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.CssClass = "Header";
            HeaderCell.ColumnSpan = 5;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow.Cells.Add(HeaderCell);

            TableCell HeaderCell1 = new TableCell();
            HeaderCell1.Text = "";
            HeaderCell1.CssClass = "Header";
            HeaderCell1.ColumnSpan = 4;
            HeaderCell1.ForeColor = System.Drawing.Color.White;

            HeaderGridRow1.Cells.Add(HeaderCell1);

            HeaderCell1 = new TableCell();
            HeaderCell1.Text = "Carpet";
            HeaderCell1.CssClass = "Header";
            HeaderCell1.ColumnSpan = 3;
            HeaderCell1.ForeColor = System.Drawing.Color.White;
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow1.Cells.Add(HeaderCell1);

            HeaderCell1 = new TableCell();
            HeaderCell1.Text = "BuiltUp";
            HeaderCell1.CssClass = "Header";
            HeaderCell1.ColumnSpan = 3;
            HeaderCell1.ForeColor = System.Drawing.Color.White;
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow1.Cells.Add(HeaderCell1);

            HeaderCell1 = new TableCell();
            HeaderCell1.Text = "Carpet";
            HeaderCell1.CssClass = "Header";
            HeaderCell1.ColumnSpan = 2;
            HeaderCell1.ForeColor = System.Drawing.Color.White;
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow1.Cells.Add(HeaderCell1);

            HeaderCell1 = new TableCell();
            HeaderCell1.Text = "BuiltUp";
            HeaderCell1.CssClass = "Header";
            HeaderCell1.ColumnSpan = 2;
            HeaderCell1.ForeColor = System.Drawing.Color.White;
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow1.Cells.Add(HeaderCell1);

            HeaderCell1 = new TableCell();
            HeaderCell1.Text = "";
            HeaderCell1.CssClass = "Header";
            HeaderCell1.ColumnSpan = 5;
            HeaderCell1.ForeColor = System.Drawing.Color.White;
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center;

            HeaderGridRow1.Cells.Add(HeaderCell1);


            GridMainDetail.Controls[0].Controls.AddAt(0, HeaderGridRow);
            GridMainDetail.Controls[0].Controls.AddAt(1, HeaderGridRow1);
        }
    }
    protected void RBType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBType.SelectedValue == "1")
        {
            trApply.Visible = false;

        }
        else
        {
            trApply.Visible = true;
        }
    }
}
