using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Practice.Areas.LOC_Country.Models;

namespace Practice.DAL.LOC_CountryDAL;

public class LOC_CountryDALBase : DALHelper
{
    #region SelectALL

    public DataTable PR_Country_SelectALL()
    {
        try
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Country_SelectALL");
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dataTable.Load(dataReader);
            }

            return dataTable;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region Delete

    public bool PR_Country_DeleteByID(int CountryID)
    {
        try
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Country_DeleteByID");
            sqlDatabase.AddInParameter(dbCommand, "@CountryID", DbType.Int32, CountryID);
            bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
            if (isSuccess)
            {
                return true;
            }

            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region Save

    public bool PR_Country_Save(LOC_CountryModel locCountryModel)
    {
        try
        {
            if (locCountryModel.CountryID == 0)
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Country_Insert");
                sqlDatabase.AddInParameter(dbCommand, "@CountryName", DbType.String, locCountryModel.CountryName);
                sqlDatabase.AddInParameter(dbCommand, "@CountryCode", DbType.String, locCountryModel.CountryCode);
                sqlDatabase.AddInParameter(dbCommand, "@Created", DbType.DateTime, DBNull.Value);
                sqlDatabase.AddInParameter(dbCommand, "@Modified", DbType.DateTime, DBNull.Value);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                if (isSuccess)
                {
                    return true;
                }

                return false;
            }
            else
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Country_Update");
                sqlDatabase.AddInParameter(dbCommand, "@CountryID", DbType.Int32, locCountryModel.CountryID);
                sqlDatabase.AddInParameter(dbCommand, "@CountryName", DbType.String, locCountryModel.CountryName);
                sqlDatabase.AddInParameter(dbCommand, "@CountryCode", DbType.String, locCountryModel.CountryCode);
                sqlDatabase.AddInParameter(dbCommand, "@Modified", DbType.String, DBNull.Value);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                if (isSuccess)
                {
                    return true;
                }

                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region Save

    public LOC_CountryModel PR_Country_SelectByPK(int CountryID)
    {
        try
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Country_SelectByID");
            sqlDatabase.AddInParameter(dbCommand, "@CountryID", DbType.Int32, CountryID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dataTable.Load(dataReader);
            }

            LOC_CountryModel locCountryModel = new LOC_CountryModel();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                locCountryModel.CountryID = Convert.ToInt32(dataRow["CountryID"]);
                locCountryModel.CountryName = dataRow["CountryName"].ToString();
                locCountryModel.CountryCode = dataRow["CountryCode"].ToString();
                locCountryModel.Created = Convert.ToDateTime(dataRow["Created"]);
                locCountryModel.Modified = Convert.ToDateTime(dataRow["Modified"]);
            }

            return locCountryModel;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
}