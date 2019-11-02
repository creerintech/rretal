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
using System.Collections.Generic;

using System.Data.SqlClient;
using Build.DALSQLHelper;
using Build.DB;
using Build.EntityClass;
using Build.Utility;

namespace Build.DataModel
{

    public class DMReceiptMaster : Utility.Setting
    {
        public DataSet GetReceiptNo(out string strError)
        {
            DataSet ds = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                pAction.Value = 1;
                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", pAction);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }
    
        //public DataSet GetBuilding(int ID, int BookingId, out string strError)
        //{
        //    strError = string.Empty;
        //    DataSet Ds = new DataSet();
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter pId = new SqlParameter(ReceiptMaster._PCId, SqlDbType.BigInt);
        //        SqlParameter pBookingId = new SqlParameter(ReceiptMaster._BookingId, SqlDbType.BigInt);

        //        pAction.Value = 3;
        //        pId.Value = ID;
        //        pBookingId.Value = BookingId;

        //        SqlParameter[] param = new SqlParameter [] { pAction, pId, pBookingId };

        //        Open(CONNECTION_STRING);
        //        Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ReceiptMasterNew_Part1", param);
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    finally { Close(); }
        //    return Ds;

        //}

        //public DataSet GetCustomer(int ID,string Building, out string strError)
        //{
        //    strError = string.Empty;
        //    DataSet Ds = new DataSet();
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter pId = new SqlParameter(ReceiptMaster._PCId, SqlDbType.BigInt);
        //        SqlParameter pBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);

        //        pAction.Value = 4;
        //        pId.Value = ID;
        //        pBuilding.Value = Building;
        //        SqlParameter[] param = new SqlParameter[] { pAction, pId, pBuilding };

        //        Open(CONNECTION_STRING);
                
        //        BeginTransaction();
        //        Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ReceiptMasterNew_Part1",param);

        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    finally { Close(); }
        //    return Ds;

        //}

        //public DataSet GetUnitNo(int ID, out string strError)
        //{
        //    strError = string.Empty;
        //    DataSet Ds = new DataSet();
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter pId = new SqlParameter(ReceiptMaster._BookingId, SqlDbType.BigInt);

        //        pAction.Value = 5;
        //        pId.Value = ID;

        //        Open(CONNECTION_STRING);
        //        Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ReceiptMasterNew_Part1", pAction, pId);

        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    finally { Close(); }
        //    return Ds;

        //}

        //public DataSet GetOutstanding(int ID,int PCId, out string strError)
        //{
        //    strError = string.Empty;
        //    DataSet Ds = new DataSet();
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter pId = new SqlParameter(ReceiptMaster._BookingId, SqlDbType.BigInt);
        //        SqlParameter pPCId = new SqlParameter(ReceiptMaster._PCId, SqlDbType.BigInt);

        //        pAction.Value = 7;
        //        pId.Value = ID;
        //        pPCId.Value = PCId;
        //        SqlParameter[] param = new SqlParameter[] { pAction, pId, pPCId };
        //        Open(CONNECTION_STRING);
        //        Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ReceiptMasterNew_Part2", param);

        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    finally { Close(); }
        //    return Ds;

        //}

        public int InsertReceiptNew(ref ReceiptMaster Entity_Receipt, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);

               
                SqlParameter pReceiptNo = new SqlParameter(ReceiptMaster._ReceiptNo, SqlDbType.NVarChar);
                SqlParameter pReceiptDate = new SqlParameter("@ReceiptDate", SqlDbType.DateTime);
                SqlParameter pPartyId = new SqlParameter(ReceiptMaster._PartyId, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(ReceiptMaster._PropertyId, SqlDbType.BigInt);
                SqlParameter pVoucherAmt = new SqlParameter(ReceiptMaster._VoucherAmt, SqlDbType.Decimal);
                SqlParameter PForTheMonth = new SqlParameter(ReceiptMaster._ForTheMonth, SqlDbType.DateTime);               
               SqlParameter PNarration = new SqlParameter(ReceiptMaster._Narration, SqlDbType.NVarChar);
               SqlParameter PUnitNo = new SqlParameter(ReceiptMaster._UnitNo, SqlDbType.NVarChar);
                SqlParameter pCreatedBy = new SqlParameter(ReceiptMaster._UserId, SqlDbType.BigInt);
               SqlParameter pCreatedDate = new SqlParameter(ReceiptMaster._LoginDate, SqlDbType.DateTime);
               SqlParameter isDeleted = new SqlParameter(ReceiptMaster._IsDeleted , SqlDbType.Bit);
               SqlParameter pPaidAmount = new SqlParameter(ReceiptMaster._PaidAmount, SqlDbType.Decimal);
               SqlParameter pRemainingAmt = new SqlParameter(ReceiptMaster._RemainingAmt, SqlDbType.Decimal);
               
                pAction.Value = 3;             
                pReceiptNo.Value = Entity_Receipt.ReceiptNo;
                pReceiptDate.Value = Entity_Receipt.ReceiptDate;
                pPartyId.Value = Entity_Receipt.PartyId;
                pPropertyId.Value = Entity_Receipt.PropertyId;
                pVoucherAmt.Value = Entity_Receipt.VoucherAmt;
                PForTheMonth.Value = Entity_Receipt.ForTheMonth;               
                PNarration.Value = Entity_Receipt.Narration;
                PUnitNo.Value = Entity_Receipt.UnitNo;               
                pCreatedBy.Value = Entity_Receipt.UserId;
                pCreatedDate.Value = Entity_Receipt.LoginDate;
                isDeleted.Value = 0;
                pPaidAmount.Value = Entity_Receipt.PaidAmount;
                pRemainingAmt.Value = Entity_Receipt.RemainingAmt;

                SqlParameter[] Param = new SqlParameter[] { pAction, pReceiptNo,pReceiptDate, pPartyId, pPropertyId, pVoucherAmt,
                    PForTheMonth,PNarration,PUnitNo,pCreatedBy,pCreatedDate,isDeleted,pPaidAmount,pRemainingAmt};

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", Param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;

        }

        //public int UpdateReceiptNew(ref ReceiptMaster Entity_Receipt, out string StrError)
        //{
        //    int iInsert = 0;
        //    StrError = string.Empty;
        //    try
        //    {

        //        //            RcptId ,ReceiptNo,ReceiptDate,PCId,BookingId,NetAmount,
        //        //CreatedBy,CreatedOn, IsDeleted




        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);

