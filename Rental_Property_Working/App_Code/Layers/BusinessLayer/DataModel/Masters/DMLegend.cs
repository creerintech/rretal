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
    public class DMLegend:Utility.Setting
    {
        public int InsertLegend(ref Legend Entity_Legend, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(Legend._Action, SqlDbType.BigInt);
                SqlParameter pTitle = new SqlParameter(Legend._Title, SqlDbType.NVarChar);
                SqlParameter pCreatedBy = new SqlParameter(Legend._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(Legend._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pTitle.Value = Entity_Legend.Title;
                pCreatedBy.Value = Entity_Legend.UserId;
                pCreatedDate.Value = Entity_Legend.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pTitle,pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, Legend.SP_LegendMaster, param);

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

        public int UpdateLegend(ref Legend Entity_Legend, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(Legend._Action, SqlDbType.BigInt);
                SqlParameter pLegendId = new SqlParameter(Legend._LegendId, SqlDbType.BigInt);
                SqlParameter pTitle = new SqlParameter(Legend._Title, SqlDbType.NVarChar);

                SqlParameter pUpdatedBy = new SqlParameter(Legend._UserId, SqlDbType.BigInt);
                SqlParameter pUpdatedDate = new SqlParameter(Legend._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pLegendId.Value = Entity_Legend.LegendId;
                pTitle.Value = Entity_Legend.Title;
                pUpdatedBy.Value = Entity_Legend.UserId;
                pUpdatedDate.Value = Entity_Legend.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pLegendId, pTitle, pUpdatedBy, pUpdatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Legend.SP_LegendMaster, param);

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

        public int DeleteLegend(ref Legend Entity_Legend, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(Legend._Action, SqlDbType.BigInt);
                SqlParameter pLegendId = new SqlParameter(Legend._LegendId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(Legend._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(Legend._LoginDate, SqlDbType.DateTime);
                //SqlParameter pIsDeleted = new SqlParameter(EmployeeMaster._IsDeleted, SqlDbType.Bit);

                pAction.Value = 3;
                pLegendId.Value = Entity_Legend.LegendId;
                pDeletedBy.Value = Entity_Legend.UserId;
                pDeletedDate.Value = Entity_Legend.LoginDate;
               // pIsDeleted.Value = Entity_Legend.IsDeleted;

                SqlParameter[] param = new SqlParameter[] { pAction, pLegendId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Legend.SP_LegendMaster, param);

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

        public DataSet GetLegendForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(Legend._Action, SqlDbType.BigInt);
                SqlParameter pLegendId = new SqlParameter(Legend._LegendId, SqlDbType.BigInt);

                pAction.Value = 4;
                pLegendId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Legend.SP_LegendMaster, pAction, pLegendId);

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

        public DataSet GetLegend(string RepCondition, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(Legend._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(Legend._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Legend.SP_LegendMaster, pAction, PrepCondition);


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
                SqlParameter pAction = new SqlParameter(Legend._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(Legend._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 6;
                pRepCondition.Value = Name;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Legend.SP_LegendMaster, pAction, pRepCondition);

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
                SqlParameter pAction = new SqlParameter(Legend._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(Legend._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, Legend.SP_LegendMaster, oparamcol);

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


        //InsertDetails Records

        public int InsertLegendDET(ref Legend Entity_Legend, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(Legend._Action, SqlDbType.BigInt);
                SqlParameter pLegendSubT = new SqlParameter(Legend._LegendSubT, SqlDbType.NVarChar);
                SqlParameter pLegendId = new SqlParameter(Legend._LegendId, SqlDbType.BigInt);

                pAction.Value = 7;
                pLegendSubT.Value = Entity_Legend.LegendSubT;
                pLegendId.Value = Entity_Legend.LegendId;


                SqlParameter[] param = new SqlParameter[] { pAction, pLegendId, pLegendSubT };
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Legend.SP_LegendMaster, param);

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

        public DMLegend()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
