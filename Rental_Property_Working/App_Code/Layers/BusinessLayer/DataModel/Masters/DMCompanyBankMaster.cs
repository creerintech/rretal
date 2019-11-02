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
    public class DMCompanyBankMaster:Utility.Setting
    {
        public DataSet FillCombo(int EmpID, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(CompanyBankMaster._Action, SqlDbType.BigInt);
                SqlParameter pEmpID = new SqlParameter("@EmpID", SqlDbType.BigInt);

                pAction.Value = 7;
                pEmpID.Value = EmpID;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, CompanyBankMaster.SP_CompanyBankMaster, pAction, pEmpID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet GetCompany(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(CompanyBankMaster._Action, SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter(CompanyBankMaster._PCId, SqlDbType.BigInt);

                pAction.Value = 10;
                pId.Value = ID;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure,CompanyBankMaster.SP_CompanyBankMaster, pAction, pId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet ChkDuplicate(string Name, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(CompanyBankMaster._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(CompanyBankMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 8;
                pRepCondition.Value = Name;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, CompanyBankMaster.SP_CompanyBankMaster, pAction, pRepCondition);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public int InsertRecord(ref CompanyBankMaster Entity_Call, out string strError)
        {
            int iInsert = 0;
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(CompanyBankMaster._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(CompanyBankMaster._PCId, SqlDbType.BigInt);
                SqlParameter pCreatedBy = new SqlParameter(CompanyBankMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(CompanyBankMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pPCId.Value = Entity_Call.PCId;
                pCreatedBy.Value = Entity_Call.UserId;
                pCreatedDate.Value = Entity_Call.LoginDate;

                SqlParameter[] Param = new SqlParameter[] { pAction, pPCId, pCreatedBy, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, CompanyBankMaster.SP_CompanyBankMaster, Param);

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
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int InsertDetailsRecord(ref CompanyBankMaster Entity_Call, out string strError)
        {
            int iInsert = 0;
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pCompanyBankId = new SqlParameter(CompanyBankMaster._CompanyBankId, SqlDbType.BigInt);
                SqlParameter pProjectCompanyId = new SqlParameter(CompanyBankMaster._ProjectCompanyId, SqlDbType.BigInt);
                SqlParameter pBankTypeId = new SqlParameter(CompanyBankMaster._BankTypeId, SqlDbType.BigInt);
                SqlParameter pBankName = new SqlParameter(CompanyBankMaster._BankName, SqlDbType.NVarChar);
                SqlParameter pBranch = new SqlParameter(CompanyBankMaster._Branch, SqlDbType.NVarChar);
                SqlParameter pAccountNo = new SqlParameter(CompanyBankMaster._AccountNo, SqlDbType.NVarChar);
                SqlParameter pRTGSNo = new SqlParameter(CompanyBankMaster._RTGSNo, SqlDbType.NVarChar);
                SqlParameter pChequeDrawnAccName = new SqlParameter(CompanyBankMaster._ChequeDrawnAccName, SqlDbType.NVarChar);

                pAction.Value = 6;
                pCompanyBankId.Value = Entity_Call.CompanyBankId;
                pProjectCompanyId.Value = Entity_Call.ProjectCompanyId;
                pBankTypeId.Value = Entity_Call.BankTypeId;
                pBankName.Value = Entity_Call.BankName;
                pBranch.Value = Entity_Call.Branch;
                pAccountNo.Value = Entity_Call.AccountNo;
                pRTGSNo.Value = Entity_Call.RTGSNo;
                pChequeDrawnAccName.Value = Entity_Call.ChequeDrawnAccName;

                SqlParameter[] Param = new SqlParameter[] { pAction, pCompanyBankId, pProjectCompanyId, pBankTypeId, pBankName, pBranch, pAccountNo, pRTGSNo, pChequeDrawnAccName };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, CompanyBankMaster.SP_CompanyBankMaster, Param);

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
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public DataSet GetList(string RepCondition, out string strError)
        {
            strError = "";
            DataSet ds = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(CompanyBankMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(CompanyBankMaster._StrCondition, SqlDbType.NVarChar);
                pAction.Value = 9;
                PrepCondition.Value = RepCondition;


                Open(CONNECTION_STRING);

                ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, CompanyBankMaster.SP_CompanyBankMaster, pAction, PrepCondition);

            }
            catch (Exception ex)
            {
                //strError = ex.Message;
                string msg = ex.Message;
            }
            finally
            {

            }
            return ds;

        }

        public DataSet GetRecordForEdit(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(CompanyBankMaster._Action, SqlDbType.BigInt);
                SqlParameter pPSId = new SqlParameter(CompanyBankMaster._CompanyBankId, SqlDbType.BigInt);

                pAction.Value = 4;
                pPSId.Value = ID;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, CompanyBankMaster.SP_CompanyBankMaster, pAction, pPSId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public int UpdateRecord(ref CompanyBankMaster Entity_Call, out string strError)
        {
            int iInsert = 0;
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(CompanyBankMaster._Action, SqlDbType.BigInt);
                SqlParameter pPSId = new SqlParameter(CompanyBankMaster._CompanyBankId, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(CompanyBankMaster._PCId, SqlDbType.BigInt);

                SqlParameter pCreatedBy = new SqlParameter(CompanyBankMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(CompanyBankMaster._LoginDate, SqlDbType.DateTime);


                pAction.Value = 2;
                pPSId.Value = Entity_Call.CompanyBankId;
                pPCId.Value = Entity_Call.PCId;

                pCreatedBy.Value = Entity_Call.UserId;
                pCreatedDate.Value = Entity_Call.LoginDate;

                SqlParameter[] Param = new SqlParameter[] { pAction, pPSId, pPCId, pCreatedBy, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, CompanyBankMaster.SP_CompanyBankMaster, Param);

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
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int DeleteRecord(ref CompanyBankMaster Entity_Call, out string strError)
        {
            int iDelete = 0;
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(CompanyBankMaster._Action, SqlDbType.BigInt);
                SqlParameter pPSId = new SqlParameter(CompanyBankMaster._CompanyBankId, SqlDbType.BigInt);

                SqlParameter pDeletedBy = new SqlParameter(CompanyBankMaster._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(CompanyBankMaster._LoginDate, SqlDbType.DateTime);
                //   SqlParameter pIsDeleted = new SqlParameter(ProjectSaleRate._IsDeleted, SqlDbType.Bit);

                pAction.Value = 3;
                pPSId.Value = Entity_Call.CompanyBankId;

                pDeletedBy.Value = Entity_Call.UserId;
                pDeletedDate.Value = Entity_Call.LoginDate;
                //   pIsDeleted.Value = Entity_Call.IsDeleted;

                SqlParameter[] Param = new SqlParameter[] { pAction, pPSId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, CompanyBankMaster.SP_CompanyBankMaster, Param);

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
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iDelete;
        }

        public string[] GetSuggestedRecord(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter(CompanyBankMaster._Action, SqlDbType.VarChar);
                SqlParameter MRepCondition = new SqlParameter(CompanyBankMaster._StrCondition, SqlDbType.NVarChar);

                MAction.Value = 5;
                MRepCondition.Value = prefixText;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(Setting.CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, CompanyBankMaster.SP_CompanyBankMaster, oParmCol);

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
        public DMCompanyBankMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
