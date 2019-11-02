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
    public class DMPropertyMaster : Utility.Setting
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
            SqlParameter pCreatedBy = new SqlParameter(PropertyMaster._UserId, SqlDbType.BigInt);
            SqlParameter pCreatedDate = new SqlParameter(PropertyMaster._LoginDate, SqlDbType.DateTime);

            pAction.Value = 1;
            pProperty.Value = Entity_PM.Property;
            pPropertyAddress.Value = Entity_PM.PropertyAddress;
            pCompanyId.Value = Entity_PM.CompanyId;             
            pCreatedBy.Value = Entity_PM.UserId;
            pCreatedDate.Value = Entity_PM.LoginDate;

            SqlParameter[] param = new SqlParameter[] { pAction, pProperty, pPropertyAddress, pCompanyId, pCreatedBy, pCreatedDate };
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
            SqlParameter pCreatedBy = new SqlParameter(PropertyMaster._UserId, SqlDbType.BigInt);
            SqlParameter pCreatedDate = new SqlParameter(PropertyMaster._LoginDate, SqlDbType.DateTime);

            pAction.Value = 2;
            pPropertyId.Value = Entity_PM.PropertyId;
            pProperty.Value = Entity_PM.Property;
            pPropertyAddress.Value = Entity_PM.PropertyAddress;
            pCompanyId.Value = Entity_PM.CompanyId;
            pCreatedBy.Value = Entity_PM.UserId;
            pCreatedDate.Value = Entity_PM.LoginDate;

            SqlParameter[] param = new SqlParameter[] { pAction, pPropertyId, pProperty, pPropertyAddress, pCompanyId, pCreatedBy, pCreatedDate };

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



	public DMPropertyMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
}
