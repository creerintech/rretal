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

    public class DMFlatTypeMaster:Utility.Setting
    {
        public int InsertFlatType(ref FlatTypeMaster Entity_FlatType, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FlatTypeMaster._Action, SqlDbType.BigInt);
                SqlParameter pFlatType = new SqlParameter(FlatTypeMaster._FlatType, SqlDbType.NVarChar);
                SqlParameter pProjectTypeID = new SqlParameter(FlatTypeMaster._ProjectTypeID, SqlDbType.BigInt);

                SqlParameter pCreatedBy = new SqlParameter(FlatTypeMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(FlatTypeMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pFlatType.Value = Entity_FlatType.FlatType;
                pProjectTypeID.Value = Entity_FlatType.ProjectTypeID;
                pCreatedBy.Value = Entity_FlatType.UserId;
                pCreatedDate.Value = Entity_FlatType.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pFlatType, pProjectTypeID, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, FlatTypeMaster.SP_FlatTypeMaster, param);

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

        public int UpdateFlatType(ref FlatTypeMaster Entity_FlatType, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FlatTypeMaster._Action, SqlDbType.BigInt);
                SqlParameter pFlatTypeId = new SqlParameter(FlatTypeMaster._FlatTypeId, SqlDbType.BigInt);
                SqlParameter pFlatType = new SqlParameter(FlatTypeMaster._FlatType, SqlDbType.NVarChar);
                SqlParameter pProjectTypeID = new SqlParameter(FlatTypeMaster._ProjectTypeID, SqlDbType.BigInt);
                SqlParameter pCreatedBy = new SqlParameter(FlatTypeMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(FlatTypeMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pFlatTypeId.Value = Entity_FlatType.FlatTypeId;
                pFlatType.Value = Entity_FlatType.FlatType;
                pProjectTypeID.Value = Entity_FlatType.ProjectTypeID;
                pCreatedBy.Value = Entity_FlatType.UserId;
                pCreatedDate.Value = Entity_FlatType.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pFlatTypeId, pFlatType, pProjectTypeID, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, FlatTypeMaster.SP_FlatTypeMaster, param);

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

        public int DeleteFlatType(ref FlatTypeMaster Entity_FlatType, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(FlatTypeMaster._Action, SqlDbType.BigInt);
                SqlParameter pFlatTypeId = new SqlParameter(FlatTypeMaster._FlatTypeId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(FlatTypeMaster._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(FlatTypeMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pFlatTypeId.Value = Entity_FlatType.FlatTypeId;
                pDeletedBy.Value = Entity_FlatType.UserId;
                pDeletedDate.Value = Entity_FlatType.LoginDate;
                // pIsDeleted.Value = Entity_Country.IsDeleted;

                SqlParameter[] param = new SqlParameter[] { pAction, pFlatTypeId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, FlatTypeMaster.SP_FlatTypeMaster, param);

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

        public DataSet GetFlatTypeForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(FlatTypeMaster._Action, SqlDbType.BigInt);
                SqlParameter pFlatTypeId = new SqlParameter(FlatTypeMaster._FlatTypeId, SqlDbType.BigInt);

                pAction.Value = 4;
                pFlatTypeId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, FlatTypeMaster.SP_FlatTypeMaster, pAction, pFlatTypeId);

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

        public DataSet GetFlatTypeList(string RepCondition, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(FlatTypeMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(FlatTypeMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, FlatTypeMaster.SP_FlatTypeMaster, pAction, PrepCondition);


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
                SqlParameter pAction = new SqlParameter(FlatTypeMaster._Action, SqlDbType.BigInt);
                
                SqlParameter pRepCondition = new SqlParameter(FlatTypeMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 6;
               
                pRepCondition.Value = Name;

                Open(CONNECTION_STRING);
                SqlParameter[] param = { pAction, pRepCondition };
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, FlatTypeMaster.SP_FlatTypeMaster,param);

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

        public string[] GetSuggestRecord(string preFixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(FlatTypeMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(FlatTypeMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, FlatTypeMaster.SP_FlatTypeMaster, oparamcol);

                if (dr != null && dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[0].ToString(),
                            dr[1].ToString());

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


        public DataSet GetProjectType(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FlatTypeMaster._Action, SqlDbType.BigInt);

                pAction.Value = 7;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, FlatTypeMaster.SP_FlatTypeMaster, pAction);

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

        public DMFlatTypeMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
