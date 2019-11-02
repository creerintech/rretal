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
    public class DMPropertyPartyMaster : Utility.Setting
    {


        public int InsertPartyMaster(ref PropertyPartyMaster Entity_PM, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyPartyMaster._Action, SqlDbType.BigInt);
                SqlParameter pPartyName = new SqlParameter(PropertyPartyMaster._PartyName, SqlDbType.NVarChar);
                SqlParameter pPartyAddress = new SqlParameter(PropertyPartyMaster._PartyAddress, SqlDbType.NVarChar);
                SqlParameter pPEmailId = new SqlParameter(PropertyPartyMaster._PEmailId, SqlDbType.NVarChar);
                SqlParameter pPmobileNo = new SqlParameter(PropertyPartyMaster._PmobileNo, SqlDbType.NVarChar);
                SqlParameter pPTelNo = new SqlParameter(PropertyPartyMaster._PTelNo, SqlDbType.NVarChar);
                SqlParameter pPWebsite = new SqlParameter(PropertyPartyMaster._PWebsite, SqlDbType.NVarChar);
                SqlParameter pContPerName = new SqlParameter(PropertyPartyMaster._ContPerName, SqlDbType.NVarChar);
                SqlParameter pContPerAddress = new SqlParameter(PropertyPartyMaster._ContPerAddress, SqlDbType.NVarChar);
                SqlParameter pCEmailId = new SqlParameter(PropertyPartyMaster._CEmailId, SqlDbType.NVarChar);
                SqlParameter pCMobileNo = new SqlParameter(PropertyPartyMaster._CMobileNo, SqlDbType.NVarChar);
                SqlParameter pCTelNo = new SqlParameter(PropertyPartyMaster._CTelNo, SqlDbType.NVarChar);
                SqlParameter pGSTNo = new SqlParameter(PropertyPartyMaster._GSTNo, SqlDbType.NVarChar);
                SqlParameter pCAdharCardNo = new SqlParameter(PropertyPartyMaster._CAdharCardNo, SqlDbType.NVarChar);
                SqlParameter pPANNO = new SqlParameter(PropertyPartyMaster._PANNO, SqlDbType.NVarChar);
                SqlParameter pNote = new SqlParameter(PropertyPartyMaster._Note, SqlDbType.NVarChar);
                SqlParameter pCreatedBy = new SqlParameter(PropertyPartyMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(PropertyPartyMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pPartyName.Value = Entity_PM.PartyName;
                pPartyAddress.Value = Entity_PM.PartyAddress;
                pPEmailId.Value = Entity_PM.PEmailId;
                pPmobileNo.Value = Entity_PM.PmobileNo;
                pPTelNo.Value = Entity_PM.PTelNo;
                pPWebsite.Value = Entity_PM.PWebsite;
                pContPerName.Value = Entity_PM.ContPerName;
                pContPerAddress.Value = Entity_PM.ContPerAddress;
                pCEmailId.Value = Entity_PM.CEmailId;
                pCMobileNo.Value = Entity_PM.CMobileNo;
                pCTelNo.Value = Entity_PM.CTelNo;
                pGSTNo.Value = Entity_PM.GSTNo;
                pCAdharCardNo.Value = Entity_PM.CAdharCardNo;
                pPANNO.Value = Entity_PM.PANNO;
                pNote.Value = Entity_PM.Note;
                pCreatedBy.Value = Entity_PM.UserId;
                pCreatedDate.Value = Entity_PM.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pPartyName, pPartyAddress, pPEmailId, pPmobileNo, pPTelNo,
                    pPWebsite,pContPerName, pContPerAddress,pCEmailId,pCMobileNo,pCTelNo,pGSTNo,pCAdharCardNo,pPANNO,pNote,pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, PropertyPartyMaster.SP_PartyMaster, param);

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



        public int UpdatePartyMaster(ref PropertyPartyMaster Entity_PM, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyPartyMaster._Action, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(PropertyPartyMaster._PartyId, SqlDbType.BigInt);
                SqlParameter pPartyName = new SqlParameter(PropertyPartyMaster._PartyName, SqlDbType.NVarChar);
                SqlParameter pPartyAddress = new SqlParameter(PropertyPartyMaster._PartyAddress, SqlDbType.NVarChar);
                SqlParameter pPEmailId = new SqlParameter(PropertyPartyMaster._PEmailId, SqlDbType.NVarChar);
                SqlParameter pPmobileNo = new SqlParameter(PropertyPartyMaster._PmobileNo, SqlDbType.NVarChar);
                SqlParameter pPTelNo = new SqlParameter(PropertyPartyMaster._PTelNo, SqlDbType.NVarChar);
                SqlParameter pPWebsite = new SqlParameter(PropertyPartyMaster._PWebsite, SqlDbType.NVarChar);
                SqlParameter pContPerName = new SqlParameter(PropertyPartyMaster._ContPerName, SqlDbType.NVarChar);
                SqlParameter pContPerAddress = new SqlParameter(PropertyPartyMaster._ContPerAddress, SqlDbType.NVarChar);
                SqlParameter pCEmailId = new SqlParameter(PropertyPartyMaster._CEmailId, SqlDbType.NVarChar);
                SqlParameter pCMobileNo = new SqlParameter(PropertyPartyMaster._CMobileNo, SqlDbType.NVarChar);
                SqlParameter pCTelNo = new SqlParameter(PropertyPartyMaster._CTelNo, SqlDbType.NVarChar);
                SqlParameter pGSTNo = new SqlParameter(PropertyPartyMaster._GSTNo, SqlDbType.NVarChar);
                SqlParameter pCAdharCardNo = new SqlParameter(PropertyPartyMaster._CAdharCardNo, SqlDbType.NVarChar);
                SqlParameter pPANNO = new SqlParameter(PropertyPartyMaster._PANNO, SqlDbType.NVarChar);
                SqlParameter pNote = new SqlParameter(PropertyPartyMaster._Note, SqlDbType.NVarChar);
                SqlParameter pCreatedBy = new SqlParameter(PropertyPartyMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(PropertyPartyMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pPartyId.Value = Entity_PM.PartyId;
                pPartyName.Value = Entity_PM.PartyName;
                pPartyAddress.Value = Entity_PM.PartyAddress;
                pPEmailId.Value = Entity_PM.PEmailId;
                pPmobileNo.Value = Entity_PM.PmobileNo;
                pPTelNo.Value = Entity_PM.PTelNo;
                pPWebsite.Value = Entity_PM.PWebsite;
                pContPerName.Value = Entity_PM.ContPerName;
                pContPerAddress.Value = Entity_PM.ContPerAddress;
                pCEmailId.Value = Entity_PM.CEmailId;
                pCMobileNo.Value = Entity_PM.CMobileNo;
                pCTelNo.Value = Entity_PM.CTelNo;
                pGSTNo.Value = Entity_PM.GSTNo;
                pCAdharCardNo.Value = Entity_PM.CAdharCardNo;
                pPANNO.Value = Entity_PM.PANNO;
                pNote.Value = Entity_PM.Note;
                pCreatedBy.Value = Entity_PM.UserId;
                pCreatedDate.Value = Entity_PM.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pPartyId,  pPartyName, pPartyAddress, pPEmailId, pPmobileNo, pPTelNo, pPWebsite,pContPerName,
                    pContPerAddress,pCEmailId,pCMobileNo,pCTelNo,pGSTNo,pCAdharCardNo,pPANNO,pNote, pCreatedBy, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyPartyMaster.SP_PartyMaster, param);

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

        public int DeletePartyMaster(ref PropertyPartyMaster Entity_PM, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(PropertyPartyMaster._Action, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(PropertyPartyMaster._PartyId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(PropertyPartyMaster._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(PropertyPartyMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pPartyId.Value = Entity_PM.PartyId;
                pDeletedBy.Value = Entity_PM.UserId;
                pDeletedDate.Value = Entity_PM.LoginDate;
                // pIsDeleted.Value = Entity_Country.IsDeleted;

                SqlParameter[] param = new SqlParameter[] { pAction, pPartyId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyPartyMaster.SP_PartyMaster, param);

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

        public DataSet GetPartyMaster(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(PropertyPartyMaster._Action, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(PropertyPartyMaster._PartyId, SqlDbType.BigInt);

                pAction.Value = 4;
                pPartyId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyPartyMaster.SP_PartyMaster, pAction, pPartyId);

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

        public DataSet GetProjectTypeList(string RepCondition, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(PropertyPartyMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(PropertyPartyMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyPartyMaster.SP_PartyMaster, pAction, PrepCondition);


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

        public DataSet ChkDuplicate(string Name, long PartyId, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyPartyMaster._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(PropertyPartyMaster._StrCondition, SqlDbType.NVarChar);
                SqlParameter pPartyId = new SqlParameter(PropertyPartyMaster._PartyId, SqlDbType.BigInt);

                pAction.Value = 6;
                pRepCondition.Value = Name;
                pPartyId.Value = PartyId;

                SqlParameter[] param = new SqlParameter[] { pAction, pRepCondition, pPartyId };

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, PropertyPartyMaster.SP_PartyMaster, param);

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
                SqlParameter pAction = new SqlParameter(PropertyPartyMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(PropertyPartyMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, PropertyPartyMaster.SP_PartyMaster, oparamcol);

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


   

        public DMPropertyPartyMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}