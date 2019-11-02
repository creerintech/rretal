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

    public class DMPropertyRentCard : Utility.Setting
    {
        public int InsertPC(ref PropertyRentCard Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                SqlParameter pPCNo = new SqlParameter(PropertyRentCard._PCNo, SqlDbType.NVarChar);
                //SqlParameter pPropertyName = new SqlParameter(PropertyRentCard._PropertyName, SqlDbType.NVarChar);
                SqlParameter pPropertyId = new SqlParameter(PropertyRentCard._PropertyId, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(PropertyRentCard._PartyId, SqlDbType.BigInt);
                SqlParameter pFlatTypeId = new SqlParameter(PropertyRentCard._FlatTypeId, SqlDbType.BigInt);
                SqlParameter pPropertyAddress = new SqlParameter(PropertyRentCard._PropertyAddress, SqlDbType.NVarChar);
                SqlParameter pUnitNo = new SqlParameter(PropertyRentCard._UnitNo, SqlDbType.NVarChar);
                SqlParameter pUnitArea = new SqlParameter(PropertyRentCard._UnitArea, SqlDbType.Decimal);
                SqlParameter pSqFt = new SqlParameter(PropertyRentCard._SqFt, SqlDbType.Decimal);
                SqlParameter pRent = new SqlParameter(PropertyRentCard._Rent, SqlDbType.Decimal);
                SqlParameter pCreatedBy = new SqlParameter(PropertyRentCard._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(PropertyRentCard._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pPCNo.Value = Entity_PC.PCNo;
                pPropertyId.Value = Entity_PC.PropertyId;
                pPartyId.Value = Entity_PC.PartyId;
                pFlatTypeId.Value = Entity_PC.FlatTypeId;
                pPropertyAddress.Value = Entity_PC.PropertyAddress;
                pUnitNo.Value = Entity_PC.UnitNo;
                pUnitArea.Value = Entity_PC.UnitArea;
                pSqFt.Value = Entity_PC.SqFt;
                pRent.Value = Entity_PC.Rent;
                pCreatedBy.Value = Entity_PC.UserId;
                pCreatedDate.Value = Entity_PC.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCNo, pPropertyId,pPartyId,pFlatTypeId,pPropertyAddress,pUnitNo,pUnitArea,pSqFt,pRent,
                                      pCreatedBy, pCreatedDate};

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, PropertyRentCard.SP_PropertyRentalCard, param);

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

        public int InsertPCDetail(ref PropertyRentCard Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                SqlParameter pPropertyRentCardId = new SqlParameter(PropertyRentCard._PropertyRentCardId, SqlDbType.BigInt);
                SqlParameter pFromDate = new SqlParameter(PropertyRentCard._FromDate, SqlDbType.DateTime);
                SqlParameter pToDate = new SqlParameter(PropertyRentCard._ToDate, SqlDbType.DateTime);
                SqlParameter pCompanyId = new SqlParameter(PropertyRentCard._CompanyId, SqlDbType.BigInt);
                SqlParameter pRentalAmt = new SqlParameter(PropertyRentCard._RentalAmt, SqlDbType.Decimal);

                SqlParameter pPropertyTaxAmt = new SqlParameter(PropertyRentCard._PropertyTaxAmt, SqlDbType.Decimal);
                SqlParameter pSocietyMaintenaceAmt = new SqlParameter(PropertyRentCard._SocietyMaintenaceAmt, SqlDbType.Decimal);
                SqlParameter pDepositAmt = new SqlParameter(PropertyRentCard._DepositAmt, SqlDbType.Decimal);
                SqlParameter pCollectedDate = new SqlParameter(PropertyRentCard._CollectedDate, SqlDbType.DateTime);
                SqlParameter pRemark = new SqlParameter(PropertyRentCard._Remark, SqlDbType.NVarChar);
                SqlParameter pFlagCheck = new SqlParameter(PropertyRentCard._FlagCheck, SqlDbType.Bit);
                SqlParameter pStatus = new SqlParameter(PropertyRentCard._Status, SqlDbType.NVarChar);
                SqlParameter pFlagReceiptType = new SqlParameter(PropertyRentCard._FlagReceiptType, SqlDbType.Bit);
                SqlParameter pGSTPerDetails = new SqlParameter(PropertyRentCard._GSTPerDetails, SqlDbType.Decimal);
                SqlParameter pGSTAmt = new SqlParameter(PropertyRentCard._GSTAmt, SqlDbType.Decimal);
                SqlParameter pAmount = new SqlParameter(PropertyRentCard._Amount, SqlDbType.Decimal);
                SqlParameter pTaxTemplateID = new SqlParameter(PropertyRentCard._TaxTemplateID, SqlDbType.BigInt);

                pAction.Value = 4;
                pPropertyRentCardId.Value = Entity_PC.PropertyRentCardId;
                pFromDate.Value = Entity_PC.FromDate;
                pToDate.Value = Entity_PC.ToDate;
                pCompanyId.Value = Entity_PC.CompanyId;
                pRentalAmt.Value = Entity_PC.RentalAmt;
                pPropertyTaxAmt.Value = Entity_PC.PropertyTaxAmt;
                pSocietyMaintenaceAmt.Value = Entity_PC.SocietyMaintenaceAmt;
                pDepositAmt.Value = Entity_PC.DepositAmt; 
                pCollectedDate.Value = Entity_PC.CollectedDate;
                pRemark.Value = Entity_PC.Remark;
                pFlagCheck.Value = Entity_PC.FlagCheck;
                pStatus.Value = Entity_PC.Status;
                pGSTPerDetails.Value = Entity_PC.GSTPerDetails;
                pGSTAmt.Value = Entity_PC.GSTAmt;
                pAmount.Value = Entity_PC.Amount;
                pFlagReceiptType.Value = Entity_PC.FlagReceiptType;
                pTaxTemplateID.Value = Entity_PC.TaxTemplateID;

                SqlParameter[] param = new SqlParameter[] { pAction, pPropertyRentCardId, pFromDate, pToDate, pCompanyId, pRentalAmt, pPropertyTaxAmt, pSocietyMaintenaceAmt, pDepositAmt, pCollectedDate,
                    pRemark, pFlagCheck, pStatus, pGSTPerDetails, pGSTAmt, pAmount, pFlagReceiptType,pTaxTemplateID };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, PropertyRentCard.SP_PropertyRentalCard, param);

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

        public DataSet FillCombo(out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                MAction.Value = 1;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyRentCard.SP_PropertyRentalCard, MAction);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public int UpdatetPropertyRentCard(ref PropertyRentCard Entity_PC, out string strerror)
        {
            strerror = string.Empty;
            int insertrow = 0;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);          
                SqlParameter pPropertyId = new SqlParameter(PropertyRentCard._PropertyId, SqlDbType.BigInt);
                SqlParameter pPropertyRentCardId = new SqlParameter(PropertyRentCard._PropertyRentCardId, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(PropertyRentCard._PartyId, SqlDbType.BigInt);
                SqlParameter pPCNo = new SqlParameter(PropertyRentCard._PCNo, SqlDbType.NVarChar);
                SqlParameter pPropertyName = new SqlParameter(PropertyRentCard._PropertyName, SqlDbType.NVarChar);
                SqlParameter pFlatTypeId = new SqlParameter(PropertyRentCard._FlatTypeId, SqlDbType.BigInt);
                SqlParameter pPropertyAddress = new SqlParameter(PropertyRentCard._PropertyAddress, SqlDbType.NVarChar);
                SqlParameter pUnitNo = new SqlParameter(PropertyRentCard._UnitNo, SqlDbType.NVarChar);
                SqlParameter pUnitArea = new SqlParameter(PropertyRentCard._UnitArea, SqlDbType.Decimal);
                SqlParameter pSqFt = new SqlParameter(PropertyRentCard._SqFt, SqlDbType.Decimal);
                SqlParameter pRent = new SqlParameter(PropertyRentCard._Rent, SqlDbType.Decimal);               
                SqlParameter pCreatedby = new SqlParameter(PropertyRentCard._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(PropertyRentCard._LoginDate, SqlDbType.DateTime);
                               
                pAction.Value = 7;
                pPCNo.Value = Entity_PC.PCNo;
                pPropertyId.Value = Entity_PC.PropertyId;
                pPartyId.Value = Entity_PC.PartyId;
                pPropertyRentCardId.Value = Entity_PC.PropertyRentCardId;
                pPropertyName.Value = Entity_PC.PropertyName;
                pFlatTypeId.Value = Entity_PC.FlatTypeId;
                pPropertyAddress.Value = Entity_PC.PropertyAddress;
                pUnitNo.Value = Entity_PC.UnitNo;
                pUnitArea.Value = Entity_PC.UnitArea;
                pSqFt.Value = Entity_PC.SqFt;
                pRent.Value = Entity_PC.Rent;
                pCreatedby.Value = Entity_PC.UserId;
                pCreatedDate.Value = Entity_PC.LoginDate;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pPCNo, pPropertyId, pPartyId, pPropertyRentCardId, pPropertyName, pFlatTypeId, pPropertyAddress, pUnitNo, pUnitArea, pSqFt, pRent, pCreatedby, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                insertrow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyRentCard.SP_PropertyRentalCard, ParamArray);

                if (insertrow > 0)
                    CommitTransaction();
                else
                    RollBackTransaction();
            }
            catch (Exception ex)
            {
                strerror = ex.Message;
                RollBackTransaction();
            }
            finally
            {
                Close();
            }
            return insertrow;
        }

        public DataSet GetPCNo(out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                MAction.Value = 2;

                Open(Setting.CONNECTION_STRING);

                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyRentCard.SP_PropertyRentalCard, MAction);

            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return Ds;
        }

        public DataSet GetProject(string RepCondition, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 6;
                pRepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyRentCard.SP_PropertyRentalCard, pAction, pRepCondition);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet GetPropertyToEdit(int Id, out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                MAction.Value = 5;

                SqlParameter MContractorID = new SqlParameter(PropertyRentCard._PropertyRentCardId, SqlDbType.BigInt);
                MContractorID.Value = Id;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyRentCard.SP_PropertyRentalCard, MAction, MContractorID);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }

            return Ds;
}

        public int DeleteProjectRent(ref PropertyRentCard Entity_PC, out string strerror)
        {
            strerror = string.Empty;
            int insertrow = 0;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                pAction.Value = 8;

                SqlParameter pPropertyId = new SqlParameter(PropertyRentCard._PropertyRentCardId, SqlDbType.BigInt);
                pPropertyId.Value = Entity_PC.PropertyRentCardId;

                SqlParameter pCreatedby = new SqlParameter(PropertyRentCard._UserId, SqlDbType.BigInt);
                pCreatedby.Value = Entity_PC.UserId;

                SqlParameter pCreatedDate = new SqlParameter(PropertyRentCard._LoginDate, SqlDbType.DateTime);
                pCreatedDate.Value = Entity_PC.LoginDate;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pPropertyId, pCreatedby, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                insertrow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyRentCard.SP_PropertyRentalCard, ParamArray);

                if (insertrow > 0)
                    CommitTransaction();
                else
                    RollBackTransaction();
            }
            catch (Exception ex)
            {
                strerror = ex.Message;
                RollBackTransaction();

            }
            finally
            {
                Close();
            }
            return insertrow;
        }

        public DMPropertyRentCard()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string[] GetSuggestRecord(string preFixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(PropertyRentCard._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 6;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, PropertyRentCard.SP_PropertyRentalCard, oparamcol);
               
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

        public DataSet GetDataOnProperty(int PropertyId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(PropertyRentCard._PropertyId, SqlDbType.BigInt);

                pAction.Value = 9;
                pPropertyId.Value = PropertyId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyRentalCard", pAction, pPropertyId);
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

        public string[] GetSuggestedRecordForUnit(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
               

                MAction.Value = 10;
                MRepCondition.Value = prefixText;
               
                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyRentalCard", oParmCol);

                if (dr != null && dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[1].ToString(), dr[0].ToString());
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

        public DataSet GetProjectId(string ProjectName, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 12;
                pRepCondition.Value = ProjectName;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyRentCard.SP_PropertyRentalCard, pAction, pRepCondition);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet GetDataOnUnitNo(string unit, int ProjectId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter("@UnitNo", SqlDbType.NVarChar);
                SqlParameter pProjectId = new SqlParameter("@PropertyId", SqlDbType.BigInt);


                pAction.Value = 11;
                pRepCondition.Value = unit;
                pProjectId.Value = ProjectId;

                SqlParameter[] oParmCol = new SqlParameter[] { pAction, pRepCondition, pProjectId };
                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, PropertyRentCard.SP_PropertyRentalCard, oParmCol);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet GetDataOnUnit(int PropertyId,Int32 UnitId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(PropertyRentCard._PropertyId, SqlDbType.BigInt);
                SqlParameter pFlatTypeId = new SqlParameter(PropertyRentCard._FlatTypeId, SqlDbType.BigInt);

                pAction.Value = 13;
                pPropertyId.Value = PropertyId;
                pFlatTypeId.Value = UnitId;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pPropertyId, pFlatTypeId };
                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyRentalCard", ParamArray);
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

        public DataSet ChkDuplicate(int ProjectId, int PartyId, string UnitNo, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(PropertyRentCard._PropertyId, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(PropertyRentCard._PartyId, SqlDbType.BigInt);
                SqlParameter pUnitNo = new SqlParameter(PropertyRentCard._UnitNo, SqlDbType.NVarChar);

                pAction.Value =14;
                pPropertyId.Value = ProjectId;
                pPartyId.Value = PartyId;
                pUnitNo.Value = UnitNo;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pPropertyId, pPartyId, pUnitNo };

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyRentalCard", ParamArray);
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

        public Int32 UpdatePropertyRentDtls(ref PropertyRentCard Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                SqlParameter PProRentDtlsId = new SqlParameter(PropertyRentCard._ProRentDtlsId, SqlDbType.BigInt);
                SqlParameter pPropertyRentCardId = new SqlParameter(PropertyRentCard._PropertyRentCardId, SqlDbType.BigInt);
                SqlParameter pFromDate = new SqlParameter(PropertyRentCard._FromDate, SqlDbType.DateTime);
                SqlParameter pToDate = new SqlParameter(PropertyRentCard._ToDate, SqlDbType.DateTime);
                SqlParameter pCompanyId = new SqlParameter(PropertyRentCard._CompanyId, SqlDbType.BigInt);
                SqlParameter pRentalAmt = new SqlParameter(PropertyRentCard._RentalAmt, SqlDbType.Decimal);
                SqlParameter pPropertyTaxAmt = new SqlParameter(PropertyRentCard._PropertyTaxAmt, SqlDbType.Decimal);
                SqlParameter pSocietyMaintenaceAmt = new SqlParameter(PropertyRentCard._SocietyMaintenaceAmt, SqlDbType.Decimal);
                SqlParameter pDepositAmt = new SqlParameter(PropertyRentCard._DepositAmt, SqlDbType.Decimal);
                SqlParameter pCollectedDate = new SqlParameter(PropertyRentCard._CollectedDate, SqlDbType.DateTime);
                SqlParameter pRemark = new SqlParameter(PropertyRentCard._Remark, SqlDbType.NVarChar);
                SqlParameter pFlagCheck = new SqlParameter(PropertyRentCard._FlagCheck, SqlDbType.Bit);
                SqlParameter pStatus = new SqlParameter(PropertyRentCard._Status, SqlDbType.NVarChar);
                SqlParameter pFlagReceiptType = new SqlParameter(PropertyRentCard._FlagReceiptType, SqlDbType.Bit);
                SqlParameter pGSTPerDetails = new SqlParameter(PropertyRentCard._GSTPerDetails, SqlDbType.Decimal);
                SqlParameter pGSTAmt = new SqlParameter(PropertyRentCard._GSTAmt, SqlDbType.Decimal);
                SqlParameter pAmount = new SqlParameter(PropertyRentCard._Amount, SqlDbType.Decimal);
                SqlParameter pTaxTemplateID = new SqlParameter(PropertyRentCard._TaxTemplateID, SqlDbType.BigInt);

                pAction.Value = 15;
                PProRentDtlsId.Value = Entity_PC.ProRentDtlsId;
                pPropertyRentCardId.Value = Entity_PC.PropertyRentCardId;
                pFromDate.Value = Entity_PC.FromDate;
                pToDate.Value = Entity_PC.ToDate;
                pCompanyId.Value = Entity_PC.CompanyId;
                pRentalAmt.Value = Entity_PC.RentalAmt;
                pPropertyTaxAmt.Value = Entity_PC.PropertyTaxAmt;
                pSocietyMaintenaceAmt.Value = Entity_PC.SocietyMaintenaceAmt;
                pDepositAmt.Value = Entity_PC.DepositAmt;
                pCollectedDate.Value = Entity_PC.CollectedDate;
                pRemark.Value = Entity_PC.Remark;
                pFlagCheck.Value = Entity_PC.FlagCheck;
                pStatus.Value = Entity_PC.Status;
                pGSTPerDetails.Value = Entity_PC.GSTPerDetails;
                pGSTAmt.Value = Entity_PC.GSTAmt;
                pAmount.Value = Entity_PC.Amount;
                pFlagReceiptType.Value = Entity_PC.FlagReceiptType;
                pTaxTemplateID.Value = Entity_PC.TaxTemplateID;

                SqlParameter[] Param = new SqlParameter[] { pAction, PProRentDtlsId, pPropertyRentCardId, pFromDate, pToDate, pCompanyId, pRentalAmt,
                    pPropertyTaxAmt, pSocietyMaintenaceAmt, pDepositAmt, pCollectedDate, pRemark, pFlagCheck, pStatus, pGSTPerDetails, pGSTAmt, pAmount, 
                    pFlagReceiptType,pTaxTemplateID };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyRentCard.SP_PropertyRentalCard, Param);

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

        public DataSet GetMonthfromNTodate(ref PropertyRentCard Entity_PC, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                SqlParameter pFromDate = new SqlParameter(PropertyRentCard._FromDate, SqlDbType.DateTime);
                SqlParameter pToDate = new SqlParameter(PropertyRentCard._ToDate, SqlDbType.DateTime);              

                pAction.Value = 16;
                pFromDate.Value = Entity_PC.FromDate;
                pToDate.Value = Entity_PC.ToDate;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pFromDate, pToDate };

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyRentalCard", ParamArray);
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

        public int InsertProjectMonth(ref PropertyRentCard Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
               
                SqlParameter pPropertyId = new SqlParameter(PropertyRentCard._PropertyId, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(PropertyRentCard._PartyId, SqlDbType.BigInt);
                SqlParameter pFortheMonthYear = new SqlParameter(PropertyRentCard._FortheMonthYear, SqlDbType.NVarChar);
                SqlParameter pReceiptVoucherId = new SqlParameter(PropertyRentCard._ReceiptVoucherId, SqlDbType.BigInt);
                SqlParameter pIsGenerated = new SqlParameter(PropertyRentCard._IsGenerated, SqlDbType.Bit);
                SqlParameter pRentalAmount = new SqlParameter(PropertyRentCard._RentalAmount, SqlDbType.Decimal);
                SqlParameter pPropertyRentCardId = new SqlParameter(PropertyRentCard._PropertyRentCardId, SqlDbType.BigInt);
                SqlParameter pProRentDtlsId = new SqlParameter(PropertyRentCard._ProRentDtlsId, SqlDbType.BigInt);
                SqlParameter pRemaingAmount = new SqlParameter(PropertyRentCard._RemaingAmount, SqlDbType.Decimal);

                pAction.Value = 17;             
                pPropertyId.Value = Entity_PC.PropertyId;
                pPartyId.Value = Entity_PC.PartyId;
                pFortheMonthYear.Value = Entity_PC.FortheMonthYear;
                pReceiptVoucherId.Value = Entity_PC.ReceiptVoucherId;
                pIsGenerated.Value = Entity_PC.IsGenerated;
                pRentalAmount.Value = Entity_PC.RentalAmount;
                pPropertyRentCardId.Value = Entity_PC.PropertyRentCardId;
                pProRentDtlsId.Value = Entity_PC.ProRentDtlsId;
                pRemaingAmount.Value = Entity_PC.RemaingAmount;

                SqlParameter[] param = new SqlParameter[] { pAction, pPropertyId, pPartyId, pFortheMonthYear, pReceiptVoucherId, pIsGenerated, pRentalAmount, pPropertyRentCardId, pProRentDtlsId, pRemaingAmount };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, PropertyRentCard.SP_PropertyRentalCard, param);

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

        public DataSet ChkDuplicateMonth(int PropertyId, int PartyId, string MonthName, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(PropertyRentCard._PropertyId, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(PropertyRentCard._PartyId, SqlDbType.BigInt);
                SqlParameter pFortheMonthYear = new SqlParameter(PropertyRentCard._FortheMonthYear, SqlDbType.NVarChar);

                pAction.Value = 18;
                pPropertyId.Value = PropertyId;
                pPartyId.Value = PartyId;
                pFortheMonthYear.Value = MonthName;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pPropertyId, pPartyId, pFortheMonthYear };

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyRentalCard", ParamArray);
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

        public int DeletePropertyMonth(ref PropertyRentCard Entity_PC, out string StrError)
        {
            StrError = string.Empty;
            int insertrow = 0;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyRentCard._Action, SqlDbType.BigInt);
                pAction.Value = 19;

                SqlParameter pProRentDtlsId = new SqlParameter(PropertyRentCard._ProRentDtlsId, SqlDbType.BigInt);
                pProRentDtlsId.Value = Entity_PC.ProRentDtlsId;


                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pProRentDtlsId};

                Open(CONNECTION_STRING);
                BeginTransaction();

                insertrow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyRentCard.SP_PropertyRentalCard, ParamArray);

                if (insertrow > 0)
                    CommitTransaction();
                else
                    RollBackTransaction();
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
                RollBackTransaction();

            }
            finally
            {
                Close();
            }
            return insertrow;
        }
    }
}