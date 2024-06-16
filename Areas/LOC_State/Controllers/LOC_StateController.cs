using System.Data;
using Microsoft.AspNetCore.Mvc;
using Practice.Areas.LOC_State.Models;
using Practice.DAL.LOC_State;

namespace Practice.Areas.LOC_State.Controllers;

[Area("LOC_State")]
[Route("LOC_State/[controller]/[action]")]
public class LOC_StateController : Controller
{
    LOC_StateDAL locStateDal = new LOC_StateDAL();

    public IActionResult LOC_StateList()
    {
        ViewBag.CountryList = locStateDal.PR_LOC_Country_Combobox();
        DataTable dataTable = locStateDal.PR_State_SelectALL();
        return View(dataTable);
    }

    public IActionResult LOC_StateDelete(int StateID)
    {
        bool isSuccess = locStateDal.PR_State_DeleteByID(StateID);
        if (isSuccess)
        {
            return RedirectToAction("LOC_StateList");
        }
        else
        {
            return RedirectToAction("LOC_StateList");
        }
    }

    public IActionResult LOC_StateSelectByPK(int StateID)
    {
        LOC_StateModel locStateModel = locStateDal.PR_State_SelectByPK(StateID);
        if (locStateModel != null)
        {
            ViewBag.CountryList = locStateDal.PR_LOC_Country_Combobox();
            return View("LOC_StateAddEdit", locStateModel);
        }
        ViewBag.CountryList = locStateDal.PR_LOC_Country_Combobox();
        return View("LOC_StateAddEdit");
    }

    public IActionResult LOC_StateSave(LOC_StateModel locStateModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                bool isSuccess = locStateDal.PR_State_Save(locStateModel);
                if (isSuccess)
                {
                    return RedirectToAction("LOC_StateList");
                }
                else
                {
                    ModelState.AddModelError(string.Empty,
                        "An error occurred while saving the country. Please try again.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        return View("LOC_StateAddEdit", locStateModel);
    }
}