using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Practice.Areas.LOC_Country.Models;
using Practice.DAL.LOC_CountryDAL;

namespace Practice.DAL.LOC_State;

public class LOC_StateDAL : LOC_StateDALBase
{
    #region Method : Country Dropdown

    public List<LOC_CountryDropDownModel> PR_LOC_Country_Combobox()
    {
        try
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Country_ComboBox");
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dataTable.Load(dataReader);
            }

            List<LOC_CountryDropDownModel> listOfCountry = new List<LOC_CountryDropDownModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                LOC_CountryDropDownModel lOC_CountryDropDownModel = new LOC_CountryDropDownModel();
                lOC_CountryDropDownModel.CountryID = Convert.ToInt32(dataRow["CountryID"]);
                lOC_CountryDropDownModel.CountryName = dataRow["CountryName"].ToString();
                listOfCountry.Add(lOC_CountryDropDownModel);
            }

            return listOfCountry;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    #endregion
}