        //        SqlParameter RcptID = new SqlParameter(ReceiptMaster._ReceiptId, SqlDbType.BigInt);
        //        SqlParameter pReceiptNo = new SqlParameter(ReceiptMaster._ReceiptNo, SqlDbType.NVarChar);
        //        SqlParameter pReceiptDate = new SqlParameter("@ReceiptDate", SqlDbType.DateTime);
        //        SqlParameter pProjectId = new SqlParameter(ReceiptMaster._PCId, SqlDbType.BigInt);
        //        SqlParameter pCustomerId = new SqlParameter(ReceiptMaster._BookingId, SqlDbType.BigInt);
        //        SqlParameter pNetAmount = new SqlParameter(ReceiptMaster._NetAmount, SqlDbType.Decimal);


        //        SqlParameter PPaymentMode = new SqlParameter(ReceiptMaster._PaymentMode, SqlDbType.Char);
        //        SqlParameter PChequeDDNo = new SqlParameter(ReceiptMaster._ChequeDDNO, SqlDbType.NVarChar);
        //        SqlParameter PChequeDDDate = new SqlParameter(ReceiptMaster._ChequeDDDate, SqlDbType.DateTime);
                
        //        SqlParameter PNarration = new SqlParameter(ReceiptMaster._Narration, SqlDbType.NVarChar);

        //        SqlParameter PDifferenceAmt = new SqlParameter(ReceiptMaster._DifferenceAmt, SqlDbType.Decimal);

        //        SqlParameter PTower = new SqlParameter(ReceiptMaster._Tower, SqlDbType.NVarChar);



        //        SqlParameter pCreatedBy = new SqlParameter(ReceiptMaster._UserId, SqlDbType.BigInt);
        //        SqlParameter pCreatedDate = new SqlParameter(ReceiptMaster._LoginDate, SqlDbType.DateTime);
        //        SqlParameter isDeleted = new SqlParameter(ReceiptMaster._IsDeleted, SqlDbType.Bit);

        //        SqlParameter PBankId = new SqlParameter(ReceiptMaster._BankId, SqlDbType.BigInt);
        //        SqlParameter PBankName = new SqlParameter(ReceiptMaster._BankName, SqlDbType.NVarChar);
        //        SqlParameter PBranchName = new SqlParameter(ReceiptMaster._BranchName, SqlDbType.NVarChar);
        //        SqlParameter PnewBranchId = new SqlParameter(ReceiptMaster._NewBranchId, SqlDbType.Int);
        //        SqlParameter PDepositionBank = new SqlParameter(ReceiptMaster._DepositionBankId, SqlDbType.Int);
        //        SqlParameter PRTGSTranNo = new SqlParameter(ReceiptMaster._RTGSTranNo, SqlDbType.NVarChar);
        //        SqlParameter pRemarks = new SqlParameter(ReceiptMaster._Remarks, SqlDbType.NVarChar);
                
        //        //,PaymentMode,ChequeDDNo,ChequeDDDate,BankName,
        //        //BranchName,Narration
        //        pAction.Value = 4;
        //        RcptID.Value = Entity_Receipt.ReceiptId;
        //        pReceiptNo.Value = Entity_Receipt.ReceiptNo;
        //        pReceiptDate.Value = Entity_Receipt.ReceiptDate;
        //        pProjectId.Value = Entity_Receipt.PCId;
        //        pCustomerId.Value = Entity_Receipt.BookingId;
        //        pNetAmount.Value = Entity_Receipt.NetAmount;

        //        PPaymentMode.Value = Entity_Receipt.PaymentMode;
        //        PChequeDDNo.Value = Entity_Receipt.ChequeDDNO;
        //        PChequeDDDate.Value = Entity_Receipt.ChequeDDDate;
        //        PBankName.Value = Entity_Receipt.BankName;
        //        PBranchName.Value = Entity_Receipt.BranchName;
        //        PNarration.Value = Entity_Receipt.Narration;
        //        PDifferenceAmt.Value = Entity_Receipt.DifferenceAmt;
        //        PTower.Value = Entity_Receipt.Tower;
        //        pCreatedBy.Value = Entity_Receipt.UserId;
        //        pCreatedDate.Value = Entity_Receipt.LoginDate;
        //        isDeleted.Value = 0;
        //        PBankId.Value = Entity_Receipt.BankId;
        //        PnewBranchId.Value = Entity_Receipt.NewDraweeBranchId;
        //        PDepositionBank.Value = Entity_Receipt.DepositionBankId;
        //        PRTGSTranNo.Value = Entity_Receipt.RTGSTranNo;
        //        pRemarks.Value = Entity_Receipt.Remarks;
        //        SqlParameter[] Param = new SqlParameter[] { pAction, RcptID, pReceiptNo,pReceiptDate, pProjectId, pCustomerId, pNetAmount,
        //            PPaymentMode,PChequeDDNo,PChequeDDDate,PBankName,PBranchName,PNarration,PDifferenceAmt, PTower ,
        //            pCreatedBy,pCreatedDate,isDeleted,PBankId,PnewBranchId,PDepositionBank,PRTGSTranNo,pRemarks};

        //        Open(CONNECTION_STRING);
        //        BeginTransaction();
        //        iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "sp_receipt_master1", Param);

        //        if (iInsert > 0)
        //        {
        //            CommitTransaction();
        //        }
        //        else
        //        {
        //            RollBackTransaction();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        RollBackTransaction();
        //        StrError = ex.Message;
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return iInsert;

