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
using System.Data.SqlClient;

using Build.Utility;
using Build.EntityClass;
using Build.DB;
using Build.DataModel;
using Build.DALSQLHelper;
using System.Collections.Generic;

namespace Build.DataModel
{

    public class DMReport : Setting
    {       
        public DMReport()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string[] GetSuggestedAllPartyName(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {
                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 3;
                MRepCondition.Value = prefixText;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_MIS_ListOfPropertyOnRentReport", oParmCol);

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

        public string[] GetSuggestedAllCompanyName(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 4;
                MRepCondition.Value = prefixText;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_MIS_ListOfPropertyOnRentReport", oParmCol);

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

        public DataSet GetPropertyOnRentDetails(string StrCondition, out string StrError)
        {
            DataSet ds = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pStrCond = new SqlParameter("@StrCond", SqlDbType.NVarChar);
              
                pAction.Value = 1;
                pStrCond.Value = StrCondition;
             

                SqlParameter[] Param = new SqlParameter[] { pAction, pStrCond };

                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_MIS_ListOfPropertyOnRentReport", Param);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }

        public DataSet GetPropertyRentExpiredDetails(string StrCondition, out string StrError)
        {
            DataSet ds = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter pFromDate = new SqlParameter("@FromDate", SqlDbType.NVarChar);
                //SqlParameter pToDate = new SqlParameter("@ToDate", SqlDbType.NVarChar);
                 SqlParameter pStrCond = new SqlParameter("@StrCond", SqlDbType.NVarChar);

                pAction.Value = 1;
                //pFromDate.Value = FromDate;
                //pToDate.Value = ToDate;
                pStrCond.Value = StrCondition;

                SqlParameter[] Param = new SqlParameter[] { pAction, pStrCond };

                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_MIS_ListOfPropertyRentExpired", Param);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }

        public DataSet GetMaintenaceregisterDetails(string StrCondition, out string StrError)
        {
            DataSet ds = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);               
                SqlParameter pStrCond = new SqlParameter("@StrCond", SqlDbType.NVarChar);

                pAction.Value = 2;                
                pStrCond.Value = StrCondition;

                SqlParameter[] Param = new SqlParameter[] { pAction, pStrCond };

                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_MIS_ListOfPropertyMaintainceDtls", Param);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }


        public DataSet GetReceiptForPrint(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pID = new SqlParameter("@ReceiptVoucherId", SqlDbType.BigInt);

                pAction.Value = 6;
                pID.Value = ID;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PrintReceipt", pAction, pID);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet FillReportInGrid1(out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                pAction.Value = 1;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_MIS_ListOfPropertyReport", oparamcol);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetExpenseOutReceiptForPrint(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pID = new SqlParameter("@ReceiptExpOutId", SqlDbType.BigInt);

                pAction.Value = 7;
                pID.Value = ID;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PrintReceipt", pAction, pID);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }
    }
}
