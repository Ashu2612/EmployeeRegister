using Dapper;
using EmployeeRegister.Models;
using EmployeeRegister.View;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EmployeeRegister.Controllers
{
    public class EmployeeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            EmployeeDAL employeeDAL = new EmployeeDAL();
            employeeDAL.InsertEmployee(employee);
            return View();
            
        }
      
        [HttpGet]
        public IActionResult TaskManager()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TaskManager(ITaskManager itaskManager)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID",itaskManager.ID);
            param.Add("@Name", itaskManager.Name);
            param.Add("@Task", itaskManager.Task);
            param.Add("@TimePeriod", itaskManager.TimePeriod);
            DapperORM.ExecuteWithoutReturn("TaskAddorEdit", param);
            return RedirectToAction("Data");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(ITaskManager itaskManager)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", itaskManager.ID);
            param.Add("@Name", itaskManager.Name);
            param.Add("@Task", itaskManager.Task);
            param.Add("@TimePeriod", itaskManager.TimePeriod);
            DapperORM.ExecuteWithoutReturn("TaskEdit", param);
            return RedirectToAction("Data");
        }
        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", id);
            DapperORM.ExecuteWithoutReturn("TaskDeleteByID", param);
            return RedirectToAction("Data");
        }
      
        

        public IActionResult About()
        {
            return View();
        }
        
        public IActionResult Data()
        {
            return View(DapperORM.ReturnList<ITaskManager>("TaskViewer"));
        }
        


    }
}