        //}

        //public int InsertReceipt(ref ReceiptMaster Entity_Receipt, out string StrError)
        //{
        //    int iInsert = 0;
        //    StrError = string.Empty;
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter pEmpId = new SqlParameter(ReceiptMaster._EmpID, SqlDbType.BigInt);
        //        SqlParameter pReceiptNo = new SqlParameter(ReceiptMaster._ReceiptNo, SqlDbType.NVarChar);
        //        SqlParameter pReceiptDate = new SqlParameter(ReceiptMaster._ReceiptDate, SqlDbType.DateTime);                
        //        SqlParameter pProjectId = new SqlParameter(ReceiptMaster._PCId, SqlDbType.BigInt);
        //        SqlParameter pCustomerId = new SqlParameter(ReceiptMaster._BookingId, SqlDbType.BigInt);
        //        SqlParameter pNetAmount = new SqlParameter(ReceiptMaster._NetAmount, SqlDbType.Decimal);               
        //        SqlParameter pPayModeFlag = new SqlParameter(ReceiptMaster._PayModeFlag, SqlDbType.Bit);
                
        //        SqlParameter pCreatedBy = new SqlParameter(ReceiptMaster._UserId, SqlDbType.BigInt);
        //        SqlParameter pCreatedDate = new SqlParameter(ReceiptMaster._LoginDate, SqlDbType.DateTime);

        //        pAction.Value = 1;
        //        pEmpId.Value = Entity_Receipt.EmpID;
        //        pReceiptNo.Value = Entity_Receipt.ReceiptNo;
        //        pReceiptDate.Value = Entity_Receipt.ReceiptDate;
        //        pProjectId.Value = Entity_Receipt.PCId;                          
        //        pCustomerId.Value = Entity_Receipt.BookingId;
        //        pNetAmount.Value = Entity_Receipt.NetAmount;                                         
        //        pPayModeFlag.Value = Entity_Receipt.PayModeFlag;

        //        pCreatedBy.Value = Entity_Receipt.UserId;
        //        pCreatedDate.Value = Entity_Receipt.LoginDate;

        //        SqlParameter[] Param = new SqlParameter[] 
        //        {pAction,pEmpId,pReceiptNo,pReceiptDate,pProjectId,pCustomerId,
        //         pNetAmount,pPayModeFlag ,pCreatedBy,pCreatedDate };

        //        Open(CONNECTION_STRING);
        //        BeginTransaction();
        //        iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ReceiptMasterNew_Part2", Param);

        //        if (iInsert > 0)
        //        {
        //            CommitTransaction();
        //        }
        //        else
        //        {
        //            RollBackTransaction();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        RollBackTransaction();
        //        StrError = ex.Message;
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return iInsert;
        //}


        //public DataSet GetReceiptDataForEdit(int receiptID,  out string strError)
        //{
        //    strError = string.Empty;
        //    DataSet Ds = new DataSet();
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        //SqlParameter pId = new SqlParameter(ReceiptMaster._PCId, SqlDbType.BigInt);
        //        //SqlParameter pBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);

        //        SqlParameter pRecieptId = new SqlParameter(ReceiptMaster._ReceiptId, SqlDbType.BigInt);
        //        //SqlParameter pRecieptId = new SqlParameter(ReceiptMaster._ReceiptId, SqlDbType.BigInt);

        //        pAction.Value = 11;
        //        //pId.Value = ID;
        //        //pBuilding.Value = Building;
        //        pRecieptId.Value = receiptID;

        //        SqlParameter[] param = new SqlParameter[] { pAction,  pRecieptId };

        //        Open(CONNECTION_STRING);

        //        BeginTransaction();
        //        Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_I", param);

        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    finally { Close(); }
        //    return Ds;

        //}

        //public int InsertReceiptDetailsNew(ref ReceiptMaster Entity_Receipt, out string StrError)
        //{
        //    int iInsert = 0;
        //    StrError = string.Empty;

        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter pReceiptId = new SqlParameter(ReceiptMaster._ReceiptId, SqlDbType.BigInt);
        //        //SqlParameter pAccountTypeId = new SqlParameter(ReceiptMaster._AccountTypeId, SqlDbType.BigInt);
        //        //SqlParameter pPSDtlId = new SqlParameter(ReceiptMaster._PSDtlId, SqlDbType.BigInt);
        //        //SqlParameter pTaxdtlId = new SqlParameter(ReceiptMaster._TaxdtlId, SqlDbType.BigInt);
        //        //SqlParameter pChargeId = new SqlParameter(ReceiptMaster._ChargeId, SqlDbType.BigInt);
        //        //SqlParameter pPayModeTypeId = new SqlParameter(ReceiptMaster._PayModeTypeId, SqlDbType.BigInt);


        //        SqlParameter collectedon = new SqlParameter(ReceiptMaster._CollectedOn, SqlDbType.NChar);
        //        SqlParameter Booking_ChargeDtlsId = new SqlParameter(ReceiptMaster._Booking_ChargeDtlsId, SqlDbType.Int);
        //        SqlParameter Booking_TaxDtlsId = new SqlParameter(ReceiptMaster._Booking_TaxDtlsId, SqlDbType.Int);
        //        SqlParameter BookingPaymentScheduleId = new SqlParameter(ReceiptMaster._BookingPaymentScheduleId, SqlDbType.Int);
        //        SqlParameter stageid = new SqlParameter(ReceiptMaster._StageId, SqlDbType.Int);
        //        SqlParameter chargeId = new SqlParameter(ReceiptMaster._ChargeId, SqlDbType.Decimal);
        //        SqlParameter TaxDtlId = new SqlParameter(ReceiptMaster._TaxDtlId, SqlDbType.Int);
        //        SqlParameter RcptAmount = new SqlParameter(ReceiptMaster._RcptAmount, SqlDbType.Decimal);

