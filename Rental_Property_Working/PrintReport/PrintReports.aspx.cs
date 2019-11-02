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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Web;
using Build.Utility;
using Build.EntityClass;
using Build.DB;
using Build.DataModel;
using Build.DALSQLHelper;
using System.IO;
using System.Net;
using System.Diagnostics;
using iTextSharp;
using iTextSharp.text.pdf;
using System.Text;
using System.Threading;


using System.Globalization;

public partial class Reports_PrintReports : System.Web.UI.Page
{
    #region Private Variable

    DataSet DS = new DataSet();
    DataSet DS1 = new DataSet();
    DataTable DTNEW = new DataTable();
    ReportDocument CRpt = new ReportDocument();
    DMReport Obj_Report = new DMReport();
    DMProjectConfigurator Obj_PC = new DMProjectConfigurator();
  
    DMMISCustomerLedger Obj_CustomerLedger = new DMMISCustomerLedger();
 
    string Flag = "0";
    int PCID = 0;
    string strError = string.Empty;
    string StrCond = string.Empty;
    string CheckCondition = "";
    int ID = 0, LocationID = 0;
    public static int Print_Flag = 0;
    decimal DueAmountPayable = 0, DueTaxPayable = 0, DueAmountReceived = 0, DueServiceTaxReceived = 0;
    decimal TotalDuesPayable = 0, BalanceDuesPayable = 0, TotalDuesReceived = 0;
    string TTitle = "", Terms = "";
    #endregion

    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!Page.IsPostBack)
    //    {
    //        Print_Flag = 0;
    //        PrintReport();
    //    }
    //    else
    //    {
    //        Print_Flag = 1;
    //        PrintReport();
    //    }
    //}
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Print_Flag = 0;
            PrintReport();
        }
        else
        {
            Print_Flag = 1;
            PrintReport();
        }
    }

        #region Stages
    // private void UpdateBalance(DataTable dtReceipts)
    //{
    //    try
    //    {
    //        decimal TotalRcvdAmount = 0;
    //        decimal TotalRcvdServiceTax = 0;
    //        decimal BalTotalRcvdAmount = 0;
    //        decimal BalTotalRcvdServiceTax = 0;
            
    //        string lastDueDate;
    //        decimal diffBalAmt = 0;
    //        decimal diffSTAmt = 0;

    //        DataTable dtData = (DataTable)ViewState["UnitHolderData"];
    //        DataView dv = dtData.DefaultView;
    //        dv.Sort = "DueDateNew asc";
    //        dtData = dv.ToTable();
    //        if (dtData.Rows.Count > 0)
    //        {
    //            lastDueDate = DateTime.Parse((dtData.Rows[0]["BookingDate"].ToString())).ToString("dd MMM yyyy");
    //        }
    //        else
    //        {
    //            return;
    //        }

    //        #region ReceiptesExist
            
    //        for (int k = 0; k < dtReceipts.Rows.Count; k++)
    //        {
    //            TotalRcvdAmount = decimal.Parse(dtReceipts.Rows[k]["RcvdAmt"].ToString());
    //            TotalRcvdServiceTax = decimal.Parse(dtReceipts.Rows[k]["STRcvdAmt"].ToString());
    //            BalTotalRcvdAmount = TotalRcvdAmount;
    //            BalTotalRcvdServiceTax = TotalRcvdServiceTax;
                
    //            for (int i = 0; i < dtData.Rows.Count; i++)
    //            {
    //                if (dtData.Rows[i]["BalaceAmountDue"].ToString() == "0" && dtData.Rows[i]["BalanceServiceTaxDue"].ToString() == "0") //stage balances are adjusted
    //                {

    //                }
    //                else
    //                {
                        
    //                    BalTotalRcvdAmount = BalTotalRcvdAmount + decimal.Parse(dtData.Rows[i]["AmountReceived"].ToString());
    //                    BalTotalRcvdServiceTax = BalTotalRcvdServiceTax + decimal.Parse(dtData.Rows[i]["ServiceTaxReceived"].ToString());
                       
    //                    decimal DueAmt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
    //                    decimal curNewSTAmt = 0;
    //                    decimal prvSTAmt = 0;

    //                    diffBalAmt = DueAmt - decimal.Parse(dtData.Rows[i]["AmountReceived"].ToString());
    //                    #region PartPaymentLatest
    //                    if (BalTotalRcvdAmount == 0)
    //                    {
    //                        lastDueDate = DateTime.Now.ToString("dd MMM yyyy");
    //                    }
    //                    else
    //                    {
    //                        if (diffBalAmt > 0 && decimal.Parse((DueAmt - BalTotalRcvdAmount).ToString()) > 0)
    //                        {
    //                            lastDueDate = DateTime.Now.ToString("dd MMM yyyy");
    //                        }
    //                        else
    //                        {
    //                            lastDueDate = dtReceipts.Rows[k]["ReceiptDate"].ToString();
    //                        }
    //                    }
    //                    #endregion
    //                    DataSet dsTaxData = Obj_Report.GetLatestTaxDetails(int.Parse(dtData.Rows[i]["PCId"].ToString()),ID, DateTime.Parse(lastDueDate).ToString("dd MMM yyyy"), out strError);
    //                    //newly added by medha for part payment fin yr change
                        
    //                    if (dsTaxData.Tables[0].Rows.Count > 0) // Set Tax % according to Tax Master for Fin Yr wise ST Percentage
    //                    {
    //                        DataTable dtTaxData = dsTaxData.Tables[0];
    //                        if (dtTaxData.Rows.Count > 0)
    //                        {
    //                            dtData.Rows[i]["TaxFormatId"] = dtTaxData.Rows[0]["TaxFormatId"].ToString();
    //                            dtData.Rows[i]["ServiceTaxPercent"] = dtTaxData.Rows[0]["TaxAmount"];
    //                            if (dtTaxData.Rows[0]["TaxFormatId"].ToString() == "3") // if tax applicable is in %
    //                            {
    //                                //DueSt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
                                    
    //                                //****** below code added by medha for part payment *****
    //                                decimal DueSt = 0;
    //                                //curNewSTAmt = diffBalAmt / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
    //                               // DueSt = decimal.Parse(dtData.Rows[i]["ServiceTaxReceived"].ToString()) + curNewSTAmt;
    //                                curNewSTAmt = (decimal.Parse((DueAmt - BalTotalRcvdAmount).ToString())) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
    //                                DueSt = BalTotalRcvdServiceTax + curNewSTAmt;
    //                                dtData.Rows[i]["ServiceTaxDue"] = DueSt;


    //                                dtData.Rows[i]["ServiceTaxPercent"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
    //                               // dtData.Rows[i]["ServiceTaxDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
    //                                dtData.Rows[i]["ServiceTaxPercent"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
    //                                //Amount
    //                                if (BalTotalRcvdAmount > DueAmt)
    //                                {
    //                                    BalTotalRcvdAmount = BalTotalRcvdAmount - DueAmt;
    //                                    dtData.Rows[i]["AmountReceived"] = DueAmt;
    //                                    dtData.Rows[i]["BalaceAmountDue"] = 0;
    //                                }
    //                                else
    //                                {
    //                                    dtData.Rows[i]["AmountReceived"] = BalTotalRcvdAmount;
    //                                    dtData.Rows[i]["BalaceAmountDue"] = DueAmt - BalTotalRcvdAmount;
    //                                    BalTotalRcvdAmount = 0;
    //                                }

    //                                //Service Tax
    //                                if (BalTotalRcvdServiceTax > DueSt)
    //                                {
    //                                    BalTotalRcvdServiceTax = BalTotalRcvdServiceTax - DueSt;
    //                                    dtData.Rows[i]["ServiceTaxReceived"] = DueSt;
    //                                    dtData.Rows[i]["BalanceServiceTaxDue"] = 0;
    //                                }
    //                                else
    //                                {
    //                                    dtData.Rows[i]["ServiceTaxReceived"] = BalTotalRcvdServiceTax;
    //                                    dtData.Rows[i]["BalanceServiceTaxDue"] = DueSt - BalTotalRcvdServiceTax;
    //                                    BalTotalRcvdServiceTax = 0;
    //                                }
    //                            }
    //                            else
    //                            {
    //                                dtData.Rows[i]["ServiceTaxDue"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
    //                            }
    //                        }
    //                        else
    //                        {
    //                            dtData.Rows[i]["ServiceTaxPercent"] = 0;
    //                            dtData.Rows[i]["ServiceTaxDue"] = 0;
    //                            dtData.Rows[i]["AmountReceived"] = 0;
    //                            dtData.Rows[i]["ServiceTaxReceived"] = 0;
    //                            dtData.Rows[i]["BalaceAmountDue"] = 0;
    //                            dtData.Rows[i]["BalanceServiceTaxDue"] = 0;
    //                        }
    //                    }
    //                    else //No Service Tax Present 
    //                    {
    //                        if (BalTotalRcvdAmount > DueAmt)
    //                        {
    //                            BalTotalRcvdAmount = BalTotalRcvdAmount - DueAmt;
    //                            dtData.Rows[i]["AmountReceived"] = DueAmt;
    //                            dtData.Rows[i]["BalaceAmountDue"] = 0;
    //                        }
    //                        else
    //                        {
    //                            dtData.Rows[i]["AmountReceived"] = BalTotalRcvdAmount;
    //                            dtData.Rows[i]["BalaceAmountDue"] = DueAmt - BalTotalRcvdAmount;
    //                            BalTotalRcvdAmount = 0;
    //                        }

    //                    }
    //                    dtData.Rows[i]["Percentage"] = dtData.Rows[i]["Percentage"].ToString();
    //                    //if (BalTotalRcvdAmount=0 || BalTotalRcvdServiceTax=0)
    //                    //{
    //                    //    break;
    //                    //}
    //                }
    //            } // end of for receipts

    //            //DataView dv1 = dtData.DefaultView;
    //            //dv1.Sort = "DispOrder asc";
    //            //dtData = dv1.ToTable();

    //            //ViewState["UnitHolderData"] = dtData;

    //        } // end for dtdata
    //        DataView dv1 = dtData.DefaultView;
    //        dv1.Sort = "DispOrder asc";
    //        dtData = dv1.ToTable();

    //        ViewState["UnitHolderData"] = dtData;
    //        #endregion

    //        #region ReceiptNotExists
    //        if (dtReceipts.Rows.Count == 0)
    //        {
    //            lastDueDate = DateTime.Now.ToString("dd MMM yyyy");
    //            for (int i = 0; i < dtData.Rows.Count; i++)
    //            {
    //                if (dtData.Rows[i]["BalaceAmountDue"].ToString() == "0" && dtData.Rows[i]["BalanceServiceTaxDue"].ToString() == "0")
    //                {

    //                }
    //                else
    //                {
    //                    BalTotalRcvdAmount = BalTotalRcvdAmount + decimal.Parse(dtData.Rows[i]["AmountReceived"].ToString());
    //                    BalTotalRcvdServiceTax = BalTotalRcvdServiceTax + decimal.Parse(dtData.Rows[i]["ServiceTaxReceived"].ToString());

    //                    DataSet dsTaxData = Obj_Report.GetLatestTaxDetails(int.Parse(dtData.Rows[i]["PCId"].ToString()), ID, DateTime.Parse(lastDueDate).ToString("dd MMM yyyy"), out strError);
    //                    decimal DueAmt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
    //                    if (dsTaxData.Tables[0].Rows.Count > 0) //Set Tax % according to Tax Master for Fin Yr wise ST Percentage
    //                    {
    //                        DataTable dtTaxData = dsTaxData.Tables[0];
    //                        if (dtTaxData.Rows.Count > 0)
    //                        {
    //                            dtData.Rows[i]["TaxFormatId"] = dtTaxData.Rows[0]["TaxFormatId"].ToString();
    //                            dtData.Rows[i]["ServiceTaxPercent"] = dtTaxData.Rows[0]["TaxAmount"];

    //                            if (dtTaxData.Rows[0]["TaxFormatId"].ToString() == "3") // if tax applicable is in %
    //                            {
    //                                dtData.Rows[i]["ServiceTaxPercent"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());

    //                                decimal DueSt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
                                    

    //                                dtData.Rows[i]["ServiceTaxDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
    //                                dtData.Rows[i]["ServiceTaxPercent"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
    //                                dtData.Rows[i]["BalaceAmountDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
    //                                dtData.Rows[i]["BalanceServiceTaxDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString()); 
                                   
    //                            }
    //                            else
    //                            {
    //                                dtData.Rows[i]["ServiceTaxDue"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
    //                            }
    //                        }
    //                        else
    //                        {
    //                            dtData.Rows[i]["ServiceTaxPercent"] = 0;
    //                            dtData.Rows[i]["ServiceTaxDue"] = 0;
    //                            dtData.Rows[i]["AmountReceived"] = 0;
    //                            dtData.Rows[i]["ServiceTaxReceived"] = 0;
    //                            dtData.Rows[i]["BalaceAmountDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) ;
    //                            dtData.Rows[i]["BalanceServiceTaxDue"] = 0;
    //                        }
    //                    }
    //                    else //No Service Tax Present 
    //                    {
    //                        if (BalTotalRcvdAmount > DueAmt)
    //                        {
    //                            BalTotalRcvdAmount = BalTotalRcvdAmount - DueAmt;
    //                            dtData.Rows[i]["AmountReceived"] = DueAmt;
    //                            dtData.Rows[i]["BalaceAmountDue"] = 0;
    //                        }
    //                        else
    //                        {
    //                            dtData.Rows[i]["AmountReceived"] = BalTotalRcvdAmount;
    //                            dtData.Rows[i]["BalaceAmountDue"] = DueAmt - BalTotalRcvdAmount;
    //                            BalTotalRcvdAmount = 0;
    //                        }

    //                    }
    //                    dtData.Rows[i]["Percentage"] = dtData.Rows[i]["Percentage"].ToString();
    //                    //if (BalTotalRcvdAmount=0 || BalTotalRcvdServiceTax=0)
    //                    //{
    //                    //    break;
    //                    //}
    //                }
    //            }
    //            ViewState["UnitHolderData"] = dtData;
    //        }
    //        #endregion
    //    }
    //    catch (Exception exp)
    //    {
    //        throw new Exception(exp.Message);
    //    }
    //}

    // private void GenerateTempTableForUnitHolderStages()
    //{
    //    try 
    //    {
    //        DataTable dtUnitHolder=(DataTable)ViewState["UnitHolderData"] ;

    //        DataSet ds=Obj_Report.GetDataForUnitHolderPrint(ID,PCID, out strError);

    //        string lastDueDate = string.Empty;
    //        if (ds.Tables.Count>0)
    //        {
    //            DataTable dtData = ds.Tables[0];

    //            for (int i = 0; i < dtData.Rows.Count; i++)
    //            {
    //                DataRow drUnitHldr = dtUnitHolder.NewRow();
    //                drUnitHldr["PCId"] = dtData.Rows[i]["PCId"];
    //                drUnitHldr["BookingId"] = dtData.Rows[i]["BookingId"];
    //                drUnitHldr["BookingDate"] = dtData.Rows[i]["BookingDate"];
                    
    //                drUnitHldr["DueDate"] = dtData.Rows[i]["BookingDueDate"].ToString();

    //                if (dtData.Rows[i]["BookingDueDate"].ToString() == "1 Jan 53")
    //                {
    //                    drUnitHldr["DueDateNew"] = DateTime.Parse("31 Dec 9999");
    //                }
    //                else
    //                {

    //                    drUnitHldr["DueDateNew"] = dtData.Rows[i]["BookingDueDate"].ToString();
    //                }

    //                drUnitHldr["TaxFormatId"] = 0;
    //                drUnitHldr["Ind"] = dtData.Rows[i]["Ind"].ToString(); ;
    //                drUnitHldr["ServiceTaxPercent"] = 0;
    //                drUnitHldr["PaymentScheduleAmount"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmt"].ToString());
    //                drUnitHldr["ServiceTaxDue"] = 0;
    //                drUnitHldr["StageId"] = dtData.Rows[i]["StageId"].ToString();
    //                drUnitHldr["StageDesc"] = dtData.Rows[i]["StageDesc"].ToString();
    //                drUnitHldr["Percentage"] = dtData.Rows[i]["Percentage"].ToString();
    //                drUnitHldr["AmountReceived"] = 0;
    //                drUnitHldr["ServiceTaxReceived"] = 0;
    //                drUnitHldr["BalaceAmountDue"] = -1;
    //                drUnitHldr["BalanceServiceTaxDue"] = -1;
    //                drUnitHldr["DispOrder"] = decimal.Parse(dtData.Rows[i]["DispOrder"].ToString());
    //                dtUnitHolder.Rows.Add(drUnitHldr);
    //            }
    //            ViewState["UnitHolderData"] = dtUnitHolder;
    //            UpdateBalance((DataTable)ds.Tables[2]);
    //           }
    //       }
    //    catch (Exception exp)
    //    {
    //        throw new Exception(exp.Message);
    //    }
    //}
    #endregion Stage

        //#region Charges
        //private void GenerateTempTableForUnitHolderCharges()
        //{
        //    try
        //    {
        //        DataTable dtUnitHolder = (DataTable)ViewState["UnitHolderDataCharges"];


        //        DataSet ds = Obj_Report.GetDataForUnitHolderPrint(ID, PCID, out strError);
        //        string lastDueDate = string.Empty;
        //        if (ds.Tables.Count > 0 && ds.Tables[3].Rows.Count>0)
        //        {
        //            DataTable dtData = ds.Tables[3];

        //            for (int i = 0; i < dtData.Rows.Count; i++)
        //            {
        //                DataRow drUnitHldr = dtUnitHolder.NewRow();
        //                drUnitHldr["PCId"] = dtData.Rows[i]["PCId"];
        //                drUnitHldr["BookingId"] = dtData.Rows[i]["BookingId"];
        //                drUnitHldr["BookingDate"] = dtData.Rows[i]["BookingDate"];
        //                drUnitHldr["DueDate"] = dtData.Rows[i]["BookingDueDate"].ToString();

        //                if (dtData.Rows[i]["BookingDueDate"].ToString() == "1 Jan 53")
        //                {
        //                    drUnitHldr["DueDateNew"] = "31 Dec 9999";
        //                }
        //                else
        //                {

        //                    drUnitHldr["DueDateNew"] = dtData.Rows[i]["BookingDueDate"].ToString();
        //                }


        //                drUnitHldr["TaxFormatId"] = 0;
        //                drUnitHldr["Ind"] = dtData.Rows[i]["Ind"].ToString(); ;
        //                drUnitHldr["ServiceTaxPercent"] = 0;
        //                drUnitHldr["PaymentScheduleAmount"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmt"].ToString());
        //                drUnitHldr["ServiceTaxDue"] = 0;
        //                drUnitHldr["StageId"] = dtData.Rows[i]["StageId"].ToString();
        //                drUnitHldr["StageDesc"] = dtData.Rows[i]["StageDesc"].ToString();
        //                drUnitHldr["Percentage"] = dtData.Rows[i]["Percentage"].ToString();
        //                drUnitHldr["AmountReceived"] = 0;
        //                drUnitHldr["ServiceTaxReceived"] = 0;
        //                drUnitHldr["BalaceAmountDue"] = -1;
        //                drUnitHldr["BalanceServiceTaxDue"] = -1;
        //                dtUnitHolder.Rows.Add(drUnitHldr);
        //            }
        //        }
        //        ViewState["UnitHolderDataCharges"] = dtUnitHolder;

        //        UpdateBalanceCharges((DataTable)ds.Tables[4]);
        //    }
        //    catch(Exception exp)
        //    {
        //        throw new Exception(exp.Message);
        //    }

        //}

        ////private void UpdateBalanceCharges(DataTable dtReceiptsCharges)
        ////{
        ////    try
        ////    {
        ////        decimal TotalRcvdAmount = 0;
        ////        decimal TotalRcvdServiceTax = 0;
        ////        decimal BalTotalRcvdAmount = 0;
        ////        decimal BalTotalRcvdServiceTax = 0;
        ////        string lastDueDate;
        ////        decimal diffBalAmt = 0;
        ////        decimal diffSTAmt = 0;

        ////        DMReport dmr = new DMReport();

        ////        DataTable dtData = (DataTable)ViewState["UnitHolderDataCharges"];
        ////        //Comment By Sushma On 11 NOV
        ////        //DataView dv = dtData.DefaultView;
        ////        //dv.Sort = "DueDateNew asc";
        ////        //dtData = dv.ToTable();

        ////        if (dtData.Rows.Count > 0)
        ////        {
        ////            lastDueDate = DateTime.Parse((dtData.Rows[0]["BookingDate"].ToString())).ToString("dd MMM yyyy");
        ////        }
        ////        else
        ////        {
        ////            return;
        ////        }
               

        ////        #region ReceiptesExist

        ////        for (int k = 0; k < dtReceiptsCharges.Rows.Count; k++)
        ////        {
        ////            TotalRcvdAmount = decimal.Parse(dtReceiptsCharges.Rows[k]["RcvdAmt"].ToString());
        ////            TotalRcvdServiceTax = decimal.Parse(dtReceiptsCharges.Rows[k]["STRcvdAmt"].ToString());
        ////            BalTotalRcvdAmount = TotalRcvdAmount;
        ////            BalTotalRcvdServiceTax = TotalRcvdServiceTax;

        ////            for (int i = 0; i < dtData.Rows.Count; i++)
        ////            {
        ////                if (dtData.Rows[i]["BalaceAmountDue"].ToString() == "0" && dtData.Rows[i]["BalanceServiceTaxDue"].ToString() == "0")
        ////                {

        ////                }
        ////                else
        ////                {
        ////                    BalTotalRcvdAmount = BalTotalRcvdAmount + decimal.Parse(dtData.Rows[i]["AmountReceived"].ToString());
        ////                    BalTotalRcvdServiceTax = BalTotalRcvdServiceTax + decimal.Parse(dtData.Rows[i]["ServiceTaxReceived"].ToString());

        ////                    decimal DueAmt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
        ////                    decimal curNewSTAmt = 0;
        ////                    decimal prvSTAmt = 0;
        ////                    diffBalAmt = DueAmt - decimal.Parse(dtData.Rows[i]["AmountReceived"].ToString());

                            
        ////                    #region PartPaymentLatest
        ////                    if (BalTotalRcvdAmount == 0)
        ////                    {
        ////                        lastDueDate = DateTime.Now.ToString("dd MMM yyyy");
        ////                    }
        ////                    else
        ////                    {
        ////                        if (diffBalAmt > 0 && decimal.Parse((DueAmt - BalTotalRcvdAmount).ToString()) > 0)
        ////                        {
        ////                            lastDueDate = DateTime.Now.ToString("dd MMM yyyy");
        ////                        }
        ////                        else
        ////                        {
        ////                            lastDueDate = dtReceiptsCharges.Rows[k]["ReceiptDate"].ToString();
        ////                        }
        ////                    }
        ////                    #endregion
        ////                    DataSet dsTaxData = Obj_Report.GetLatestTaxDetails(int.Parse(dtData.Rows[i]["PCId"].ToString()), ID, DateTime.Parse(lastDueDate).ToString("dd MMM yyyy"), out strError);

        ////                    //decimal DueAmt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
                          
        ////                    //newly added by medha for part payment fin yr change
                            
        ////                    if (dsTaxData.Tables[0].Rows.Count > 0) //Set Tax % according to Tax Master for Fin Yr wise ST Percentage
        ////                    {
        ////                        DataTable dtTaxData = dsTaxData.Tables[0];
        ////                        if (dtTaxData.Rows.Count > 0)
        ////                        {
        ////                            dtData.Rows[i]["TaxFormatId"] = dtTaxData.Rows[0]["TaxFormatId"].ToString();
        ////                            dtData.Rows[i]["ServiceTaxPercent"] = dtTaxData.Rows[0]["TaxAmount"];

        ////                            if (dtTaxData.Rows[0]["TaxFormatId"].ToString() == "3") // if tax applicable is in %
        ////                            {
        ////                                dtData.Rows[i]["ServiceTaxPercent"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());

        ////                               // decimal DueSt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        ////                                //dtData.Rows[i]["ServiceTaxDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
                                        
        ////                                //****** below code added by medha for part payment *****
        ////                                decimal DueSt = 0;
        ////                                //curNewSTAmt = diffBalAmt / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        ////                                // DueSt = decimal.Parse(dtData.Rows[i]["ServiceTaxReceived"].ToString()) + curNewSTAmt;
        ////                                curNewSTAmt = (decimal.Parse((DueAmt - BalTotalRcvdAmount).ToString())) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        ////                                DueSt = BalTotalRcvdServiceTax + curNewSTAmt;
        ////                                dtData.Rows[i]["ServiceTaxDue"] = DueSt;

        ////                                dtData.Rows[i]["ServiceTaxPercent"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        ////                                //Amount
        ////                                if (BalTotalRcvdAmount > DueAmt)
        ////                                {
        ////                                    BalTotalRcvdAmount = BalTotalRcvdAmount - DueAmt;
        ////                                    dtData.Rows[i]["AmountReceived"] = DueAmt;
        ////                                    dtData.Rows[i]["BalaceAmountDue"] = 0;
        ////                                }
        ////                                else
        ////                                {
        ////                                    dtData.Rows[i]["AmountReceived"] = BalTotalRcvdAmount;
        ////                                    dtData.Rows[i]["BalaceAmountDue"] = DueAmt - BalTotalRcvdAmount;
        ////                                    BalTotalRcvdAmount = 0;
        ////                                }

        ////                                //Service Tax
        ////                                if (BalTotalRcvdServiceTax > DueSt)
        ////                                {
        ////                                    BalTotalRcvdServiceTax = BalTotalRcvdServiceTax - DueSt;
        ////                                    dtData.Rows[i]["ServiceTaxReceived"] = DueSt;
        ////                                    dtData.Rows[i]["BalanceServiceTaxDue"] = 0;
        ////                                }
        ////                                else
        ////                                {
        ////                                    dtData.Rows[i]["ServiceTaxReceived"] = BalTotalRcvdServiceTax;
        ////                                    dtData.Rows[i]["BalanceServiceTaxDue"] = DueSt - BalTotalRcvdServiceTax;
        ////                                    BalTotalRcvdServiceTax = 0;
        ////                                }
        ////                            }
        ////                            else
        ////                            {
        ////                                dtData.Rows[i]["ServiceTaxDue"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        ////                                dtData.Rows[i]["BalanceServiceTaxDue"] = 0;
        ////                                dtData.Rows[i]["ServiceTaxReceived"] = 0;
        ////                            }
        ////                        }
        ////                        else
        ////                        {
        ////                            dtData.Rows[i]["ServiceTaxPercent"] = 0;
        ////                            dtData.Rows[i]["ServiceTaxDue"] = 0;
        ////                            dtData.Rows[i]["AmountReceived"] = 0;
        ////                            dtData.Rows[i]["ServiceTaxReceived"] = 0;
        ////                            dtData.Rows[i]["BalaceAmountDue"] = 0;
        ////                            dtData.Rows[i]["BalanceServiceTaxDue"] = 0;
        ////                        }
        ////                    }
        ////                    else //No Service Tax Present 
        ////                    {
        ////                        if (BalTotalRcvdAmount > DueAmt)
        ////                        {
        ////                            BalTotalRcvdAmount = BalTotalRcvdAmount - DueAmt;
        ////                            dtData.Rows[i]["AmountReceived"] = DueAmt;
        ////                            dtData.Rows[i]["BalaceAmountDue"] = 0;
        ////                        }
        ////                        else
        ////                        {
        ////                            dtData.Rows[i]["AmountReceived"] = BalTotalRcvdAmount;
        ////                            dtData.Rows[i]["BalaceAmountDue"] = DueAmt - BalTotalRcvdAmount;
        ////                            BalTotalRcvdAmount = 0;
        ////                        }

        ////                    }
        ////                    dtData.Rows[i]["Percentage"] = dtData.Rows[i]["Percentage"].ToString();
        ////                    //if (BalTotalRcvdAmount=0 || BalTotalRcvdServiceTax=0)
        ////                    //{
        ////                    //    break;
        ////                    //}
        ////                }
        ////            } // end of for receipts

        ////            ViewState["UnitHolderDataCharges"] = dtData;

        ////        } // end for dtdata

        ////        #endregion

        ////        #region ReceiptNotExists
        ////        if (dtReceiptsCharges.Rows.Count == 0)
        ////        {
        ////            lastDueDate = DateTime.Now.ToString("dd MMM yyyy");//--added by Medha Mam 23Sep2014
        ////            for (int i = 0; i < dtData.Rows.Count; i++)
        ////            {
        ////                if (dtData.Rows[i]["BalaceAmountDue"].ToString() == "0" && dtData.Rows[i]["BalanceServiceTaxDue"].ToString() == "0")
        ////                {

        ////                }
        ////                else
        ////                {
        ////                    BalTotalRcvdAmount = BalTotalRcvdAmount + decimal.Parse(dtData.Rows[i]["AmountReceived"].ToString());
        ////                    BalTotalRcvdServiceTax = BalTotalRcvdServiceTax + decimal.Parse(dtData.Rows[i]["ServiceTaxReceived"].ToString());

        ////                    DataSet dsTaxData = Obj_Report.GetLatestTaxDetails(int.Parse(dtData.Rows[i]["PCId"].ToString()), ID, DateTime.Parse(lastDueDate).ToString("dd MMM yyyy"), out strError);
        ////                    decimal DueAmt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
        ////                    if (dsTaxData.Tables[0].Rows.Count > 0) //Set Tax % according to Tax Master for Fin Yr wise ST Percentage
        ////                    {
        ////                        DataTable dtTaxData = dsTaxData.Tables[0];
        ////                        if (dtTaxData.Rows.Count > 0)
        ////                        {
        ////                            dtData.Rows[i]["TaxFormatId"] = dtTaxData.Rows[0]["TaxFormatId"].ToString();
        ////                            dtData.Rows[i]["ServiceTaxPercent"] = dtTaxData.Rows[0]["TaxAmount"];

        ////                            if (dtTaxData.Rows[0]["TaxFormatId"].ToString() == "3") // if tax applicable is in %
        ////                            {
        ////                                dtData.Rows[i]["ServiceTaxPercent"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());

        ////                                decimal DueSt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
                                        

        ////                                dtData.Rows[i]["ServiceTaxDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        ////                                dtData.Rows[i]["ServiceTaxPercent"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        ////                                dtData.Rows[i]["BalaceAmountDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
        ////                                dtData.Rows[i]["BalanceServiceTaxDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());

        ////                            }
        ////                            else
        ////                            {
        ////                                dtData.Rows[i]["ServiceTaxDue"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        ////                            }
        ////                        }
        ////                        else
        ////                        {
        ////                            dtData.Rows[i]["ServiceTaxPercent"] = 0;
        ////                            dtData.Rows[i]["ServiceTaxDue"] = 0;
        ////                            dtData.Rows[i]["AmountReceived"] = 0;
        ////                            dtData.Rows[i]["ServiceTaxReceived"] = 0;
        ////                            dtData.Rows[i]["BalaceAmountDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
        ////                            dtData.Rows[i]["BalanceServiceTaxDue"] = 0;
        ////                        }
        ////                    }
        ////                    else //No Service Tax Present 
        ////                    {
        ////                        if (BalTotalRcvdAmount > DueAmt)
        ////                        {
        ////                            BalTotalRcvdAmount = BalTotalRcvdAmount - DueAmt;
        ////                            dtData.Rows[i]["AmountReceived"] = DueAmt;
        ////                            dtData.Rows[i]["BalaceAmountDue"] = 0;
        ////                        }
        ////                        else
        ////                        {
        ////                            dtData.Rows[i]["AmountReceived"] = BalTotalRcvdAmount;
        ////                            dtData.Rows[i]["BalaceAmountDue"] = DueAmt - BalTotalRcvdAmount;
        ////                            BalTotalRcvdAmount = 0;
        ////                        }

        ////                    }
        ////                    dtData.Rows[i]["Percentage"] = dtData.Rows[i]["Percentage"].ToString();
        ////                    //if (BalTotalRcvdAmount=0 || BalTotalRcvdServiceTax=0)
        ////                    //{
        ////                    //    break;
        ////                    //}
        ////                }
        ////            }
        ////            ViewState["UnitHolderDataCharges"] = dtData;
        ////        }
        ////        #endregion
        ////    }
        ////    catch (Exception exp)
        ////    {
        ////        throw new Exception(exp.Message);
        ////    }
        ////}

        //private void UpdateBalanceCharges(DataTable dtReceiptsCharges)
        //{
        //    try
        //    {
        //        decimal TotalRcvdAmount = 0;
        //        decimal TotalRcvdServiceTax = 0;
        //        decimal BalTotalRcvdAmount = 0;
        //        decimal BalTotalRcvdServiceTax = 0;
        //        string lastDueDate;
        //        decimal diffBalAmt = 0;
        //        decimal diffSTAmt = 0;

        //        DMReport dmr = new DMReport();

        //        DataTable dtData = (DataTable)ViewState["UnitHolderDataCharges"];

        //        //DataView dv = dtData.DefaultView;
        //        //dv.Sort = "DueDateNew asc";
        //        //dtData = dv.ToTable();

        //        if (dtData.Rows.Count > 0)
        //        {
        //            lastDueDate = DateTime.Parse((dtData.Rows[0]["BookingDate"].ToString())).ToString("dd MMM yyyy");
        //        }
        //        else
        //        {
        //            return;
        //        }


        //        #region ReceiptesExist

        //        for (int k = 0; k < dtReceiptsCharges.Rows.Count; k++)
        //        {
        //            TotalRcvdAmount = decimal.Parse(dtReceiptsCharges.Rows[k]["RcvdAmt"].ToString());
        //            TotalRcvdServiceTax = decimal.Parse(dtReceiptsCharges.Rows[k]["STRcvdAmt"].ToString());
        //            BalTotalRcvdAmount = TotalRcvdAmount;
        //            BalTotalRcvdServiceTax = TotalRcvdServiceTax;

        //            for (int i = 0; i < dtData.Rows.Count; i++)
        //            {
        //                if (dtData.Rows[i]["BalaceAmountDue"].ToString() == "0" && dtData.Rows[i]["BalanceServiceTaxDue"].ToString() == "0")
        //                {

        //                }
        //                else
        //                {
        //                    if (dtReceiptsCharges.Rows[k]["ChargeId"].ToString() == dtData.Rows[i]["StageId"].ToString())
        //                    {
        //                        #region AdjustAmounts


        //                        BalTotalRcvdAmount = BalTotalRcvdAmount + decimal.Parse(dtData.Rows[i]["AmountReceived"].ToString());
        //                        BalTotalRcvdServiceTax = BalTotalRcvdServiceTax + decimal.Parse(dtData.Rows[i]["ServiceTaxReceived"].ToString());

        //                        decimal DueAmt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
        //                        decimal curNewSTAmt = 0;
        //                        decimal prvSTAmt = 0;
        //                        diffBalAmt = DueAmt - decimal.Parse(dtData.Rows[i]["AmountReceived"].ToString());


        //                        #region PartPaymentLatest
        //                        if (BalTotalRcvdAmount == 0)
        //                        {
        //                            lastDueDate = DateTime.Now.ToString("dd MMM yyyy");
        //                        }
        //                        else
        //                        {
        //                            if (diffBalAmt > 0 && decimal.Parse((DueAmt - BalTotalRcvdAmount).ToString()) > 0)
        //                            {
        //                                lastDueDate = DateTime.Now.ToString("dd MMM yyyy");
        //                            }
        //                            else
        //                            {
        //                                lastDueDate = dtReceiptsCharges.Rows[k]["ReceiptDate"].ToString();
        //                            }
        //                        }
        //                        #endregion
        //                        DataSet dsTaxData = Obj_Report.GetLatestTaxDetails(int.Parse(dtData.Rows[i]["PCId"].ToString()), ID, DateTime.Parse(lastDueDate).ToString("dd MMM yyyy"), out strError);

        //                        //decimal DueAmt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());

        //                        //newly added by medha for part payment fin yr change

        //                        if (dsTaxData.Tables[0].Rows.Count > 0) //Set Tax % according to Tax Master for Fin Yr wise ST Percentage
        //                        {
        //                            DataTable dtTaxData = dsTaxData.Tables[0];
        //                            if (dtTaxData.Rows.Count > 0)
        //                            {
        //                                dtData.Rows[i]["TaxFormatId"] = dtTaxData.Rows[0]["TaxFormatId"].ToString();
        //                                dtData.Rows[i]["ServiceTaxPercent"] = dtTaxData.Rows[0]["TaxAmount"];

        //                                if (dtTaxData.Rows[0]["TaxFormatId"].ToString() == "3") // if tax applicable is in %
        //                                {
        //                                    dtData.Rows[i]["ServiceTaxPercent"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());

        //                                    // decimal DueSt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        //                                    //dtData.Rows[i]["ServiceTaxDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());

        //                                    //****** below code added by medha for part payment *****
        //                                    decimal DueSt = 0;
        //                                    //curNewSTAmt = diffBalAmt / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        //                                    // DueSt = decimal.Parse(dtData.Rows[i]["ServiceTaxReceived"].ToString()) + curNewSTAmt;
        //                                    curNewSTAmt = (decimal.Parse((DueAmt - BalTotalRcvdAmount).ToString())) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        //                                    DueSt = BalTotalRcvdServiceTax + curNewSTAmt;
        //                                    dtData.Rows[i]["ServiceTaxDue"] = DueSt;

        //                                    dtData.Rows[i]["ServiceTaxPercent"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        //                                    //Amount
        //                                    if (BalTotalRcvdAmount > DueAmt)
        //                                    {
        //                                        BalTotalRcvdAmount = BalTotalRcvdAmount - DueAmt;
        //                                        dtData.Rows[i]["AmountReceived"] = DueAmt;
        //                                        dtData.Rows[i]["BalaceAmountDue"] = 0;
        //                                    }
        //                                    else
        //                                    {
        //                                        dtData.Rows[i]["AmountReceived"] = BalTotalRcvdAmount;
        //                                        dtData.Rows[i]["BalaceAmountDue"] = DueAmt - BalTotalRcvdAmount;
        //                                        BalTotalRcvdAmount = 0;
        //                                    }

        //                                    //Service Tax
        //                                    if (BalTotalRcvdServiceTax > DueSt)
        //                                    {
        //                                        BalTotalRcvdServiceTax = BalTotalRcvdServiceTax - DueSt;
        //                                        dtData.Rows[i]["ServiceTaxReceived"] = DueSt;
        //                                        dtData.Rows[i]["BalanceServiceTaxDue"] = 0;
        //                                    }
        //                                    else
        //                                    {
        //                                        dtData.Rows[i]["ServiceTaxReceived"] = BalTotalRcvdServiceTax;
        //                                        dtData.Rows[i]["BalanceServiceTaxDue"] = DueSt - BalTotalRcvdServiceTax;
        //                                        BalTotalRcvdServiceTax = 0;
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    dtData.Rows[i]["ServiceTaxDue"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        //                                    dtData.Rows[i]["BalanceServiceTaxDue"] = 0;
        //                                    dtData.Rows[i]["ServiceTaxReceived"] = 0;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                dtData.Rows[i]["ServiceTaxPercent"] = 0;
        //                                dtData.Rows[i]["ServiceTaxDue"] = 0;
        //                                dtData.Rows[i]["AmountReceived"] = 0;
        //                                dtData.Rows[i]["ServiceTaxReceived"] = 0;
        //                                dtData.Rows[i]["BalaceAmountDue"] = 0;
        //                                dtData.Rows[i]["BalanceServiceTaxDue"] = 0;
        //                            }
        //                        }
        //                        else //No Service Tax Present 
        //                        {
        //                            if (BalTotalRcvdAmount > DueAmt)
        //                            {
        //                                BalTotalRcvdAmount = BalTotalRcvdAmount - DueAmt;
        //                                dtData.Rows[i]["AmountReceived"] = DueAmt;
        //                                dtData.Rows[i]["BalaceAmountDue"] = 0;
        //                            }
        //                            else
        //                            {
        //                                dtData.Rows[i]["AmountReceived"] = BalTotalRcvdAmount;
        //                                dtData.Rows[i]["BalaceAmountDue"] = DueAmt - BalTotalRcvdAmount;
        //                                BalTotalRcvdAmount = 0;
        //                            }

        //                        }
        //                        dtData.Rows[i]["Percentage"] = dtData.Rows[i]["Percentage"].ToString();
        //                        //if (BalTotalRcvdAmount=0 || BalTotalRcvdServiceTax=0)
        //                        //{
        //                        //    break;
        //                        //}
        //                        #endregion
        //                    }

        //                }
        //            } // end of for receipts

        //            ViewState["UnitHolderDataCharges"] = dtData;

        //        } // end for dtdata

        //        #endregion

        //        #region ReceiptNotExists
        //        if (dtReceiptsCharges.Rows.Count == 0)
        //        {
        //            lastDueDate = DateTime.Now.ToString("dd MMM yyyy");//--added by Medha Mam 23Sep2014
        //            for (int i = 0; i < dtData.Rows.Count; i++)
        //            {
        //                if (dtData.Rows[i]["BalaceAmountDue"].ToString() == "0" && dtData.Rows[i]["BalanceServiceTaxDue"].ToString() == "0")
        //                {

        //                }
        //                else
        //                {
        //                    BalTotalRcvdAmount = BalTotalRcvdAmount + decimal.Parse(dtData.Rows[i]["AmountReceived"].ToString());
        //                    BalTotalRcvdServiceTax = BalTotalRcvdServiceTax + decimal.Parse(dtData.Rows[i]["ServiceTaxReceived"].ToString());

        //                    DataSet dsTaxData = Obj_Report.GetLatestTaxDetails(int.Parse(dtData.Rows[i]["PCId"].ToString()), ID, DateTime.Parse(lastDueDate).ToString("dd MMM yyyy"), out strError);
        //                    decimal DueAmt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
        //                    if (dsTaxData.Tables[0].Rows.Count > 0) //Set Tax % according to Tax Master for Fin Yr wise ST Percentage
        //                    {
        //                        DataTable dtTaxData = dsTaxData.Tables[0];
        //                        if (dtTaxData.Rows.Count > 0)
        //                        {
        //                            dtData.Rows[i]["TaxFormatId"] = dtTaxData.Rows[0]["TaxFormatId"].ToString();
        //                            dtData.Rows[i]["ServiceTaxPercent"] = dtTaxData.Rows[0]["TaxAmount"];

        //                            if (dtTaxData.Rows[0]["TaxFormatId"].ToString() == "3") // if tax applicable is in %
        //                            {
        //                                dtData.Rows[i]["ServiceTaxPercent"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());

        //                                decimal DueSt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());


        //                                dtData.Rows[i]["ServiceTaxDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        //                                dtData.Rows[i]["ServiceTaxPercent"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        //                                dtData.Rows[i]["BalaceAmountDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
        //                                dtData.Rows[i]["BalanceServiceTaxDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString()) / 100 * decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());

        //                            }
        //                            else
        //                            {
        //                                dtData.Rows[i]["ServiceTaxDue"] = decimal.Parse(dtTaxData.Rows[0]["TaxAmount"].ToString());
        //                            }
        //                        }
        //                        else
        //                        {
        //                            dtData.Rows[i]["ServiceTaxPercent"] = 0;
        //                            dtData.Rows[i]["ServiceTaxDue"] = 0;
        //                            dtData.Rows[i]["AmountReceived"] = 0;
        //                            dtData.Rows[i]["ServiceTaxReceived"] = 0;
        //                            dtData.Rows[i]["BalaceAmountDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
        //                            dtData.Rows[i]["BalanceServiceTaxDue"] = 0;
        //                        }
        //                    }
        //                    else //No Service Tax Present 
        //                    {
        //                        if (BalTotalRcvdAmount > DueAmt)
        //                        {
        //                            BalTotalRcvdAmount = BalTotalRcvdAmount - DueAmt;
        //                            dtData.Rows[i]["AmountReceived"] = DueAmt;
        //                            dtData.Rows[i]["BalaceAmountDue"] = 0;
        //                        }
        //                        else
        //                        {
        //                            dtData.Rows[i]["AmountReceived"] = BalTotalRcvdAmount;
        //                            dtData.Rows[i]["BalaceAmountDue"] = DueAmt - BalTotalRcvdAmount;
        //                            BalTotalRcvdAmount = 0;
        //                        }

        //                    }
        //                    dtData.Rows[i]["Percentage"] = dtData.Rows[i]["Percentage"].ToString();
        //                    //if (BalTotalRcvdAmount=0 || BalTotalRcvdServiceTax=0)
        //                    //{
        //                    //    break;
        //                    //}
        //                }
        //            }
        //            ViewState["UnitHolderDataCharges"] = dtData;
        //        }
        //        #endregion

        //        for (int i = 0; i < dtData.Rows.Count; i++)
        //        {
        //            if (dtData.Rows[i]["BalaceAmountDue"].ToString() == "-1")//                                    dtData.Rows[i]["BalanceServiceTaxDue"] = 0;)
        //            {
        //                dtData.Rows[i]["BalaceAmountDue"] = "0";
        //            }
        //            if (dtData.Rows[i]["BalanceServiceTaxDue"].ToString() == "-1")//                                    dtData.Rows[i]["BalanceServiceTaxDue"] = 0;)
        //            {
        //                dtData.Rows[i]["BalanceServiceTaxDue"] = "0";
        //            }
        //        }
        //        ViewState["UnitHolderDataCharges"] = dtData;
        //    }
        //    catch (Exception exp)
        //    {
        //        throw new Exception(exp.Message);
        //    }
        //}

        //#endregion

        //#region Taxes

        //private void GenerateTempTableForUnitHolderTaxes()
        //{
        //    try
        //    {
        //        DataTable dtUnitHolder = (DataTable)ViewState["UnitHolderDataTaxes"];

        //        DataSet ds = Obj_Report.GetDataForUnitHolderPrint(ID, PCID, out strError);
        //        string lastDueDate = string.Empty;
        //        if (ds.Tables.Count > 0 && ds.Tables[5].Rows.Count > 0)
        //        {
        //            DataTable dtData = ds.Tables[7];

        //            for (int i = 0; i < dtData.Rows.Count; i++)
        //            {
        //                DataRow drUnitHldr = dtUnitHolder.NewRow();
        //                drUnitHldr["PCId"] = dtData.Rows[i]["PCId"];
        //                drUnitHldr["BookingId"] = dtData.Rows[i]["BookingId"];
        //                drUnitHldr["BookingDate"] = dtData.Rows[i]["BookingDate"];
        //                drUnitHldr["DueDate"] = dtData.Rows[i]["BookingDueDate"].ToString();
        //                if (dtData.Rows[i]["BookingDueDate"].ToString() == "1 Jan 53" || dtData.Rows[i]["BookingDueDate"].ToString()=="")
        //                {
        //                    drUnitHldr["DueDateNew"] = "31 Dec 9999";
        //                }
        //                else
        //                {
        //                    drUnitHldr["DueDateNew"] = dtData.Rows[i]["BookingDueDate"].ToString();
        //                }

                        
        //                drUnitHldr["TaxFormatId"] = 0;
        //                drUnitHldr["Ind"] = dtData.Rows[i]["Ind"].ToString(); ;
        //                drUnitHldr["ServiceTaxPercent"] = 0;
        //                drUnitHldr["PaymentScheduleAmount"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmt"].ToString());
        //                drUnitHldr["ServiceTaxDue"] = 0;
        //                drUnitHldr["StageId"] = dtData.Rows[i]["StageId"].ToString();
        //                drUnitHldr["StageDesc"] = dtData.Rows[i]["StageDesc"].ToString();
        //                drUnitHldr["Percentage"] = dtData.Rows[i]["Percentage"].ToString();
        //                drUnitHldr["AmountReceived"] = dtData.Rows[i]["RcvdAmt"].ToString(); 
        //                drUnitHldr["ServiceTaxReceived"] = 0;
        //                drUnitHldr["BalaceAmountDue"] = dtData.Rows[i]["BalanceAmt"].ToString(); 
        //                drUnitHldr["BalanceServiceTaxDue"] = 0;
        //                dtUnitHolder.Rows.Add(drUnitHldr);
        //            }
        //        }
        //        ViewState["UnitHolderDataTaxes"] = dtUnitHolder;

        //        //UpdateBalanceTaxes((DataTable)ds.Tables[6]);
        //    }
        //    catch (Exception exp)
        //    {
        //        throw new Exception(exp.Message);
        //    }

        //}

        //private void UpdateBalanceTaxes(DataTable dtReceiptsCharges)
        //{
        //    try
        //    {
        //        decimal TotalRcvdAmount = 0;
        //        decimal TotalRcvdServiceTax = 0;
        //        decimal BalTotalRcvdAmount = 0;
        //        decimal BalTotalRcvdServiceTax = 0;
        //        string lastDueDate;
        //        DMReport dmr = new DMReport();

        //        DataTable dtData = (DataTable)ViewState["UnitHolderDataTaxes"];
        //        //Comment By Sushma On 11 NOV
        //        //DataView dv = dtData.DefaultView;
        //        //dv.Sort = "DueDateNew asc";
        //        //dtData = dv.ToTable();
        //        if (dtData.Rows.Count > 0)
        //        {
        //            lastDueDate = DateTime.Parse((dtData.Rows[0]["BookingDate"].ToString())).ToString("dd MMM yyyy");
        //        }
        //        else
        //        {
        //            return;
        //        }


        //        #region ReceiptesExist

        //        for (int k = 0; k < dtReceiptsCharges.Rows.Count; k++)
        //        {
        //            TotalRcvdAmount = decimal.Parse(dtReceiptsCharges.Rows[k]["RcvdAmt"].ToString());
        //            TotalRcvdServiceTax = decimal.Parse(dtReceiptsCharges.Rows[k]["STRcvdAmt"].ToString());
        //            BalTotalRcvdAmount = TotalRcvdAmount;
        //            BalTotalRcvdServiceTax = TotalRcvdServiceTax;

        //            for (int i = 0; i < dtData.Rows.Count; i++)
        //            {
        //                if (dtData.Rows[i]["BalaceAmountDue"].ToString() == "0" && dtData.Rows[i]["BalanceServiceTaxDue"].ToString() == "0")
        //                {

        //                }
        //                else
        //                {
        //                    BalTotalRcvdAmount = BalTotalRcvdAmount + decimal.Parse(dtData.Rows[i]["AmountReceived"].ToString());
        //                    BalTotalRcvdServiceTax = BalTotalRcvdServiceTax + decimal.Parse(dtData.Rows[i]["ServiceTaxReceived"].ToString());

        //                    lastDueDate = dtReceiptsCharges.Rows[k]["ReceiptDate"].ToString();

        //                    decimal DueAmt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());

        //                    if (BalTotalRcvdAmount > DueAmt)
        //                    {
        //                        BalTotalRcvdAmount = BalTotalRcvdAmount - DueAmt;
        //                        dtData.Rows[i]["AmountReceived"] = DueAmt;
        //                        dtData.Rows[i]["BalaceAmountDue"] = 0;
        //                    }
        //                    else
        //                    {
        //                        dtData.Rows[i]["AmountReceived"] = BalTotalRcvdAmount;
        //                        dtData.Rows[i]["BalaceAmountDue"] = DueAmt - BalTotalRcvdAmount;
        //                        BalTotalRcvdAmount = 0;
        //                    }
        //                    dtData.Rows[i]["ServiceTaxPercent"] = 0;
        //                    dtData.Rows[i]["ServiceTaxDue"] = 0;
        //                    dtData.Rows[i]["ServiceTaxReceived"] = 0;
                           
        //                    dtData.Rows[i]["BalanceServiceTaxDue"] = 0;
        //                    dtData.Rows[i]["Percentage"] = dtData.Rows[i]["Percentage"].ToString();
        //                    //if (BalTotalRcvdAmount=0 || BalTotalRcvdServiceTax=0)
        //                    //{
        //                    //    break;
        //                    //}
        //                }
        //            } // end of for receipts

        //            ViewState["UnitHolderDataTaxes"] = dtData;

        //        } // end for dtdata
        //        //Comment By Sushma On 11 NOV
        //        //DataView dv1 = dtData.DefaultView;
        //        //dv1.Sort = "DispOrder asc";
        //        //dtData = dv1.ToTable();
        //        #endregion

        //        #region ReceiptNotExists
        //        if (dtReceiptsCharges.Rows.Count == 0)
        //        {
        //            for (int i = 0; i < dtData.Rows.Count; i++)
        //            {
        //                if (dtData.Rows[i]["BalaceAmountDue"].ToString() == "0" && dtData.Rows[i]["BalanceServiceTaxDue"].ToString() == "0")
        //                {

        //                }
        //                else
        //                {
        //                    BalTotalRcvdAmount = BalTotalRcvdAmount + decimal.Parse(dtData.Rows[i]["AmountReceived"].ToString());
        //                    decimal DueAmt = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
        //                    dtData.Rows[i]["BalaceAmountDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
        //                    dtData.Rows[i]["ServiceTaxPercent"] = 0;
        //                    dtData.Rows[i]["ServiceTaxDue"] = 0;
        //                    dtData.Rows[i]["AmountReceived"] = 0;
        //                    dtData.Rows[i]["ServiceTaxReceived"] = 0;
        //                    dtData.Rows[i]["BalaceAmountDue"] = decimal.Parse(dtData.Rows[i]["PaymentScheduleAmount"].ToString());
        //                    dtData.Rows[i]["BalanceServiceTaxDue"] = 0;
        //                }
                            
                            
        //              } //end for
        //        }
        //        ViewState["UnitHolderDataTaxes"] = dtData;
        //        #endregion

        //    }
        //    catch (Exception exp)
        //    {
        //        throw new Exception(exp.Message);
        //    }
        //}

        //#endregion


    private void PrintReport()
    {
        try
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Flag"]))
            {
                #region [Page Title]
                Flag = Convert.ToString(Request.QueryString["Flag"]);
                
                if (Flag.Contains("ReceiptMaster"))
                {
                    CheckCondition = "ReceiptMaster";
                    this.Page.Title = "Print-Receipt";
                }
                if (Flag.Contains("ExpOutReceipt"))
                {
                    CheckCondition = "ExpOutReceipt";
                    this.Page.Title = "Print-ExpOutReceipt";
                }

                if (Flag.Contains("DL"))
                {
                    CheckCondition = "DemandLetter";
                    this.Page.Title = "Print-DemandLetter";
                }
                if (Flag.Contains("PC"))
                {
                    CheckCondition = "ProjectCOnfigurator";
                    this.Page.Title = "Print-Project";
                }
                if (Flag.Contains("DocPrint"))
                {
                    CheckCondition = "DocPrint";
                    this.Page.Title = "Print-Document";
                }
                if (Flag.Contains("DocPrintwithFlat"))
                {
                    CheckCondition = "DocPrintwithFlat";
                    this.Page.Title = "Print-Document";
                }
                if (Flag.Contains("DocPrintwithFlat"))
                {
                    CheckCondition = "DocPrintwithFlat";
                    this.Page.Title = "Print-Document";
                }
                if (Flag.Contains("PCPrint"))
                {
                    CheckCondition = "ProjectConfiguratorPrint";
                    this.Page.Title = "Print-Document";
                }
              
                if (Flag.Contains("UnitHolderDetails"))
                {
                    CheckCondition = "UnitHolderDetails";
                    this.Page.Title = "Print-UnitHolderDetails";
                }

                if (Flag.Contains("UnitHolderRecieptDtls"))
                {
                    CheckCondition = "UnitHolderRecieptDtls";
                    this.Page.Title = "Print-UnitHolderRecieptDtls";
                }

                if (Flag.Contains("FlatLayoutPrint"))
                {
                    CheckCondition = "FlatLayoutPrint";
                    this.Page.Title = "Print-FlatLayout";
                }
                if (Flag.Contains("StampDuty"))
                {
                    CheckCondition = "StampDuty";
                    this.Page.Title = "Print-StampDuty";
                }
                if (Flag.Contains("InterestLedger"))
                {
                    CheckCondition = "InterestLedger";
                    this.Page.Title = "Print-InterestLedger";
                }
                if (Flag.Contains("TermCond"))
                {
                    CheckCondition = "TermCond";
                    this.Page.Title = "Print-TermCond";
                }
                #endregion
            }
            else
            {
                //Go to Default Error Page===========                        
            }

            switch (CheckCondition)
            {
                //#region [Receipt]

                case "ReceiptMaster":
                    {
                        
                        ID = Convert.ToInt32(Request.QueryString["ID"]);
                        DS = Obj_Report.GetReceiptForPrint(ID, out strError);

                        if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty((DS.Tables[0].Rows[0]["ReceiptDate"]).ToString()))
                            {
                                #region[Without charge&Tax Details]
                                DataColumn column = new DataColumn("AmountInWords");
                                column.DataType = typeof(string);
                                DS.Tables[0].Columns.Add("AmountInWords");
                                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                {
                                    DS.Tables[0].Rows[i]["AmountInWords"] = WordAmount.convertcurrency(Convert.ToDecimal(DS.Tables[0].Rows[i]["VoucherAmt"]));
                                }


                                DS.Tables[0].TableName = "ReceiptMaster";
                                                              
                                CRpt.Load(Server.MapPath("~/PrintReport/CryRptReceiptWithoutDetails.rpt"));
                                CRpt.SetDataSource(DS);
                                CRPrint.ReportSource = CRpt;
                                CRPrint.DataBind();
                                CRPrint.DisplayToolbar = true;

                                //------- Add New Code For Print-----
                                if (Print_Flag != 0)
                                {
                                  
                                }
                                //------- Add New Code For Print-----
                                #endregion
                            }
                        }
                            
                        break;
                    }

                case "ExpOutReceipt":
                    {

                        ID = Convert.ToInt32(Request.QueryString["ID"]);
                        DS = Obj_Report.GetExpenseOutReceiptForPrint(ID, out strError);

                        if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty((DS.Tables[0].Rows[0]["ReceiptDate"]).ToString()))
                            {
                                #region[Without charge&Tax Details]
                                DataColumn column = new DataColumn("AmountInWords");
                                column.DataType = typeof(string);
                                DS.Tables[0].Columns.Add("AmountInWords");
                                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                {
                                    DS.Tables[0].Rows[i]["AmountInWords"] = WordAmount.convertcurrency(Convert.ToDecimal(DS.Tables[0].Rows[i]["VoucherAmt"]));
                                }


                                DS.Tables[0].TableName = "ReceiptMaster";

                                CRpt.Load(Server.MapPath("~/PrintReport/CryRptExpenseOutstandingReceipt.rpt"));
                                CRpt.SetDataSource(DS);
                                CRPrint.ReportSource = CRpt;
                                CRPrint.DataBind();
                                CRPrint.DisplayToolbar = true;

                                //------- Add New Code For Print-----
                                if (Print_Flag != 0)
                                {

                                }
                                //------- Add New Code For Print-----
                                #endregion
                            }
                        }

                        break;
                    }
              
            }
        }
   
        catch (ThreadAbortException th)
        {
           
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
       
    }
}
