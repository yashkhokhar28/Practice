using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Practice.Areas.LOC_State.Models;

namespace Practice.DAL.LOC_CountryDAL;

public class LOC_StateDALBase : DALHelper
{
    #region SelectALL
    public DataTable PR_State_SelectALL()
    {
        try
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_State_SelectALL");
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

    public bool PR_State_DeleteByID(int StateID)
    {
        try
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_State_DeleteByID");
            sqlDatabase.AddInParameter(dbCommand, "@StateID", DbType.Int32, StateID);
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

    public bool PR_State_Save(LOC_StateModel locStateModel)
    {
        try
        {
            if (locStateModel.StateID == 0)
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_State_Insert");
                sqlDatabase.AddInParameter(dbCommand, "@StateName", DbType.String, locStateModel.StateName);
                sqlDatabase.AddInParameter(dbCommand, "@StateCode", DbType.String, locStateModel.StateCode);
                sqlDatabase.AddInParameter(dbCommand, "@CountryID", DbType.Int32, locStateModel.CountryID);
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
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_State_Update");
                sqlDatabase.AddInParameter(dbCommand, "@StateID", DbType.Int32, locStateModel.StateID);
                sqlDatabase.AddInParameter(dbCommand, "@StateName", DbType.String, locStateModel.StateName);
                sqlDatabase.AddInParameter(dbCommand, "@StateCode", DbType.String, locStateModel.StateCode);
                sqlDatabase.AddInParameter(dbCommand, "@CountryID", DbType.Int32, locStateModel.CountryID);
                sqlDatabase.AddInParameter(dbCommand, "@Created", DbType.DateTime, DBNull.Value);
                sqlDatabase.AddInParameter(dbCommand, "@Modified", DbType.DateTime, DBNull.Value);
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

    public LOC_StateModel PR_State_SelectByPK(int StateID)
    {
        try
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_State_SelectByID");
            sqlDatabase.AddInParameter(dbCommand, "@StateID", DbType.Int32, StateID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dataTable.Load(dataReader);
            }

            LOC_StateModel locStateModel = new LOC_StateModel();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                locStateModel.StateID = Convert.ToInt32(dataRow["StateID"]);
                locStateModel.CountryID = Convert.ToInt32(dataRow["CountryID"]);
                locStateModel.StateName = dataRow["StateName"].ToString();
                locStateModel.StateCode = dataRow["StateCode"].ToString();
                locStateModel.Created = Convert.ToDateTime(dataRow["Created"]);
                locStateModel.Modified = Convert.ToDateTime(dataRow["Modified"]);
            }

            return locStateModel;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
}