        //        SqlParameter STReceiptAmt = new SqlParameter(ReceiptMaster._STReceiptAmt, SqlDbType.Decimal);

        //        pAction.Value = 2;
        //        pReceiptId.Value = Entity_Receipt.ReceiptId;
        //        RcptAmount.Value = Entity_Receipt.RcptAmount;

        //        collectedon.Value = Entity_Receipt.CollectedOn;

        //        stageid.Value = Entity_Receipt.StageId;
        //        chargeId.Value = Entity_Receipt.ChargeId;
        //        TaxDtlId.Value = Entity_Receipt.TaxdtlId;

        //        STReceiptAmt.Value = Entity_Receipt.STReceiptAmt;
                            

        //        SqlParameter[] param = new SqlParameter[] { pAction, pReceiptId, collectedon, Booking_ChargeDtlsId, Booking_TaxDtlsId, BookingPaymentScheduleId, stageid, chargeId, TaxDtlId, RcptAmount, STReceiptAmt };

        //        Open(CONNECTION_STRING);
        //        BeginTransaction();
        //        iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "sp_receipt_master1", param);

        //        if (iInsert > 0)
        //        {
        //            CommitTransaction();
        //        }
        //        else
        //        {
        //            RollBackTransaction();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        RollBackTransaction();
        //        StrError = ex.Message;
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return iInsert;
        //}


        //public int DeleteReceipt(ref ReceiptMaster  Entity_Receipt, out string StrError)
        //{
        //    int iDelete = 0;
        //    StrError = string.Empty;
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter pReceiptId = new SqlParameter(ReceiptMaster._ReceiptId, SqlDbType.BigInt);
        //        SqlParameter pDeletedBy = new SqlParameter(ReceiptMaster._UserId, SqlDbType.BigInt);
        //        SqlParameter pDeletedDate = new SqlParameter(ReceiptMaster._LoginDate, SqlDbType.DateTime);

        //        pAction.Value = 3;
        //        pReceiptId.Value = Entity_Receipt.ReceiptId;
        //        pDeletedBy.Value = Entity_Receipt.UserId;
        //        pDeletedDate.Value = Entity_Receipt.LoginDate;

        //        SqlParameter[] param = new SqlParameter[] { pAction, pReceiptId, pDeletedBy, pDeletedDate };
        //        Open(CONNECTION_STRING);
        //        BeginTransaction();
        //        iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_Master1", param);

        //        if (iDelete > 0)
        //        {
        //            CommitTransaction();
        //        }
        //        else
        //        {
        //            RollBackTransaction();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RollBackTransaction();
        //        StrError = ex.Message;
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return iDelete;
        //}

        //public int InsertReceiptDetails(ref ReceiptMaster Entity_Receipt, out string StrError)
        //{
        //    int iInsert = 0;
        //    StrError = string.Empty;
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter pReceiptId = new SqlParameter(ReceiptMaster._ReceiptId, SqlDbType.BigInt);              
        //        SqlParameter pAccountTypeId = new SqlParameter(ReceiptMaster._AccountTypeId, SqlDbType.BigInt);
        //        SqlParameter pPSDtlId = new SqlParameter(ReceiptMaster._PSDtlId, SqlDbType.BigInt);
        //        SqlParameter pTaxdtlId = new SqlParameter(ReceiptMaster._TaxdtlId, SqlDbType.BigInt);
        //        SqlParameter pChargeId = new SqlParameter(ReceiptMaster._ChargeId, SqlDbType.BigInt);
        //        SqlParameter pPayModeTypeId = new SqlParameter(ReceiptMaster._PayModeTypeId, SqlDbType.BigInt);
        //        SqlParameter pAmount = new SqlParameter(ReceiptMaster._Amount, SqlDbType.Decimal);
        //        SqlParameter pChequeDDNO = new SqlParameter(ReceiptMaster._ChequeDDNO, SqlDbType.NVarChar);
        //        SqlParameter pChequeDDDate = new SqlParameter(ReceiptMaster._ChequeDDDate, SqlDbType.DateTime);
        //        SqlParameter pBankName = new SqlParameter(ReceiptMaster._BankName, SqlDbType.NVarChar);
        //        SqlParameter pBranchName = new SqlParameter(ReceiptMaster._BranchName, SqlDbType.NVarChar);
        //        SqlParameter pReceiptFor = new SqlParameter(ReceiptMaster._ReceiptFor, SqlDbType.NVarChar);

        //        pAction.Value = 4;
        //        pReceiptId.Value = Entity_Receipt.ReceiptId;
        //        pAccountTypeId.Value = Entity_Receipt.AccountTypeId;
        //        pPSDtlId.Value = Entity_Receipt.PSDtlId;
        //        pTaxdtlId.Value = Entity_Receipt.TaxdtlId;
        //        pChargeId.Value = Entity_Receipt.ChargeId;
        //        pPayModeTypeId.Value = Entity_Receipt.PayModeTypeId;
        //        pAmount.Value = Entity_Receipt.Amount;
        //        pChequeDDNO.Value = Entity_Receipt.ChequeDDNO;
        //        pChequeDDDate.Value = Entity_Receipt.ChequeDDDate;
        //        pBankName.Value = Entity_Receipt.BankName;
        //        pBranchName.Value = Entity_Receipt.BranchName;
        //        pReceiptFor.Value = Entity_Receipt.ReceiptFor;
               
        //        SqlParameter[] param = new SqlParameter[] { pAction, pReceiptId, pAccountTypeId, pPSDtlId, pPayModeTypeId,
        //           pTaxdtlId,pChargeId,pAmount, pChequeDDNO, pChequeDDDate, pBankName, pBranchName,pReceiptFor };

        //        Open(CONNECTION_STRING);
        //        BeginTransaction();
        //        iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ReceiptMasterNew_Part2", param);

        //        if (iInsert > 0)
        //        {
        //            CommitTransaction();
        //        }
        //        else
        //        {
        //            RollBackTransaction();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        RollBackTransaction();
        //        StrError = ex.Message;
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return iInsert;
        //}

