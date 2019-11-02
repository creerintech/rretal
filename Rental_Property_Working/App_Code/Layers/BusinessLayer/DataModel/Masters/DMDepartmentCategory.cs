using Build.DALSQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Build.EntityClass;

namespace Build.DataModel
{
    public class DMProperty:Utility.Setting
    {
        public int InsertPropertyMaster(ref PropertyMaster Entity_PM, out string StrError)
        {
             int iInsert = 0;
        StrError = string.Empty;
        try
        {
            SqlParameter pAction = new SqlParameter(PropertyMaster._Action, SqlDbType.BigInt);
            SqlParameter pProperty = new SqlParameter(PropertyMaster._Property, SqlDbType.NVarChar);
            SqlParameter pPropertyAddress = new SqlParameter(PropertyMaster._PropertyAddress, SqlDbType.NVarChar);
            SqlParameter pCompanyId = new SqlParameter(PropertyMaster._CompanyId, SqlDbType.BigInt);
            SqlParameter pPropertyTypeId = new SqlParameter(PropertyMaster._PropertyTypeId, SqlDbType.BigInt);
            SqlParameter pPropertySubTypeId = new SqlParameter(PropertyMaster._PropertySubTypeId, SqlDbType.BigInt);
            SqlParameter pCityId = new SqlParameter(PropertyMaster._CityId, SqlDbType.BigInt);
            SqlParameter pLocationId = new SqlParameter(PropertyMaster._LocationId, SqlDbType.BigInt);   
            SqlParameter pCreatedBy = new SqlParameter(PropertyMaster._UserId, SqlDbType.BigInt);
            SqlParameter pCreatedDate = new SqlParameter(PropertyMaster._LoginDate, SqlDbType.DateTime);

            pAction.Value = 1;
            pProperty.Value = Entity_PM.Property;
            pPropertyAddress.Value = Entity_PM.PropertyAddress;
            pCompanyId.Value = Entity_PM.CompanyId;
            pPropertyTypeId.Value = Entity_PM.PropertyTypeId;

            pPropertySubTypeId.Value = Entity_PM.PropertySubTypeId;
            pCityId.Value = Entity_PM.CityId;
            pLocationId.Value = Entity_PM.LocationId;     
            pCreatedBy.Value = Entity_PM.UserId;
            pCreatedDate.Value = Entity_PM.LoginDate;

            SqlParameter[] param = new SqlParameter[] { pAction, pProperty, pPropertyAddress, pCompanyId, pPropertyTypeId, pPropertySubTypeId, pCityId, pLocationId, pCreatedBy, pCreatedDate };
            Open(CONNECTION_STRING);
            BeginTransaction();
            iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaster.SP_PropertyMaster, param);

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

        public int UpdatePropertyMaster(ref PropertyMaster Entity_PM, out string StrError)
        {
            int iInsert = 0;
        StrError = string.Empty;
        try
        {
            SqlParameter pAction = new SqlParameter(PropertyMaster._Action, SqlDbType.BigInt);
            SqlParameter pPropertyId = new SqlParameter(PropertyMaster._PropertyId, SqlDbType.BigInt);
            SqlParameter pProperty = new SqlParameter(PropertyMaster._Property, SqlDbType.NVarChar);
            SqlParameter pPropertyAddress = new SqlParameter(PropertyMaster._PropertyAddress, SqlDbType.NVarChar);
            SqlParameter pCompanyId = new SqlParameter(PropertyMaster._CompanyId, SqlDbType.BigInt);
            SqlParameter pPropertyTypeId = new SqlParameter(PropertyMaster._PropertyTypeId, SqlDbType.BigInt);
            SqlParameter pPropertySubTypeId = new SqlParameter(PropertyMaster._PropertySubTypeId, SqlDbType.BigInt);
            SqlParameter pCityId = new SqlParameter(PropertyMaster._CityId, SqlDbType.BigInt);
            SqlParameter pLocationId = new SqlParameter(PropertyMaster._LocationId, SqlDbType.BigInt);  
            SqlParameter pCreatedBy = new SqlParameter(PropertyMaster._UserId, SqlDbType.BigInt);
            SqlParameter pCreatedDate = new SqlParameter(PropertyMaster._LoginDate, SqlDbType.DateTime);

            pAction.Value = 2;
            pPropertyId.Value = Entity_PM.PropertyId;
            pProperty.Value = Entity_PM.Property;
            pPropertyAddress.Value = Entity_PM.PropertyAddress;
            pCompanyId.Value = Entity_PM.CompanyId;
            pPropertyTypeId.Value = Entity_PM.PropertyTypeId;

            pPropertySubTypeId.Value = Entity_PM.PropertySubTypeId;
            pCityId.Value = Entity_PM.CityId;
            pLocationId.Value = Entity_PM.LocationId;  
            pCreatedBy.Value = Entity_PM.UserId;                                          
            pCreatedDate.Value = Entity_PM.LoginDate;

            SqlParameter[] param = new SqlParameter[] { pAction, pPropertyId, pProperty, pPropertyAddress, pCompanyId, pPropertyTypeId, pPropertySubTypeId, pCityId, pLocationId, pCreatedBy, pCreatedDate };

            Open(CONNECTION_STRING);
            BeginTransaction();

            iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaster.SP_PropertyMaster, param);

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

        public int DeletePropertyMaster(ref PropertyMaster Entity_PM, out string StrError)
        {
            int iDelete = 0;
        StrError = string.Empty;

        try
        {
            SqlParameter pAction = new SqlParameter(PropertyMaster._Action, SqlDbType.BigInt);
            SqlParameter pPropertyId = new SqlParameter(PropertyMaster._PropertyId, SqlDbType.BigInt);
            SqlParameter pDeletedBy = new SqlParameter(PropertyMaster._UserId, SqlDbType.BigInt);
            SqlParameter pDeletedDate = new SqlParameter(PropertyMaster._LoginDate, SqlDbType.DateTime);

            pAction.Value = 3;
            pPropertyId.Value = Entity_PM.PropertyId;
            pDeletedBy.Value = Entity_PM.UserId;
            pDeletedDate.Value = Entity_PM.LoginDate;

            SqlParameter[] param = new SqlParameter[] { pAction, pPropertyId, pDeletedBy, pDeletedDate };

            Open(CONNECTION_STRING);
            BeginTransaction();

            iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaster.SP_PropertyMaster, param);

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

        public DataSet ChkDuplicate(string Property,long CompanyId ,long PropertyId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@PropertyId", SqlDbType.BigInt);
                SqlParameter pName = new SqlParameter("@Property", SqlDbType.NVarChar);
                SqlParameter pCompanyId = new SqlParameter("@CompanyId", SqlDbType.BigInt);
                pAction.Value = 4;
                pName.Value = Property;
                pId.Value = PropertyId;
                pCompanyId.Value = CompanyId;

                SqlParameter[] param = new SqlParameter[] { pAction, pName, pId, pCompanyId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyMaster", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet FillReportGrid(string condition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = condition;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyMaster", pAction, PrepCondition);


            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataTable FillSalutation_Active()
        {
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                pAction.Value = 6;
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyMaster", pAction);
                if (Ds.Tables.Count > 0)
                    return Ds.Tables[0];
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { Close(); }

        }

        public DataSet BindCombo(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

                pAction.Value = 1;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_BindCombo", pAction);
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
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyMaster", oparamcol);

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

        public DataSet GetRocordtoEdit(int Id, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
             SqlParameter pAction = new SqlParameter(PropertyMaster._Action, SqlDbType.BigInt);
            SqlParameter pPropertyId = new SqlParameter(PropertyMaster._PropertyId, SqlDbType.BigInt);

            pAction.Value = 7;
            pPropertyId.Value = Id;

            Open(CONNECTION_STRING);

            Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaster.SP_PropertyMaster, pAction, pPropertyId);


            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }


    

        public DMProperty()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public int InsertPMDetail(ref PropertyMaster Entity_PM, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyMaster._Action, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(PropertyMaster._PropertyId, SqlDbType.BigInt);
                SqlParameter pFlatTypeId = new SqlParameter(PropertyMaster._FlatTypeId, SqlDbType.BigInt);
                SqlParameter pUnitArea = new SqlParameter(PropertyMaster._UnitArea, SqlDbType.Decimal);
                SqlParameter pUnitNo = new SqlParameter(PropertyMaster._UnitNo, SqlDbType.NVarChar);
                SqlParameter pSocietyMaintenaceAmt = new SqlParameter(PropertyMaster._SocietyMaintenaceAmt, SqlDbType.Decimal);
                SqlParameter pPropertyTaxAmt = new SqlParameter(PropertyMaster._PropertyTaxAmt, SqlDbType.Decimal);
               


                pAction.Value = 9;
                pPropertyId.Value = Entity_PM.PropertyId;
                pFlatTypeId.Value = Entity_PM.FlatTypeId;
                pUnitArea.Value = Entity_PM.UnitArea;
                pUnitNo.Value = Entity_PM.UnitNo;
                pSocietyMaintenaceAmt.Value = Entity_PM.SocietyMaintenaceAmt;
                pPropertyTaxAmt.Value = Entity_PM.PropertyTaxAmt;

                SqlParameter[] param = new SqlParameter[] { pAction, pPropertyId, pFlatTypeId, pUnitArea, pUnitNo, pSocietyMaintenaceAmt, pPropertyTaxAmt};

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaster.SP_PropertyMaster, param);

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

        public string[] GetSuggestedAllProjectName(string prefixText)
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

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_MIS_ListOfPropertyReport", oParmCol);

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

        public DataSet FillCheckReportGridForProperty(int PropID, out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);               
                SqlParameter pPropID = new SqlParameter("@PropertyId", SqlDbType.Int);
                

                pAction.Value = 2;
                pPropID.Value = PropID;
              
                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pPropID };

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




        public int InsertPMExpDetail(ref PropertyMaster Entity_Property, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyMaster._Action, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(PropertyMaster._PropertyId, SqlDbType.BigInt);
                SqlParameter pExpenseHdId = new SqlParameter(PropertyMaster._ExpenseHdId, SqlDbType.BigInt);
                SqlParameter pAmount = new SqlParameter(PropertyMaster._Amount, SqlDbType.Decimal);             

                pAction.Value = 10;
                pPropertyId.Value = Entity_Property.PropertyId;
                pExpenseHdId.Value = Entity_Property.ExpenseHdId;
                pAmount.Value = Entity_Property.Amount;

                SqlParameter[] param = new SqlParameter[] { pAction, pPropertyId, pExpenseHdId, pAmount};

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaster.SP_PropertyMaster, param);

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

        public DataSet GetDataOnProperty(int PTId, out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter(PropertyMaster._Action, SqlDbType.BigInt);
                MAction.Value = 11;
                SqlParameter MPropertyId = new SqlParameter(PropertyMaster._PropertyTypeId, SqlDbType.BigInt);
                MPropertyId.Value = PTId;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaster.SP_PropertyMaster, MAction, MPropertyId);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }

            return Ds;
        }

        public DataSet GetDataOnCity(int CTId, out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter(PropertyMaster._Action, SqlDbType.BigInt);
                MAction.Value = 12;
                SqlParameter MPropertyId = new SqlParameter("@CityId", SqlDbType.BigInt);
                MPropertyId.Value = CTId;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaster.SP_PropertyMaster, MAction, MPropertyId);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }

            return Ds;
        }
    }
}