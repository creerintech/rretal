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
using Build.Utility;
using Build.EntityClass;
using Build.DB;
using Build.DataModel;
using Build.DALSQLHelper;

namespace Build.DataModel
{
    public class DMLocationMaster:Utility.Setting
    {
        public int InsertRecord(ref LocationMaster Entity_call, out string strError)
        {
            int iInsert = 0;
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(LocationMaster._Action, SqlDbType.BigInt);
                SqlParameter pLocationName = new SqlParameter(LocationMaster._LocationName, SqlDbType.NVarChar);
                SqlParameter pCityId = new SqlParameter(LocationMaster._CityId, SqlDbType.BigInt);
                SqlParameter pCreatedBy = new SqlParameter(LocationMaster._LoginId, SqlDbType.BigInt);
                SqlParameter PCreatedDate = new SqlParameter(LocationMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pLocationName.Value = Entity_call.LocationName;
                pCityId.Value = Entity_call.CityId;
                pCreatedBy.Value = Entity_call.LoginId;
                PCreatedDate.Value = Entity_call.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pLocationName, pCityId, pCreatedBy, PCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, LocationMaster.SP_LocationMaster, param);

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

        public int UpdateRecord(ref LocationMaster Entity_Call, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(LocationMaster._Action, SqlDbType.BigInt);
                SqlParameter pLocationId = new SqlParameter(LocationMaster._LocationId, SqlDbType.BigInt);
                SqlParameter pLocationName = new SqlParameter(LocationMaster._LocationName, SqlDbType.NVarChar);
                SqlParameter pCityId = new SqlParameter(LocationMaster._CityId, SqlDbType.BigInt);
                SqlParameter pCreatedBy = new SqlParameter(LocationMaster._LoginId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(LocationMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pLocationId.Value = Entity_Call.LocationId;
                pLocationName.Value = Entity_Call.LocationName;
                pCityId.Value = Entity_Call.CityId;               
                pCreatedBy.Value = Entity_Call.LoginId;
                pCreatedDate.Value = Entity_Call.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pLocationId, pLocationName, pCityId, pCreatedBy, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, LocationMaster.SP_LocationMaster, param);
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

        public int DeleteRecord(ref LocationMaster EntityCall, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(LocationMaster._Action, SqlDbType.BigInt);
                SqlParameter PLocationId = new SqlParameter(LocationMaster._LocationId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(LocationMaster._LoginId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(LocationMaster._LoginDate, SqlDbType.DateTime);
                pAction.Value = 3;
                PLocationId.Value = EntityCall.LocationId;
                pDeletedBy.Value = EntityCall.LoginId;
                pDeletedDate.Value = EntityCall.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, PLocationId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, LocationMaster.SP_LocationMaster, param);

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

        public DataSet GetLocationForEdit(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(LocationMaster._Action, SqlDbType.BigInt);
                SqlParameter PLocationId = new SqlParameter(LocationMaster._LocationId, SqlDbType.BigInt);

                pAction.Value = 4;
                PLocationId.Value = ID;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, LocationMaster.SP_LocationMaster, pAction, PLocationId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet GetLocation(string RepCondition, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(LocationMaster._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(LocationMaster._StrCondition, SqlDbType.NVarChar);


                pAction.Value = 5;
                pRepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, LocationMaster.SP_LocationMaster, pAction, pRepCondition);


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

        public DataSet ChkDuplicate(string Name, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(LocationMaster._Action, SqlDbType.BigInt);
                SqlParameter PRepCondition = new SqlParameter(LocationMaster._StrCondition, SqlDbType.NVarChar);
                pAction.Value = 6;
                PRepCondition.Value = Name;
                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, LocationMaster.SP_LocationMaster,
                    pAction, PRepCondition);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
            return DS;
        }

        public string[] GetSuggestRecord(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(LocationMaster._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(LocationMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                pRepCondition.Value = prefixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, LocationMaster.SP_LocationMaster, oparamcol);
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

        public DataSet BindCombo(out string StrError)
        {
            DataSet ds = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                
                pAction.Value = 7;
                

                Open(CONNECTION_STRING);

                ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_LocationMaster", pAction);
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


        public DMLocationMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

}