        //public int UpdateReceipt(ref ReceiptMaster Entity_Receipt, out string StrError)
        //{
        //    int iInsert = 0;
        //    StrError = string.Empty;
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter pReceiptId = new SqlParameter(ReceiptMaster._ReceiptId, SqlDbType.BigInt);
        //        SqlParameter pReceiptNo = new SqlParameter(ReceiptMaster._ReceiptNo, SqlDbType.NVarChar);
        //        SqlParameter pEmpId = new SqlParameter(ReceiptMaster._EmpID, SqlDbType.BigInt);
        //        SqlParameter pReceiptDate = new SqlParameter(ReceiptMaster._ReceiptDate, SqlDbType.DateTime);              
        //        SqlParameter pProjectId = new SqlParameter(ReceiptMaster._PCId, SqlDbType.BigInt);
        //        SqlParameter pCustomerId = new SqlParameter(ReceiptMaster._BookingId, SqlDbType.BigInt);
        //        SqlParameter pNetAmount = new SqlParameter(ReceiptMaster._NetAmount, SqlDbType.Decimal);
        //        SqlParameter pPayModeFlag = new SqlParameter(ReceiptMaster._PayModeFlag, SqlDbType.Bit);
                
        //        SqlParameter pUpdatedBy = new SqlParameter(ReceiptMaster._UserId, SqlDbType.BigInt);
        //        SqlParameter pUpdatedDate = new SqlParameter(ReceiptMaster._LoginDate, SqlDbType.DateTime);

        //        pAction.Value = 2;
        //        pReceiptId.Value = Entity_Receipt.ReceiptId;
        //        pReceiptNo.Value = Entity_Receipt.ReceiptNo;
        //        pEmpId.Value = Entity_Receipt.EmpID;
        //        pReceiptDate.Value = Entity_Receipt.ReceiptDate;
        //        pProjectId.Value = Entity_Receipt.PCId;                           
        //        pCustomerId.Value = Entity_Receipt.BookingId;
        //        pNetAmount.Value = Entity_Receipt.NetAmount;               
        //        pPayModeFlag.Value = Entity_Receipt.PayModeFlag;

        //        pUpdatedBy.Value = Entity_Receipt.UserId;
        //        pUpdatedDate.Value = Entity_Receipt.LoginDate;

        //        SqlParameter[] param = new SqlParameter[]
        //        {pAction,pReceiptId,pReceiptNo,pEmpId,pReceiptDate,pProjectId,pCustomerId,pNetAmount,pPayModeFlag,
        //         pUpdatedBy,pUpdatedDate };
        //        Open(CONNECTION_STRING);
        //        BeginTransaction();
        //        iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ReceiptMasterNew_Part2", param);

        //        if (iInsert > 0)
        //        {
        //            CommitTransaction();
        //        }
        //        else
        //        {
        //            RollBackTransaction();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        RollBackTransaction();
        //        StrError = ex.Message;
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return iInsert;
        //}

        //public DataSet GetReceiptList(string RepCondition, out string StrError)
        //{
        //    StrError = string.Empty;

        //    DataSet DS = new DataSet();

        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

        //        pAction.Value = 7;// 5;
        //        PrepCondition.Value = RepCondition;

        //        Open(CONNECTION_STRING);

        //        DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_I", pAction, PrepCondition);


        //    }
        //    catch (Exception ex)
        //    {
        //        StrError = ex.Message;

        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return DS;
        //}

        //public DataSet GetBookingID(long BookingID,string receiptDate ,long Pcid , out string StrError)
        //{
        //    StrError = string.Empty;
            
        //    DataSet ds = new DataSet();
           
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
        //        SqlParameter bID = new SqlParameter("@BKId", SqlDbType.BigInt);
        //        SqlParameter pRcptDate = new SqlParameter("@ReceiptDate", SqlDbType.VarChar);
        //        SqlParameter pPcid = new SqlParameter("@PCId", SqlDbType.BigInt);

        //        pAction.Value = 9;
        //        bID.Value = BookingID;
        //        pRcptDate.Value = receiptDate;
        //        pPcid.Value = Pcid;
        //        SqlParameter[] param = new SqlParameter[] { pAction, bID,pRcptDate,pPcid};
        //        Open(CONNECTION_STRING);
        //        ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "Receipt_III_ServiceTaxCalculation", param);
        //    }
        //    catch (Exception ex)
        //    {
        //        StrError = ex.Message;
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return ds;

        //}

        //public void  InsertReceiptMaster()
        //{

        //}
       
        //public DataSet GetReceiptDetailsForEdit(long ID,long bookingID,string receiptDate,long pcid, long receiptId,out string StrError)
        //{
        //    StrError = string.Empty;
        //    DataSet DS = new DataSet();
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter pReceiptID = new SqlParameter("@ReceiptId", SqlDbType.BigInt);
        //        SqlParameter pBookingId = new SqlParameter("@BKId", SqlDbType.BigInt);
        //        SqlParameter pRcptDate = new SqlParameter("@ReceiptDate", SqlDbType.VarChar);
        //        SqlParameter pPcid = new SqlParameter("@PCId", SqlDbType.BigInt);

        //        pAction.Value = 10;
        //        pBookingId.Value = bookingID;
        //        pRcptDate.Value = receiptDate;
        //        pReceiptID.Value = receiptId;
        //        pPcid.Value = pcid;
        //        SqlParameter[] param = new SqlParameter[] { pAction, pBookingId, pRcptDate, pPcid ,pReceiptID};
        //        Open(CONNECTION_STRING);

        //        //DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_I", param);
        //        DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "Receipt_III_ServiceTaxCalculation", param);
                
                
        //    }
        //    catch (Exception ex)
        //    {
        //        StrError = ex.Message;
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return DS;
        //}

