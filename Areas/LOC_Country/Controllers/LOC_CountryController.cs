using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Practice.Areas.LOC_Country.Models;
using Practice.DAL.LOC_CountryDAL;

namespace Practice.Areas.LOC_Country.Controllers;

[Area("LOC_Country")]
[Route("LOC_Country/[controller]/[action]")]
public class LOC_CountryController : Controller
{
    LOC_CountryDAL locCountryDal = new LOC_CountryDAL();

    public IActionResult LOC_CountryList()
    {
        DataTable dataTable = locCountryDal.PR_Country_SelectALL();
        return View(dataTable);
    }

    public IActionResult LOC_CountryDelete(int CountryID)
    {
        bool isSuccess = locCountryDal.PR_Country_DeleteByID(CountryID);
        if (isSuccess)
        {
            return RedirectToAction("LOC_CountryList");
        }

        return RedirectToAction("LOC_CountryList");
    }

    public IActionResult LOC_CountrySelectByPK(int CountryID)
    {
        LOC_CountryModel locCountryModel = locCountryDal.PR_Country_SelectByPK(CountryID);
        if (locCountryModel != null)
        {
            return View("LOC_CountryAddEdit", locCountryModel);
        }

        return View("LOC_CountryAddEdit");
    }

    public IActionResult LOC_CountrySave(LOC_CountryModel locCountryModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                bool isSuccess = locCountryDal.PR_Country_Save(locCountryModel);
                if (isSuccess)
                {
                    return RedirectToAction("LOC_CountryList");
                }
                else
                {
                    ModelState.AddModelError(string.Empty,
                        "An error occurred while saving the country. Please try again.");
                }
            }
            catch (SqlException ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving the country. Please try again.");
            }
        }
        return View("LOC_CountryAddEdit", locCountryModel);
    }
}