        //public string[] GetSuggestRecord(string preFixText)
        //{
        //    List<string> SearchList = new List<string>();
        //    string ListItem = string.Empty;

        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(BookingMaster._Action, SqlDbType.BigInt);
        //        SqlParameter PrepCondition = new SqlParameter(BookingMaster._StrCondition, SqlDbType.NVarChar);

        //        pAction.Value = 5;
        //        PrepCondition.Value = preFixText;

        //        SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

        //        Open(CONNECTION_STRING);
        //        SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ReceiptMasterNew_Part2", oparamcol);

        //        if (dr != null && dr.HasRows == true)
        //        {
        //            while (dr.Read())
        //            {
        //                ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[0].ToString(),
        //                    dr[1].ToString());

        //                SearchList.Add(ListItem);
        //            }

        //        }
        //        dr.Close();
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //    finally
        //    {
        //        Close();
        //    }

        //    return SearchList.ToArray();
        //}


        //public int UpdateChequeBounceDetails(ref ReceiptMaster Entity_Receipt, out string StrError)
        //{
        //    int iInsert = 0;
        //    StrError = string.Empty;
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter pReceiptId = new SqlParameter(ReceiptMaster._ReceiptId, SqlDbType.BigInt);
        //        SqlParameter pUpdatedBy = new SqlParameter(ReceiptMaster._UserId, SqlDbType.BigInt);
        //        SqlParameter pUpdatedDate = new SqlParameter(ReceiptMaster._LoginDate, SqlDbType.DateTime);
        //        SqlParameter pBounceDate = new SqlParameter(ReceiptMaster._BounceDate, SqlDbType.DateTime);
        //        SqlParameter pBounceReason = new SqlParameter(ReceiptMaster._BounceReason, SqlDbType.NVarChar);

        //        pAction.Value = 2;
        //        pReceiptId.Value = Entity_Receipt.ReceiptId;
        //        pUpdatedBy.Value = Entity_Receipt.UserId;
        //        pUpdatedDate.Value = Entity_Receipt.LoginDate;
        //        pBounceDate.Value = Entity_Receipt.ChequeBounceDate;
        //        pBounceReason.Value = Entity_Receipt.BounceReason;

        //        SqlParameter[] param = new SqlParameter[]
        //        {pAction,pReceiptId,pUpdatedBy,pUpdatedDate,pBounceDate,pBounceReason };
        //        Open(CONNECTION_STRING);
        //        BeginTransaction();
        //        iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", param);

        //        if (iInsert > 0)
        //        {
        //            CommitTransaction();
        //        }
        //        else
        //        {
        //            RollBackTransaction();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        RollBackTransaction();
        //        StrError = ex.Message;
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return iInsert;
        //}
        
        //public int RollbackChequeBounceDetails(ref ReceiptMaster Entity_Receipt, out string StrError)
        //{
        //    int iInsert = 0;
        //    StrError = string.Empty;
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter pReceiptId = new SqlParameter(ReceiptMaster._ReceiptId, SqlDbType.BigInt);
        //        SqlParameter pUpdatedBy = new SqlParameter(ReceiptMaster._UserId, SqlDbType.BigInt);
        //        SqlParameter pUpdatedDate = new SqlParameter(ReceiptMaster._LoginDate, SqlDbType.DateTime);
            
        //        pAction.Value = 3;
        //        pReceiptId.Value = Entity_Receipt.ReceiptId;
        //        pUpdatedBy.Value = Entity_Receipt.UserId;
        //        pUpdatedDate.Value = Entity_Receipt.LoginDate;
            
        //        SqlParameter[] param = new SqlParameter[] { pAction, pReceiptId, pUpdatedBy, pUpdatedDate };
        //        Open(CONNECTION_STRING);
        //        BeginTransaction();
        //        iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", param);

        //        if (iInsert > 0)
        //        {
        //            CommitTransaction();
        //        }
        //        else
        //        {
        //            RollBackTransaction();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        RollBackTransaction();
        //        StrError = ex.Message;
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return iInsert;
        //}
       
        //public DataSet GetInterestAmount(long BookingID,long rcptId, out string StrError)
        //{
        //    StrError = string.Empty;
        //    DataSet ds = new DataSet();

        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
        //        SqlParameter bID = new SqlParameter("@BKId", SqlDbType.BigInt);
        //        SqlParameter pRcptId = new SqlParameter("@ReceiptId", SqlDbType.BigInt);
                
        //        pAction.Value =101;
        //        bID.Value = BookingID;
        //        pRcptId.Value = rcptId;

        //        SqlParameter[] param = new SqlParameter[] { pAction,bID,pRcptId};
        //        Open(CONNECTION_STRING);
        //        ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "Receipt_III_ServiceTaxCalculation",param);

        //    }
        //    catch (Exception ex)
        //    {
        //        StrError = ex.Message;
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return ds;

        //}

        //public DataSet CheckRefundsMadeOrNot(ref ReceiptMaster Entity_Receipt, out string StrError)
        //{
        //    DataSet ds = new DataSet();
        //    StrError = string.Empty;
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter pId = new SqlParameter(ReceiptMaster._BookingId, SqlDbType.BigInt);
                
        //        pAction.Value = 13;
        //        pId.Value = Entity_Receipt.BookingId;
              
        //        SqlParameter[] param = new SqlParameter[] {pAction, pId,};

        //        Open(CONNECTION_STRING);
        //        BeginTransaction();
        //        ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_I", pAction,pId);

        //    }
        //    catch (Exception ex)
        //    {
        //        RollBackTransaction();
        //        StrError = ex.Message;
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return ds;
        //}
        //#region Report
        //public DataSet GetReceiptReport(string RepCondition, out string strError)
        //{
        //    strError = string.Empty;
        //    DataSet Ds = new DataSet();
        //    try
        //    {
        //        SqlParameter MAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
        //        SqlParameter MRepCondition = new SqlParameter(ReceiptMaster._StrCondition, SqlDbType.NVarChar);
        //        MAction.Value = 7;
        //        MRepCondition.Value = RepCondition;

        //        Open(Setting.CONNECTION_STRING);
        //        Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ReceiptMasterNew_Part1", MAction, MRepCondition);

        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    finally { Close(); }
        //    return Ds;

        //}

        //public DataSet PrintReceiptReport(int ReceiptId, out string strError)
        //{
        //    strError = string.Empty;
        //    DataSet Ds = new DataSet();
        //    try
        //    {
        //        SqlParameter pReceiptId = new SqlParameter(ReceiptMaster._ReceiptId, SqlDbType.BigInt);
        //        SqlParameter pPrintID = new SqlParameter("@PrintID", SqlDbType.NVarChar);

        //        pPrintID.Value = "RF";
        //        pReceiptId.Value = ReceiptId;

        //        Open(Setting.CONNECTION_STRING);
        //        Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ReceiptMaster.SP_Print, pPrintID, pReceiptId);

        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    finally { Close(); }
        //    return Ds;
        //}
        //#endregion

        public DMReceiptMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet BindCombo(out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
                pAction.Value = 2;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", pAction);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet GetReceiptList(string RepCondition, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", pAction, PrepCondition);


            }
            catch (Exception ex)
            {
                StrError = ex.Message;

            }
            finally
            {
                Close();
            }
            return DS;
        }

        public int DeleteReceipt(ref ReceiptMaster Entity_Receipt, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
                SqlParameter pReceiptId = new SqlParameter(ReceiptMaster._ReceiptVoucherId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(ReceiptMaster._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(ReceiptMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value =6;
                pReceiptId.Value = Entity_Receipt.ReceiptVoucherId;
                pDeletedBy.Value = Entity_Receipt.UserId;
                pDeletedDate.Value = Entity_Receipt.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pReceiptId, pDeletedBy, pDeletedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", param);

                if (iDelete > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iDelete;
        }

        public DataSet GetReceiptToEdit(int ReceiptVoucherId, out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);               
                SqlParameter pRecieptId = new SqlParameter(ReceiptMaster._ReceiptVoucherId, SqlDbType.BigInt);
             
                pAction.Value = 7;
                pRecieptId.Value = ReceiptVoucherId;

                SqlParameter[] param = new SqlParameter[] { pAction, pRecieptId };

                Open(CONNECTION_STRING);

                BeginTransaction();
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", param);

            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public string[] GetSuggestRecord(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = prefixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", oparamcol);

                if (dr != null && dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[0].ToString(), dr[1].ToString());

                        SearchList.Add(ListItem);
                    }
                }
                dr.Close();
            }

            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                Close();
            }

            return SearchList.ToArray();
        }

        public int UpdatetReceiptVoucher(ref ReceiptMaster Entity_Receipt, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);

                SqlParameter pReceiptVoucherId = new SqlParameter(ReceiptMaster._ReceiptVoucherId, SqlDbType.BigInt);
                SqlParameter pReceiptNo = new SqlParameter(ReceiptMaster._ReceiptNo, SqlDbType.NVarChar);
                SqlParameter pReceiptDate = new SqlParameter("@ReceiptDate", SqlDbType.DateTime);
                SqlParameter pPartyId = new SqlParameter(ReceiptMaster._PartyId, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(ReceiptMaster._PropertyId, SqlDbType.BigInt);
                SqlParameter pVoucherAmt = new SqlParameter(ReceiptMaster._VoucherAmt, SqlDbType.Decimal);
                SqlParameter PForTheMonth = new SqlParameter(ReceiptMaster._ForTheMonth, SqlDbType.DateTime);
                SqlParameter PNarration = new SqlParameter(ReceiptMaster._Narration, SqlDbType.NVarChar);
                SqlParameter PUnitNo = new SqlParameter(ReceiptMaster._UnitNo, SqlDbType.NVarChar);
                SqlParameter pCreatedBy = new SqlParameter(ReceiptMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(ReceiptMaster._LoginDate, SqlDbType.DateTime);
                //SqlParameter isDeleted = new SqlParameter(ReceiptMaster._IsDeleted, SqlDbType.Bit);
                SqlParameter pPaidAmount = new SqlParameter(ReceiptMaster._PaidAmount, SqlDbType.Decimal);
                SqlParameter pRemainingAmt = new SqlParameter(ReceiptMaster._RemainingAmt, SqlDbType.Decimal);

                pAction.Value = 4;
                pReceiptVoucherId.Value = Entity_Receipt.ReceiptVoucherId;
                pReceiptNo.Value = Entity_Receipt.ReceiptNo;
                pReceiptDate.Value = Entity_Receipt.ReceiptDate;
                pPartyId.Value = Entity_Receipt.PartyId;
                pPropertyId.Value = Entity_Receipt.PropertyId;
                pVoucherAmt.Value = Entity_Receipt.VoucherAmt;
                PForTheMonth.Value = Entity_Receipt.ForTheMonth;
                PNarration.Value = Entity_Receipt.Narration;
                PUnitNo.Value = Entity_Receipt.UnitNo;
                pCreatedBy.Value = Entity_Receipt.UserId;
                pCreatedDate.Value = Entity_Receipt.LoginDate;
               // isDeleted.Value = 0;
                pPaidAmount.Value = Entity_Receipt.PaidAmount;
                pRemainingAmt.Value = Entity_Receipt.RemainingAmt;

                SqlParameter[] Param = new SqlParameter[] { pAction,pReceiptVoucherId, pReceiptNo,pReceiptDate, pPartyId, pPropertyId, pVoucherAmt,
                    PForTheMonth,PNarration,PUnitNo,pCreatedBy,pCreatedDate,pPaidAmount,pRemainingAmt};

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", Param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public DataSet GetPropertyOnParty(int PartyId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPartyId= new SqlParameter("@PartyId", SqlDbType.BigInt);

                pAction.Value = 8;
                pPartyId.Value = PartyId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", pAction, pPartyId);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public int UpdatePropertRentDtls(ref ReceiptMaster Entity_Receipt, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);


                SqlParameter pFromDate = new SqlParameter("@FormDate", SqlDbType.NVarChar);
                SqlParameter pPartyId = new SqlParameter(ReceiptMaster._PartyId, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(ReceiptMaster._PropertyId, SqlDbType.BigInt);
                SqlParameter pUnitNo = new SqlParameter("@UnitNo", SqlDbType.NVarChar);
                SqlParameter pFortheMonthYear = new SqlParameter("@FortheMonthYear", SqlDbType.NVarChar);
                SqlParameter pReceiptVoucherId = new SqlParameter("@ReceiptVoucherId", SqlDbType.BigInt); 

                pAction.Value = 9;
                pFromDate.Value = Entity_Receipt.ForTheMonth;
                pPartyId.Value = Entity_Receipt.PartyId;
                pPropertyId.Value = Entity_Receipt.PropertyId;
                pUnitNo.Value = Entity_Receipt.UnitNo;
                pFortheMonthYear.Value = Entity_Receipt.FortheMonthYear;
                pReceiptVoucherId.Value = Entity_Receipt.ReceiptVoucherId;

                SqlParameter[] Param = new SqlParameter[] { pAction, pFromDate, pPartyId, pPropertyId, pUnitNo, pFortheMonthYear, pReceiptVoucherId };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", Param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int UpdatePropertMonthmapping(ref ReceiptMaster Entity_Receipt, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);


                SqlParameter pFromDate = new SqlParameter("@FormDate", SqlDbType.NVarChar);
                SqlParameter pPartyId = new SqlParameter(ReceiptMaster._PartyId, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(ReceiptMaster._PropertyId, SqlDbType.BigInt);
                SqlParameter pUnitNo = new SqlParameter("@UnitNo", SqlDbType.NVarChar);
                SqlParameter pFortheMonthYear = new SqlParameter("@FortheMonthYear", SqlDbType.NVarChar);
                SqlParameter pReceiptVoucherId = new SqlParameter("@ReceiptVoucherId", SqlDbType.BigInt);
                SqlParameter pRemainingAmt = new SqlParameter("@RemainingAmt", SqlDbType.Decimal);
                pAction.Value = 13;
                pFromDate.Value = Entity_Receipt.ForTheMonth;
                pPartyId.Value = Entity_Receipt.PartyId;
                pPropertyId.Value = Entity_Receipt.PropertyId;
                pUnitNo.Value = Entity_Receipt.UnitNo;
                pFortheMonthYear.Value = Entity_Receipt.FortheMonthYear;
                pReceiptVoucherId.Value = Entity_Receipt.ReceiptVoucherId;
                pRemainingAmt.Value = Entity_Receipt.RemainingAmt;
                SqlParameter[] Param = new SqlParameter[] { pAction, pFromDate, pPartyId, pPropertyId, pUnitNo, pFortheMonthYear, pReceiptVoucherId, pRemainingAmt };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", Param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }
       
        public DataSet GetPartyandAmount(int PTId, string FortheMonth,string UnitNo, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter("@PropertyId", SqlDbType.BigInt);
                SqlParameter pForTheMonth = new SqlParameter("@FormDate", SqlDbType.NVarChar);
                SqlParameter pUnitNo = new SqlParameter("@UnitNo", SqlDbType.NVarChar);

                pAction.Value = 11;
                pPartyId.Value = PTId;
                pForTheMonth.Value = FortheMonth;
                pUnitNo.Value = UnitNo;

                 SqlParameter[] Param = new SqlParameter[] {pAction, pPartyId, pForTheMonth,pUnitNo };

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", Param);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet GetAmountOnMonth(Int32 PropertyId, Int32 PartyId,String MonthYear, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter("@PropertyId", SqlDbType.BigInt);
                SqlParameter pFortheMonthYear = new SqlParameter("@FortheMonthYear", SqlDbType.NVarChar);
                SqlParameter pPartyId = new SqlParameter("@PartyId", SqlDbType.BigInt);

                pAction.Value = 12;
                pPropertyId.Value = PropertyId;
                pFortheMonthYear.Value = MonthYear;
                pPartyId.Value = PartyId;

                SqlParameter[] Param = new SqlParameter[] { pAction, pPropertyId, pFortheMonthYear, pPartyId };

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", Param);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public int UpdateAmtPropertMonthmapping(ref ReceiptMaster Entity_Receipt, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ReceiptMaster._Action, SqlDbType.BigInt);


                SqlParameter pFromDate = new SqlParameter("@FormDate", SqlDbType.NVarChar);
                SqlParameter pPartyId = new SqlParameter(ReceiptMaster._PartyId, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(ReceiptMaster._PropertyId, SqlDbType.BigInt);
                SqlParameter pUnitNo = new SqlParameter("@UnitNo", SqlDbType.NVarChar);
                SqlParameter pFortheMonthYear = new SqlParameter("@FortheMonthYear", SqlDbType.NVarChar);
                SqlParameter pReceiptVoucherId = new SqlParameter("@ReceiptVoucherId", SqlDbType.BigInt);
                SqlParameter pRemainingAmt = new SqlParameter("@RemainingAmt", SqlDbType.Decimal);
                pAction.Value = 14;
                pFromDate.Value = Entity_Receipt.ForTheMonth;
                pPartyId.Value = Entity_Receipt.PartyId;
                pPropertyId.Value = Entity_Receipt.PropertyId;
                pUnitNo.Value = Entity_Receipt.UnitNo;
                pFortheMonthYear.Value = Entity_Receipt.FortheMonthYear;
                pReceiptVoucherId.Value = Entity_Receipt.ReceiptVoucherId;
                pRemainingAmt.Value = Entity_Receipt.RemainingAmt;

                SqlParameter[] Param = new SqlParameter[] { pAction, pFromDate, pPartyId, pPropertyId, pUnitNo, pFortheMonthYear, pReceiptVoucherId, pRemainingAmt };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_Receipt_II", Param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }
    }
}
